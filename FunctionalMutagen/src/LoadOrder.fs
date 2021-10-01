namespace Mutagen.Func

open Mutagen.Bethesda
open Mutagen.Bethesda.Plugins.Order
open Mutagen.Bethesda.Skyrim
open Mutagen.Bethesda.Environments

open System.Linq
open System.Collections.Generic


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