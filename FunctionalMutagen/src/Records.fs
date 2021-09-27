namespace Mutagen.Func

open Mutagen.Bethesda
open Mutagen.Bethesda.Plugins.Order
open Mutagen.Bethesda.Skyrim
open Mutagen.Bethesda.Environments
open System.Linq
open System.Collections.Generic
open Mutagen.Bethesda.Skyrim

[<RequireQualifiedAccess>]
type private GetterType =
  |Weapon
  |Armor

[<RequireQualifiedAccess>]
module Records =

  let private winningOverrideRecords getterType (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
    match getterType with
    |GetterType.Weapon ->
      let result = let x = loadOrder.Weapon() in x.WinningOverrides()
      result.Cast<ISkyrimMajorRecordGetter>()
    |GetterType.Armor ->
      let result = let x = loadOrder.Armor() in x.WinningOverrides()
      result.Cast<ISkyrimMajorRecordGetter>()

  [<RequireQualifiedAccess>]
  module WinningOverrides =

    let Weapon (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      (winningOverrideRecords GetterType.Weapon loadOrder).Cast<IWeaponGetter>()

    let Armor (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      (winningOverrideRecords GetterType.Armor loadOrder).Cast<IArmorGetter>()