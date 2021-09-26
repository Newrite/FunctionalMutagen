﻿namespace Mutagen.Func

open Mutagen.Bethesda
open Mutagen.Bethesda.Plugins.Order
open Mutagen.Bethesda.Skyrim
open Mutagen.Bethesda.Environments
open System.Linq
open System.Collections.Generic
open Mutagen.Bethesda.Skyrim


module private Internal =

  let listingGetter (a: IEnumerable<IModListing<ISkyrimModGetter>>) =
    a.Cast<IModListingGetter<ISkyrimModGetter>>()

[<RequireQualifiedAccess>]
type GetterType =
  |Weapon
  |Armor

[<RequireQualifiedAccess>]
module LoadOrder =
  
  let ListedOrderFromEnv (skyrimRelease: SkyrimRelease) =
    let env = GameEnvironment.Typical.Skyrim(skyrimRelease)
    Internal.listingGetter env.LoadOrder.ListedOrder

  let PriorityOrderFromEnv (skyrimRelease: SkyrimRelease) =
    let env = GameEnvironment.Typical.Skyrim(skyrimRelease)
    Internal.listingGetter env.LoadOrder.ListedOrder

  let ListedOrderFromEnvRevers (skyrimRelease: SkyrimRelease) =
    let env = GameEnvironment.Typical.Skyrim(skyrimRelease)
    Internal.listingGetter env.LoadOrder.ListedOrder
    |>Seq.rev

  let PriorityOrderFromEnvRevers (skyrimRelease: SkyrimRelease) =
    let env = GameEnvironment.Typical.Skyrim(skyrimRelease)
    Internal.listingGetter env.LoadOrder.ListedOrder
    |>Seq.rev

[<RequireQualifiedAccess>]
module Cache =
  
  let ToImmutableLinkCache (getter: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
    getter.ToImmutableLinkCache()

  let ToUntypedImmutableLinkCache (getter: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
    getter.ToUntypedImmutableLinkCache()

module Records =

  let WinningOverrideRecords getterType (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
    match getterType with
    |GetterType.Weapon ->
      let result = let x = loadOrder.Weapon() in x.WinningOverrides()
      result.Cast<ISkyrimMajorRecordGetter>()
    |GetterType.Armor ->
      let result = let x = loadOrder.Armor() in x.WinningOverrides()
      result.Cast<ISkyrimMajorRecordGetter>()