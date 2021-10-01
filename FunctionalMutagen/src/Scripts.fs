namespace Mutagen.Func

open Mutagen.Bethesda.Skyrim
open Mutagen.Bethesda

module Scripts =

  [<RequireQualifiedAccess>]
  module ScriptEntry =

    ///<summary>Create new ScriptEntry with ScriptName and list of ScriptProperty, can fill with Scripts.ScriptProperty module.</summary>
    let New entryName (propertyList: ScriptProperty list) =
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
    
    ///<summary>Create new ScriptFloatProperty, field name and float32 value.</summary>
    let Float name value =
      new ScriptFloatProperty(Name = name, Data = value)

    ///<summary>Create new ScriptBoolProperty, field name and bool value.</summary>
    let Bool name value =
      new ScriptBoolProperty(Name = name, Data = value)

    ///<summary>Create new ScriptStringProperty, field name and string value.</summary>
    let String name value =
      new ScriptStringProperty(Name = name, Data = value)

    ///<summary>Create new ScriptIntProperty, field name and int value.</summary>
    let Integer name value =
      new ScriptIntProperty(Name = name, Data = value)

    ///<summary>Create new ScriptObjectProperty, field name and Bethesda object, 
    ///need link object so you can use FormKeys from Mutagen.Bethesda.FormKeys lib 
    ///lib link: https://github.com/Mutagen-Modding/Mutagen.Bethesda.FormKeys.</summary>
    let Object name (object: Plugins.FormLink<#ISkyrimMajorRecordGetter>) =  //Need cast and flex type for interop with C#
      new ScriptObjectProperty(Name = name, Object = object.Cast<ISkyrimMajorRecordGetter>())

    ///<summary>Create new ScriptFloatListProperty, field float32 list value.</summary>
    let FloatList values =
      new ScriptFloatListProperty(Data = buildExtendList values)

    ///<summary>Create new ScriptBoolListProperty, field bool list value.</summary>
    let BoolList values =
      new ScriptBoolListProperty(Data = buildExtendList values)

    ///<summary>Create new ScriptStringListProperty, field string list value.</summary>
    let StringList values =
      new ScriptStringListProperty(Data = buildExtendList values)

    ///<summary>Create new ScriptIntListProperty, field int list value.</summary>
    let IntegerList values =
      new ScriptIntListProperty(Data = buildExtendList values)

    ///<summary>Create new ScriptObjectListProperty, field Bethesda objects, 
    ///for create list of objects use Scripts.ScriptProperty.Object.</summary>
    let ObjectList (values: ScriptObjectProperty list) =
      new ScriptObjectListProperty(Objects = buildExtendList values)

  [<RequireQualifiedAccess>]
  module VirtualMachineAdapter =
    
    ///<summary>Create new VirtualMachineAdapter, can fill ScriptEntry list with Scripts.ScriptEntry.New.</summary>
    let New (scriptEntryList: ScriptEntry list) =
      let vm = new VirtualMachineAdapter()
      scriptEntryList
      |>List.iter (fun e -> vm.Scripts.Add(e))
      vm