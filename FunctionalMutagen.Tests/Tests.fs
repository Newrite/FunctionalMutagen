module Tests

open Mutagen.Func
open Mutagen.Bethesda.Skyrim
open Mutagen.Bethesda.FormKeys.SkyrimSE
open Xunit
open Swensen.Unquote

module ScriptsTest =

  [<Fact>]
  let ``Create new virtual machine adapter must not be null`` ()=
  
    let vma =
      Scripts.VirtualMachineAdapter.createWithScripts [
      
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

  [<Fact>]
  let ``Float script propertys from DSL must be equal float propertys from Mutagen`` ()=
    
    let floatDSLPropertyZero = Scripts.ScriptProperty.float "testZero" 0.f
    let floatDSLPropertyPos = Scripts.ScriptProperty.float "testPos" 2000.f
    let floatDSLPropertyNeg = Scripts.ScriptProperty.float "testNeg" -2000.f

    let floatMutagenPropertyZero = new ScriptFloatProperty(Name = "testZero", Data = 0.f)
    let floatMutagenPropertyPos = new ScriptFloatProperty(Name = "testPos", Data = 2000.f)
    let floatMutagenPropertyNeg = new ScriptFloatProperty(Name = "testNeg", Data = -2000.f)
    
    test <@ floatDSLPropertyZero.Equals(floatMutagenPropertyZero) @>
    test <@ floatDSLPropertyPos.Equals(floatMutagenPropertyPos) @>
    test <@ floatDSLPropertyNeg.Equals(floatMutagenPropertyNeg) @>

  [<Fact>]
  let ``Integer script propertys from DSL must be equal integer propertys from Mutagen`` ()=
    
    let integerDSLPropertyZero = Scripts.ScriptProperty.integer "testZero" 0
    let integerDSLPropertyPos = Scripts.ScriptProperty.integer "testPos" 2000
    let integerDSLPropertyNeg = Scripts.ScriptProperty.integer "testNeg" -2000

    let integerMutagenPropertyZero = new ScriptIntProperty(Name = "testZero", Data = 0)
    let integerMutagenPropertyPos = new ScriptIntProperty(Name = "testPos", Data = 2000)
    let integerMutagenPropertyNeg = new ScriptIntProperty(Name = "testNeg", Data = -2000)
    
    test <@ integerDSLPropertyZero.Equals(integerMutagenPropertyZero) @>
    test <@ integerDSLPropertyPos.Equals(integerMutagenPropertyPos) @>
    test <@ integerDSLPropertyNeg.Equals(integerMutagenPropertyNeg) @>

  [<Fact>]
  let ``String script propertys from DSL must be equal string propertys from Mutagen`` ()=
    
    let stringDSLPropertyWhitespaces = Scripts.ScriptProperty.string "testWhitespaces" "     "
    let stringDSLPropertyVoid = Scripts.ScriptProperty.string "testVoid" ""
    let stringDSLProperty = Scripts.ScriptProperty.string "testStr" "Hello Test"

    let stringMutagenPropertyWhitespaces = new ScriptStringProperty(Name = "testWhitespaces", Data = "     ")
    let stringMutagenPropertyVoid = new ScriptStringProperty(Name = "testVoid", Data = "")
    let stringMutagenProperty = new ScriptStringProperty(Name = "testStr", Data = "Hello Test")
    
    test <@ stringDSLPropertyWhitespaces.Equals(stringMutagenPropertyWhitespaces) @>
    test <@ stringDSLPropertyVoid.Equals(stringMutagenPropertyVoid) @>
    test <@ stringDSLProperty.Equals(stringMutagenProperty) @>

  [<Fact>]
  let ``Bool script propertys from DSL must be equal bool propertys from Mutagen`` ()=
    
    let boolDSLPropertyTrue = Scripts.ScriptProperty.bool "testTrue" true
    let boolDSLPropertyFalse = Scripts.ScriptProperty.bool "testFalse" false

    let boolMutagenPropertyTrue = new ScriptBoolProperty(Name = "testTrue", Data = true)
    let boolMutagenPropertyFalse = new ScriptBoolProperty(Name = "testFalse", Data = false)
    
    test <@ boolDSLPropertyTrue.Equals(boolMutagenPropertyTrue) @>
    test <@ boolDSLPropertyFalse.Equals(boolMutagenPropertyFalse) @>

  [<Fact>]
  let ``Object script property from DSL must be equal object property from Mutagen`` ()=
    
    let objectDSLProperty = Scripts.ScriptProperty.object "testKatana" Skyrim.Weapon.AkaviriKatana

    let objectMutagenProperty = new ScriptObjectProperty(Name = "testKatana", Object = Skyrim.Weapon.AkaviriKatana.Cast<ISkyrimMajorRecordGetter>())
    
    test <@ objectDSLProperty.Equals(objectMutagenProperty) @>