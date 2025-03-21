﻿
using HarmonyLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spacechase.Shared.Patching;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Objects;


namespace LootFilter
{

    public class ModConfig
    {
        public Keys KeyboardToggleFilterThisItem { get; set; } = Keys.X;
        public Keys KeyboardTurnOffLootFiltering { get; set; } = Keys.Z;
        public Buttons GamepadToggleFilterThisItem { get; set; } = Buttons.RightStick;
        public Buttons GamepadTurnOffLootFiltering { get; set; } = Buttons.LeftStick;
        public int distanceFilterItemMovesAwayFromPlayer { get; set; } = 8;
        public bool RemoveFilteredItemFromGame { get; set; } = false;
        public String note002 { get; set; } = "Set ShouldFilter field to True to filter Items. After filter is appied a restart is required.";
        public List<FilteredItem> ObjectToFilter { get; set; } = new List<FilteredItem>
        {

        };

    }

    public class FilteredItem
    {
        public bool ShouldFilter { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
    }

    internal sealed class ModEntry : Mod
    {
        public static IMonitor ModMonitor;
        public bool FilterMenuOpen { set; get; } = false;
        public static ModEntry Instance { get; private set; }
        public ModConfig Config { get; private set; }
        public bool LootFilterOn = true;
        //public IGenericModConfigMenuApi configMenu;
        private Harmony _harmony;
        public override void Entry(IModHelper helper)
        {

            _harmony = new Harmony(ModManifest.UniqueID);
            Instance = this;
            Config = helper.ReadConfig<ModConfig>() ?? new ModConfig();

            ModMonitor = Monitor;

            HarmonyPatcher.Apply(this,
             new addItemToInventoryBoolPatch(Config, Instance)
             );


            helper.Events.Input.ButtonPressed += Input_ButtonPressed;
            helper.Events.GameLoop.GameLaunched += GameLoop_GameLaunched;


        }

        private void GameLoop_GameLaunched(object? sender, GameLaunchedEventArgs e)
        {

            // get Generic Mod Config Menu's API (if it's installed)
            var configMenu = this.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (configMenu is null)
                return;



            // register mod
            configMenu.Register(
                mod: this.ModManifest,
                reset: () => this.Config = new ModConfig(),
                save: () => this.Helper.WriteConfig(this.Config)
            );

            configMenu.AddParagraph(
                ModManifest,
                text: () => "To Filter an item, Left Click the item in menu, and press the Filter item hotkey (default X) to Add to the filter list. You can repeat same step to unfilter items. If you accidently filter item and can't pick up item  press the hotkey (default Z) to turn off loot filter"

            );

            configMenu.AddKeybind(
                ModManifest,
                name: () => "Key: Filter Item",
                tooltip: () => "Left Click item in Menu, Press this key to filter/unfilter Item",
                getValue: () => Config.KeyboardToggleFilterThisItem.ToSButton(),
                setValue: value => Config.KeyboardToggleFilterThisItem = (Keys)value
            );

            configMenu.AddKeybind(
                ModManifest,
                name: () => "Key: Loot Filter On/Off",
                tooltip: () => "Press this key to turn on/off all loot filtering",
                getValue: () => Config.KeyboardTurnOffLootFiltering.ToSButton(),
                setValue: value => Config.KeyboardTurnOffLootFiltering = (Keys)value
            );

            configMenu.AddKeybind(
                ModManifest,
                name: () => "Pad: Filter Item",
                tooltip: () => "Left Click item in Menu, Press this gamepad button to filter/unfilter Item",
                getValue: () => Config.GamepadToggleFilterThisItem.ToSButton(),
                setValue: value => Config.GamepadToggleFilterThisItem = (Buttons)value
            );

            configMenu.AddKeybind(
                ModManifest,
                name: () => "Pad: Loot Filter On/Off",
                tooltip: () => "Press this gamepad button to turn on/off all loot filtering",
                getValue: () => Config.GamepadTurnOffLootFiltering.ToSButton(),
                setValue: value => Config.GamepadTurnOffLootFiltering = (Buttons)value
            );

            configMenu.AddNumberOption(
                mod: ModManifest,
                getValue: () => Instance.Config.distanceFilterItemMovesAwayFromPlayer,
                setValue: value => Instance.Config.distanceFilterItemMovesAwayFromPlayer = (int)value,
                name: () => "#Tile Filtered distance",
                tooltip: () => "Number of Tile distance (default 8) that the Filter Item Moves Away From Player",
                min: 5,
                max: 40,
                interval: 1

            );

            configMenu.AddBoolOption( 
                mod: ModManifest, 
                getValue: () => Config.RemoveFilteredItemFromGame, 
                setValue: value => Config.RemoveFilteredItemFromGame = value, 
                name: () => "RemoveFilteredItemFromGame",
                tooltip: () => "Turning this option on will remove item from game, otherwise if it's off item will spawn away from character"
            );



        }

