namespace Mutagen.Func

open Mutagen.Bethesda
open Mutagen.Bethesda.Plugins.Order
open Mutagen.Bethesda.Skyrim
open Mutagen.Bethesda.Environments
open System.Linq
open System.Collections.Generic
open Mutagen.Bethesda.Skyrim

[<RequireQualifiedAccess>]
module Cache =
  
  let ToImmutableLinkCache (getter: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
    getter.ToImmutableLinkCache()

  let ToUntypedImmutableLinkCache (getter: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
    getter.ToUntypedImmutableLinkCache()