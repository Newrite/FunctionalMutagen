



namespace Mutagen.Func
    
    module Mods =
        
        val CreateSkyrimMod:
          modName: string -> skyrimRelease: Bethesda.Skyrim.SkyrimRelease
            -> Bethesda.Skyrim.SkyrimMod

namespace Mutagen.Func
    
    module private Internal =
        
        val listingGetter:
          a: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListing<Bethesda.Skyrim.ISkyrimModGetter>>
            -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
    
    module LoadOrder =
        
        val ListedOrderFromEnv:
          skyrimRelease: Bethesda.Skyrim.SkyrimRelease
            -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
        
        val PriorityOrderFromEnv:
          skyrimRelease: Bethesda.Skyrim.SkyrimRelease
            -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
        
        val ListedOrderFromEnvRevers:
          skyrimRelease: Bethesda.Skyrim.SkyrimRelease
            -> seq<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
        
        val PriorityOrderFromEnvRevers:
          skyrimRelease: Bethesda.Skyrim.SkyrimRelease
            -> seq<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>

namespace Mutagen.Func
    
    module Records =
        
        module Weapon =
            
            val WinningContextOverrides:
              includeDeletedRecords: bool
              -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Cache.IModContext<Bethesda.Skyrim.ISkyrimMod,
                                                                                             Bethesda.Skyrim.ISkyrimModGetter,
                                                                                             Bethesda.Skyrim.IWeapon,
                                                                                             Bethesda.Skyrim.IWeaponGetter>>
            
            val WinningOverrides:
              includeDeletedRecords: bool
              -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                -> System.Collections.Generic.IEnumerable<Bethesda.Skyrim.IWeaponGetter>
        
        module Armor =
            
            val WinningContextOverrides:
              includeDeletedRecords: bool
              -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Cache.IModContext<Bethesda.Skyrim.ISkyrimMod,
                                                                                             Bethesda.Skyrim.ISkyrimModGetter,
                                                                                             Bethesda.Skyrim.IArmor,
                                                                                             Bethesda.Skyrim.IArmorGetter>>
            
            val WinningOverrides:
              includeDeletedRecords: bool
              -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                -> System.Collections.Generic.IEnumerable<Bethesda.Skyrim.IArmorGetter>
        
        module Npc =
            
            val WinningContextOverrides:
              includeDeletedRecords: bool
              -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Cache.IModContext<Bethesda.Skyrim.ISkyrimMod,
                                                                                             Bethesda.Skyrim.ISkyrimModGetter,
                                                                                             Bethesda.Skyrim.INpc,
                                                                                             Bethesda.Skyrim.INpcGetter>>
            
            val WinningOverrides:
              includeDeletedRecords: bool
              -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                -> System.Collections.Generic.IEnumerable<Bethesda.Skyrim.INpcGetter>
        
        module LeveledNpc =
            
            val WinningContextOverrides:
              includeDeletedRecords: bool
              -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Cache.IModContext<Bethesda.Skyrim.ISkyrimMod,
                                                                                             Bethesda.Skyrim.ISkyrimModGetter,
                                                                                             Bethesda.Skyrim.ILeveledNpc,
                                                                                             Bethesda.Skyrim.ILeveledNpcGetter>>
            
            val WinningOverrides:
              includeDeletedRecords: bool
              -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                -> System.Collections.Generic.IEnumerable<Bethesda.Skyrim.ILeveledNpcGetter>
        
        module MagicEffect =
            
            val WinningContextOverrides:
              includeDeletedRecords: bool
              -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Cache.IModContext<Bethesda.Skyrim.ISkyrimMod,
                                                                                             Bethesda.Skyrim.ISkyrimModGetter,
                                                                                             Bethesda.Skyrim.IMagicEffect,
                                                                                             Bethesda.Skyrim.IMagicEffectGetter>>
            
            val WinningOverrides:
              includeDeletedRecords: bool
              -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                -> System.Collections.Generic.IEnumerable<Bethesda.Skyrim.IMagicEffectGetter>

