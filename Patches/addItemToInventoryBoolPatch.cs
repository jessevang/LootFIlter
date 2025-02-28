using StardewModdingAPI;
using StardewValley;
using HarmonyLib;
using Spacechase.Shared.Patching;
using LootFilter;
using StardewValley.Objects;

/// <summary>Applies Harmony patches to <see cref="GameLocation"/>.</summary>
internal class addItemToInventoryBoolPatch : BasePatcher
{
    public readonly ModConfig _config;
    public static ModEntry Instance;

    public addItemToInventoryBoolPatch(ModConfig Config)
    {
        _config = Config;
    }

    public addItemToInventoryBoolPatch(ModConfig Config, ModEntry _instance)
    {
        _config = Config;
        Instance = _instance;
    } 

    public override void Apply(Harmony harmony, IMonitor monitor)
    {

        harmony.Patch(
            original: this.RequireMethod<Farmer>(nameof(Farmer.addItemToInventoryBool)),
            prefix: this.GetHarmonyMethod(nameof(PrefixaddItemToInventoryBool))
        );

    }

    //Don't edit anymore works with items
    public static bool PrefixaddItemToInventoryBool(Debris __instance, Item item, ref bool __result, bool makeActiveObject = false)
    {
        if (item == null)
        {
            return true;
        }
        
        // if filter is on then don't run this ending scrip instead continue to check filters
        if (!Instance.LootFilterOn)
        {
            return true;
        }
        
        var filteredItem = Instance.Config.ObjectToFilter.FirstOrDefault(f =>
            f.ItemId.Contains(item.ItemId) && f.ShouldFilter);

        if (filteredItem != null)
        {
           
            if (filteredItem.ShouldFilter)
            {

               __result = true;  //true will remove item debris

               
                Farmer player = Game1.player;
                int randomNumber = Game1.random.Next(8, 10);
    
                // Calculate a position a bit away from the player
                int tileX = (int)player.Tile.X + randomNumber; // random tiles to the right
                int tileY = (int)player.Tile.Y; // Same Y level

                // Spawn the object at the specified location
                Game1.createObjectDebris(item.ItemId, tileX, tileY, player.UniqueMultiplayerID);

                return false;
            }

        }

        return true;
    }
    



}