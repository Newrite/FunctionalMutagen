namespace Mutagen.Func

open Mutagen.Bethesda
open Mutagen.Bethesda.Plugins.Order
open Mutagen.Bethesda.Skyrim
open Mutagen.Bethesda.Environments
open System.Linq
open System.Collections.Generic

module private Internal =

  let listingGetter (a: IEnumerable<IModListing<ISkyrimModGetter>>) =
    a.Cast<IModListingGetter<ISkyrimModGetter>>()

module LoadOrder =
  
  let ListedOrderFromEnv (skyrimRelease: SkyrimRelease) =
    let env = GameEnvironment.Typical.Skyrim(skyrimRelease)
    env.LoadOrder.ListedOrder

  let PriorityOrderFromEnv (skyrimRelease: SkyrimRelease) =
    let env = GameEnvironment.Typical.Skyrim(skyrimRelease)
    env.LoadOrder.ListedOrder

  let ListedOrderFromEnvRevers (skyrimRelease: SkyrimRelease) =
    let env = GameEnvironment.Typical.Skyrim(skyrimRelease)
    env.LoadOrder.ListedOrder
    |>Seq.rev

  let PriorityOrderFromEnvRevers (skyrimRelease: SkyrimRelease) =
    let env = GameEnvironment.Typical.Skyrim(skyrimRelease)
    env.LoadOrder.ListedOrder
    |>Seq.rev

module Cache =
  
  let ToImmutableLinkCache getter =
    (Internal.listingGetter getter).ToImmutableLinkCache()

  let ToUntypedImmutableLinkCache getter =
    (Internal.listingGetter getter).ToUntypedImmutableLinkCache
