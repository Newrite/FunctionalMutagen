



namespace Mutagen.Func
    
    ///<summary>
    ///Module contain some wrappers for create bethesda mods
    ///</summary>
    module Mods =
        
        ///<summary>
        ///Function for create a new skyrim mod, fields mod name, name must include file extension, 
        ///and SkyrimRelease Enum from Mutagen.Bethesda.Skyrim namespace
        ///</summary>
        val createSkyrimMod:
          modName: string -> skyrimRelease: Bethesda.Skyrim.SkyrimRelease
            -> Bethesda.Skyrim.SkyrimMod
        
        ///<summary>
        ///Function for create a new Fallout4 mod, fields only mod name
        ///</summary>
        val createFalloutMod: modName: string -> Bethesda.Fallout4.Fallout4Mod
        
        ///<summary>
        ///Function for create a new Oblivion mod, fields only mod name
        ///</summary>
        val createOblivionMod: modName: string -> Bethesda.Oblivion.OblivionMod

namespace Mutagen.Func
    
    module private Internal =
        
        val listingGetter:
          a: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListing<Bethesda.Skyrim.ISkyrimModGetter>>
            -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
    
    ///<summary>
    ///Module contain functions for get a some loaded orders
    ///</summary>
    module LoadOrder =
        
        ///<summary> 
        ///Get Skyrim Listed Order from system enviroment, need skyrim release, Enum Mutagen.Bethesda.Skyrim namespace
        ///</summary>
        val skyrimListedOrderFromEnv:
          skyrimRelease: Bethesda.Skyrim.SkyrimRelease
            -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
        
        ///<summary> 
        ///Get Skyrim Priority Order from system enviroment, need skyrim release, Enum Mutagen.Bethesda.Skyrim namespace
        ///</summary>
        val skyrimPriorityOrderFromEnv:
          skyrimRelease: Bethesda.Skyrim.SkyrimRelease
            -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
        
        ///<summary> 
        ///Get Skyrim Listed Order from system enviroment, return reverse order, need skyrim release, Enum Mutagen.Bethesda.Skyrim namespace
        ///</summary>
        val skyrimListedOrderFromEnvRevers:
          skyrimRelease: Bethesda.Skyrim.SkyrimRelease
            -> seq<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
        
        ///<summary> 
        ///Get Skyrim Priority Order from system enviroment, return reverse order, need skyrim release, Enum Mutagen.Bethesda.Skyrim namespace
        ///</summary>
        val skyrimPriorityOrderFromEnvRevers:
          skyrimRelease: Bethesda.Skyrim.SkyrimRelease
            -> seq<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>

