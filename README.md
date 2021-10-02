# FunctionalMutagen

Functional wrapper for Mutagen.Bethesda library, check it here: https://github.com/Mutagen-Modding/Mutagen 

The library aims to improve the use of the mutagen from F#, because F# is not very user-friendly when using C# libraries. It also adds a bit of functional use of some of the methods now wrapped in functions.

Open Mutagen.Func after add library and get started.

##  Some script create DSL


```FSHarp
Scripts.ScriptEntry.create "XP" [
  Scripts.ScriptProperty.float "XPStaticAmount" staticAmount
  Scripts.ScriptProperty.float "XPMultAmount" multAmount
]
```

You can create VirtualMachineAdapter, ScriptEntry and ScriptProperty instances with functional DSL. `Scripts` module contains `ScriptEntry`, `ScriptProperty` and `VirtualMachineAdapter` modules. This is very simple.

If you need create new VirtualMachineAdapter.

```FSHarp
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
			Scripts.ScriptProperty.object "someobject" Skyrim.Weapon.AkaviriKatana // FormKeys from Mutagen.Bethesda.FormKeys lib
			Scripts.ScriptProperty.object "someobject" Skyrim.Armor.ArmorAstrid // FormKeys from Mutagen.Bethesda.FormKeys lib
		]
	]
]
```

New script entry.

```FSHarp
	Scripts.ScriptEntry.create "SomeScriptName" [
		Scripts.ScriptProperty.float "somefloat" 20.f
		Scripts.ScriptProperty.bool "somebool" true
		Scripts.ScriptProperty.integer "someint" 20
		Scripts.ScriptProperty.string "somestring" "Hello"
		Scripts.ScriptProperty.object "someobject" Skyrim.Weapon.AkaviriKatana
	]
```

Just new property.

```FSharp
	Scripts.ScriptProperty.float "somefloat" 20.f //single property float

	Scripts.ScriptProperty.object "someobject" Skyrim.Weapon.AkaviriKatana //single property  object

	Scripts.ScriptProperty.floatList "somefloatlist" [ 10.f; 20.f; 30.f ] //array property float

	Scripts.ScriptProperty.objectList [ // array propery objects
		Scripts.ScriptProperty.object "someobject" Skyrim.Weapon.AkaviriKatana // FormKeys from Mutagen.Bethesda.FormKeys lib
		Scripts.ScriptProperty.object "someobject" Skyrim.Armor.ArmorAstrid // FormKeys from Mutagen.Bethesda.FormKeys lib
	]
```

## Create new mod

Create mod for write records to this mod.

```FSharp
let modName = "SomePatchEsp.esp"
let newMod = Mods.createSkyrimMod modName SkyrimRelease.SkyrimLE
```

Functions for create mods locate in `Mods` module. You just need choose right function, name for mod and mb game release if function need this.


After work with mod don't fogget write this with default Mutagen method.

```FSharp
newMod.WriteToBinaryParallel(modName)
//or
newMod.WriteToBinary(modName)
```