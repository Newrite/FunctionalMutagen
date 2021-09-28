namespace Mutagen.Func

open Mutagen.Bethesda
open Mutagen.Bethesda.Skyrim
open System.IO
open System


[<RequireQualifiedAccess>]
module Mods =

  let CreateMod (modName: string) (skyrimRelease: SkyrimRelease) =
    SkyrimMod(Plugins.ModKey.FromNameAndExtension(Path.GetFileName(modName.AsSpan())), skyrimRelease)