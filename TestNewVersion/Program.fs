open Mutagen.Bethesda
open Mutagen.Bethesda.Skyrim
open Mutagen.Bethesda.Fallout4
open Mutagen.Bethesda.Oblivion

open System.IO
open System

open Mutagen.Bethesda
open Mutagen.Bethesda.Plugins.Order
open Mutagen.Bethesda.Skyrim
open Mutagen.Bethesda.Environments

open System.Linq
open System.Collections.Generic

///<summary>
///Module contain some wrappers for create bethesda mods
///</summary>
[<RequireQualifiedAccess>]
module Mods =

  ///<summary>
  ///Function for create a new skyrim mod, fields mod name, name must include file extension, 
  ///and SkyrimRelease Enum from Mutagen.Bethesda.Skyrim namespace
  ///</summary>
  let createSkyrimMod (modName: string) (skyrimRelease: SkyrimRelease) =
    SkyrimMod(Plugins.ModKey.FromNameAndExtension(Path.GetFileName(modName.AsSpan())), skyrimRelease)

  ///<summary>
  ///Function for create a new Fallout4 mod, fields only mod name
  ///</summary>
  let createFalloutMod (modName: string) =
    Fallout4Mod(Plugins.ModKey.FromNameAndExtension(Path.GetFileName(modName.AsSpan())))

  ///<summary>
  ///Function for create a new Oblivion mod, fields only mod name
  ///</summary>
  let createOblivionMod (modName: string) =
    OblivionMod(Plugins.ModKey.FromNameAndExtension(Path.GetFileName(modName.AsSpan())))


module private Internal =

  //Wrapper function for cast IModListing, need for access to some methods
  let listingGetter (a: IEnumerable<IModListing<ISkyrimModGetter>>) =
    a.Cast<IModListingGetter<ISkyrimModGetter>>()

///<summary>
///Module contain functions for get a some loaded orders
///</summary>
[<RequireQualifiedAccess>]
module LoadOrder =
  
  ///<summary> 
  ///Get Skyrim Listed Order from system enviroment, need skyrim release, Enum Mutagen.Bethesda.Skyrim namespace
  ///</summary>
  let skyrimListedOrderFromEnv (skyrimRelease: SkyrimRelease) =
    let env = GameEnvironment.Typical.Skyrim(skyrimRelease)
    Internal.listingGetter env.LoadOrder.ListedOrder

  ///<summary> 
  ///Get Skyrim Priority Order from system enviroment, need skyrim release, Enum Mutagen.Bethesda.Skyrim namespace
  ///</summary>
  let skyrimPriorityOrderFromEnv (skyrimRelease: SkyrimRelease) =
    let env = GameEnvironment.Typical.Skyrim(skyrimRelease)
    Internal.listingGetter env.LoadOrder.ListedOrder

  ///<summary> 
  ///Get Skyrim Listed Order from system enviroment, return reverse order, need skyrim release, Enum Mutagen.Bethesda.Skyrim namespace
  ///</summary>
  let skyrimListedOrderFromEnvRevers (skyrimRelease: SkyrimRelease) =
    let env = GameEnvironment.Typical.Skyrim(skyrimRelease)
    Internal.listingGetter env.LoadOrder.ListedOrder
    |>Seq.rev

  ///<summary> 
  ///Get Skyrim Priority Order from system enviroment, return reverse order, need skyrim release, Enum Mutagen.Bethesda.Skyrim namespace
  ///</summary>
  let skyrimPriorityOrderFromEnvRevers (skyrimRelease: SkyrimRelease) =
    let env = GameEnvironment.Typical.Skyrim(skyrimRelease)
    Internal.listingGetter env.LoadOrder.ListedOrder
    |>Seq.rev

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

    [<RequireQualifiedAccess>]
    module Perks =

      ///<summary>
      ///Get context Perk records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
      ///
      ///Original description of method:
      ///Will find and return the most overridden version of each record in the list of mods of the given type. <br /><br />
      ///            Additionally, it will come wrapped in a context object that has knowledge of where each record came from. <br />
      ///            This context helps when trying to override deep records such as Cells/PlacedObjects/etc, as the context is able to navigate
      ///            and insert the record into the proper location for you.
      ///</summary>
      let winningContextOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
        let result = let x = loadOrder.Perk() in x.WinningContextOverrides(includeDeletedRecords)
        result
      
      ///<summary>
      ///Get Perk records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
      ///</summary>
      let winningOverrides includeDeletedRecords (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
        let result = let x = loadOrder.Perk() in x.WinningOverrides(includeDeletedRecords)
        result