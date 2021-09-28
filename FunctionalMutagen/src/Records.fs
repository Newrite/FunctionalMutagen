namespace Mutagen.Func

open Mutagen.Bethesda.Plugins.Order
open Mutagen.Bethesda.Skyrim
open System.Linq
open System.Collections.Generic

[<RequireQualifiedAccess>]
module Records =

  //type LeveledNpc = bool -> IEnumerable<IModListingGetter<ISkyrimModGetter>> -> IEnumerable<ILeveledNpcGetter>

  [<RequireQualifiedAccess>]
  module Weapon =

    let LoadOrder (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      loadOrder.Weapon()
    
    let WinningOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      let result = let x = loadOrder.Weapon() in x.WinningOverrides(includeDeletedRecords)
      result

  [<RequireQualifiedAccess>]
  module Armor =

    let LoadOrder (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      loadOrder.Armor()
    
    let WinningOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      let result = let x = loadOrder.Armor() in x.WinningOverrides(includeDeletedRecords)
      result

  [<RequireQualifiedAccess>]
  module Npc =

    let LoadOrder (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      loadOrder.Npc()
    
    let WinningOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      let result = let x = loadOrder.Npc() in x.WinningOverrides(includeDeletedRecords)
      result

  [<RequireQualifiedAccess>]
  module LeveledNpc =

    let LoadOrder (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      loadOrder.LeveledNpc()
    
    let WinningOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      let result = let x = loadOrder.LeveledNpc() in x.WinningOverrides(includeDeletedRecords)
      result