        private void Input_ButtonPressed(object? sender, ButtonPressedEventArgs e)
        {
            // Toggle global loot filtering if the corresponding key is pressed.
            if (e.Button == Config.KeyboardTurnOffLootFiltering.ToSButton() ||
                e.Button == Config.GamepadTurnOffLootFiltering.ToSButton())
            {
                LootFilterOn = !LootFilterOn;
                string message = LootFilterOn ? "Loot Filter is turned on" : "Loot Filter is turned off";
                int type = LootFilterOn ? 4 : 3;

                Game1.addHUDMessage(new HUDMessage(message, type));
                return;
            }

            if (e.Button == Config.KeyboardToggleFilterThisItem.ToSButton() || e.Button == Config.GamepadToggleFilterThisItem.ToSButton())
            {
                if (Game1.activeClickableMenu != null)
                {


                    // Check if the player is currently holding an item in the cursor.
                    StardewValley.Item itemHeld = Game1.player.CursorSlotItem as StardewValley.Item;

                    //StardewValley.Object heldItem = Game1.player.CursorSlotItem as StardewValley.Object;

                    if (itemHeld != null)
                    {

                        // Use the held item's ParentSheetIndex as a unique identifier.
                        string itemID = itemHeld.GetItemTypeId() + itemHeld.ItemId;

                        //Console.WriteLine("itemID: " + itemID );


                        // string itemID = itemHeld.ParentSheetIndex.ToString();
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
                    }
                    else
                    {
                        Game1.addHUDMessage(new HUDMessage("No held item found.", 3));
                    }
                }
            }



        }


    }


    /// <summary>The API which lets other mods add a config UI through Generic Mod Config Menu.</summary>
    public interface IGenericModConfigMenuApi
    {
        /*********
        ** Methods
        *********/
        /****
        ** Must be called first
        ****/
        /// <summary>Register a mod whose config can be edited through the UI.</summary>
        /// <param name="mod">The mod's manifest.</param>
        /// <param name="reset">Reset the mod's config to its default values.</param>
        /// <param name="save">Save the mod's current config to the <c>config.json</c> file.</param>
        /// <param name="titleScreenOnly">Whether the options can only be edited from the title screen.</param>
        /// <remarks>Each mod can only be registered once, unless it's deleted via <see cref="Unregister"/> before calling this again.</remarks>
        void Register(IManifest mod, Action reset, Action save, bool titleScreenOnly = false);


        /****
        ** Basic options
        ****/
        /// <summary>Add a section title at the current position in the form.</summary>
        /// <param name="mod">The mod's manifest.</param>
        /// <param name="text">The title text shown in the form.</param>
        /// <param name="tooltip">The tooltip text shown when the cursor hovers on the title, or <c>null</c> to disable the tooltip.</param>
        void AddSectionTitle(IManifest mod, Func<string> text, Func<string> tooltip = null);

