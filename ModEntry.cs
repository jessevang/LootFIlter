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
                configMenu.Unregister(this.ModManifest); // Removes my GMCM and reloads it so that updated loot filter list is updated in GMCM

            Config.CategoryFilters ??= new CategoryFiltersConfig();

            // register mod
            configMenu.Register(
                mod: this.ModManifest,
                reset: () =>
                {
                    this.Config = new ModConfig();
                    this.Config.CategoryFilters ??= new CategoryFiltersConfig();
                },
                save: () => this.Helper.WriteConfig(this.Config)
            );

            // MAIN PAGE
            configMenu.AddParagraph(
                ModManifest,
                text: () => "To add/remove item to loot Filter, Left Click the item in menu, and press the Filter item hotkey to Add to the filter list. You can repeat same step to unfilter items. If you accidently filter item and can't pick up item press the hotkey (default Z) to turn off loot filter, then follow the same steps here to remove a filter item."
            );

            configMenu.AddKeybindList(
                mod: ModManifest,
                name: () => "Add/Remove Item to filter list",
                tooltip: () => "When inventory menu is open and the player clicks on a item to hold the item then press this hotkey, the item is added to loot filter, or if item is already in the loot filter the item would instead be removed from the loot filter.",
                getValue: () => Config.KeyToAddOrRemoveFromLootFilter,
                setValue: value => Config.KeyToAddOrRemoveFromLootFilter = value
            );

            configMenu.AddKeybindList(
                mod: ModManifest,
                name: () => "Toggle Loot Filter On/Off",
                tooltip: () => "Pressing this hotkey will turn the loot filter on or off. Great when you accidently added an item to loot filter and can't pick up the item. Use this to turn off the loot filter then pick up the item.",
                getValue: () => Config.KeyToTurnOffOnLootFilter,
                setValue: value => Config.KeyToTurnOffOnLootFilter = value
            );

            configMenu.AddNumberOption(
                mod: ModManifest,
                getValue: () => Instance.Config.distanceFilterItemMovesAwayFromPlayer,
                setValue: value => Instance.Config.distanceFilterItemMovesAwayFromPlayer = (int)value,
                name: () => "#Tile Filtered distance",
                tooltip: () => "Number of Tile distance (default 8) that the Filter Item Moves Away From Player.",
                min: 5,
                max: 80,
                interval: 1
            );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.RemoveFilteredItemFromGame,
                setValue: value => Config.RemoveFilteredItemFromGame = value,
                name: () => "Remove Filtered Items from Game",
                tooltip: () => "If true, filtered items will be deleted instead of dropped nearby."
            );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.DeveloperMode,
                setValue: value => Config.DeveloperMode = value,
                name: () => "Enable Developer Mode",
                tooltip: () => "Turns on extra debug logging that appears in console."
            );

            // Link to CATEGORY FILTERS page
            configMenu.AddPageLink(
                mod: this.ModManifest,
                pageId: "category_filters",
                text: () => "Category-based filters (override item list)",
                tooltip: () => "Toggle broad categories like weapons, tools, artifacts, etc. These apply before the per-item loot filter list."
            );

            // Link to alphabetized version
            configMenu.AddPageLink(
                mod: this.ModManifest,
                pageId: "loot_filter_list_sorted",
                text: () => "View/Edit Loot Filtered Items sorted alphabetically",
                tooltip: () => "Toggle filtered items, listed alphabetically."
            );

            // PAGE: loot_filter_list_sorted (existing behavior)
            configMenu.AddPage(
                mod: this.ModManifest,
                pageId: "loot_filter_list_sorted",
                pageTitle: () => "List Loot Filter Items Alphabetically"
            );

            configMenu.SetTitleScreenOnlyForNextOptions(this.ModManifest, false);
            configMenu.AddSectionTitle(this.ModManifest, () => "List Loot Filter Items Alphabetically");
            configMenu.AddParagraph(this.ModManifest, () => "Items below are sorted alphabetically. Toggle to include or exclude them from auto-pickup.");

            foreach (var filteredItem in Config.ObjectToFilter.OrderBy(f => f.Name, StringComparer.OrdinalIgnoreCase))
            {
                var localItem = filteredItem;

                configMenu.AddBoolOption(
                    mod: this.ModManifest,
                    getValue: () => localItem.ShouldFilter,
                    setValue: value => localItem.ShouldFilter = value,
                    name: () => $"{localItem.Name}: ({localItem.ItemId})",
                    tooltip: () => "Toggle whether this item should be filtered when picked up."
                );
            }

            // PAGE: category_filters (new)
            configMenu.AddPage(
                mod: this.ModManifest,
                pageId: "category_filters",
                pageTitle: () => "Category Filters"
            );

            configMenu.SetTitleScreenOnlyForNextOptions(this.ModManifest, false);

            // Top note
            configMenu.AddSectionTitle(
                this.ModManifest,
                text: () => "Category-based Filters",
                tooltip: () => "These options apply broad filters by item type or category. If enabled, they override the per-item loot filter list."
            );

            configMenu.AddParagraph(
                this.ModManifest,
                () => "If a category or subcategory is enabled here, any item that matches it will be treated as filtered even if it is not in the per-item loot filter list. This runs BEFORE item-specific filters."
            );

            // MAIN CATEGORIES
            configMenu.AddSectionTitle(this.ModManifest, () => "Main Categories");
            configMenu.AddParagraph(this.ModManifest, () => "These apply to broad item types based on QualifiedItemId or item class.");

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.CategoryFilters.Weapons,
                setValue: value => Config.CategoryFilters.Weapons = value,
                name: () => "Weapons",
                tooltip: () => "Filter all melee weapons (swords, daggers, clubs, etc.)."
            );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.CategoryFilters.Tools,
                setValue: value => Config.CategoryFilters.Tools = value,
                name: () => "Tools",
                tooltip: () => "Filter all tools (axes, pickaxes, hoes, watering cans, fishing rods, etc.)."
            );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.CategoryFilters.Boots,
                setValue: value => Config.CategoryFilters.Boots = value,
                name: () => "Boots",
                tooltip: () => "Filter all boots and footwear."
            );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.CategoryFilters.Hats,
                setValue: value => Config.CategoryFilters.Hats = value,
                name: () => "Hats",
                tooltip: () => "Filter all hats."
            );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.CategoryFilters.Shirts,
                setValue: value => Config.CategoryFilters.Shirts = value,
                name: () => "Shirts",
                tooltip: () => "Filter all shirts."
            );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.CategoryFilters.Pants,
                setValue: value => Config.CategoryFilters.Pants = value,
                name: () => "Pants",
                tooltip: () => "Filter all pants."
            );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.CategoryFilters.Rings,
                setValue: value => Config.CategoryFilters.Rings = value,
                name: () => "Rings",
                tooltip: () => "Filter all rings."
            );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.CategoryFilters.Objects,
                setValue: value => Config.CategoryFilters.Objects = value,
                name: () => "Objects",
                tooltip: () => "Filter all regular object items (QualifiedItemId starting with (O))."
            );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.CategoryFilters.Artifacts,
                setValue: value => Config.CategoryFilters.Artifacts = value,
                name: () => "Artifacts",
                tooltip: () => "Filter all artifacts."
            );

            // SUBCATEGORIES
            configMenu.AddSectionTitle(this.ModManifest, () => "Subcategories");
            configMenu.AddParagraph(this.ModManifest, () => "These use the game's object categories (like Fish, Milk, Monster Loot, etc.) to filter more specific groups.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Fish, v => Config.CategoryFilters.Fish = v,
                name: () => "Fish", tooltip: () => "Filter all items in the Fish category.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Eggs, v => Config.CategoryFilters.Eggs = v,
                name: () => "Eggs", tooltip: () => "Filter all items in the Egg category.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Milk, v => Config.CategoryFilters.Milk = v,
                name: () => "Milk", tooltip: () => "Filter all items in the Milk category.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Food, v => Config.CategoryFilters.Food = v,
                name: () => "Food (Cooking)", tooltip: () => "Filter all cooked food items (Cooking category).");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.CraftingMaterials, v => Config.CategoryFilters.CraftingMaterials = v,
                name: () => "Crafting Materials", tooltip: () => "Filter all items in the Crafting category.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.BigCraftables, v => Config.CategoryFilters.BigCraftables = v,
                name: () => "Big Craftables", tooltip: () => "Filter items that are big craftables.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Minerals, v => Config.CategoryFilters.Minerals = v,
                name: () => "Minerals", tooltip: () => "Filter all items in the Minerals category.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Meat, v => Config.CategoryFilters.Meat = v,
                name: () => "Meat", tooltip: () => "Filter all items in the Meat category.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.MetalResources, v => Config.CategoryFilters.MetalResources = v,
                name: () => "Metal Resources", tooltip: () => "Filter all items in the Metal Resources category.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.BuildingResources, v => Config.CategoryFilters.BuildingResources = v,
                name: () => "Building Resources", tooltip: () => "Filter all items in the Building Resources category.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.PierreShopItems, v => Config.CategoryFilters.PierreShopItems = v,
                name: () => "Pierre Shop Items", tooltip: () => "Filter items marked as sold at Pierre's.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.GusShopItems, v => Config.CategoryFilters.GusShopItems = v,
                name: () => "Gus Shop Items", tooltip: () => "Filter items marked as sold at Gus's.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Fertilizer, v => Config.CategoryFilters.Fertilizer = v,
                name: () => "Fertilizer", tooltip: () => "Filter all fertilizers.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Junk, v => Config.CategoryFilters.Junk = v,
                name: () => "Junk / Trash", tooltip: () => "Filter junk or trash-category items.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Bait, v => Config.CategoryFilters.Bait = v,
                name: () => "Bait", tooltip: () => "Filter all bait items.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Tackle, v => Config.CategoryFilters.Tackle = v,
                name: () => "Tackle", tooltip: () => "Filter all tackle items.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Ingredients, v => Config.CategoryFilters.Ingredients = v,
                name: () => "Ingredients", tooltip: () => "Filter all items in the Ingredients category.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.ArtisanGoods, v => Config.CategoryFilters.ArtisanGoods = v,
                name: () => "Artisan Goods", tooltip: () => "Filter all items in the Artisan Goods category.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Syrups, v => Config.CategoryFilters.Syrups = v,
                name: () => "Syrups", tooltip: () => "Filter all items in the Syrups category.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.MonsterLoot, v => Config.CategoryFilters.MonsterLoot = v,
                name: () => "Monster Loot", tooltip: () => "Filter all items in the Monster Loot category.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Seeds, v => Config.CategoryFilters.Seeds = v,
                name: () => "Seeds", tooltip: () => "Filter all seeds.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Vegetables, v => Config.CategoryFilters.Vegetables = v,
                name: () => "Vegetables", tooltip: () => "Filter all vegetables.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Fruit, v => Config.CategoryFilters.Fruit = v,
                name: () => "Fruit", tooltip: () => "Filter all fruits.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Flowers, v => Config.CategoryFilters.Flowers = v,
                name: () => "Flowers", tooltip: () => "Filter all flowers.");

            configMenu.AddBoolOption(this.ModManifest, () => Config.CategoryFilters.Forage, v => Config.CategoryFilters.Forage = v,
                name: () => "Forage", tooltip: () => "Filter all foraged items.");
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
