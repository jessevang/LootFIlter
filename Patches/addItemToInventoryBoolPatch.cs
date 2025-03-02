
using StardewModdingAPI;
using StardewValley;
using HarmonyLib;
using Spacechase.Shared.Patching;
using LootFilter;


/// <summary>Applies Prefix Harmony patches to <see cref="Farmer.addItemToInventoryBool"/>.</summary>

internal class addItemToInventoryBoolPatch : BasePatcher
{

     public static ModConfig config { get; set; }
     public static ModEntry Instance { get;set;}

    public addItemToInventoryBoolPatch(ModConfig config2, ModEntry Instance2)
    {
        config = config2;
        Instance = Instance2;
    }

    public override void Apply(Harmony harmony, IMonitor monitor)
    {
        harmony.Patch(
        original: this.RequireMethod<Farmer>(
               nameof(Farmer.addItemToInventoryBool)),
           prefix: this.GetHarmonyMethod(nameof(PrefixaddItemToInventoryBool)) // prefix method
         ); 
    }


    ///<Summary> Checks If item is filtered list if it is, 
    ///then item is removed, then recreated a distanced away from from character. 
    ///If item is not on the filtered list then normal functions apply the add item into inventory.</summary>
    public static bool PrefixaddItemToInventoryBool(Item item, ref bool __result)
    {
        if (item == null)
        {
            return true;
        }

        //if loot filter is turned off runs original code
        if (!Instance.LootFilterOn)
        {
            return true;
        }

        //Console.WriteLine("ItemName: " + item.Name+ "  ItemID: " + item.ItemId);

        var filteredItem = Instance.Config.ObjectToFilter.FirstOrDefault(f =>
            f.ItemId.Contains(item.ItemId) && f.ShouldFilter);

        if (filteredItem != null)
        {

            if (filteredItem.ShouldFilter)
            {

                __result = true;  //true will remove item debris


                Farmer player = Game1.player;
                int randomNumber = Game1.random.Next(Instance.Config.distanceFilterItemMovesAwayFromPlayer, Instance.Config.distanceFilterItemMovesAwayFromPlayer + 2);

                // Calculate a position a bit away from the player
                int tileX = (int)player.Tile.X + randomNumber; // random tiles to the right
                int tileY = (int)player.Tile.Y; // Same Y level

                // Spawn the object at the specified location
                Game1.createObjectDebris(filteredItem.ItemId, tileX, tileY, player.UniqueMultiplayerID);

                return false;
            }

        }

        return true;
    }


}







