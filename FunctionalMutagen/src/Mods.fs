namespace Mutagen.Func

open Mutagen.Bethesda
open Mutagen.Bethesda.Skyrim
open Mutagen.Bethesda.Fallout4
open Mutagen.Bethesda.Oblivion

open System.IO
open System

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