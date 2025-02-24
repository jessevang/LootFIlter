using HarmonyLib;
using Spacechase.Shared.Patching;
using StardewModdingAPI;
using StardewValley;

namespace LootFilter
{
    public class Config
    {
        public bool Slime { get; set; } = false;
        public bool Sap { get; set; } = false;

    }

    internal sealed class ModEntry : Mod
    {
        public static ModEntry Instance { get; private set; }
        public Config Config { get; private set; }

        
        public override void Entry(IModHelper helper)
        {
            Instance = this; 
            Config = helper.ReadConfig<Config>() ?? new Config(); // Sample to call --> int somevalue = Instance.Config.Somevalues; 

            //Sample to Apply a Patch from patches folder. Used this if you want to use a replace an existing stardew valley function some other other code.
            HarmonyPatcher.Apply(this,
            new TryToAddItemPatch(Config, Instance)
            );


        }



    }
}