namespace Mutagen.Func
    
    ///<summary>
    ///Module contain functions get and manipulate records
    ///</summary>
    module Records =
        
        module Skyrim =
            
            module Weapon =
                
                ///<summary>
                ///Get context Weapon records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
                ///
                ///Original description of method:
                ///Will find and return the most overridden version of each record in the list of mods of the given type. <br /><br />
                ///            Additionally, it will come wrapped in a context object that has knowledge of where each record came from. <br />
                ///            This context helps when trying to override deep records such as Cells/PlacedObjects/etc, as the context is able to navigate
                ///            and insert the record into the proper location for you.
                ///</summary>
                val winningContextOverrides:
                  includeDeletedRecords: bool
                  -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                    -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Cache.IModContext<Bethesda.Skyrim.ISkyrimMod,
                                                                                                 Bethesda.Skyrim.ISkyrimModGetter,
                                                                                                 Bethesda.Skyrim.IWeapon,
                                                                                                 Bethesda.Skyrim.IWeaponGetter>>
                
                ///<summary>
                ///Get Weapon records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
                ///</summary>
                val winningOverrides:
                  includeDeletedRecords: bool
                  -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                    -> System.Collections.Generic.IEnumerable<Bethesda.Skyrim.IWeaponGetter>
            
            module Armor =
                
                ///<summary>
                ///Get context Armor records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
                ///
                ///Original description of method:
                ///Will find and return the most overridden version of each record in the list of mods of the given type. <br /><br />
                ///            Additionally, it will come wrapped in a context object that has knowledge of where each record came from. <br />
                ///            This context helps when trying to override deep records such as Cells/PlacedObjects/etc, as the context is able to navigate
                ///            and insert the record into the proper location for you.
                ///</summary>
                val winningContextOverrides:
                  includeDeletedRecords: bool
                  -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                    -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Cache.IModContext<Bethesda.Skyrim.ISkyrimMod,
                                                                                                 Bethesda.Skyrim.ISkyrimModGetter,
                                                                                                 Bethesda.Skyrim.IArmor,
                                                                                                 Bethesda.Skyrim.IArmorGetter>>
                
                ///<summary>
                ///Get Armor records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
                ///</summary>
                val winningOverrides:
                  includeDeletedRecords: bool
                  -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                    -> System.Collections.Generic.IEnumerable<Bethesda.Skyrim.IArmorGetter>
            
            module Npc =
                
                ///<summary>
                ///Get context Npc records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
                ///
                ///Original description of method:
                ///Will find and return the most overridden version of each record in the list of mods of the given type. <br /><br />
                ///            Additionally, it will come wrapped in a context object that has knowledge of where each record came from. <br />
                ///            This context helps when trying to override deep records such as Cells/PlacedObjects/etc, as the context is able to navigate
                ///            and insert the record into the proper location for you.
                ///</summary>
                val winningContextOverrides:
                  includeDeletedRecords: bool
                  -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                    -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Cache.IModContext<Bethesda.Skyrim.ISkyrimMod,
                                                                                                 Bethesda.Skyrim.ISkyrimModGetter,
                                                                                                 Bethesda.Skyrim.INpc,
                                                                                                 Bethesda.Skyrim.INpcGetter>>
                
                ///<summary>
                ///Get Npc records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
                ///</summary>
                val winningOverrides:
                  includeDeletedRecords: bool
                  -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                    -> System.Collections.Generic.IEnumerable<Bethesda.Skyrim.INpcGetter>
            
            module LeveledNpc =
                
                ///<summary>
                ///Get context LeveledNpc records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
                ///
                ///Original description of method:
                ///Will find and return the most overridden version of each record in the list of mods of the given type. <br /><br />
                ///            Additionally, it will come wrapped in a context object that has knowledge of where each record came from. <br />
                ///            This context helps when trying to override deep records such as Cells/PlacedObjects/etc, as the context is able to navigate
                ///            and insert the record into the proper location for you.
                ///</summary>
                val winningContextOverrides:
                  includeDeletedRecords: bool
                  -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                    -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Cache.IModContext<Bethesda.Skyrim.ISkyrimMod,
                                                                                                 Bethesda.Skyrim.ISkyrimModGetter,
                                                                                                 Bethesda.Skyrim.ILeveledNpc,
                                                                                                 Bethesda.Skyrim.ILeveledNpcGetter>>
                
                ///<summary>
                ///Get LeveledNpc records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
                ///</summary>
                val winningOverrides:
                  includeDeletedRecords: bool
                  -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                    -> System.Collections.Generic.IEnumerable<Bethesda.Skyrim.ILeveledNpcGetter>
            
            module MagicEffect =
                
                ///<summary>
                ///Get context MagicEffect records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
                ///
                ///Original description of method:
                ///Will find and return the most overridden version of each record in the list of mods of the given type. <br /><br />
                ///            Additionally, it will come wrapped in a context object that has knowledge of where each record came from. <br />
                ///            This context helps when trying to override deep records such as Cells/PlacedObjects/etc, as the context is able to navigate
                ///            and insert the record into the proper location for you.
                ///</summary>
                val winningContextOverrides:
                  includeDeletedRecords: bool
                  -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                    -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Cache.IModContext<Bethesda.Skyrim.ISkyrimMod,
                                                                                                 Bethesda.Skyrim.ISkyrimModGetter,
                                                                                                 Bethesda.Skyrim.IMagicEffect,
                                                                                                 Bethesda.Skyrim.IMagicEffectGetter>>
                
                ///<summary>
                ///Get MagicEffect records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
                ///</summary>
                val winningOverrides:
                  includeDeletedRecords: bool
                  -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                    -> System.Collections.Generic.IEnumerable<Bethesda.Skyrim.IMagicEffectGetter>
            
            module Perks =
                
                ///<summary>
                ///Get context Perk records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
                ///
                ///Original description of method:
                ///Will find and return the most overridden version of each record in the list of mods of the given type. <br /><br />
                ///            Additionally, it will come wrapped in a context object that has knowledge of where each record came from. <br />
                ///            This context helps when trying to override deep records such as Cells/PlacedObjects/etc, as the context is able to navigate
                ///            and insert the record into the proper location for you.
                ///</summary>
                val winningContextOverrides:
                  includeDeletedRecords: bool
                  -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                    -> System.Collections.Generic.IEnumerable<Bethesda.Plugins.Cache.IModContext<Bethesda.Skyrim.ISkyrimMod,
                                                                                                 Bethesda.Skyrim.ISkyrimModGetter,
                                                                                                 Bethesda.Skyrim.IPerk,
                                                                                                 Bethesda.Skyrim.IPerkGetter>>
                
                ///<summary>
                ///Get Perk records with last overrides in given load order, load order can get from Mutagen.Func.LoadOrder
                ///</summary>
                val winningOverrides:
                  includeDeletedRecords: bool
                  -> loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
                    -> System.Collections.Generic.IEnumerable<Bethesda.Skyrim.IPerkGetter>

