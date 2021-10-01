namespace Mutagen.Func

open Mutagen.Bethesda.Plugins.Order
open Mutagen.Bethesda.Skyrim
open System.Collections.Generic

///<summary>
///Module contain functions get and manipulate records
///</summary>
[<RequireQualifiedAccess>]
module Records =

  [<RequireQualifiedAccess>]
  module Skyrim = 
    
    [<RequireQualifiedAccess>]
    module Weapon =

      ///<summary>
      ///Get context Weapon records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
      ///
      ///Original description of method:
      ///Will find and return the most overridden version of each record in the list of mods of the given type. <br /><br />
      ///            Additionally, it will come wrapped in a context object that has knowledge of where each record came from. <br />
      ///            This context helps when trying to override deep records such as Cells/PlacedObjects/etc, as the context is able to navigate
      ///            and insert the record into the proper location for you.
      ///</summary>
      let winningContextOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
        let result = let x = loadOrder.Weapon() in x.WinningContextOverrides(includeDeletedRecords)
        result
      
      ///<summary>
      ///Get Weapon records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
      ///</summary>
      let winningOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
        let result = let x = loadOrder.Weapon() in x.WinningOverrides(includeDeletedRecords)
        result

    [<RequireQualifiedAccess>]
    module Armor =

      ///<summary>
      ///Get context Armor records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
      ///
      ///Original description of method:
      ///Will find and return the most overridden version of each record in the list of mods of the given type. <br /><br />
      ///            Additionally, it will come wrapped in a context object that has knowledge of where each record came from. <br />
      ///            This context helps when trying to override deep records such as Cells/PlacedObjects/etc, as the context is able to navigate
      ///            and insert the record into the proper location for you.
      ///</summary>
      let winningContextOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
        let result = let x = loadOrder.Armor() in x.WinningContextOverrides(includeDeletedRecords)
        result
      
      ///<summary>
      ///Get Armor records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
      ///</summary>
      let winningOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
        let result = let x = loadOrder.Armor() in x.WinningOverrides(includeDeletedRecords)
        result

    [<RequireQualifiedAccess>]
    module Npc =

      ///<summary>
      ///Get context Npc records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
      ///
      ///Original description of method:
      ///Will find and return the most overridden version of each record in the list of mods of the given type. <br /><br />
      ///            Additionally, it will come wrapped in a context object that has knowledge of where each record came from. <br />
      ///            This context helps when trying to override deep records such as Cells/PlacedObjects/etc, as the context is able to navigate
      ///            and insert the record into the proper location for you.
      ///</summary>
      let winningContextOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
        let result = let x = loadOrder.Npc() in x.WinningContextOverrides(includeDeletedRecords)
        result
      
      ///<summary>
      ///Get Npc records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
      ///</summary>
      let winningOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
        let result = let x = loadOrder.Npc() in x.WinningOverrides(includeDeletedRecords)
        result

    [<RequireQualifiedAccess>]
    module LeveledNpc =

      ///<summary>
      ///Get context LeveledNpc records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
      ///
      ///Original description of method:
      ///Will find and return the most overridden version of each record in the list of mods of the given type. <br /><br />
      ///            Additionally, it will come wrapped in a context object that has knowledge of where each record came from. <br />
      ///            This context helps when trying to override deep records such as Cells/PlacedObjects/etc, as the context is able to navigate
      ///            and insert the record into the proper location for you.
      ///</summary>
      let winningContextOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
        let result = let x = loadOrder.LeveledNpc() in x.WinningContextOverrides(includeDeletedRecords)
        result
      
      ///<summary>
      ///Get LeveledNpc records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
      ///</summary>
      let winningOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
        let result = let x = loadOrder.LeveledNpc() in x.WinningOverrides(includeDeletedRecords)
        result

    [<RequireQualifiedAccess>]
    module MagicEffect =

      ///<summary>
      ///Get context MagicEffect records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
      ///
      ///Original description of method:
      ///Will find and return the most overridden version of each record in the list of mods of the given type. <br /><br />
      ///            Additionally, it will come wrapped in a context object that has knowledge of where each record came from. <br />
      ///            This context helps when trying to override deep records such as Cells/PlacedObjects/etc, as the context is able to navigate
      ///            and insert the record into the proper location for you.
      ///</summary>
      let winningContextOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
        let result = let x = loadOrder.MagicEffect() in x.WinningContextOverrides(includeDeletedRecords)
        result
      
      ///<summary>
      ///Get MagicEffect records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
      ///</summary>
      let winningOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
        let result = let x = loadOrder.MagicEffect() in x.WinningOverrides(includeDeletedRecords)
        result