namespace Mutagen.Func
    
    module Cache =
        
        val ToImmutableLinkCache:
          loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
            -> Bethesda.Cache.Implementations.ImmutableLoadOrderLinkCache<Bethesda.Skyrim.ISkyrimMod,
                                                                          Bethesda.Skyrim.ISkyrimModGetter>
        
        val ToUntypedImmutableLinkCache:
          loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
            -> Bethesda.Cache.Implementations.ImmutableLoadOrderLinkCache

namespace Mutagen.Func
    
    module Scripts =
        
        module ScriptEntry =
            
            ///<summary>Create new ScriptEntry with ScriptName and list of ScriptProperty, can fill with Scripts.ScriptProperty module.</summary>
            val New:
              entryName: string
              -> propertyList: Bethesda.Skyrim.ScriptProperty list
                -> Bethesda.Skyrim.ScriptEntry
        
        module ScriptProperty =
            
            ///Internal function, build ExtendedList from F# list, need for PropertyList functions
            val private buildExtendList:
              values: 'a list -> Noggog.ExtendedList<'a>
            
            ///<summary>Create new ScriptFloatProperty, field name and float32 value.</summary>
            val Float:
              name: string -> value: float32
                -> Bethesda.Skyrim.ScriptFloatProperty
            
            ///<summary>Create new ScriptBoolProperty, field name and bool value.</summary>
            val Bool:
              name: string -> value: bool -> Bethesda.Skyrim.ScriptBoolProperty
            
            ///<summary>Create new ScriptStringProperty, field name and string value.</summary>
            val String:
              name: string -> value: string
                -> Bethesda.Skyrim.ScriptStringProperty
            
            ///<summary>Create new ScriptIntProperty, field name and int value.</summary>
            val Integer:
              name: string -> value: int -> Bethesda.Skyrim.ScriptIntProperty
            
            ///<summary>Create new ScriptObjectProperty, field name and Bethesda object, 
            ///need link object so you can use FormKeys from Mutagen.Bethesda.FormKeys lib 
            ///lib link: https://github.com/Mutagen-Modding/Mutagen.Bethesda.FormKeys.</summary>
            val Object:
              name: string -> object: Bethesda.Plugins.FormLink<'a>
                -> Bethesda.Skyrim.ScriptObjectProperty
                when 'a :> Bethesda.Skyrim.ISkyrimMajorRecordGetter and
                     'a: not struct
            
            ///<summary>Create new ScriptFloatListProperty, field float32 list value.</summary>
            val FloatList:
              values: float32 list -> Bethesda.Skyrim.ScriptFloatListProperty
            
            ///<summary>Create new ScriptBoolListProperty, field bool list value.</summary>
            val BoolList:
              values: bool list -> Bethesda.Skyrim.ScriptBoolListProperty
            
            ///<summary>Create new ScriptStringListProperty, field string list value.</summary>
            val StringList:
              values: string list -> Bethesda.Skyrim.ScriptStringListProperty
            
            ///<summary>Create new ScriptIntListProperty, field int list value.</summary>
            val IntegerList:
              values: int list -> Bethesda.Skyrim.ScriptIntListProperty
            
            ///<summary>Create new ScriptObjectListProperty, field Bethesda objects, 
            ///for create list of objects use Scripts.ScriptProperty.Object.</summary>
            val ObjectList:
              values: Bethesda.Skyrim.ScriptObjectProperty list
                -> Bethesda.Skyrim.ScriptObjectListProperty
        
        module VirtualMachineAdapter =
            
            ///<summary>Create new VirtualMachineAdapter, can fill ScriptEntry list with Scripts.ScriptEntry.New.</summary>
            val New:
              scriptEntryList: Bethesda.Skyrim.ScriptEntry list
                -> Bethesda.Skyrim.VirtualMachineAdapter