namespace Mutagen.Func
    
    ///<summary>
    ///Module contain functions get and manipulate form link cache
    ///</summary>
    module Cache =
        
        ///<summary>
        ///Origianl description:
        ///Create a new linking package relative a load order. Will resolve links to the highest overriding mod containing 
        ///the record being sought. Modification of target LoadOrder, or Mods on the LoadOrder is not safe. 
        ///Internal caches become incorrect in modifications occur on content already cached.
        ///</summary>
        val toImmutableLinkCache:
          loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
            -> Bethesda.Plugins.Cache.Internals.Implementations.ImmutableLoadOrderLinkCache<Bethesda.Skyrim.ISkyrimMod,
                                                                                            Bethesda.Skyrim.ISkyrimModGetter>
        
        ///<summary>
        ///Origianl description:
        ///Create a new linking package relative a load order. Will resolve links to the highest overriding mod containing 
        ///the record being sought. Modification of target LoadOrder, or Mods on the LoadOrder is not safe. 
        ///Internal caches become incorrect in modifications occur on content already cached.
        ///</summary>
        val toUntypedImmutableLinkCache:
          loadOrder: System.Collections.Generic.IEnumerable<Bethesda.Plugins.Order.IModListingGetter<Bethesda.Skyrim.ISkyrimModGetter>>
            -> Bethesda.Plugins.Cache.Internals.Implementations.ImmutableLoadOrderLinkCache

