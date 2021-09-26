open Mutagen.Func
open Mutagen.Bethesda
open Mutagen.Bethesda.Plugins.Order.Internals
open Mutagen.Bethesda.Plugins.Order
open Mutagen.Bethesda.Plugins
open Mutagen.Bethesda.Skyrim
open Mutagen.Bethesda.FormKeys.SkyrimSE
open Mutagen.Bethesda.Environments
open System.Linq
open System.Collections.Generic
open FSharp.Core.Fluent

open Mutagen.Func.Scripts

//let env = GameEnvironment.Typical.Skyrim(SkyrimRelease.SkyrimSE)

let test (a: IEnumerable<IModListing<ISkyrimModGetter>>) =
  let casted = a.Cast<IModListingGetter<ISkyrimModGetter>>()
  let b = let x = casted.Weapon() in x.WinningOverrides()
  b

//test env.LoadOrder.PriorityOrder |> printfn "%A"

let entry =
  VirtualMachineAdapter.New [

    ScriptEntry.New "XPScript" [
      ScriptProperty.Float "AmountXP" 20.f
      ScriptProperty.Bool "GiveExp" true
      ScriptProperty.Integer "Int amount" 20
      ScriptProperty.String "This is string" "Hello"
      ScriptProperty.Object "Katana" Skyrim.Weapon.AkaviriKatana
    ]

    ScriptEntry.New "XPScriptList" [
      ScriptProperty.FloatList "Name" [ 10.f; 20.f; 30.f ]
      ScriptProperty.BoolList "BoolName" [ true; false; true; true ]
      ScriptProperty.IntegerList "IntName" [ 10; 20; 30 ]
      ScriptProperty.StringList "StrName" [ "Helo"; "World"; "" ]
      ScriptProperty.ObjectList "ObjList" [
        ScriptProperty.Object "Katana" Skyrim.Weapon.AkaviriKatana
        ScriptProperty.Object "Armor" Skyrim.Armor.ArmorAstrid
        ]

    ]
  ]

entry.Scripts
|>Seq.iter (fun s ->
    Seq.iter (fun (p: ScriptProperty) -> 
      match p with
      | :? ScriptFloatProperty as property -> printfn "Float: %s %f %A" property.Name property.Data property.Flags
      | :? ScriptBoolProperty as property -> printfn "Bool: %s %b %A" property.Name property.Data property.Flags
      | :? ScriptIntProperty as property -> printfn "Int: %s %d %A" property.Name property.Data property.Flags
      | :? ScriptStringProperty as property -> printfn "String: %s %s %A" property.Name property.Data property.Flags
      | :? ScriptObjectProperty as property -> printfn "Object: %s %A %A" property.Name property.Object property.Flags
      | :? ScriptFloatListProperty as property -> printfn "FloatList: %s %A %A" property.Name property.Data property.Flags
      | :? ScriptBoolListProperty as property -> printfn "BoolList: %s %A %A" property.Name property.Data property.Flags
      | :? ScriptStringListProperty as property -> printfn "StringList: %s %A %A" property.Name property.Data property.Flags
      | :? ScriptIntListProperty as property -> printfn "IntList: %s %A %A" property.Name property.Data property.Flags
      | :? ScriptObjectListProperty as property -> printfn "ObjectList: %s %A %A" property.Name property.Objects property.Flags
      | _ -> ()) s.Properties
    )

let order = LoadOrder.PriorityOrderFromEnvRevers SkyrimRelease.SkyrimSE

let cache = Cache.ToImmutableLinkCache order

let wep = Records.WinningOverrides.Weapon order

wep
  .Where(fun weapon -> not weapon.Template.IsNull)
  .Select(fun weapon -> weapon.EditorID)
  .Where(fun eid -> not eid.IsEmpty )
  .Distinct()
|>Seq.iter(fun id -> printfn "Weapon editor: %s" id)