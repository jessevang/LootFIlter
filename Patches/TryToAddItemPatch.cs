
using StardewModdingAPI;
using StardewValley;
using HarmonyLib;
using Spacechase.Shared.Patching;
using StardewValley.Menus;
using LootFilter;
using static StardewValley.Debris;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using StardewValley.Extensions;
using StardewValley.Locations;

/// <summary>Applies Harmony patches to <see cref="GameLocation"/>.</summary>

internal class TryToAddItemPatch : BasePatcher
{

    public readonly Config _config;
    public static ModEntry Instance;

    public TryToAddItemPatch(Config Config)
    {
        _config = Config;
    }


    public TryToAddItemPatch(Config Config, ModEntry _instance)
    {
        _config = Config;
        Instance = _instance;
    }




    public override void Apply(Harmony harmony, IMonitor monitor)
    {

        //Example of a postfix use case, code runes original function to get the profession name and text description on Miner (level 5), afterwards
        //Postfix will run our own version in this example is "ModifyProfessionDescription" and pass the ref string value so that we can replace the profession name and text description with our own description and profession.
        harmony.Patch(
            original: this.RequireMethod<Debris>(
            nameof(Debris.collect)
        ),
        prefix: this.GetHarmonyMethod(nameof(PrefixCollect)) 
        );


        harmony.Patch(
            original: this.RequireMethod<Debris>(
            nameof(Debris.updateChunks)
        ),
        prefix: this.GetHarmonyMethod(nameof(PrefixUpdateChunks))
        );



    }


    //check for certain item to filter before running original code to add item into loot.
    public static bool PrefixCollect(Debris __instance, Farmer farmer, ref bool __result, Chunk chunk = null)
    {


        // If this debris is a dropped object (not regular debris)
        if (__instance.debrisType.Value == DebrisType.OBJECT && __instance.item != null)
        {
            //Console.WriteLine("Debris Type Value = DebrisType.Object");
            // Example: Ignore swords, food, and drinks
            if (__instance.item is StardewValley.Object obj)
            {
               // Console.WriteLine("Debris type is considered an Object");
                if (__instance.item.ItemId.Contains("226") || __instance.item.ItemId.Contains("253"))
                {
                    //Console.WriteLine("Debris type spicy Eel, or triple expresso");
                    return true; // Skip magnet effect for these items
                }
            }
        }

        return true;
    }


    //functions to determine if magnet should attract item back to me or not
    public static bool PrefixUpdateChunks(Debris __instance, GameTime time, GameLocation location, ref bool __result)
    {
        if (__instance.debrisType.Value == DebrisType.OBJECT && __instance.item != null)
        {
            //Console.WriteLine("Debris Type Value = DebrisType.Object");
            // Example: Ignore swords, food, and drinks
            if (__instance.item is StardewValley.Object obj)
            {
               // Console.WriteLine("Debris type is considered an Object");
                if (__instance.item.ItemId.Contains("226") || __instance.item.ItemId.Contains("253"))
                {
                    //Console.WriteLine("Debris type spicy Eel, or triple expresso");
                    __result = false;
                    return false; // Skip magnet effect for these items
                }
            }
        }
        __result = true;
        return true;
    }

    

}