namespace Mutagen.Func
    
    ///<summary>
    ///Module contains a small DSL for create scripts.
    ///Script entry in Scripts.ScriptEntry
    ///Script propertyes in Scripts.ScriptProperty
    ///VirtualMachineAdapter module for build new VirtualMachineAdapter if needed
    ///</summary>
    module Scripts =
        
        module ScriptEntry =
            
            ///<summary>
            ///Create new ScriptEntry with ScriptName and list of ScriptProperty, can fill with Scripts.ScriptProperty module.
            ///</summary>
            val create:
              entryName: string
              -> propertyList: Bethesda.Skyrim.ScriptProperty list
                -> Bethesda.Skyrim.ScriptEntry
        
        module ScriptProperty =
            
            ///Internal function, build ExtendedList from F# list, need for PropertyList functions
            val private buildExtendList:
              values: 'a list -> Noggog.ExtendedList<'a>
            
            ///<summary>
            ///Create new ScriptFloatProperty, field name and float32 value.
            ///</summary>
            val float:
              name: string -> value: float32
                -> Bethesda.Skyrim.ScriptFloatProperty
            
            ///<summary>
            ///Create new ScriptBoolProperty, field name and bool value.
            ///</summary>
            val bool:
              name: string -> value: bool -> Bethesda.Skyrim.ScriptBoolProperty
            
            ///<summary>
            ///Create new ScriptStringProperty, field name and string value.
            ///</summary>
            val string:
              name: string -> value: string
                -> Bethesda.Skyrim.ScriptStringProperty
            
            ///<summary>
            ///Create new ScriptIntProperty, field name and int value.
            ///</summary>
            val integer:
              name: string -> value: int -> Bethesda.Skyrim.ScriptIntProperty
            
            ///<summary>
            ///Create new ScriptObjectProperty, field name and Bethesda object, 
            ///need link object so you can use FormKeys from Mutagen.Bethesda.FormKeys lib 
            ///lib link: https://github.com/Mutagen-Modding/Mutagen.Bethesda.FormKeys.
            ///</summary>
            val object:
              name: string -> object: Bethesda.Plugins.FormLink<'a>
                -> Bethesda.Skyrim.ScriptObjectProperty
                when 'a :> Bethesda.Skyrim.ISkyrimMajorRecordGetter and
                     'a: not struct
            
            ///<summary>
            ///Create new ScriptFloatListProperty, field name and float32 list value.
            ///</summary>
            val floatList:
              name: string -> values: float32 list
                -> Bethesda.Skyrim.ScriptFloatListProperty
            
            ///<summary>
            ///Create new ScriptBoolListProperty, field name and bool list value.
            ///</summary>
            val boolList:
              name: string -> values: bool list
                -> Bethesda.Skyrim.ScriptBoolListProperty
            
            ///<summary>
            ///Create new ScriptStringListProperty, field name and string list value.
            ///</summary>
            val stringList:
              name: string -> values: string list
                -> Bethesda.Skyrim.ScriptStringListProperty
            
            ///<summary>
            ///Create new ScriptIntListProperty, field name and int list value.
            ///</summary>
            val integerList:
              name: string -> values: int list
                -> Bethesda.Skyrim.ScriptIntListProperty
            
            ///<summary>
            ///Create new ScriptObjectListProperty, field Bethesda objects, 
            ///for create list of objects use Scripts.ScriptProperty.Object.
            ///</summary>
            val objectList:
              values: Bethesda.Skyrim.ScriptObjectProperty list
                -> Bethesda.Skyrim.ScriptObjectListProperty
        
        module VirtualMachineAdapter =
            
            ///<summary>
            ///Create new VirtualMachineAdapter, add ScriptEntry with Scripts.ScriptEntry.create.
            ///</summary>
            val createWithScript:
              scriptEntryList: Bethesda.Skyrim.ScriptEntry
                -> Bethesda.Skyrim.VirtualMachineAdapter
            
            ///<summary>
            ///Create new VirtualMachineAdapter, fill ScriptEntry list with Scripts.ScriptEntry.create.
            ///</summary>
            val createWithScripts:
              scriptEntryList: Bethesda.Skyrim.ScriptEntry list
                -> Bethesda.Skyrim.VirtualMachineAdapter
            
            val ensureVMAExistAddScript:
              record: inref<#Bethesda.Skyrim.IScripted>
              -> script: Bethesda.Skyrim.ScriptEntry -> unit
            
            val ensureVMAExistAddScripts:
              record: inref<#Bethesda.Skyrim.IScripted>
              -> scripts: Bethesda.Skyrim.ScriptEntry list -> unit