        /// <summary>Add a paragraph of text at the current position in the form.</summary>
        /// <param name="mod">The mod's manifest.</param>
        /// <param name="text">The paragraph text to display.</param>
        void AddParagraph(IManifest mod, Func<string> text);

        /// <summary>Add an image at the current position in the form.</summary>
        /// <param name="mod">The mod's manifest.</param>
        /// <param name="texture">The image texture to display.</param>
        /// <param name="texturePixelArea">The pixel area within the texture to display, or <c>null</c> to show the entire image.</param>
        /// <param name="scale">The zoom factor to apply to the image.</param>
        void AddImage(IManifest mod, Func<Texture2D> texture, Rectangle? texturePixelArea = null, int scale = Game1.pixelZoom);

        /// <summary>Add a boolean option at the current position in the form.</summary>
        /// <param name="mod">The mod's manifest.</param>
        /// <param name="getValue">Get the current value from the mod config.</param>
        /// <param name="setValue">Set a new value in the mod config.</param>
        /// <param name="name">The label text to show in the form.</param>
        /// <param name="tooltip">The tooltip text shown when the cursor hovers on the field, or <c>null</c> to disable the tooltip.</param>
        /// <param name="fieldId">The unique field ID for use with <see cref="OnFieldChanged"/>, or <c>null</c> to auto-generate a randomized ID.</param>
        void AddBoolOption(IManifest mod, Func<bool> getValue, Action<bool> setValue, Func<string> name, Func<string> tooltip = null, string fieldId = null);

        /// <summary>Add an integer option at the current position in the form.</summary>
        /// <param name="mod">The mod's manifest.</param>
        /// <param name="getValue">Get the current value from the mod config.</param>
        /// <param name="setValue">Set a new value in the mod config.</param>
        /// <param name="name">The label text to show in the form.</param>
        /// <param name="tooltip">The tooltip text shown when the cursor hovers on the field, or <c>null</c> to disable the tooltip.</param>
        /// <param name="min">The minimum allowed value, or <c>null</c> to allow any.</param>
        /// <param name="max">The maximum allowed value, or <c>null</c> to allow any.</param>
        /// <param name="interval">The interval of values that can be selected.</param>
        /// <param name="formatValue">Get the display text to show for a value, or <c>null</c> to show the number as-is.</param>
        /// <param name="fieldId">The unique field ID for use with <see cref="OnFieldChanged"/>, or <c>null</c> to auto-generate a randomized ID.</param>
        void AddNumberOption(IManifest mod, Func<int> getValue, Action<int> setValue, Func<string> name, Func<string> tooltip = null, int? min = null, int? max = null, int? interval = null, Func<int, string> formatValue = null, string fieldId = null);

        /// <summary>Add a float option at the current position in the form.</summary>
        /// <param name="mod">The mod's manifest.</param>
        /// <param name="getValue">Get the current value from the mod config.</param>
        /// <param name="setValue">Set a new value in the mod config.</param>
        /// <param name="name">The label text to show in the form.</param>
        /// <param name="tooltip">The tooltip text shown when the cursor hovers on the field, or <c>null</c> to disable the tooltip.</param>
        /// <param name="min">The minimum allowed value, or <c>null</c> to allow any.</param>
        /// <param name="max">The maximum allowed value, or <c>null</c> to allow any.</param>
        /// <param name="interval">The interval of values that can be selected.</param>
        /// <param name="formatValue">Get the display text to show for a value, or <c>null</c> to show the number as-is.</param>
        /// <param name="fieldId">The unique field ID for use with <see cref="OnFieldChanged"/>, or <c>null</c> to auto-generate a randomized ID.</param>
        void AddNumberOption(IManifest mod, Func<float> getValue, Action<float> setValue, Func<string> name, Func<string> tooltip = null, float? min = null, float? max = null, float? interval = null, Func<float, string> formatValue = null, string fieldId = null);

