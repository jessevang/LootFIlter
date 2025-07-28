using HarmonyLib;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;
using System.Linq;

namespace LootFilter.Patches
{
    [HarmonyPatch(typeof(Farmer), nameof(Farmer.addItemToInventoryBool))]
    public static class AddItemToInventoryBoolPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(Item item, ref bool __result)
        {
            return PrefixaddItemToInventoryBool(item, ref __result);
        }

        public static bool PrefixaddItemToInventoryBool(Item item, ref bool __result)
        {
            var mod = ModEntry.Instance;
            if (mod == null || item == null)
                return true;

            if (!mod.LootFilterOn)
                return true;

            if (Game1.activeClickableMenu != null)
            {

                if (mod.Config.DeveloperMode)
                {
                    mod.Monitor.Log($"\n", LogLevel.Debug); //add new line to see seperations
                    mod.Monitor.Log($"[DevMode-addItemToInventoryBoolPatch] A Menu is Open so Loot Filter Will not be Applied", LogLevel.Debug); //add new line to see seperations
                }
                return true;
            } //Added to prevent loot filter from applying when a menu is open to fix a bug that applied filter during stash transfer
                

            if (mod.Config.DeveloperMode)
            {
                mod.Monitor.Log($"\n", LogLevel.Debug); //add new line to see seperations
            }

            string itemID = item.GetItemTypeId() + item.ItemId;
            int stackSize = item.Stack;
            int quality = item.Quality;

            if (mod.Config.DeveloperMode)
            {
                mod.Monitor.Log($"[DevMode-addItemToInventoryBoolPatch] Trying to add item: {item.Name} (ID: {itemID}) Stack: {stackSize}, Quality: {quality}", LogLevel.Debug);
            }

           

            var filteredItem = mod.Config.ObjectToFilter.FirstOrDefault(f =>
                f.ItemId.Contains(itemID) && f.ShouldFilter);

            if (mod.Config.DeveloperMode)
            {
                if (filteredItem == null)
                {
                    mod.Monitor.Log($"[DevMode-addItemToInventoryBoolPatch] Item {item.Name} is NOT in loot filter list.", LogLevel.Debug);
                }
                else if (!filteredItem.ShouldFilter)
                {
                    mod.Monitor.Log($"[DevMode-addItemToInventoryBoolPatch] Item {item.Name} is in loot filter list, but ShouldFilter = false.", LogLevel.Debug);
                }
                else
                {
                    mod.Monitor.Log($"[DevMode-addItemToInventoryBoolPatch] Item {item.Name} is in loot filter list and ShouldFilter = true. Filtering will apply.", LogLevel.Debug);
                }
            }


            if (filteredItem != null && filteredItem.ShouldFilter)
            {
                __result = true;

                Farmer player = Game1.player;
                int randomDist = Game1.random.Next(mod.Config.distanceFilterItemMovesAwayFromPlayer,
                                                   mod.Config.distanceFilterItemMovesAwayFromPlayer + 2);
                Vector2 pos = new Vector2((player.Tile.X + randomDist) * 64, player.Tile.Y * 64);

                if (!mod.Config.RemoveFilteredItemFromGame)
                {
                    Game1.createItemDebris(item, pos, Game1.random.Next(4));
                    if (mod.Config.DeveloperMode)
                    {
                        mod.Monitor.Log($"[DevMode-addItemToInventoryBoolPatch] Item {item.Name} dropped at distance {randomDist} to ({pos.X},{pos.Y})", LogLevel.Debug);
                    }
                }

                else if (mod.Config.DeveloperMode && mod.Config.RemoveFilteredItemFromGame)
                {
                    mod.Monitor.Log($"[DevMode-addItemToInventoryBoolPatch] Item {item.Name} is a loot filtered item and because the GMCM setting 'RemoveFilteredItemFromGame' is set to true the item has been removed from the game.", LogLevel.Debug);
                }

                return false;
            }

            return true;
        }
    }
}
