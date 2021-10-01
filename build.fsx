#r "paket:
nuget Fake.Core.Target
nuget Fake.DotNet.Cli
nuget Fake.IO.FileSystem
nuget FSharp.Core 5.0.0 //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.IO
open Fake.DotNet

let buildDir = "./build/"
let buildTestPatcherDir = buildDir + "Patcher/"
let buildLibDir = buildDir + "Lib/"
let skyrimDir = @"G:\MO2Dev\overwrite"
let projectPatcherDir = @"G:\Programming\Languages\F#\SkyrimPatcher\SkyrimPatcher\lib\"

Target.create "Clean" (fun _ ->
  Shell.cleanDir buildDir
)

Target.create "BuildLib" (fun _ ->

  let setBuildParamLib (defaults: DotNet.BuildOptions) =
    { defaults with
        OutputPath = Some buildLibDir
        MSBuildParams =
        { MSBuild.CliArguments.Create() with
            Properties =
            [
              "Optimize", "True"
              "PublishSingleFile", "True"
            ]
        }
    }
  
  DotNet.build setBuildParamLib "./FunctionalMutagen/FunctionalMutagen.fsproj"
)

Target.create "PublishPatcher" (fun _ ->

  let setPublishParamExe (defaults: DotNet.PublishOptions) =
    { defaults with
        Runtime = Some "win-x64"
        OutputPath = Some buildTestPatcherDir
        SelfContained = Some true
        MSBuildParams =
        { MSBuild.CliArguments.Create() with
            Properties =
            [
              "Optimize", "True"
              "PublishSingleFile", "True"
            ]
        }
    }
  
  DotNet.publish setPublishParamExe "./FunctionalMutagenTest/FunctionalMutagenTest.fsproj"
)

Target.create "MovePatcher" (fun _ ->
  Shell.copyFile skyrimDir (buildTestPatcherDir + "FunctionalMutagenTest.exe")
)

Target.create "MoveLibToPatcherProject" (fun _ ->
  Shell.copyFiles projectPatcherDir [ 
    buildLibDir + "FunctionalMutagen.dll"
    buildLibDir + "FunctionalMutagen.xml"
    buildLibDir + "FunctionalMutagen.pdb"
    buildLibDir + "FunctionalMutagen.deps.json"
  ]
)

open Fake.Core.TargetOperators

"Clean"
  ==> "BuildLib"
  ==> "PublishPatcher"
  ==> "MoveLibToPatcherProject"
  ==> "MovePatcher"

Target.runOrDefault "MovePatcher"