        /// <summary>Add a string option at the current position in the form.</summary>
        /// <param name="mod">The mod's manifest.</param>
        /// <param name="getValue">Get the current value from the mod config.</param>
        /// <param name="setValue">Set a new value in the mod config.</param>
        /// <param name="name">The label text to show in the form.</param>
        /// <param name="tooltip">The tooltip text shown when the cursor hovers on the field, or <c>null</c> to disable the tooltip.</param>
        /// <param name="allowedValues">The values that can be selected, or <c>null</c> to allow any.</param>
        /// <param name="formatAllowedValue">Get the display text to show for a value from <paramref name="allowedValues"/>, or <c>null</c> to show the values as-is.</param>
        /// <param name="fieldId">The unique field ID for use with <see cref="OnFieldChanged"/>, or <c>null</c> to auto-generate a randomized ID.</param>
        void AddTextOption(IManifest mod, Func<string> getValue, Action<string> setValue, Func<string> name, Func<string> tooltip = null, string[] allowedValues = null, Func<string, string> formatAllowedValue = null, string fieldId = null);

        /// <summary>Add a key binding at the current position in the form.</summary>
        /// <param name="mod">The mod's manifest.</param>
        /// <param name="getValue">Get the current value from the mod config.</param>
        /// <param name="setValue">Set a new value in the mod config.</param>
        /// <param name="name">The label text to show in the form.</param>
        /// <param name="tooltip">The tooltip text shown when the cursor hovers on the field, or <c>null</c> to disable the tooltip.</param>
        /// <param name="fieldId">The unique field ID for use with <see cref="OnFieldChanged"/>, or <c>null</c> to auto-generate a randomized ID.</param>
        void AddKeybind(IManifest mod, Func<SButton> getValue, Action<SButton> setValue, Func<string> name, Func<string> tooltip = null, string fieldId = null);

        /// <summary>Add a key binding list at the current position in the form.</summary>
        /// <param name="mod">The mod's manifest.</param>
        /// <param name="getValue">Get the current value from the mod config.</param>
        /// <param name="setValue">Set a new value in the mod config.</param>
        /// <param name="name">The label text to show in the form.</param>
        /// <param name="tooltip">The tooltip text shown when the cursor hovers on the field, or <c>null</c> to disable the tooltip.</param>
        /// <param name="fieldId">The unique field ID for use with <see cref="OnFieldChanged"/>, or <c>null</c> to auto-generate a randomized ID.</param>
        void AddKeybindList(IManifest mod, Func<KeybindList> getValue, Action<KeybindList> setValue, Func<string> name, Func<string> tooltip = null, string fieldId = null);


        /****
        ** Multi-page management
        ****/
        /// <summary>Start a new page in the mod's config UI, or switch to that page if it already exists. All options registered after this will be part of that page.</summary>
        /// <param name="mod">The mod's manifest.</param>
        /// <param name="pageId">The unique page ID.</param>
        /// <param name="pageTitle">The page title shown in its UI, or <c>null</c> to show the <paramref name="pageId"/> value.</param>
        /// <remarks>You must also call <see cref="AddPageLink"/> to make the page accessible. This is only needed to set up a multi-page config UI. If you don't call this method, all options will be part of the mod's main config UI instead.</remarks>
        void AddPage(IManifest mod, string pageId, Func<string> pageTitle = null);

        /// <summary>Add a link to a page added via <see cref="AddPage"/> at the current position in the form.</summary>
        /// <param name="mod">The mod's manifest.</param>
        /// <param name="pageId">The unique ID of the page to open when the link is clicked.</param>
        /// <param name="text">The link text shown in the form.</param>
        /// <param name="tooltip">The tooltip text shown when the cursor hovers on the link, or <c>null</c> to disable the tooltip.</param>
        void AddPageLink(IManifest mod, string pageId, Func<string> text, Func<string> tooltip = null);


