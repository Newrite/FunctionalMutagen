namespace Mutagen.Func

open Mutagen.Bethesda.Plugins.Order
open Mutagen.Bethesda.Skyrim
open System.Collections.Generic

[<RequireQualifiedAccess>]
module Records =

  [<RequireQualifiedAccess>]
  module Weapon =

    let WinningContextOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      let result = let x = loadOrder.Weapon() in x.WinningContextOverrides(includeDeletedRecords)
      result
    
    let WinningOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      let result = let x = loadOrder.Weapon() in x.WinningOverrides(includeDeletedRecords)
      result

  [<RequireQualifiedAccess>]
  module Armor =

    let WinningContextOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      let result = let x = loadOrder.Armor() in x.WinningContextOverrides(includeDeletedRecords)
      result
    
    let WinningOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      let result = let x = loadOrder.Armor() in x.WinningOverrides(includeDeletedRecords)
      result

  [<RequireQualifiedAccess>]
  module Npc =

    let WinningContextOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      let result = let x = loadOrder.Npc() in x.WinningContextOverrides(includeDeletedRecords)
      result
    
    let WinningOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      let result = let x = loadOrder.Npc() in x.WinningOverrides(includeDeletedRecords)
      result

  [<RequireQualifiedAccess>]
  module LeveledNpc =

    let WinningContextOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      let result = let x = loadOrder.LeveledNpc() in x.WinningContextOverrides(includeDeletedRecords)
      result
    
    let WinningOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      let result = let x = loadOrder.LeveledNpc() in x.WinningOverrides(includeDeletedRecords)
      result

  [<RequireQualifiedAccess>]
  module MagicEffect =

    let WinningContextOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      let result = let x = loadOrder.MagicEffect() in x.WinningContextOverrides(includeDeletedRecords)
      result
    
    let WinningOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
      let result = let x = loadOrder.MagicEffect() in x.WinningOverrides(includeDeletedRecords)
      result
