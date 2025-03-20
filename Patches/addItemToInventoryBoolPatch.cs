
using StardewModdingAPI;
using StardewValley;
using HarmonyLib;
using Spacechase.Shared.Patching;
using LootFilter;
using Microsoft.Xna.Framework;
using xTile.Dimensions;


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


        string itemID = item.GetItemTypeId() + item.ItemId;
        int stackSize = item.Stack;
        int quality = item.Quality;
        Console.WriteLine("ItemID: " + itemID + " ItemStack: " + stackSize + " Quality: " + quality);
        var filteredItem = Instance.Config.ObjectToFilter.FirstOrDefault(f =>
            f.ItemId.Contains(itemID) && f.ShouldFilter);

        if (filteredItem != null)
        {

            if (filteredItem.ShouldFilter)
            {

                __result = true;  //true will remove item debris


                Farmer player = Game1.player;
                int randomNumber = Game1.random.Next(Instance.Config.distanceFilterItemMovesAwayFromPlayer, Instance.Config.distanceFilterItemMovesAwayFromPlayer + 2);

                // Calculate a position a bit away from the player

                Vector2 vector2 = new Vector2((int)((player.Tile.X + randomNumber )* 64), (int)player.Tile.Y*64);
                
                if (!Instance.Config.RemoveFilteredItemFromGame)
                {
                   
                    Game1.createItemDebris(item, vector2, Game1.random.Next(4));
                   
                }
                

                return false;
            }

        }

        return true;
    }


}