        /****
        ** Advanced
        ****/
        /// <summary>Add an option at the current position in the form using custom rendering logic.</summary>
        /// <param name="mod">The mod's manifest.</param>
        /// <param name="name">The label text to show in the form.</param>
        /// <param name="draw">Draw the option in the config UI. This is called with the sprite batch being rendered and the pixel position at which to start drawing.</param>
        /// <param name="tooltip">The tooltip text shown when the cursor hovers on the field, or <c>null</c> to disable the tooltip.</param>
        /// <param name="beforeMenuOpened">A callback raised just before the menu containing this option is opened.</param>
        /// <param name="beforeSave">A callback raised before the form's current values are saved to the config (i.e. before the <c>save</c> callback passed to <see cref="Register"/>).</param>
        /// <param name="afterSave">A callback raised after the form's current values are saved to the config (i.e. after the <c>save</c> callback passed to <see cref="Register"/>).</param>
        /// <param name="beforeReset">A callback raised before the form is reset to its default values (i.e. before the <c>reset</c> callback passed to <see cref="Register"/>).</param>
        /// <param name="afterReset">A callback raised after the form is reset to its default values (i.e. after the <c>reset</c> callback passed to <see cref="Register"/>).</param>
        /// <param name="beforeMenuClosed">A callback raised just before the menu containing this option is closed.</param>
        /// <param name="height">The pixel height to allocate for the option in the form, or <c>null</c> for a standard input-sized option. This is called and cached each time the form is opened.</param>
        /// <param name="fieldId">The unique field ID for use with <see cref="OnFieldChanged"/>, or <c>null</c> to auto-generate a randomized ID.</param>
        /// <remarks>The custom logic represented by the callback parameters is responsible for managing its own state if needed. For example, you can store state in a static field or use closures to use a state variable.</remarks>
        void AddComplexOption(IManifest mod, Func<string> name, Action<SpriteBatch, Vector2> draw, Func<string> tooltip = null, Action beforeMenuOpened = null, Action beforeSave = null, Action afterSave = null, Action beforeReset = null, Action afterReset = null, Action beforeMenuClosed = null, Func<int> height = null, string fieldId = null);

        /// <summary>Set whether the options registered after this point can only be edited from the title screen.</summary>
        /// <param name="mod">The mod's manifest.</param>
        /// <param name="titleScreenOnly">Whether the options can only be edited from the title screen.</param>
        /// <remarks>This lets you have different values per-field. Most mods should just set it once in <see cref="Register"/>.</remarks>
        void SetTitleScreenOnlyForNextOptions(IManifest mod, bool titleScreenOnly);

        /// <summary>Register a method to notify when any option registered by this mod is edited through the config UI.</summary>
        /// <param name="mod">The mod's manifest.</param>
        /// <param name="onChange">The method to call with the option's unique field ID and new value.</param>
        /// <remarks>Options use a randomized ID by default; you'll likely want to specify the <c>fieldId</c> argument when adding options if you use this.</remarks>
        void OnFieldChanged(IManifest mod, Action<string, object> onChange);

        /// <summary>Open the config UI for a specific mod.</summary>
        /// <param name="mod">The mod's manifest.</param>
        void OpenModMenu(IManifest mod);

        /// <summary>Open the config UI for a specific mod, as a child menu if there is an existing menu.</summary>
        /// <param name="mod">The mod's manifest.</param>
        void OpenModMenuAsChildMenu(IManifest mod);

        /// <summary>Get the currently-displayed mod config menu, if any.</summary>
        /// <param name="mod">The manifest of the mod whose config menu is being shown, or <c>null</c> if not applicable.</param>
        /// <param name="page">The page ID being shown for the current config menu, or <c>null</c> if not applicable. This may be <c>null</c> even if a mod config menu is shown (e.g. because the mod doesn't have pages).</param>
        /// <returns>Returns whether a mod config menu is being shown.</returns>
        bool TryGetCurrentMenu(out IManifest mod, out string page);

        /// <summary>Remove a mod from the config UI and delete all its options and pages.</summary>
        /// <param name="mod">The mod's manifest.</param>
        void Unregister(IManifest mod);
    }






}





