module Tests

open Mutagen.Func
open Mutagen.Bethesda.FormKeys.SkyrimSE
open Xunit
open Swensen.Unquote
open System

module ScriptsTest =

  [<Fact>]
  let ``Create new virtual machine adapter must not be null`` ()=
  
    let vma =
      Scripts.VirtualMachineAdapter.create [
      
        Scripts.ScriptEntry.create "SomeScriptName" [
          Scripts.ScriptProperty.float "somefloat" 20.f
          Scripts.ScriptProperty.bool "somebool" true
          Scripts.ScriptProperty.integer "someint" 20
          Scripts.ScriptProperty.string "somestring" "Hello"
          Scripts.ScriptProperty.object "someobject" Skyrim.Weapon.AkaviriKatana
        ]
      
        Scripts.ScriptEntry.create "SomeScriptNameWithArrayPropertyes" [
          Scripts.ScriptProperty.floatList "somefloatlist" [ 10.f; 20.f; 30.f ]
          Scripts.ScriptProperty.boolList "someboollist" [ true; false; true; true ]
          Scripts.ScriptProperty.integerList "someintlist" [ 10; 20; 30 ]
          Scripts.ScriptProperty.stringList "somestringlist" [ "Helo"; "World"; "" ]
          Scripts.ScriptProperty.objectList [
            Scripts.ScriptProperty.object "someobject" Skyrim.Weapon.AkaviriKatana
            Scripts.ScriptProperty.object "someobject" Skyrim.Armor.ArmorAstrid
          ]
        ]
      ]

    test <@ (isNull >> not) vma @>