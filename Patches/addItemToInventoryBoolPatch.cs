using HarmonyLib;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Tools;
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
                    mod.Monitor.Log($"\n", LogLevel.Debug);
                    mod.Monitor.Log("[DevMode-addItemToInventoryBoolPatch] Menu open → filter disabled", LogLevel.Debug);
                }
                return true;
            }

            if (mod.Config.DeveloperMode)
                mod.Monitor.Log($"\n", LogLevel.Debug);

            string itemID = item.QualifiedItemId;

            if (mod.Config.DeveloperMode)
                mod.Monitor.Log($"[Siphon] Checking item {item.Name} ({itemID})", LogLevel.Debug);

            // 1) CATEGORY FILTER OVERRIDE
            var filters = mod.Config.CategoryFilters ?? new CategoryFiltersConfig();

            if (IsBlockedByCategory(item, filters, mod))
            {
                BlockItem(item, ref __result, mod, "(Category)");
                return false;
            }

            // 2) PER-ITEM FILTER LIST
            var filteredItem = mod.Config.ObjectToFilter
                .FirstOrDefault(f => f.ItemId == itemID && f.ShouldFilter);

            if (filteredItem != null)
            {
                BlockItem(item, ref __result, mod, "(Per-Item)");
                return false;
            }

            return true;
        }


        // --------------------------------------------
        // BLOCK ITEM HELPER
        // --------------------------------------------
        private static void BlockItem(Item item, ref bool __result, ModEntry mod, string reason)
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
                    mod.Monitor.Log($"{reason} Dropped {item.Name} at {pos}", LogLevel.Debug);
            }
            else
            {
                if (mod.Config.DeveloperMode)
                    mod.Monitor.Log($"{reason} Removed {item.Name} from game.", LogLevel.Debug);
            }
        }



        // --------------------------------------------
        // CATEGORY FILTERS (SDV 1.6 CORRECT VERSION)
        // --------------------------------------------
        private static bool IsBlockedByCategory(Item item, CategoryFiltersConfig filters, ModEntry mod)
        {
            if (filters == null)
                return false;

            string qid = item.QualifiedItemId ?? string.Empty;


            // =========================================================
            // MAIN CATEGORIES
            // =========================================================

            if (filters.Weapons)
            {
                if (item is MeleeWeapon || qid.StartsWith("(W)"))
                    return true;
            }

            if (filters.Tools)
            {
                if (item is Tool && item is not MeleeWeapon)
                    return true;
                if (qid.StartsWith("(T)"))
                    return true;
            }

            if (filters.Boots)
            {
                if (item is StardewValley.Objects.Boots || qid.StartsWith("(B)"))
                    return true;
            }

            if (filters.Hats)
            {
                if (item is StardewValley.Objects.Hat || qid.StartsWith("(H)"))
                    return true;
            }

            if (filters.Shirts)
            {
                if (item is StardewValley.Objects.Clothing c &&
                    c.clothesType.Value == StardewValley.Objects.Clothing.ClothesType.SHIRT)
                    return true;

                if (qid.StartsWith("(S)"))
                    return true;
            }

            if (filters.Pants)
            {
                if (item is StardewValley.Objects.Clothing c &&
                    c.clothesType.Value == StardewValley.Objects.Clothing.ClothesType.PANTS)
                    return true;

                if (qid.StartsWith("(P)"))
                    return true;
            }

            if (filters.Rings)
            {
                if (item is StardewValley.Objects.Ring || qid.StartsWith("(R)"))
                    return true;
            }

            if (filters.Objects)
            {
                if (item is StardewValley.Object && qid.StartsWith("(O)"))
                    return true;
            }

            // Artifacts (SDV 1.6 correct: Category == -2)
            if (filters.Artifacts && item is StardewValley.Object oArt)
            {
                if (oArt.Category == -2)
                    return true;
            }



            // =========================================================
            // SUBCATEGORIES — SDV 1.6 category values
            // =========================================================
            if (item is StardewValley.Object obj)
            {
                int cat = obj.Category;

                if (filters.Fish && cat == -4) return true;
                if (filters.Eggs && cat == -5) return true;
                if (filters.Milk && cat == -6) return true;
                if (filters.Food && cat == -7) return true;
                if (filters.CraftingMaterials && cat == -8) return true;
                if (filters.BigCraftables && obj.bigCraftable.Value) return true;

                if (filters.Minerals && cat == -12) return true;
                if (filters.Meat && cat == -14) return true;
                if (filters.MetalResources && cat == -15) return true;
                if (filters.BuildingResources && cat == -16) return true;

                if (filters.Fertilizer && cat == -20) return true;
                if (filters.Bait && cat == -21) return true;
                if (filters.Tackle && cat == -22) return true;
                if (filters.Ingredients && cat == -23) return true;

                if (filters.ArtisanGoods && cat == -26) return true;
                if (filters.Syrups && cat == -27) return true;
                if (filters.MonsterLoot && cat == -28) return true;

                if (filters.Seeds && cat == -74) return true;
                if (filters.Vegetables && cat == -75) return true;
                if (filters.Flowers && cat == -80) return true;
                if (filters.Forage && cat == -81) return true;

                // Junk / Trash is -79
                if (filters.Junk && cat == -79) return true;

                // Fruit uses type, not category
                if (filters.Fruit && obj.Type == "Fruit") return true;
            }

            return false;
        }
    }
}
