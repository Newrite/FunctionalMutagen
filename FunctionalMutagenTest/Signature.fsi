




module Program

val test:
  a: System.Collections.Generic.IEnumerable<Mutagen.Bethesda.Plugins.Order.IModListing<Mutagen.Bethesda.Skyrim.ISkyrimModGetter>>
    -> System.Collections.Generic.IEnumerable<Mutagen.Bethesda.Skyrim.IWeaponGetter>

val entry: Mutagen.Bethesda.Skyrim.VirtualMachineAdapter

val order:
  seq<Mutagen.Bethesda.Plugins.Order.IModListingGetter<Mutagen.Bethesda.Skyrim.ISkyrimModGetter>>

val cache:
  Mutagen.Bethesda.Cache.Implementations.ImmutableLoadOrderLinkCache<Mutagen.Bethesda.Skyrim.ISkyrimMod,
                                                                     Mutagen.Bethesda.Skyrim.ISkyrimModGetter>

val wep:
  System.Collections.Generic.IEnumerable<Mutagen.Bethesda.Skyrim.IWeaponGetter>

