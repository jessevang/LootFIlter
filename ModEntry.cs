using HarmonyLib;

using Microsoft.Xna.Framework.Input;
using Spacechase.Shared.Patching;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;


namespace LootFilter
{

    public class ModConfig
    {
        public Keys KeyboardFilterOrUnfilterItem { get; set; } = Keys.X;
        public Keys KeyboardHotkeyToTurnOffLootFiltering { get; set; } = Keys.Z;
        public Buttons GamePadHotkeyToTurnOffLootFiltering { get; set; } = Buttons.RightStick;
        public Buttons GamePadFilterOrUnfilterItem { get; set; } = Buttons.LeftStick;
        public int distanceFilterItemMovesAwayFromPlayer { get; set; } = 8;
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
            

    
        }





        private void Input_ButtonPressed(object? sender, ButtonPressedEventArgs e)
        {
            // Toggle global loot filtering if the corresponding key is pressed.
            if (e.Button == Config.KeyboardHotkeyToTurnOffLootFiltering.ToSButton() ||
                e.Button == Config.GamePadHotkeyToTurnOffLootFiltering.ToSButton())
            {
                LootFilterOn = !LootFilterOn;
                string message = LootFilterOn ? "Loot Filter is turned on" : "Loot Filter is turned off";
                int type = LootFilterOn ? 4 : 3;
                Game1.addHUDMessage(new HUDMessage(message, type));
                return;
            }

            if (e.Button == Config.KeyboardFilterOrUnfilterItem.ToSButton() || e.Button == Config.GamePadFilterOrUnfilterItem.ToSButton())
            {
                if(Game1.activeClickableMenu != null)
                {

               
                    // Check if the player is currently holding an item in the cursor.
                    StardewValley.Object heldItem = Game1.player.CursorSlotItem as StardewValley.Object;

                    if (heldItem != null)
                    {
                        // Use the held item's ParentSheetIndex as a unique identifier.
                        string itemID = heldItem.ParentSheetIndex.ToString();
                        FilteredItem fi = Config.ObjectToFilter.Find(i => i.ItemId == itemID);

                        if (fi != null)
                        {
                            // Toggle the filter state.
                            fi.ShouldFilter = !fi.ShouldFilter;
                            if (fi.ShouldFilter)
                            {
                                Game1.addHUDMessage(new HUDMessage($"Item {heldItem.Name} filter set to {fi.ShouldFilter}", 4));
                            }
                            else
                            {
                                Game1.addHUDMessage(new HUDMessage($"Item {heldItem.Name} filter set to {fi.ShouldFilter}", 3));
                            }
                            
                        }
                        else
                        {
                            // If the item is not in our filter list, add it and mark it as filtered.
                            fi = new FilteredItem
                            {
                                ItemId = itemID,
                                Name = heldItem.Name,
                                ShouldFilter = true
                            };
                            Config.ObjectToFilter.Add(fi);
                            Game1.addHUDMessage(new HUDMessage($"New Item {heldItem.Name} added and marked for filtering", 4));
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



}





