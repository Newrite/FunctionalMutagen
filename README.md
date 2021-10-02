# FunctionalMutagen

Functional wrapper for Mutagen.Bethesda library, check it here: https://github.com/Mutagen-Modding/Mutagen 

The library aims to improve the use of the mutagen from F#, because F# is not very user-friendly when using C# libraries. It also adds a bit of functional use of some of the methods now wrapped in functions.

###  Some script create DSL

Look this

```FSHarp
Scripts.ScriptEntry.create "XP" [
  Scripts.ScriptProperty.float "XPStaticAmount" staticAmount
  Scripts.ScriptProperty.float "XPMultAmount" multAmount
]
```

You can create ScriptEntry instance with functional DSL. `Scripts` module contains `ScriptEntry`, `ScriptProperty` and `VirtualMachineAdapter` modules. This is very simple.

If you need create new VirtualMachineAdapter

```FSHarp
Scripts.VirtualMachineAdapter.create [

	Scripts.ScriptEntry.create "SomeScriptName" [
		Scripts.ScriptProperty.float "AmountXP" 20.f
		Scripts.ScriptProperty.bool "GiveExp" true
		Scripts.ScriptProperty.integer "Int amount" 20
		Scripts.ScriptProperty.string "This is string" "Hello"
		Scripts.ScriptProperty.object "Katana" Skyrim.Weapon.AkaviriKatana
	]

	Scripts.ScriptEntry.create "SomeScriptNameWithArrayPropertyes" [
		Scripts.ScriptProperty.floatList "Name" [ 10.f; 20.f; 30.f ]
		Scripts.ScriptProperty.boolList "BoolName" [ true; false; true; true ]
		Scripts.ScriptProperty.integerList "IntName" [ 10; 20; 30 ]
		Scripts.ScriptProperty.stringList "StrName" [ "Helo"; "World"; "" ]
		Scripts.ScriptProperty.objectList [
			Scripts.ScriptProperty.object "Katana" Skyrim.Weapon.AkaviriKatana // FormKeys from Mutagen.Bethesda.FormKeys lib
			Scripts.ScriptProperty.object "Armor" Skyrim.Armor.ArmorAstrid // FormKeys from Mutagen.Bethesda.FormKeys lib
		]
	]
]
```