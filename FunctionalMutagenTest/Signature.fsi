




module Program

val inline (=>) : f: ('a -> 'b) -> x: 'a -> 'b

val loadOrder:
  seq<Mutagen.Bethesda.Plugins.Order.IModListingGetter<Mutagen.Bethesda.Skyrim.ISkyrimModGetter>>

val cacheLink:
  Mutagen.Bethesda.Cache.Implementations.ImmutableLoadOrderLinkCache<Mutagen.Bethesda.Skyrim.ISkyrimMod,
                                                                     Mutagen.Bethesda.Skyrim.ISkyrimModGetter>

val outMod: Mutagen.Bethesda.Skyrim.SkyrimMod

val LVLNPC:
  System.Collections.Generic.IEnumerable<Mutagen.Bethesda.Skyrim.ILeveledNpcGetter>

val MGEFS:
  System.Collections.Generic.IEnumerable<Mutagen.Bethesda.Skyrim.IMagicEffectGetter>

val fullDeepCopyleveledNpc:
  lnpc: Mutagen.Bethesda.Skyrim.ILeveledNpcGetter
    -> Mutagen.Bethesda.Skyrim.LeveledNpc

val setLevelForEntries:
  lnpc: Mutagen.Bethesda.Skyrim.LeveledNpc -> Mutagen.Bethesda.Skyrim.LeveledNpc

val addAsOverrideAllLeveledNpcs:
  lnpc: Mutagen.Bethesda.Skyrim.LeveledNpc -> unit

val (|BlockActorValue|NoBlockActorValue|) :
  actorValue: Mutagen.Bethesda.Skyrim.ActorValue *
  dualActorValue: Mutagen.Bethesda.Skyrim.ActorValue -> Choice<unit,unit>

