using HarmonyLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LootFilter
{
    public class ModConfig
    {
        public KeybindList KeyToAddOrRemoveFromLootFilter { get; set; } = new(
            new Keybind(SButton.X),
            new Keybind(SButton.LeftTrigger)
        );

        public KeybindList KeyToTurnOffOnLootFilter { get; set; } = new(
            new Keybind(SButton.Z),
            new Keybind(SButton.LeftStick, SButton.LeftTrigger)
        );

        public int distanceFilterItemMovesAwayFromPlayer { get; set; } = 8;
        public bool RemoveFilteredItemFromGame { get; set; } = false;

        public bool DeveloperMode { get; set; } = false;

        public List<FilteredItem> ObjectToFilter { get; set; } = new List<FilteredItem>();

        /// <summary>
        /// Broad category-based filters (weapons, tools, artifacts, etc.).
        /// These are applied BEFORE the per-item loot filter list and override it.
        /// </summary>
        public CategoryFiltersConfig CategoryFilters { get; set; } = new CategoryFiltersConfig();
    }

    public class FilteredItem
    {
        public bool ShouldFilter { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Category-based filters used to override the per-item loot filter list.
    /// </summary>
    public class CategoryFiltersConfig
    {
        // MAIN CATEGORIES
        public bool Weapons { get; set; } = false;
        public bool Tools { get; set; } = false;
        public bool Boots { get; set; } = false;
        public bool Hats { get; set; } = false;
        public bool Shirts { get; set; } = false;
        public bool Pants { get; set; } = false;
        public bool Rings { get; set; } = false;
        public bool Objects { get; set; } = false;
        public bool Artifacts { get; set; } = false;

        // SUBCATEGORIES
        public bool Fish { get; set; } = false;
        public bool Eggs { get; set; } = false;
        public bool Milk { get; set; } = false;
        public bool Food { get; set; } = false;
        public bool CraftingMaterials { get; set; } = false;
        public bool BigCraftables { get; set; } = false;
        public bool Minerals { get; set; } = false;
        public bool Meat { get; set; } = false;
        public bool MetalResources { get; set; } = false;
        public bool BuildingResources { get; set; } = false;
        public bool PierreShopItems { get; set; } = false;
        public bool GusShopItems { get; set; } = false;
        public bool Fertilizer { get; set; } = false;
        public bool Junk { get; set; } = false;
        public bool Bait { get; set; } = false;
        public bool Tackle { get; set; } = false;
        public bool Ingredients { get; set; } = false;
        public bool ArtisanGoods { get; set; } = false;
        public bool Syrups { get; set; } = false;
        public bool MonsterLoot { get; set; } = false;
        public bool Seeds { get; set; } = false;
        public bool Vegetables { get; set; } = false;
        public bool Fruit { get; set; } = false;
        public bool Flowers { get; set; } = false;
        public bool Forage { get; set; } = false;
    }

    public class ModEntry : Mod
    {
        private IGenericModConfigMenuApi? configMenu;  // GMCM doesn't refresh listings dynamically and so this needs to be manually updated by refreshing GMCM list by registering and unregistering this

        public static IMonitor ModMonitor;
        public bool FilterMenuOpen { set; get; } = false;
        public static ModEntry Instance { get; private set; }
        public ModConfig Config { get; private set; }
        public bool LootFilterOn { get; set; } = true;
        private Harmony _harmony;
        private bool shouldRefreshGMCM = false;

        public override void Entry(IModHelper helper)
        {
            _harmony = new Harmony(ModManifest.UniqueID);
            Instance = this;
            Config = helper.ReadConfig<ModConfig>() ?? new ModConfig();
            Config.CategoryFilters ??= new CategoryFiltersConfig();

            ModMonitor = Monitor;

            var harmony = new Harmony(this.ModManifest.UniqueID);
            harmony.PatchAll();

            helper.Events.Input.ButtonPressed += Input_ButtonPressed;
            helper.Events.GameLoop.GameLaunched += GameLoop_GameLaunched;
            helper.Events.GameLoop.UpdateTicked += OnUpdateTicked;
        }

        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            if (Game1.activeClickableMenu == null)
                return;

            if (!shouldRefreshGMCM)
                return;

            RegisterConfigMenu(); // rebuilds the GMCM layout
            shouldRefreshGMCM = false; // Reset flag

            if (Config.DeveloperMode)
                Monitor.Log("GMCM refreshed with updated loot filter list.", LogLevel.Debug);
        }

        private void GameLoop_GameLaunched(object? sender, GameLaunchedEventArgs e)
        {
            // get Generic Mod Config Menu's API (if it's installed)
            var configMenu = this.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (configMenu is null)
                return;

            RegisterConfigMenu();
        }


        private void RegisterConfigMenu()
        {
            var configMenu = this.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (configMenu == null)
                return;

            if (shouldRefreshGMCM)
                configMenu.Unregister(this.ModManifest);

            Config.CategoryFilters ??= new CategoryFiltersConfig();

            configMenu.Register(
                mod: this.ModManifest,
                reset: () =>
                {
                    this.Config = new ModConfig();
                    this.Config.CategoryFilters ??= new CategoryFiltersConfig();
                },
                save: () => this.Helper.WriteConfig(this.Config)
            );

            // MAIN PAGE ---------------------------------------------------

            configMenu.AddParagraph(
                ModManifest,
                text: () => Helper.Translation.Get("main.description")
            );

            configMenu.AddKeybindList(
                mod: ModManifest,
                name: () => Helper.Translation.Get("key.addremove.name"),
                tooltip: () => Helper.Translation.Get("key.addremove.tooltip"),
                getValue: () => Config.KeyToAddOrRemoveFromLootFilter,
                setValue: value => Config.KeyToAddOrRemoveFromLootFilter = value
            );

            configMenu.AddKeybindList(
                mod: ModManifest,
                name: () => Helper.Translation.Get("key.toggle.name"),
                tooltip: () => Helper.Translation.Get("key.toggle.tooltip"),
                getValue: () => Config.KeyToTurnOffOnLootFilter,
                setValue: value => Config.KeyToTurnOffOnLootFilter = value
            );

            configMenu.AddNumberOption(
                mod: ModManifest,
                getValue: () => Instance.Config.distanceFilterItemMovesAwayFromPlayer,
                setValue: value => Instance.Config.distanceFilterItemMovesAwayFromPlayer = (int)value,
                name: () => Helper.Translation.Get("distance.name"),
                tooltip: () => Helper.Translation.Get("distance.tooltip"),
                min: 5,
                max: 80,
                interval: 1
            );

            configMenu.AddBoolOption(
                mod: ModManifest,
                getValue: () => Config.RemoveFilteredItemFromGame,
                setValue: value => Config.RemoveFilteredItemFromGame = value,
                name: () => Helper.Translation.Get("removefiltered.name"),
                tooltip: () => Helper.Translation.Get("removefiltered.tooltip")
            );

            configMenu.AddBoolOption(
                mod: ModManifest,
                getValue: () => Config.DeveloperMode,
                setValue: value => Config.DeveloperMode = value,
                name: () => Helper.Translation.Get("devmode.name"),
                tooltip: () => Helper.Translation.Get("devmode.tooltip")
            );

            // PAGE LINKS ---------------------------------------------------------

            configMenu.AddPageLink(
                mod: ModManifest,
                pageId: "category_filters",
                text: () => Helper.Translation.Get("page.categoryfilters.name"),
                tooltip: () => Helper.Translation.Get("page.categoryfilters.tooltip")
            );

            configMenu.AddPageLink(
                mod: ModManifest,
                pageId: "loot_filter_list_sorted",
                text: () => Helper.Translation.Get("page.sortedlist.name"),
                tooltip: () => Helper.Translation.Get("page.sortedlist.tooltip")
            );

            // PAGE: loot_filter_list_sorted -------------------------------------

            configMenu.AddPage(
                mod: ModManifest,
                pageId: "loot_filter_list_sorted",
                pageTitle: () => Helper.Translation.Get("page.sortedlist.title")
            );

            configMenu.SetTitleScreenOnlyForNextOptions(ModManifest, false);
            configMenu.AddSectionTitle(ModManifest, () => Helper.Translation.Get("page.sortedlist.section"));
            configMenu.AddParagraph(ModManifest, () => Helper.Translation.Get("page.sortedlist.description"));

            foreach (var filteredItem in Config.ObjectToFilter.OrderBy(f => f.Name, StringComparer.OrdinalIgnoreCase))
            {
                var localItem = filteredItem;

                configMenu.AddBoolOption(
                    mod: ModManifest,
                    getValue: () => localItem.ShouldFilter,
                    setValue: v => localItem.ShouldFilter = v,
                    name: () => Helper.Translation.Get("item.entry.name", new { item = localItem.Name, id = localItem.ItemId }),
                    tooltip: () => Helper.Translation.Get("item.entry.tooltip")
                );
            }

            // PAGE: category_filters ---------------------------------------------

            configMenu.AddPage(
                mod: ModManifest,
                pageId: "category_filters",
                pageTitle: () => Helper.Translation.Get("page.categoryfilters.title")
            );

            configMenu.SetTitleScreenOnlyForNextOptions(ModManifest, false);

            configMenu.AddSectionTitle(
                ModManifest,
                text: () => Helper.Translation.Get("category.section.title"),
                tooltip: () => Helper.Translation.Get("category.section.tooltip")
            );

            configMenu.AddParagraph(
                ModManifest,
                () => Helper.Translation.Get("category.section.description")
            );

            // MAIN CATEGORIES
            configMenu.AddSectionTitle(ModManifest, () => Helper.Translation.Get("category.main.title"));
            configMenu.AddParagraph(ModManifest, () => Helper.Translation.Get("category.main.description"));

            configMenu.AddBoolOption(ModManifest,
                () => Config.CategoryFilters.Weapons,
                v => Config.CategoryFilters.Weapons = v,
                name: () => Helper.Translation.Get("category.weapons"),
                tooltip: () => Helper.Translation.Get("category.weapons.tooltip")
            );

            configMenu.AddBoolOption(ModManifest,
                () => Config.CategoryFilters.Tools,
                v => Config.CategoryFilters.Tools = v,
                name: () => Helper.Translation.Get("category.tools"),
                tooltip: () => Helper.Translation.Get("category.tools.tooltip")
            );

            configMenu.AddBoolOption(ModManifest,
                () => Config.CategoryFilters.Boots,
                v => Config.CategoryFilters.Boots = v,
                name: () => Helper.Translation.Get("category.boots"),
                tooltip: () => Helper.Translation.Get("category.boots.tooltip")
            );

            configMenu.AddBoolOption(ModManifest,
                () => Config.CategoryFilters.Hats,
                v => Config.CategoryFilters.Hats = v,
                name: () => Helper.Translation.Get("category.hats"),
                tooltip: () => Helper.Translation.Get("category.hats.tooltip")
            );

            configMenu.AddBoolOption(ModManifest,
                () => Config.CategoryFilters.Shirts,
                v => Config.CategoryFilters.Shirts = v,
                name: () => Helper.Translation.Get("category.shirts"),
                tooltip: () => Helper.Translation.Get("category.shirts.tooltip")
            );

            configMenu.AddBoolOption(ModManifest,
                () => Config.CategoryFilters.Pants,
                v => Config.CategoryFilters.Pants = v,
                name: () => Helper.Translation.Get("category.pants"),
                tooltip: () => Helper.Translation.Get("category.pants.tooltip")
            );

            configMenu.AddBoolOption(ModManifest,
                () => Config.CategoryFilters.Rings,
                v => Config.CategoryFilters.Rings = v,
                name: () => Helper.Translation.Get("category.rings"),
                tooltip: () => Helper.Translation.Get("category.rings.tooltip")
            );

            configMenu.AddBoolOption(ModManifest,
                () => Config.CategoryFilters.Objects,
                v => Config.CategoryFilters.Objects = v,
                name: () => Helper.Translation.Get("category.objects"),
                tooltip: () => Helper.Translation.Get("category.objects.tooltip")
            );

            configMenu.AddBoolOption(ModManifest,
                () => Config.CategoryFilters.Artifacts,
                v => Config.CategoryFilters.Artifacts = v,
                name: () => Helper.Translation.Get("category.artifacts"),
                tooltip: () => Helper.Translation.Get("category.artifacts.tooltip")
            );

            // SUBCATEGORIES
            configMenu.AddSectionTitle(ModManifest, () => Helper.Translation.Get("subcategory.title"));
            configMenu.AddParagraph(ModManifest, () => Helper.Translation.Get("subcategory.description"));

            void AddSub(string key, Func<bool> g, Action<bool> s)
            {
                configMenu.AddBoolOption(
                    ModManifest,
                    getValue: g,
                    setValue: s,
                    name: () => Helper.Translation.Get($"subcategory.{key}"),
                    tooltip: () => Helper.Translation.Get($"subcategory.{key}.tooltip")
                );
            }

            AddSub("fish", () => Config.CategoryFilters.Fish, v => Config.CategoryFilters.Fish = v);
            AddSub("eggs", () => Config.CategoryFilters.Eggs, v => Config.CategoryFilters.Eggs = v);
            AddSub("milk", () => Config.CategoryFilters.Milk, v => Config.CategoryFilters.Milk = v);
            AddSub("food", () => Config.CategoryFilters.Food, v => Config.CategoryFilters.Food = v);
            AddSub("crafting", () => Config.CategoryFilters.CraftingMaterials, v => Config.CategoryFilters.CraftingMaterials = v);
            AddSub("bigcraftables", () => Config.CategoryFilters.BigCraftables, v => Config.CategoryFilters.BigCraftables = v);
            AddSub("minerals", () => Config.CategoryFilters.Minerals, v => Config.CategoryFilters.Minerals = v);
            AddSub("meat", () => Config.CategoryFilters.Meat, v => Config.CategoryFilters.Meat = v);
            AddSub("metal", () => Config.CategoryFilters.MetalResources, v => Config.CategoryFilters.MetalResources = v);
            AddSub("building", () => Config.CategoryFilters.BuildingResources, v => Config.CategoryFilters.BuildingResources = v);
            AddSub("pierre", () => Config.CategoryFilters.PierreShopItems, v => Config.CategoryFilters.PierreShopItems = v);
            AddSub("gus", () => Config.CategoryFilters.GusShopItems, v => Config.CategoryFilters.GusShopItems = v);
            AddSub("fertilizer", () => Config.CategoryFilters.Fertilizer, v => Config.CategoryFilters.Fertilizer = v);
            AddSub("junk", () => Config.CategoryFilters.Junk, v => Config.CategoryFilters.Junk = v);
            AddSub("bait", () => Config.CategoryFilters.Bait, v => Config.CategoryFilters.Bait = v);
            AddSub("tackle", () => Config.CategoryFilters.Tackle, v => Config.CategoryFilters.Tackle = v);
            AddSub("ingredients", () => Config.CategoryFilters.Ingredients, v => Config.CategoryFilters.Ingredients = v);
            AddSub("artisangoods", () => Config.CategoryFilters.ArtisanGoods, v => Config.CategoryFilters.ArtisanGoods = v);
            AddSub("syrups", () => Config.CategoryFilters.Syrups, v => Config.CategoryFilters.Syrups = v);
            AddSub("monsterloot", () => Config.CategoryFilters.MonsterLoot, v => Config.CategoryFilters.MonsterLoot = v);
            AddSub("seeds", () => Config.CategoryFilters.Seeds, v => Config.CategoryFilters.Seeds = v);
            AddSub("vegetables", () => Config.CategoryFilters.Vegetables, v => Config.CategoryFilters.Vegetables = v);
            AddSub("fruit", () => Config.CategoryFilters.Fruit, v => Config.CategoryFilters.Fruit = v);
            AddSub("flowers", () => Config.CategoryFilters.Flowers, v => Config.CategoryFilters.Flowers = v);
            AddSub("forage", () => Config.CategoryFilters.Forage, v => Config.CategoryFilters.Forage = v);
        }




        private void Input_ButtonPressed(object? sender, ButtonPressedEventArgs e)
        {
            // Toggle global loot filtering if the corresponding key is pressed.
            if (Config.KeyToTurnOffOnLootFilter.JustPressed())
            {
                LootFilterOn = !LootFilterOn;
                string message = LootFilterOn ? "Loot Filter is turned on" : "Loot Filter is turned off";
                int type = LootFilterOn ? 4 : 3;

                Game1.addHUDMessage(new HUDMessage(message, type));
                return;
            }

            if (Config.KeyToAddOrRemoveFromLootFilter.JustPressed())
            {
                if (Game1.activeClickableMenu != null)
                {
                    // Check if the player is currently holding an item in the cursor.
                    StardewValley.Item itemHeld = Game1.player.CursorSlotItem as StardewValley.Item;

                    if (itemHeld != null)
                    {
                        string itemID = itemHeld.QualifiedItemId;

                        FilteredItem fi = Config.ObjectToFilter.Find(i => i.ItemId == itemID);

                        if (fi != null)
                        {
                            // Toggle the filter state.
                            fi.ShouldFilter = !fi.ShouldFilter;
                            if (fi.ShouldFilter)
                            {
                                Game1.addHUDMessage(new HUDMessage($"Item {itemHeld.Name} filter set to {fi.ShouldFilter}", 4));
                            }
                            else
                            {
                                Game1.addHUDMessage(new HUDMessage($"Item {itemHeld.Name} filter set to {fi.ShouldFilter}", 3));
                            }
                        }
                        else
                        {
                            // If the item is not in our filter list, add it and mark it as filtered.
                            fi = new FilteredItem
                            {
                                ItemId = itemID,
                                Name = itemHeld.Name,
                                ShouldFilter = true
                            };
                            Config.ObjectToFilter.Add(fi);
                            Game1.addHUDMessage(new HUDMessage($"New Item {itemHeld.Name} added and marked for filtering", 4));
                        }

                        // Save the updated configuration.
                        Helper.WriteConfig(Config);
                        shouldRefreshGMCM = true;
                    }
                    else
                    {
                        Game1.addHUDMessage(new HUDMessage("No held item found.", 3));
                    }
                }
            }
        }
    }

    public interface IGenericModConfigMenuApi
    {
        /*********
        ** Methods
        *********/
        /****
        ** Must be called first
        ****/
        void Register(IManifest mod, Action reset, Action save, bool titleScreenOnly = false);

        void AddSectionTitle(IManifest mod, Func<string> text, Func<string> tooltip = null);
        void AddParagraph(IManifest mod, Func<string> text);
        void AddImage(IManifest mod, Func<Texture2D> texture, Rectangle? texturePixelArea = null, int scale = Game1.pixelZoom);
        void AddBoolOption(IManifest mod, Func<bool> getValue, Action<bool> setValue, Func<string> name, Func<string> tooltip = null, string fieldId = null);
        void AddNumberOption(IManifest mod, Func<int> getValue, Action<int> setValue, Func<string> name, Func<string> tooltip = null, int? min = null, int? max = null, int? interval = null, Func<int, string> formatValue = null, string fieldId = null);
        void AddNumberOption(IManifest mod, Func<float> getValue, Action<float> setValue, Func<string> name, Func<string> tooltip = null, float? min = null, float? max = null, float? interval = null, Func<float, string> formatValue = null, string fieldId = null);
        void AddTextOption(IManifest mod, Func<string> getValue, Action<string> setValue, Func<string> name, Func<string> tooltip = null, string[] allowedValues = null, Func<string, string> formatAllowedValue = null, string fieldId = null);
        void AddKeybind(IManifest mod, Func<SButton> getValue, Action<SButton> setValue, Func<string> name, Func<string> tooltip = null, string fieldId = null);
        void AddKeybindList(IManifest mod, Func<KeybindList> getValue, Action<KeybindList> setValue, Func<string> name, Func<string> tooltip = null, string fieldId = null);

        void AddPage(IManifest mod, string pageId, Func<string> pageTitle = null);
        void AddPageLink(IManifest mod, string pageId, Func<string> text, Func<string> tooltip = null);

        void AddComplexOption(IManifest mod, Func<string> name, Action<SpriteBatch, Vector2> draw, Func<string> tooltip = null, Action beforeMenuOpened = null, Action beforeSave = null, Action afterSave = null, Action beforeReset = null, Action afterReset = null, Action beforeMenuClosed = null, Func<int> height = null, string fieldId = null);
        void SetTitleScreenOnlyForNextOptions(IManifest mod, bool titleScreenOnly);
        void OnFieldChanged(IManifest mod, Action<string, object> onChange);
        void OpenModMenu(IManifest mod);
        void OpenModMenuAsChildMenu(IManifest mod);
        bool TryGetCurrentMenu(out IManifest mod, out string page);
        void Unregister(IManifest mod);
    }
}
