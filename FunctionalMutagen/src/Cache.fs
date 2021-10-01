namespace Mutagen.Func

open Mutagen.Bethesda
open Mutagen.Bethesda.Plugins.Order
open Mutagen.Bethesda.Skyrim
open System.Collections.Generic

///<summary>
///Module contain functions get and manipulate form link cache
///</summary>
[<RequireQualifiedAccess>]
module Cache =
  
  ///<summary>
  ///Origianl description:
  ///Create a new linking package relative a load order. Will resolve links to the highest overriding mod containing 
  ///the record being sought. Modification of target LoadOrder, or Mods on the LoadOrder is not safe. 
  ///Internal caches become incorrect in modifications occur on content already cached.
  ///</summary>
  let toImmutableLinkCache (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
    loadOrder.ToImmutableLinkCache()

  ///<summary>
  ///Origianl description:
  ///Create a new linking package relative a load order. Will resolve links to the highest overriding mod containing 
  ///the record being sought. Modification of target LoadOrder, or Mods on the LoadOrder is not safe. 
  ///Internal caches become incorrect in modifications occur on content already cached.
  ///</summary>
  let toUntypedImmutableLinkCache (loadOrder: IEnumerable<IModListingGetter<ISkyrimModGetter>>) =
    loadOrder.ToUntypedImmutableLinkCache()