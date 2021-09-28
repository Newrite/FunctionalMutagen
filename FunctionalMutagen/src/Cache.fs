namespace Mutagen.Func

open Mutagen.Bethesda
open Mutagen.Bethesda.Plugins.Order
open Mutagen.Bethesda.Skyrim
open System.Collections.Generic

[<RequireQualifiedAccess>]
module Cache =
  
  let ToImmutableLinkCache (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
    loadOrder.ToImmutableLinkCache()

  let ToUntypedImmutableLinkCache (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
    loadOrder.ToUntypedImmutableLinkCache()