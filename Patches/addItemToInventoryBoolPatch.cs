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

            string itemID = item.GetItemTypeId() + item.ItemId;
            int stackSize = item.Stack;
            int quality = item.Quality;

            mod.Monitor.Log($"ItemID: {itemID}, Stack: {stackSize}, Quality: {quality}", LogLevel.Trace);

            var filteredItem = mod.Config.ObjectToFilter.FirstOrDefault(f =>
                f.ItemId.Contains(itemID) && f.ShouldFilter);

            if (filteredItem != null && filteredItem.ShouldFilter)
            {
                __result = true;

                Farmer player = Game1.player;
                int randomDist = Game1.random.Next(mod.Config.distanceFilterItemMovesAwayFromPlayer,
                                                   mod.Config.distanceFilterItemMovesAwayFromPlayer + 2);
                Vector2 pos = new Vector2((player.Tile.X + randomDist) * 64, player.Tile.Y * 64);

                if (!mod.Config.RemoveFilteredItemFromGame)
                    Game1.createItemDebris(item, pos, Game1.random.Next(4));

                return false;
            }

            return true;
        }
    }
}
