
using StardewModdingAPI;
using StardewValley;
using HarmonyLib;
using Spacechase.Shared.Patching;
using LootFilter;
using StardewValley.Locations;
using Microsoft.Xna.Framework;
using Object = StardewValley.Object;




/// <summary>Applies Harmony patches to <see cref="GameLocation"/>.</summary>

internal class PlayerInRangePatch : BasePatcher
{

    private readonly ModConfig Config;
    public static ModEntry Instance { get; private set; }

    public PlayerInRangePatch(ModConfig _config, ModEntry _Instance)
    {
        Config = _config;
        Instance = _Instance;

    }

    public override void Apply(Harmony harmony, IMonitor monitor)
    {
        var originalMethod = AccessTools.Method(typeof(Debris), "playerInRange");

        if (originalMethod == null)
        {
            monitor.Log("Failed to find method: Debris.playerInRange", LogLevel.Error);
            return;
        }

        harmony.Patch(
            original: originalMethod,
            prefix: new HarmonyMethod(typeof(PlayerInRangePatch), nameof(prefixPlayerInRange))
        );



    }

    public static bool prefixPlayerInRange(Debris __instance, Vector2 position, Farmer farmer , ref bool __result)
    {


        if (__instance.debrisType.Value == Debris.DebrisType.OBJECT || __instance.debrisType.Value == Debris.DebrisType.ARCHAEOLOGY)
        {
            if (__instance.item != null)
            {
                var filteredItem = Instance.Config.ObjectToFilter.FirstOrDefault(f =>
                    f.ItemId.Contains(__instance.item.ItemId) && f.ShouldFilter);

                if (filteredItem != null)
                {

                    if (filteredItem.ShouldFilter)
                    {
                        
                        __result = false;
                        return false;


                    }
                }
            }

        }
        return true;




    }
}