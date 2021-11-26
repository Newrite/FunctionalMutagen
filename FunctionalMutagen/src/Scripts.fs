namespace Mutagen.Func

open Mutagen.Bethesda.Skyrim
open Mutagen.Bethesda

#nowarn "64"

///<summary>
///Module contains a small DSL for create scripts.
///Script entry in Scripts.ScriptEntry
///Script propertyes in Scripts.ScriptProperty
///VirtualMachineAdapter module for build new VirtualMachineAdapter if needed
///</summary>
module Scripts =
  
  [<RequireQualifiedAccess>]
  module ScriptEntry =

    ///<summary>
    ///Create new ScriptEntry with ScriptName and list of ScriptProperty, can fill with Scripts.ScriptProperty module.
    ///</summary>
    let create entryName (propertyList: ScriptProperty list) =
      let entry = new ScriptEntry(Name = entryName)
      propertyList
      |>List.iter (fun property -> entry.Properties.Add(property))
      entry

  [<RequireQualifiedAccess>]
  module ScriptProperty =

    ///Internal function, build ExtendedList from F# list, need for PropertyList functions
    let private buildExtendList values =
      let l = new Noggog.ExtendedList<_>()
      values
      |>List.iter (fun v -> l.Add(v))
      l
    
    ///<summary>
    ///Create new ScriptFloatProperty, field name and float32 value.
    ///</summary>
    let float name value =
      new ScriptFloatProperty(Name = name, Data = value)

    ///<summary>
    ///Create new ScriptBoolProperty, field name and bool value.
    ///</summary>
    let bool name value =
      new ScriptBoolProperty(Name = name, Data = value)

    ///<summary>
    ///Create new ScriptStringProperty, field name and string value.
    ///</summary>
    let string name value =
      new ScriptStringProperty(Name = name, Data = value)

    ///<summary>
    ///Create new ScriptIntProperty, field name and int value.
    ///</summary>
    let integer name value =
      new ScriptIntProperty(Name = name, Data = value)

    ///<summary>
    ///Create new ScriptObjectProperty, field name and Bethesda object, 
    ///need link object so you can use FormKeys from Mutagen.Bethesda.FormKeys lib 
    ///lib link: https://github.com/Mutagen-Modding/Mutagen.Bethesda.FormKeys.
    ///</summary>
    let object name (object: Plugins.FormLink<#ISkyrimMajorRecordGetter>) =  //Need cast and flex type for interop with C#
      new ScriptObjectProperty(Name = name, Object = object.Cast<ISkyrimMajorRecordGetter>())

    ///<summary>
    ///Create new ScriptFloatListProperty, field name and float32 list value.
    ///</summary>
    let floatList name values =
      new ScriptFloatListProperty(Name = name, Data = buildExtendList values)

    ///<summary>
    ///Create new ScriptBoolListProperty, field name and bool list value.
    ///</summary>
    let boolList name values =
      new ScriptBoolListProperty(Name = name, Data = buildExtendList values)

    ///<summary>
    ///Create new ScriptStringListProperty, field name and string list value.
    ///</summary>
    let stringList name values =
      new ScriptStringListProperty(Name = name, Data = buildExtendList values)

    ///<summary>
    ///Create new ScriptIntListProperty, field name and int list value.
    ///</summary>
    let integerList name values =
      new ScriptIntListProperty(Name = name, Data = buildExtendList values)

    ///<summary>
    ///Create new ScriptObjectListProperty, field Bethesda objects, 
    ///for create list of objects use Scripts.ScriptProperty.Object.
    ///</summary>
    let objectList (values: ScriptObjectProperty list) =
      new ScriptObjectListProperty(Objects = buildExtendList values)

  [<RequireQualifiedAccess>]
  module VirtualMachineAdapter =

    ///<summary>
    ///Create new VirtualMachineAdapter, add ScriptEntry with Scripts.ScriptEntry.create.
    ///</summary>
    let createWithScript (scriptEntryList: ScriptEntry) =
      let vm = new VirtualMachineAdapter()
      vm.Scripts.Add(scriptEntryList)
      vm

    ///<summary>
    ///Create new VirtualMachineAdapter, fill ScriptEntry list with Scripts.ScriptEntry.create.
    ///</summary>
    let createWithScripts (scriptEntryList: ScriptEntry list) =
      let vm = new VirtualMachineAdapter()
      scriptEntryList
      |>List.iter (fun e -> vm.Scripts.Add(e))
      vm

    let ensureVMAExistAddScript (record: inref<#IScripted>) script =
      match record.VirtualMachineAdapter with
      | null ->
        let newVMA =
          createWithScript script
        record.VirtualMachineAdapter <- newVMA
      | _ ->
        record.VirtualMachineAdapter.Scripts.Add(script)

    let ensureVMAExistAddScripts (record: inref<#IScripted>) scripts =
      match record.VirtualMachineAdapter with
      | null ->
        let newVMA =
          createWithScripts scripts
        record.VirtualMachineAdapter <- newVMA
      | _ ->
        for script in scripts do record.VirtualMachineAdapter.Scripts.Add(script)