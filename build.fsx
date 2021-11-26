#r "nuget: Fake.Core.Target"
#r "nuget: Fake.DotNet.Cli"
#r "nuget: Fake.IO.FileSystem"
//#r "nuget: FSharp.Core"

#load @".\.fake\build.fsx\intellisense.fsx"

open Fake.Core
open Fake.IO
open Fake.DotNet

let buildDir = "./build/"
let buildLibDir = buildDir + "Lib/"
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

Target.create "TestLib" (fun _ ->

  let setBuildParamLib (defaults: DotNet.TestOptions) =
    defaults
  
  DotNet.test setBuildParamLib "./FunctionalMutagen.Tests/FunctionalMutagen.Tests.fsproj"
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
  ==> "TestLib"
  ==> "MoveLibToPatcherProject"

Target.runOrDefault "MoveLibToPatcherProject"