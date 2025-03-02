using HarmonyLib;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spacechase.Shared.Patching;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.BellsAndWhistles;
using StardewValley.Objects;
using StardewValley.Quests;
using System.Net;

namespace LootFilter
{

    public class ModConfig
    {
        public Keys KeyboardHotkeyToTurnOffLootFiltering { get; set; } = Keys.Z;
        public Buttons GamePadHotkeyToTurnOffLootFiltering { get; set; } = Buttons.LeftStick;
        public int distanceFilterItemMovesAwayFromPlayer { get; set; } = 8;
        public String note002 { get; set; } = "Set ShouldFilter field to True to filter Items. After filter is appied a restart is required.";
        public List<FilteredItem> ObjectToFilter { get; set; } = new List<FilteredItem>
        {
            new FilteredItem { ShouldFilter = false, ItemId ="930" , Name = "???", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)92" , Name = "???", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)162" , Name = "??Foroguemon??", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)155" , Name = "??HMTGF??", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)161" , Name = "??Pinky Lemon??", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1136" , Name = "80's Shirt (F)", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1152" , Name = "80's Shirt (M)", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)40" , Name = "Abby's Planchette", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)AbigailsBow" , Name = "Abigail's Bow", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="309" , Name = "Acorn", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="867" , Name = "Advanced TV Remote", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="541" , Name = "Aerinite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="447" , Name = "Aged Roe", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="538" , Name = "Alamite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="705" , Name = "Albacore", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)25" , Name = "Alex's Bat", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="456" , Name = "Algae Soup", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="300" , Name = "Amaranth", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="299" , Name = "Amaranth Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="66" , Name = "Amethyst", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="529" , Name = "Amethyst Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="587" , Name = "Amphibian Fossil", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="117" , Name = "Anchor", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="129" , Name = "Anchovy", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="103" , Name = "Ancient Doll", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="123" , Name = "Ancient Drum", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="454" , Name = "Ancient Fruit", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="114" , Name = "Ancient Seed", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="499" , Name = "Ancient Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)67" , Name = "Ancient Stool", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="109" , Name = "Ancient Sword", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)66" , Name = "Ancient Table", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="160" , Name = "Angler", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_AnimalCatalogue" , Name = "Animal Catalogue", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1227" , Name = "Antiquity Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)Anvil" , Name = "Anvil", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="613" , Name = "Apple", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="633" , Name = "Apple Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="634" , Name = "Apricot", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="629" , Name = "Apricot Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="62" , Name = "Aquamarine", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="531" , Name = "Aquamarine Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1009" , Name = "Aquamarine Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)60" , Name = "Arcane Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1215" , Name = "Arcane Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)35" , Name = "Archer's Cap", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="868" , Name = "Arctic Shard", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="101" , Name = "Arrowhead", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="274" , Name = "Artichoke", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="605" , Name = "Artichoke Dip", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="489" , Name = "Artichoke Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="590" , Name = "Artifact Spot", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="275" , Name = "Artifact Trove", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)165" , Name = "Auto-Grabber", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)272" , Name = "Auto-Petter", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="235" , Name = "Autumn's Bounty", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1196" , Name = "Backpack Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)10" , Name = "Baggy Pants", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="685" , Name = "Bait", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="SpecificBait" , Name = "Bait", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="SkillBook_1" , Name = "Bait And Bobber", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)BaitMaker" , Name = "Bait Maker", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="198" , Name = "Baked Fish", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="91" , Name = "Banana", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="904" , Name = "Banana Pudding", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="69" , Name = "Banana Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1293" , Name = "Banana Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1195" , Name = "Bandana Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1203" , Name = "Bandana Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1206" , Name = "Bandana Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="691" , Name = "Barbed Hook", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)118" , Name = "Barrel", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)120" , Name = "Barrel", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)122" , Name = "Barrel", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)124" , Name = "Barrel", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)174" , Name = "Barrel", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)262" , Name = "Barrel", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)150" , Name = "Barrel Brazier", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="540" , Name = "Baryte", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="570" , Name = "Basalt", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="368" , Name = "Basic Fertilizer", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)35" , Name = "Basic Log", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1177" , Name = "Basic Pullover (F)", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1176" , Name = "Basic Pullover (M)", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)SoftEdgePullover" , Name = "Basic Pullover (M)", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="370" , Name = "Basic Retaining Soil", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)BasiliskPaw" , Name = "Basilisk Paw", Category = "Trinket"},
            new FilteredItem { ShouldFilter = false, ItemId ="767" , Name = "Bat Wing", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="787" , Name = "Battery Pack", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="207" , Name = "Bean Hotpot", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="473" , Name = "Bean Starter", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)53" , Name = "Beanie", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)10" , Name = "Bee House", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="346" , Name = "Beer", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="284" , Name = "Beet", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="494" , Name = "Beet Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1221" , Name = "Belted Coat", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="790" , Name = "Berry Basket", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)BigChest" , Name = "Big Chest", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)40" , Name = "Big Green Cane", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)44" , Name = "Big Red Cane", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)BigStoneChest" , Name = "Big Stone Chest", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1134" , Name = "Bikini Top", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="539" , Name = "Bixite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1138" , Name = "Black Leather Jacket", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="410" , Name = "Blackberry", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="611" , Name = "Blackberry Cobbler", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1172" , Name = "Blacksmith Apron", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="800" , Name = "Blobfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)56" , Name = "Blobfish Mask", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)6" , Name = "Blue Bonnet", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)BlueBow" , Name = "Blue Bow", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1278" , Name = "Blue Buttoned Vest", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)37" , Name = "Blue Cowboy Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="838" , Name = "Blue Discus", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="BlueGrassStarter" , Name = "Blue Grass Starter", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1161" , Name = "Blue Hoodie", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="597" , Name = "Blue Jazz", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1242" , Name = "Blue Long Vest", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)BlueRibbon" , Name = "Blue Ribbon", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="413" , Name = "Blue Slime Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="258" , Name = "Blueberry", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="481" , Name = "Blueberry Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="234" , Name = "Blueberry Tart", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)80" , Name = "Bluebird Mask", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1245" , Name = "Bobo Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="278" , Name = "Bok Choy", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="491" , Name = "Bok Choy Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="287" , Name = "Bomb", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1155" , Name = "Bomber Jacket", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="119" , Name = "Bone Flute", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="881" , Name = "Bone Fragment", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)90" , Name = "Bone Mill", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)5" , Name = "Bone Sword", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)74" , Name = "Bonfire", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)75" , Name = "Bongo", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Mystery" , Name = "Book of Mysteries", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="PurpleBook" , Name = "Book Of Stars", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Artifact" , Name = "Book_Artifact", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Grass" , Name = "Book_Grass", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Horse" , Name = "Book_Horse", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)64" , Name = "Bookcase", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)78" , Name = "Boulder", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="458" , Name = "Bouquet", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)1" , Name = "Bowler Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="216" , Name = "Bread", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="132" , Name = "Bream", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="293" , Name = "Brick Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1265" , Name = "Bridal Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)69" , Name = "Bridal Veil", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="Broccoli" , Name = "Broccoli", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="BroccoliSeeds" , Name = "Broccoli Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="171" , Name = "Broken CD", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="170" , Name = "Broken Glasses", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)51" , Name = "Broken Trident", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1018" , Name = "Brown Jacket", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1266" , Name = "Brown Overalls", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1237" , Name = "Brown Suit", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="618" , Name = "Bruschetta", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)BucketHat" , Name = "Bucket Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="684" , Name = "Bug Meat", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="874" , Name = "Bug Steak", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="700" , Name = "Bullhead", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1247" , Name = "Burger Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="526" , Name = "Burglar's Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)18" , Name = "Burglar's Shank", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)14" , Name = "Butterfly Bow", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="ButterflyPowder" , Name = "Butterfly Powder", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1140" , Name = "Button Down Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="90" , Name = "Cactus Fruit", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="802" , Name = "Cactus Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="542" , Name = "Calcite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="CalicoEgg" , Name = "Calico Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)106" , Name = "Camera", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1274" , Name = "Camo Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)146" , Name = "Campfire", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)278" , Name = "Campfire", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="927" , Name = "Camping Stove", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1231" , Name = "Canvas Jacket", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1239" , Name = "Captain's Uniform", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1218" , Name = "Cardigan", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="142" , Name = "Carp", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1250" , Name = "Carp Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="209" , Name = "Carp Surprise", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="Carrot" , Name = "Carrot", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="CarrotSeeds" , Name = "Carrot Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)148" , Name = "Carved Brazier", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)16" , Name = "Carving Knife", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)163" , Name = "Cask", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)32" , Name = "Cat Ears", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="143" , Name = "Catfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="190" , Name = "Cauliflower", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="474" , Name = "Cauliflower Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="78" , Name = "Cave Carrot", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="CaveJelly" , Name = "Cave Jelly", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1156" , Name = "Caveman Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="445" , Name = "Caviar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="566" , Name = "Celestine", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="ChallengeBait" , Name = "Challenge Bait", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="281" , Name = "Chanterelle", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)114" , Name = "Charcoal Kiln", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="424" , Name = "Cheese", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="197" , Name = "Cheese Cauliflower", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)16" , Name = "Cheese Press", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1213" , Name = "Chef Coat", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)61" , Name = "Chef Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="638" , Name = "Cherry", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="286" , Name = "Cherry Bomb", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="628" , Name = "Cherry Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)130" , Name = "Chest", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="105" , Name = "Chewing Stick", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)10" , Name = "Chicken Mask", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="113" , Name = "Chicken Statue", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)31" , Name = "Chicken Statue", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="100" , Name = "Chipped Amphora", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="220" , Name = "Chocolate Cake", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="727" , Name = "Chowder", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="702" , Name = "Chub", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="848" , Name = "Cinder Shard", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)853" , Name = "Cinderclown Shoes", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1234" , Name = "Circuitboard Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="372" , Name = "Clam", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1000" , Name = "Classic Overalls", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1202" , Name = "Classy Top (F)", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1201" , Name = "Classy Top (M)", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="330" , Name = "Clay", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)10" , Name = "Claymore", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="428" , Name = "Cloth", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="382" , Name = "Coal", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="411" , Name = "Cobblestone Path", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="718" , Name = "Cockle", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="88" , Name = "Coconut", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="395" , Name = "Coffee", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="433" , Name = "Coffee Bean", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)246" , Name = "Coffee Maker", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="648" , Name = "Coleslaw", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1248" , Name = "Collared Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)508" , Name = "Combat Boots", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="SkillBook_4" , Name = "Combat Quarterly", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="880" , Name = "Combined Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="404" , Name = "Common Mushroom", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="201" , Name = "Complete Breakfast", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)39" , Name = "Cone Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="223" , Name = "Cookie", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="926" , Name = "Cookout Kit", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)20" , Name = "Cool Cap", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="334" , Name = "Copper Bar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1149" , Name = "Copper Breastplate", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="378" , Name = "Copper Ore", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)71" , Name = "Copper Pan", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="393" , Name = "Coral", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="695" , Name = "Cork Bobber", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="270" , Name = "Corn", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="487" , Name = "Corn Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)515" , Name = "Cowboy Boots", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)0" , Name = "Cowboy Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1131" , Name = "Cowboy Poncho", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)33" , Name = "Cowgal Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)34" , Name = "Cowpoke Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="717" , Name = "Crab", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1276" , Name = "Crab Cake Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="732" , Name = "Crab Cakes", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="710" , Name = "Crab Pot", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="810" , Name = "Crabshell Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="282" , Name = "Cranberries", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="612" , Name = "Cranberry Candy", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="238" , Name = "Cranberry Sauce", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="493" , Name = "Cranberry Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)119" , Name = "Crate", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)121" , Name = "Crate", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)123" , Name = "Crate", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)125" , Name = "Crate", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)175" , Name = "Crate", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)263" , Name = "Crate", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="716" , Name = "Crayfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="159" , Name = "Crimsonfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="214" , Name = "Crispy Bass", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="418" , Name = "Crocus", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1133" , Name = "Crop Tank Top (F)", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1132" , Name = "Crop Tank Top (M)", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1141" , Name = "Crop Top Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)21" , Name = "Crystal Dagger", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="333" , Name = "Crystal Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="414" , Name = "Crystal Fruit", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="409" , Name = "Crystal Path", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)878" , Name = "Crystal Shoes", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)21" , Name = "Crystalarium", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="856" , Name = "Curiosity Lure", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)219" , Name = "Cursed P.K. Arcade System", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)44" , Name = "Cutlass", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="18" , Name = "Daffodil", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)29" , Name = "Daisy", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="22" , Name = "Dandelion", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)DarkBallcap" , Name = "Dark Ballcap", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1262" , Name = "Dark Bandana Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)511" , Name = "Dark Boots", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)83" , Name = "Dark Cowboy Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1263" , Name = "Dark Highlight Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1211" , Name = "Dark Jacket", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1003" , Name = "Dark Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)39" , Name = "Dark Sign", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1194" , Name = "Dark Striped Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)2" , Name = "Dark Sword", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)DarkVelvetBow" , Name = "Dark Velvet Bow", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1289" , Name = "Darkness Suit", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)70" , Name = "Dead Tree", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)265" , Name = "Deconstructor", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)111" , Name = "Decorative Pitcher", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="461" , Name = "Decorative Pot", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)76" , Name = "Decorative Spears", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)Dehydrator" , Name = "Dehydrator", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)12" , Name = "Delicate Bow", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="DeluxeBait" , Name = "Deluxe Bait", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)81" , Name = "Deluxe Cowboy Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="919" , Name = "Deluxe Fertilizer", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)76" , Name = "Deluxe Pirate Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="920" , Name = "Deluxe Retaining Soil", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)167" , Name = "Deluxe Scarecrow", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="466" , Name = "Deluxe Speed-Gro", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)DeluxeWormBin" , Name = "Deluxe Worm Bin", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1163" , Name = "Denim Jacket", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="72" , Name = "Diamond", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="107" , Name = "Dinosaur Egg", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)43" , Name = "Dinosaur Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="807" , Name = "Dinosaur Mayonnaise", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)5" , Name = "Dinosaur Pants", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1275" , Name = "Dirt Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="242" , Name = "Dish O' The Sea", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1229" , Name = "Doll Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="543" , Name = "Dolomite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)79" , Name = "Door", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)80" , Name = "Door", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="704" , Name = "Dorado", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="852" , Name = "Dragon Tooth", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)855" , Name = "Dragonscale Boots", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)58" , Name = "Dragontooth Club", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)57" , Name = "Dragontooth Cutlass", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)59" , Name = "Dragontooth Shiv", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="687" , Name = "Dressed Spinner", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="DriedFruit" , Name = "Dried", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="DriedMushrooms" , Name = "Dried", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="116" , Name = "Dried Starfish", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)112" , Name = "Dried Sunflowers", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="169" , Name = "Driftwood", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="463" , Name = "Drum Block", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="442" , Name = "Duck Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="444" , Name = "Duck Feather", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="307" , Name = "Duck Mayonnaise", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)56" , Name = "Dwarf Dagger", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="122" , Name = "Dwarf Gadget", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)55" , Name = "Dwarf Hammer", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="96" , Name = "Dwarf Scroll I", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="97" , Name = "Dwarf Scroll II", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="98" , Name = "Dwarf Scroll III", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="99" , Name = "Dwarf Scroll IV", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)54" , Name = "Dwarf Sword", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="121" , Name = "Dwarvish Helm", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Bombs" , Name = "Dwarvish Safety Manual", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="326" , Name = "Dwarvish Translation Guide", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)11" , Name = "Earmuffs", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="86" , Name = "Earth Crystal", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="875" , Name = "Ectoplasm", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="148" , Name = "Eel", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="176" , Name = "Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="180" , Name = "Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="272" , Name = "Eggplant", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="231" , Name = "Eggplant Parmesan", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="488" , Name = "Eggplant Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)64" , Name = "Elegant Turban", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)20" , Name = "Elf Blade", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)35" , Name = "Elliott's Pencil", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="104" , Name = "Elvish Jewelry", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="60" , Name = "Emerald", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="533" , Name = "Emerald Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)804" , Name = "Emily's Magic Boots", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)41" , Name = "Emily's Magic Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1127" , Name = "Emily's Magic Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)98" , Name = "Empty Capsule", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="349" , Name = "Energy Tonic", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="913" , Name = "Enricher", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="729" , Name = "Escargot", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="544" , Name = "Esperite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1208" , Name = "Excavator Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="441" , Name = "Explosive Ammo", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)24" , Name = "Eye Patch", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1279" , Name = "Faded Denim Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)FairyBox" , Name = "Fairy Box", Category = "Trinket"},
            new FilteredItem { ShouldFilter = false, ItemId ="872" , Name = "Fairy Dust", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="595" , Name = "Fairy Rose", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="425" , Name = "Fairy Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="577" , Name = "Fairy Stone", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1153" , Name = "Fake Muscles Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="497" , Name = "Fall Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1035" , Name = "Fancy Red Blouse", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)65" , Name = "Fancy Table", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="FarAwayStone" , Name = "Far Away Stone", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)239" , Name = "Farm Computer", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)0" , Name = "Farmer Pants", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="240" , Name = "Farmer's Lunch", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)47" , Name = "Fashion Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)19" , Name = "Fedora", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)99" , Name = "Feed Hopper", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)31" , Name = "Femur", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="771" , Name = "Fiber", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="885" , Name = "Fiber Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="259" , Name = "Fiddlehead Fern", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="649" , Name = "Fiddlehead Risotto", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="403" , Name = "Field Snack", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="565" , Name = "Fire Opal", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="82" , Name = "Fire Quartz", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)512" , Name = "Firewalker Boots", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="895" , Name = "Fireworks (Green)", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="894" , Name = "Fireworks (Purple)", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="893" , Name = "Fireworks (Red)", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1158" , Name = "Fish Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)FishSmoker" , Name = "Fish Smoker", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="728" , Name = "Fish Stew", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="213" , Name = "Fish Taco", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)55" , Name = "Fishing Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1157" , Name = "Fishing Vest", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1226" , Name = "Flames Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1154" , Name = "Flannel Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)63" , Name = "Flat Topped Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)54" , Name = "Floppy Beanie", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="267" , Name = "Flounder", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1235" , Name = "Fluffy Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="545" , Name = "Fluorapatite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="464" , Name = "Flute Block", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)90" , Name = "Forager's Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)15" , Name = "Forest Sword", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="823" , Name = "Fossilized Leg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="824" , Name = "Fossilized Ribs", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="820" , Name = "Fossilized Skull", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="821" , Name = "Fossilized Spine", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="822" , Name = "Fossilized Tail", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="202" , Name = "Fried Calamari", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="225" , Name = "Fried Eel", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="194" , Name = "Fried Egg", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1246" , Name = "Fried Egg Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="205" , Name = "Fried Mushroom", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Friendship" , Name = "Friendship 101", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1283" , Name = "Fringed Vest", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)FrogEgg" , Name = "Frog Egg", Category = "Trinket"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)78" , Name = "Frog Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="536" , Name = "Frozen Geode", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="84" , Name = "Frozen Tear", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="610" , Name = "Fruit Salad", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)13" , Name = "Furnace", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)23" , Name = "Galaxy Dagger", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)29" , Name = "Galaxy Hammer", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)34" , Name = "Galaxy Slingshot", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="896" , Name = "Galaxy Soul", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)4" , Name = "Galaxy Sword", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)66" , Name = "Garbage Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)62" , Name = "Garden Pot", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="248" , Name = "Garlic", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="476" , Name = "Garlic Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="325" , Name = "Gate", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1170" , Name = "Gaudy Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="546" , Name = "Geminite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)8" , Name = "Genie Pants", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)513" , Name = "Genie Shoes", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="535" , Name = "Geode", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)182" , Name = "Geode Crusher", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="561" , Name = "Ghost Crystal", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="156" , Name = "Ghostfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)GilsHat" , Name = "Gil's Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="829" , Name = "Ginger", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="903" , Name = "Ginger Ale", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1292" , Name = "Ginger Overalls", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="775" , Name = "Glacierfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="902" , Name = "Glacierfish Jr.", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="118" , Name = "Glass Shards", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="208" , Name = "Glazed Yams", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1284" , Name = "Globby Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="517" , Name = "Glow Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="888" , Name = "Glowstone Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)23" , Name = "Gnome's Cap", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="426" , Name = "Goat Cheese", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="436" , Name = "Goat Milk", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)9" , Name = "Goblin Mask", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="Goby" , Name = "Goby", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)89" , Name = "Goggles", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="336" , Name = "Gold Bar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)145" , Name = "Gold Brazier", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1150" , Name = "Gold Breastplate", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="GoldCoin" , Name = "Gold Coin", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="384" , Name = "Gold Ore", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)GoldPanHat" , Name = "Gold Pan", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1222" , Name = "Gold Trimmed Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="GoldenAnimalCracker" , Name = "Golden Animal Cracker", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="GoldenBobber" , Name = "Golden Bobber", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="791" , Name = "Golden Coconut", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="928" , Name = "Golden Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)75" , Name = "Golden Helmet", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="124" , Name = "Golden Mask", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)67" , Name = "Golden Mask", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="GoldenMysteryBox" , Name = "Golden Mystery Box", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="373" , Name = "Golden Pumpkin", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="125" , Name = "Golden Relic", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)53" , Name = "Golden Scythe", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1238" , Name = "Golden Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)IridiumSpur" , Name = "Golden Spur", Category = "Trinket"},
            new FilteredItem { ShouldFilter = false, ItemId ="TroutDerbyTag" , Name = "Golden Tag", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="73" , Name = "Golden Walnut", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1008" , Name = "Good Grief Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)18" , Name = "Good Ol' Cap", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1188" , Name = "Goodnight Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="865" , Name = "Gourmet Tomato Salt", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)GovernorsHat" , Name = "Governor's Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)68" , Name = "Grandfather Clock", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="569" , Name = "Granite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="398" , Name = "Grape", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="301" , Name = "Grape Starter", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)6" , Name = "Grass Skirt", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="297" , Name = "Grass Starter", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)47" , Name = "Grave Stone", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="407" , Name = "Gravel Path", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1160" , Name = "Gray Hoodie", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1183" , Name = "Gray Suit", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1167" , Name = "Gray Vest", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="153" , Name = "Green Algae", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="188" , Name = "Green Bean", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1011" , Name = "Green Belted Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1189" , Name = "Green Belted Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1281" , Name = "Green Buttoned Vest", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)41" , Name = "Green Canes", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1255" , Name = "Green Flannel Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1270" , Name = "Green Jacket Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1007" , Name = "Green Overalls", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="680" , Name = "Green Slime Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="614" , Name = "Green Tea", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1205" , Name = "Green Thumb Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1034" , Name = "Green Tunic", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)72" , Name = "Green Turban", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1020" , Name = "Green Vest", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds0" , Name = "GreenRainWeeds0", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds1" , Name = "GreenRainWeeds1", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds2" , Name = "GreenRainWeeds2", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds3" , Name = "GreenRainWeeds3", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds4" , Name = "GreenRainWeeds4", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds5" , Name = "GreenRainWeeds5", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds6" , Name = "GreenRainWeeds6", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds7" , Name = "GreenRainWeeds7", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)49" , Name = "Hair Bone", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)42" , Name = "Haley's Iron", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="742" , Name = "Haley's Lost Bracelet", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="708" , Name = "Halibut", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1190" , Name = "Happy Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)27" , Name = "Hard Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="709" , Name = "Hardwood", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="298" , Name = "Hardwood Fence", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)37" , Name = "Harvey's Mallet", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="210" , Name = "Hashbrowns", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="178" , Name = "Hay", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="408" , Name = "Hazelnut", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1028" , Name = "Heart Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1210" , Name = "Heart Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)104" , Name = "Heater", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)HeavyFurnace" , Name = "Heavy Furnace", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)264" , Name = "Heavy Tapper", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="929" , Name = "Hedge", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="547" , Name = "Helvite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="573" , Name = "Hematite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="147" , Name = "Herring", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1225" , Name = "High Heat Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1174" , Name = "High-Waisted Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1175" , Name = "High-Waisted Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1186" , Name = "Holiday Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="283" , Name = "Holly", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)3" , Name = "Holy Blade", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="340" , Name = "Honey", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)275" , Name = "Hopper", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="304" , Name = "Hops", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="302" , Name = "Hops Starter", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="911" , Name = "Horse Flute", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="860" , Name = "Hot Java Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="260" , Name = "Hot Pepper", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1295" , Name = "Hot Pink Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)0" , Name = "House Plant", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)1" , Name = "House Plant", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)2" , Name = "House Plant", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)3" , Name = "House Plant", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)4" , Name = "House Plant", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)5" , Name = "House Plant", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)6" , Name = "House Plant", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)7" , Name = "House Plant", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)15" , Name = "Hunter's Cap", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="918" , Name = "Hyper Speed-Gro", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="233" , Name = "Ice Cream", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="161" , Name = "Ice Pip", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)IceRod" , Name = "Ice Rod", Category = "Trinket"},
            new FilteredItem { ShouldFilter = false, ItemId ="887" , Name = "Immunity Band", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)101" , Name = "Incubator", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)62" , Name = "Infinity Blade", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)InfinityCrown" , Name = "Infinity Crown", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)64" , Name = "Infinity Dagger", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)63" , Name = "Infinity Gavel", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)13" , Name = "Insect Head", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="527" , Name = "Iridium Band", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="337" , Name = "Iridium Bar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1151" , Name = "Iridium Breastplate", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1179" , Name = "Iridium Energy Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="803" , Name = "Iridium Milk", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)61" , Name = "Iridium Needle", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="386" , Name = "Iridium Ore", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)IridiumPanHat" , Name = "Iridium Pan", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)66" , Name = "Iridium Scythe", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="645" , Name = "Iridium Sprinkler", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="335" , Name = "Iron Bar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)17" , Name = "Iron Dirk", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)6" , Name = "Iron Edge", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="324" , Name = "Iron Fence", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)153" , Name = "Iron Lamp-post", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="380" , Name = "Iron Ore", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1297" , Name = "Island Bikini", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)221" , Name = "Item Pedestal", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Defense" , Name = "Jack Be Nimble, Jack Be Thick", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="746" , Name = "Jack-O-Lantern", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="70" , Name = "Jade", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="532" , Name = "Jade Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="549" , Name = "Jagoite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="548" , Name = "Jamborite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="563" , Name = "Jasper", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="429" , Name = "Jazz Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="344" , Name = "Jelly", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)JesterHat" , Name = "Jester Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1192" , Name = "Jester Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1230" , Name = "Jewelry Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Roe" , Name = "Jewels Of The Sea", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)JojaCap" , Name = "Joja Cap", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="167" , Name = "Joja Cola", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="842" , Name = "Journal Scrap", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="350" , Name = "Juice", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="528" , Name = "Jukebox Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)256" , Name = "Junimo Chest", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)JunimoHat" , Name = "Junimo Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)159" , Name = "Junimo Kart Arcade System", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="250" , Name = "Kale", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="477" , Name = "Kale Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)12" , Name = "Keg", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1168" , Name = "Kelp Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)50" , Name = "Knight's Helmet", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)46" , Name = "Kudgel", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="550" , Name = "Kyanite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="438" , Name = "L. Goat Milk", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="174" , Name = "Large Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="182" , Name = "Large Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="186" , Name = "Large Milk", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="136" , Name = "Largemouth Bass", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)LaurelWreathCrown" , Name = "Laurel Wreath Crown", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="162" , Name = "Lava Eel", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)9" , Name = "Lava Katana", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)36" , Name = "Lawn Flamingo", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="692" , Name = "Lead Bobber", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)26" , Name = "Lead Rod", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1187" , Name = "Leafy Top", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)39" , Name = "Leah's Whittler", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)506" , Name = "Leather Boots", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="20" , Name = "Leek", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="163" , Name = "Legend", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="900" , Name = "Legend II", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="554" , Name = "Lemon Stone", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)LeprechuanHat" , Name = "Leprechaun Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)806" , Name = "Leprechaun Shoes", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1137" , Name = "Letterman Jacket", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="773" , Name = "Life Elixir", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1005" , Name = "Light Blue Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1026" , Name = "Light Blue Striped Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)9" , Name = "Lightning Rod", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1012" , Name = "Lime Green Striped Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1042" , Name = "Lime Green Tunic", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="571" , Name = "Limestone", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="707" , Name = "Lingcod", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="837" , Name = "Lionfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)40" , Name = "Living Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="715" , Name = "Lobster", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="730" , Name = "Lobster Bisque", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)81" , Name = "Locked Door", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)82" , Name = "Locked Door", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)46" , Name = "Log Section", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)45" , Name = "Logo Cap", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)2" , Name = "Long Dress", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)17" , Name = "Loom", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="788" , Name = "Lost Axe", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="102" , Name = "Lost Book", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)7" , Name = "Luau Skirt", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)21" , Name = "Lucky Bow", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="204" , Name = "Lucky Lunch", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="789" , Name = "Lucky Purple Shorts", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="859" , Name = "Lucky Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="30" , Name = "Lumber", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="551" , Name = "Lunarite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1291" , Name = "Magenta Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="908" , Name = "Magic Bait", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)73" , Name = "Magic Cowboy Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)MagicHairDye" , Name = "Magic Hair Gel", Category = "Trinket"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)MagicQuiver" , Name = "Magic Quiver", Category = "Trinket"},
            new FilteredItem { ShouldFilter = false, ItemId ="279" , Name = "Magic Rock Candy", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1997" , Name = "Magic Sprinkle Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)74" , Name = "Magic Turban", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="851" , Name = "Magma Cap", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="537" , Name = "Magma Geode", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="703" , Name = "Magnet", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="519" , Name = "Magnet Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="292" , Name = "Mahogany Seed", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="228" , Name = "Maki Roll", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="552" , Name = "Malachite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="834" , Name = "Mango", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="835" , Name = "Mango Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="905" , Name = "Mango Sticky Rice", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="731" , Name = "Maple Bar", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="310" , Name = "Maple Seed", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="724" , Name = "Maple Syrup", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Marlon" , Name = "Mapping Cave Systems", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="567" , Name = "Marble", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)151" , Name = "Marble Brazier", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)36" , Name = "Maru's Wrench", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)33" , Name = "Master Slingshot", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="306" , Name = "Mayonnaise", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)24" , Name = "Mayonnaise Machine", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1017" , Name = "Mayoral Suspenders", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="459" , Name = "Mead", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="288" , Name = "Mega Bomb", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="254" , Name = "Melon", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="479" , Name = "Melon Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)65" , Name = "Meowmere", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)854" , Name = "Mermaid Boots", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="460" , Name = "Mermaid's Pendant", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="269" , Name = "Midnight Carp", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1285" , Name = "Midnight Dog Jacket", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="798" , Name = "Midnight Squid", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="184" , Name = "Milk", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1290" , Name = "Mineral Dog Jacket", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="243" , Name = "Miner's Treat", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)MiniForge" , Name = "Mini-Forge", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)216" , Name = "Mini-Fridge", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)209" , Name = "Mini-Jukebox", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="SkillBook_3" , Name = "Mining Monthly", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)238" , Name = "Mini-Obelisk", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)248" , Name = "Mini-Shipping Bin", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1002" , Name = "Mint Blouse", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)42" , Name = "Mixed Cane", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="MixedFlowerSeeds" , Name = "Mixed Flower Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="770" , Name = "Mixed Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Void" , Name = "Monster Compendium", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="879" , Name = "Monster Musk", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="257" , Name = "Morel", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1257" , Name = "Morel Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="Moss" , Name = "Moss", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="MossSoup" , Name = "Moss Soup", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="MossySeed" , Name = "Mossy Seed", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)31" , Name = "Mouse Ears", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="809" , Name = "Movie Ticket", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)82" , Name = "Mr. Qi's Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="899" , Name = "Ms. Angler", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="574" , Name = "Mudstone", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="827" , Name = "Mummified Bat", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="828" , Name = "Mummified Frog", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)MummyMask" , Name = "Mummy Mask", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="351" , Name = "Muscle Remedy", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)128" , Name = "Mushroom Box", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)42" , Name = "Mushroom Cap", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)MushroomLog" , Name = "Mushroom Log", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="891" , Name = "Mushroom Tree Seed", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="719" , Name = "Mussel", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="682" , Name = "Mutant Carp", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="MysteryBox" , Name = "Mystery Box", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)MysteryHat" , Name = "Mystery Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)MysteryShirt" , Name = "Mystery Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="MysticSyrup" , Name = "Mystic Syrup", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="MysticTreeSeed" , Name = "Mystic Tree Seed", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="811" , Name = "Napalm Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="586" , Name = "Nautilus Fossil", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="392" , Name = "Nautilus Shell", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1185" , Name = "Navy Tuxedo", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1087" , Name = "Neat Bow Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1173" , Name = "Neat Bow Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1220" , Name = "Necklace Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="555" , Name = "Nekoite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)14" , Name = "Neptune's Glaive", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="553" , Name = "Neptunite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1016" , Name = "Night Sky Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="725" , Name = "Oak Resin", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1171" , Name = "Oasis Gown", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)29" , Name = "Obelisk", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="575" , Name = "Obsidian", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)8" , Name = "Obsidian Edge", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)89" , Name = "Obsidian Vase", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1193" , Name = "Ocean Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="560" , Name = "Ocean Stone", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="149" , Name = "Octopus", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1240" , Name = "Officer Uniform", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)5" , Name = "Official Cap", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="247" , Name = "Oil", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)19" , Name = "Oil Maker", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="772" , Name = "Oil of Garlic", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1256" , Name = "Oil Stained Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="195" , Name = "Omelet", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="749" , Name = "Omni Geode", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1264" , Name = "Omni Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="564" , Name = "Opal", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="635" , Name = "Orange", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1267" , Name = "Orange Bow Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1166" , Name = "Orange Gi", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="630" , Name = "Orange Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1015" , Name = "Orange Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="106" , Name = "Ornamental Fan", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)45" , Name = "Ornamental Hay Bale", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="191" , Name = "Ornate Necklace", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="556" , Name = "Orpiment", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)60" , Name = "Ossified Blade", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="289" , Name = "Ostrich Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)254" , Name = "Ostrich Incubator", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="723" , Name = "Oyster", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)PageboyCap" , Name = "Pageboy Cap", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="303" , Name = "Pale Ale", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="457" , Name = "Pale Broth", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="588" , Name = "Palm Fossil", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="211" , Name = "Pancakes", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)36" , Name = "Panda Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)PaperHat" , Name = "Paper Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)ParrotEgg" , Name = "Parrot Egg", Category = "Trinket"},
            new FilteredItem { ShouldFilter = false, ItemId ="24" , Name = "Parsnip", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="472" , Name = "Parsnip Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="199" , Name = "Parsnip Soup", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)57" , Name = "Party Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)58" , Name = "Party Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)59" , Name = "Party Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="636" , Name = "Peach", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="631" , Name = "Peach Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="797" , Name = "Pearl", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1224" , Name = "Pendant Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)38" , Name = "Penny's Fryer", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="215" , Name = "Pepper Poppers", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="482" , Name = "Pepper Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="141" , Name = "Perch", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="722" , Name = "Periwinkle", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="PetLicense" , Name = "Pet License", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="557" , Name = "Petrified Slime", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="863" , Name = "Phoenix Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="342" , Name = "Pickles", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="897" , Name = "Pierre's Missing Stocklist", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="144" , Name = "Pike", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="873" , Name = "Piña Colada", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="311" , Name = "Pine Cone", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="726" , Name = "Pine Tar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="832" , Name = "Pineapple", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="833" , Name = "Pineapple Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)77" , Name = "Pink Bow", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="221" , Name = "Pink Cake", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1027" , Name = "Pink Striped Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)62" , Name = "Pirate Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="870" , Name = "Pirate's Locket", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)43" , Name = "Pirate's Sword", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="206" , Name = "Pizza", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1216" , Name = "Plain Overalls", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1041" , Name = "Plain Shirt (F)", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1038" , Name = "Plain Shirt (M)", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)4" , Name = "Pleated Skirt", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)7" , Name = "Plum Chapeau", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="604" , Name = "Plum Pudding", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)107" , Name = "Plush Bunny", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="906" , Name = "Poi", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)22" , Name = "Polka Bow", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1272" , Name = "Polka Dot Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)14" , Name = "Polka Dot Shorts", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="637" , Name = "Pomegranate", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="632" , Name = "Pomegranate Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="376" , Name = "Poppy", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="453" , Name = "Poppy Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="651" , Name = "Poppyseed Muffin", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="192" , Name = "Potato", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="475" , Name = "Potato Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="PotOfGold" , Name = "PotOfGold", Category = "interactive"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1269" , Name = "Pour-Over Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="Powdermelon" , Name = "Powdermelon", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="PowdermelonSeeds" , Name = "Powdermelon Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)141" , Name = "Prairie King Arcade System", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="120" , Name = "Prehistoric Handaxe", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="583" , Name = "Prehistoric Rib", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="579" , Name = "Prehistoric Scapula", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="581" , Name = "Prehistoric Skull", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="580" , Name = "Prehistoric Tibia", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="115" , Name = "Prehistoric Tool", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="584" , Name = "Prehistoric Vertebra", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)15" , Name = "Preserves Jar", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="915" , Name = "Pressure Nozzle", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_PriceCatalogue" , Name = "Price Catalogue", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)999" , Name = "Prismatic Genie Pants", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="876" , Name = "Prismatic Jelly", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)998" , Name = "Prismatic Pants", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="74" , Name = "Prismatic Shard", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1223" , Name = "Prismatic Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1998" , Name = "Prismatic Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1999" , Name = "Prismatic Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="PrizeTicket" , Name = "Prize Ticket", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)68" , Name = "Propeller Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="861" , Name = "Protection Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="128" , Name = "Pufferfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="276" , Name = "Pumpkin", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)48" , Name = "Pumpkin Mask", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="608" , Name = "Pumpkin Pie", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="490" , Name = "Pumpkin Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="236" , Name = "Pumpkin Soup", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1197" , Name = "Purple Blouse", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="422" , Name = "Purple Mushroom", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="439" , Name = "Purple Slime Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="559" , Name = "Pyrite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="890" , Name = "Qi Bean", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="889" , Name = "Qi Fruit", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="858" , Name = "Qi Gem", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)86" , Name = "Qi Mask", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="917" , Name = "Qi Seasoning", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="877" , Name = "Quality Bobber", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="369" , Name = "Quality Fertilizer", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="371" , Name = "Quality Retaining Soil", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="621" , Name = "Quality Sprinkler", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="80" , Name = "Quartz", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_QueenOfSauce" , Name = "Queen Of Sauce Cookbook", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="446" , Name = "Rabbit's Foot", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)RaccoonHat" , Name = "Raccoon Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="910" , Name = "Radioactive Bar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="901" , Name = "Radioactive Carp", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)84" , Name = "Radioactive Goggles", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="909" , Name = "Radioactive Ore", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="264" , Name = "Radish", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="609" , Name = "Radish Salad", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="484" , Name = "Radish Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1260" , Name = "Rain Coat", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="681" , Name = "Rain Totem", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="394" , Name = "Rainbow Shell", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="138" , Name = "Rainbow Trout", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="Raisins" , Name = "Raisins", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1241" , Name = "Ranger Uniform", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)49" , Name = "Rapier", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="108" , Name = "Rare Disc", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="347" , Name = "Rare Seed", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)126" , Name = "Rarecrow (Alien)", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)138" , Name = "Rarecrow (Dwarf)", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)137" , Name = "Rarecrow (Golden Hair)", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)140" , Name = "Rarecrow (Pumpkin)", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)110" , Name = "Rarecrow (purple bow tie)", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)139" , Name = "Rarecrow (Racoon)", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)136" , Name = "Rarecrow (Snowman)", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)113" , Name = "Rarecrow (Witch)", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)20" , Name = "Recycling Machine", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1280" , Name = "Red Buttoned Vest", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="266" , Name = "Red Cabbage", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="485" , Name = "Red Cabbage Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)43" , Name = "Red Canes", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)38" , Name = "Red Cowboy Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)RedFez" , Name = "Red Fez", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1251" , Name = "Red Flannel Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1162" , Name = "Red Hoodie", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="146" , Name = "Red Mullet", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="420" , Name = "Red Mushroom", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="230" , Name = "Red Plate", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="437" , Name = "Red Slime Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="150" , Name = "Red Snapper", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1013" , Name = "Red Striped Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1184" , Name = "Red Tuxedo", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="338" , Name = "Refined Quartz", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1243" , Name = "Regal Mantle", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)12" , Name = "Relaxed Fit Pants", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)13" , Name = "Relaxed Fit Shorts", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1244" , Name = "Relic Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1039" , Name = "Retro Rainbow Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="252" , Name = "Rhubarb", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="222" , Name = "Rhubarb Pie", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="478" , Name = "Rhubarb Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="423" , Name = "Rice", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="232" , Name = "Rice Pudding", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="273" , Name = "Rice Shoot", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="524" , Name = "Ring of Yoba", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)73" , Name = "Ritual Mask", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="RiverJelly" , Name = "River Jelly", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="607" , Name = "Roasted Hazelnuts", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="812" , Name = "Roe", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="244" , Name = "Roots Platter", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="747" , Name = "Rotten Plant", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="748" , Name = "Rotten Plant", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)505" , Name = "Rubber Boots", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="64" , Name = "Ruby", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="534" , Name = "Ruby Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="840" , Name = "Rustic Plank Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="112" , Name = "Rusty Cog", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1233" , Name = "Rusty Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="110" , Name = "Rusty Spoon", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="111" , Name = "Rusty Spur", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)0" , Name = "Rusty Sword", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1019" , Name = "Sailor Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1259" , Name = "Sailor Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1261" , Name = "Sailor Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)17" , Name = "Sailor's Cap", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="196" , Name = "Salad", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="139" , Name = "Salmon", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="212" , Name = "Salmon Dinner", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="296" , Name = "Salmonberry", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)30" , Name = "Sam's Old Guitar", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="164" , Name = "Sandfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="568" , Name = "Sandstone", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)25" , Name = "Santa Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="92" , Name = "Sap", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="131" , Name = "Sardine", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="227" , Name = "Sashimi", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1236" , Name = "Sauce-Stained Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="523" , Name = "Savage Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)8" , Name = "Scarecrow", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="165" , Name = "Scorpion Carp", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)47" , Name = "Scythe", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="154" , Name = "Sea Cucumber", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="SeaJelly" , Name = "Sea Jelly", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="397" , Name = "Sea Urchin", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="265" , Name = "Seafoam Pudding", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)48" , Name = "Seasonal Decor", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)184" , Name = "Seasonal Plant", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)188" , Name = "Seasonal Plant", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)192" , Name = "Seasonal Plant", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)196" , Name = "Seasonal Plant", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)200" , Name = "Seasonal Plant", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)204" , Name = "Seasonal Plant", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="152" , Name = "Seaweed", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)41" , Name = "Seb's Lost Mace", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="79" , Name = "Secret Note", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)25" , Name = "Seed Maker", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="SeedSpot" , Name = "Seed Spot", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)247" , Name = "Sewing Machine", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="706" , Name = "Shad", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)19" , Name = "Shadow Dagger", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1001" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1022" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1023" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1024" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1025" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1031" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1032" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1033" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1036" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1037" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1040" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1043" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1044" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1045" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1046" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1047" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1048" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1049" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1050" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1051" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1052" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1053" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1054" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1055" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1056" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1057" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1058" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1059" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1060" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1061" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1062" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1063" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1064" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1065" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1066" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1067" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1068" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1069" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1070" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1072" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1073" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1074" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1075" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1076" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1077" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1078" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1079" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1080" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1081" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1082" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1083" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1084" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1085" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1086" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1088" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1089" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1090" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1091" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1092" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1093" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1094" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1095" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1096" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1097" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1098" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1099" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1100" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1101" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1102" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1103" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1104" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1105" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1106" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1107" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1108" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1109" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1110" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1111" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1112" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1113" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1114" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1115" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1116" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1117" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1118" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1119" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1120" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1121" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1122" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1124" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1125" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1126" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1144" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1145" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1146" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1147" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1181" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1182" , Name = "Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1159" , Name = "Shirt And Belt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1123" , Name = "Shirt And Tie", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1214" , Name = "Shirt O' The Sea", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1191" , Name = "Shirt with Bow", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1271" , Name = "Short Jacket", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)1" , Name = "Shorts", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="720" , Name = "Shrimp", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="733" , Name = "Shrimp Cocktail", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1286" , Name = "Shrimp Enthusiast Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)34" , Name = "Sign Of The Vessel", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1277" , Name = "Silky Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)1" , Name = "Silver Saber", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)11" , Name = "Simple Dress", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)94" , Name = "Singing Stone", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="582" , Name = "Skeletal Hand", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="585" , Name = "Skeletal Tail", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)8" , Name = "Skeleton Mask", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)28" , Name = "Skeleton Model", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1014" , Name = "Skeleton Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)3" , Name = "Skirt", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)149" , Name = "Skull Brazier", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1004" , Name = "Skull Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="576" , Name = "Slate", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1217" , Name = "Sleeveless Overalls", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="766" , Name = "Slime", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)56" , Name = "Slime Ball", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="520" , Name = "Slime Charmer Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="925" , Name = "Slime Crate", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)158" , Name = "Slime Egg-Press", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)156" , Name = "Slime Incubator", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1207" , Name = "Slime Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="796" , Name = "Slimejack", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)32" , Name = "Slingshot", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)85" , Name = "Sloth Skeleton L", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)86" , Name = "Sloth Skeleton M", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)87" , Name = "Sloth Skeleton R", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)79" , Name = "Small Cap", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="516" , Name = "Small Glow Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="518" , Name = "Small Magnet Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="137" , Name = "Smallmouth Bass", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="SmokedFish" , Name = "Smoked", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="721" , Name = "Snail", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="825" , Name = "Snake Skull", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="826" , Name = "Snake Vertebrae", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)504" , Name = "Sneakers", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="416" , Name = "Snow Yam", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="572" , Name = "Soapstone", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)117" , Name = "Soda Machine", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1228" , Name = "Soft Arrow Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="172" , Name = "Soggy Newspaper", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="768" , Name = "Solar Essence", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)231" , Name = "Solar Panel", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)164" , Name = "Solid Gold Lewis", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)3" , Name = "Sombrero", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="898" , Name = "Son of Crimsonfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="SonarBobber" , Name = "Sonar Bobber", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="862" , Name = "Soul Sapper Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)28" , Name = "Sou'wester", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)514" , Name = "Space Boots", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)SpaceHelmet" , Name = "Space Helmet", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="224" , Name = "Spaghetti", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="455" , Name = "Spangle Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="465" , Name = "Speed-Gro", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="396" , Name = "Spice Berry", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="226" , Name = "Spicy Eel", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="686" , Name = "Spinner", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="94" , Name = "Spirit Torch", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="799" , Name = "Spook Fish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)SportsCap" , Name = "Sports Cap", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1209" , Name = "Sports Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)52" , Name = "Spotted Headscarf", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="399" , Name = "Spring Onion", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="495" , Name = "Spring Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1258" , Name = "Spring Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="599" , Name = "Sprinkler", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="151" , Name = "Squid", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)SquidHat" , Name = "Squid Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="814" , Name = "Squid Ink", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="921" , Name = "Squid Ink Ravioli", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)51" , Name = "Squire's Helmet", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)71" , Name = "Staircase", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)88" , Name = "Standing Geode", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)87" , Name = "Star Helmet", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="578" , Name = "Star Shards", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1200" , Name = "Star Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)116" , Name = "Stardew Hero Trophy", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="SkillBook_0" , Name = "Stardew Valley Almanac", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="866" , Name = "Stardew Valley Rose", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="434" , Name = "Stardrop", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="StardropTea" , Name = "Stardrop Tea", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="268" , Name = "Starfruit", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="486" , Name = "Starfruit Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)StatueOfBlessings" , Name = "Statue Of Blessings", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)127" , Name = "Statue Of Endless Fortune", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)160" , Name = "Statue Of Perfection", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)StatueOfTheDwarfKing" , Name = "Statue Of The Dwarf King", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)280" , Name = "Statue Of True Perfection", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1148" , Name = "Steel Breastplate", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)50" , Name = "Steel Falchion", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)SteelPanHat" , Name = "Steel Pan", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)11" , Name = "Steel Smallsword", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="415" , Name = "Stepping Stone Path", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="836" , Name = "Stingray", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="606" , Name = "Stir Fry", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="390" , Name = "Stone", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="2" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="4" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="6" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="8" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="10" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="12" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="14" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="32" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="34" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="36" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="38" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="40" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="42" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="44" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="46" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="48" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="50" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="52" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="54" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="56" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="58" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="75" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="76" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="77" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="95" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="290" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="343" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="450" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="668" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="670" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="751" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="760" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="762" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="764" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="765" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="25" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="816" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="817" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="818" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="819" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="843" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="844" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="845" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="846" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="847" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="849" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="850" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="CalicoEggStone_0" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="CalicoEggStone_1" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="CalicoEggStone_2" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="VolcanoGoldNode" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="VolcanoCoalNode0" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="VolcanoCoalNode1" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="BasicCoalNode0" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="BasicCoalNode1" , Name = "Stone", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="449" , Name = "Stone Base", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)144" , Name = "Stone Brazier", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)32" , Name = "Stone Cairn", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)232" , Name = "Stone Chest", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="323" , Name = "Stone Fence", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="329" , Name = "Stone Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)52" , Name = "Stone Frog", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)55" , Name = "Stone Junimo", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)54" , Name = "Stone Owl", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)95" , Name = "Stone Owl", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)53" , Name = "Stone Parrot", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)38" , Name = "Stone Sign", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="841" , Name = "Stone Walkway Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="158" , Name = "Stonefish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1030" , Name = "Store Owner's Jacket", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="203" , Name = "Strange Bun", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)96" , Name = "Strange Capsule", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="126" , Name = "Strange Doll", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="127" , Name = "Strange Doll", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1139" , Name = "Strapped Top", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="401" , Name = "Straw Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)4" , Name = "Straw Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="400" , Name = "Strawberry", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="745" , Name = "Strawberry Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1128" , Name = "Striped Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1169" , Name = "Studded Vest", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="239" , Name = "Stuffing", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)147" , Name = "Stump Brazier", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="525" , Name = "Sturdy Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="698" , Name = "Sturgeon", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="245" , Name = "Sugar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1254" , Name = "Sugar Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)33" , Name = "Suit Of Armor", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1010" , Name = "Suit Top", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="496" , Name = "Summer Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="593" , Name = "Summer Spangle", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="SummerSquash" , Name = "Summer Squash", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="SummerSquashSeeds" , Name = "Summer Squash Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="145" , Name = "Sunfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="421" , Name = "Sunflower", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="431" , Name = "Sunflower Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)88" , Name = "Sunglasses", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1212" , Name = "Sunset Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="155" , Name = "Super Cucumber", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="237" , Name = "Super Meal", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="922" , Name = "SupplyCrate", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="923" , Name = "SupplyCrate", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="924" , Name = "SupplyCrate", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="241" , Name = "Survival Burger", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)85" , Name = "Swashbuckler Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="417" , Name = "Sweet Gem Berry", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="402" , Name = "Sweet Pea", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)22" , Name = "Table Piece L", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)23" , Name = "Table Piece R", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)72" , Name = "Tall Torch", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1006" , Name = "Tan Striped Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1130" , Name = "Tank Top (F)", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1129" , Name = "Tank Top (M)", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)105" , Name = "Tapper", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="830" , Name = "Taro Root", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="831" , Name = "Taro Tuber", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="815" , Name = "Tea Leaves", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="251" , Name = "Tea Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="341" , Name = "Tea Set", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1287" , Name = "Tea Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)69" , Name = "Teddy Timer", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)214" , Name = "Telephone", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)52" , Name = "Tempered Broadsword", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)7" , Name = "Templar's Blade", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="TentKit" , Name = "Tent Kit", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)TextSign" , Name = "Text Sign", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Trash" , Name = "The Alleyway Buffet", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Crabbing" , Name = "The Art O' Crabbing", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Diamonds" , Name = "The Diamond Hunter", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)28" , Name = "The Slammer", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)510" , Name = "Thermal Boots", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="839" , Name = "Thorns Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="558" , Name = "Thunder Egg", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)26" , Name = "Tiara", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1143" , Name = "Tie Dye Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)91" , Name = "Tiger Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="857" , Name = "Tiger Slime Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="699" , Name = "Tiger Trout", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="562" , Name = "Tigerseye", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)9" , Name = "Tight Pants", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="701" , Name = "Tilapia", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1249" , Name = "Toasted Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1199" , Name = "Toga Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="218" , Name = "Tom Kha Soup", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="256" , Name = "Tomato", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="480" , Name = "Tomato Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1282" , Name = "Tomato Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)2" , Name = "Top Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="68" , Name = "Topaz", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="530" , Name = "Topaz Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="93" , Name = "Torch", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="229" , Name = "Tortilla", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1252" , Name = "Tortilla Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)44" , Name = "Totem Mask", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1164" , Name = "Track Jacket", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="694" , Name = "Trap Bobber", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="168" , Name = "Trash", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1232" , Name = "Trash Can Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="166" , Name = "Treasure Chest", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="693" , Name = "Treasure Hunter", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="TreasureTotem" , Name = "Treasure Totem", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="805" , Name = "Tree Fertilizer", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)TricornHat" , Name = "Tricorn Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="589" , Name = "Trilobite", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="71" , Name = "Trimmed Lucky Purple Shorts", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)15" , Name = "Trimmed Lucky Purple Shorts", Category = "Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1288" , Name = "Trinket Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="253" , Name = "Triple Shot Espresso", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="907" , Name = "Tropical Curry", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1296" , Name = "Tropical Sunrise Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)13" , Name = "Tropiclip", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="219" , Name = "Trout Soup", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)16" , Name = "Trucker Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="430" , Name = "Truffle", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="432" , Name = "Truffle Oil", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)108" , Name = "Tub o' Flowers", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1142" , Name = "Tube Top", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="591" , Name = "Tulip", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="427" , Name = "Tulip Bulb", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="130" , Name = "Tuna", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)509" , Name = "Tundra Boots", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1180" , Name = "Tunnelers Jersey", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1178" , Name = "Turtleneck Sweater", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="294" , Name = "Twig", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="295" , Name = "Twig", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="271" , Name = "Unmilled Rice", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1204" , Name = "Vacation Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="522" , Name = "Vampire Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="200" , Name = "Vegetable Medley", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="419" , Name = "Vinegar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1198" , Name = "Vintage Polo", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="305" , Name = "Void Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="769" , Name = "Void Essence", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="808" , Name = "Void Ghost Pendant", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="308" , Name = "Void Mayonnaise", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="795" , Name = "Void Salmon", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="140" , Name = "Walleye", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="864" , Name = "War Memento", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1253" , Name = "Warm Flannel Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="690" , Name = "Warp Totem: Beach", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="261" , Name = "Warp Totem: Desert", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="688" , Name = "Warp Totem: Farm", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="886" , Name = "Warp Totem: Island", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="689" , Name = "Warp Totem: Mountains", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="892" , Name = "Warp Totem: Qi's Arena", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)93" , Name = "Warrior Helmet", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="521" , Name = "Warrior Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)30" , Name = "Watermelon Band", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Speed" , Name = "Way Of The Wind pt. 1", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Speed2" , Name = "Way Of The Wind pt. 2", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_WildSeeds" , Name = "Ways Of The Wild", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)46" , Name = "Wearable Dwarf Helm", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="331" , Name = "Weathered Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="801" , Name = "Wedding Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="0" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="313" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="314" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="315" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="316" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="317" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="318" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="319" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="320" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="321" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="452" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="674" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="675" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="676" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="677" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="678" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="679" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="750" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="784" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="785" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="786" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="792" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="793" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="794" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="882" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="883" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="884" , Name = "Weeds", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="262" , Name = "Wheat", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="246" , Name = "Wheat Flour", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="483" , Name = "Wheat Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="157" , Name = "White Algae", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)WhiteBow" , Name = "White Bow", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1273" , Name = "White Dot Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1165" , Name = "White Gi", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1268" , Name = "White Overalls", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1071" , Name = "White Overalls Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)65" , Name = "White Turban", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)45" , Name = "Wicked Kris", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)83" , Name = "Wicked Statue", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)84" , Name = "Wicked Statue", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="774" , Name = "Wild Bait", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="16" , Name = "Wild Horseradish", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="406" , Name = "Wild Plum", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="277" , Name = "Wilted Bouquet", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)22" , Name = "Wind Spire", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="348" , Name = "Wine", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="412" , Name = "Winter Root", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="498" , Name = "Winter Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)70" , Name = "Witch Hat", Category = "Hats"},
            new FilteredItem { ShouldFilter = false, ItemId ="388" , Name = "Wood", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)26" , Name = "Wood Chair", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)27" , Name = "Wood Chair", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)211" , Name = "Wood Chipper", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)24" , Name = "Wood Club", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="322" , Name = "Wood Fence", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="328" , Name = "Wood Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)152" , Name = "Wood Lamp-post", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)27" , Name = "Wood Mallet", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="405" , Name = "Wood Path", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)37" , Name = "Wood Sign", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="SkillBook_2" , Name = "Woodcutter's Weekly", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)12" , Name = "Wooden Blade", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)143" , Name = "Wooden Brazier", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="734" , Name = "Woodskip", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Woodcutting" , Name = "Woody's Secret", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="440" , Name = "Wool", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)507" , Name = "Work Boots", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1029" , Name = "Work Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)208" , Name = "Workbench", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)154" , Name = "Worm Bin", Category = "Big Craftables"},
            new FilteredItem { ShouldFilter = false, ItemId ="869" , Name = "Wriggling Worm", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1135" , Name = "Wumbus Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="280" , Name = "Yam", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="492" , Name = "Yam Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1021" , Name = "Yellow and Green Shirt", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1294" , Name = "Yellow Suit", Category = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)48" , Name = "Yeti Tooth", Category = "Weapons"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1219" , Name = "Yoba Shirt", Category = "Shirt"}

        };

    }

    public class FilteredItem
    {
        public bool ShouldFilter { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }

    internal sealed class ModEntry : Mod
    {
        public static IMonitor ModMonitor;

        public static ModEntry Instance { get; private set; }
        public ModConfig Config { get; private set; }
        public bool LootFilterOn = true;
        //public IGenericModConfigMenuApi configMenu;
        private Harmony _harmony;
        public override void Entry(IModHelper helper)
        {

            _harmony = new Harmony(ModManifest.UniqueID);
            Instance = this;
            Config = helper.ReadConfig<ModConfig>() ?? new ModConfig(); // Sample to call --> int somevalue = Instance.Config.Somevalues; 

            ModMonitor = Monitor;

            HarmonyPatcher.Apply(this,
             new addItemToInventoryBoolPatch(Config, Instance)
             );

            
            helper.Events.Input.ButtonPressed += Input_ButtonPressed;

        }

        

    


        /*      
              private void RegisterAndAddLootFilterGenericModMenu()
              {

                  // Register mod
                  configMenu.Register(
                      mod: this.ModManifest,
                      reset: () => this.Config = this.Config,
                      save: () => this.Helper.WriteConfig(this.Config)
                  );


                  // Keyboard hotkey on main page
                  configMenu.AddKeybind(
                      mod: this.ModManifest,
                      name: () => "Toggle Loot Filter (Keyboard)",
                      getValue: () =>
                      {

                          return Config.KeyboardHotkeyToTurnOffLootFiltering.ToSButton();
                      },
                      setValue: value =>
                      {

                          Config.KeyboardHotkeyToTurnOffLootFiltering = (Keys)value;
                      }
                  );

                  // Keyboard hotkey on main page
                  configMenu.AddKeybind(
                      mod: this.ModManifest,
                      name: () => "Toggle Loot Filter (Gamepad)",
                      getValue: () =>
                      {
                          // Convert stored string to SButton
                          return Config.GamePadHotkeyToTurnOffLootFiltering.ToSButton();


                      },
                      setValue: value =>
                      {
                          // Convert SButton to string and store it
                          Config.GamePadHotkeyToTurnOffLootFiltering = (Buttons)value;
                      }
                  );


                  configMenu.AddNumberOption(
                      mod: this.ModManifest,
                      name: () => $"# tiles Filtered Items are moved away",
                      getValue: () => Config.distanceFilterItemMovesAwayFromPlayer,
                  setValue: value => Config.distanceFilterItemMovesAwayFromPlayer = value
                  );


                  //Page Links on Main Page ---------------------------------------



                  configMenu.AddPageLink(
                      mod: this.ModManifest,
                      pageId: "Artifacts",
                      text: () => "Artifacts",
                      tooltip: () => "Filter Artifacts"
                  );
                  configMenu.AddPageLink(
                      mod: this.ModManifest,
                      pageId: "SkillBooks",
                      text: () => "SkillBooks",
                      tooltip: () => "Filter SkillBooks"
                  );
                  configMenu.AddPageLink(
                      mod: this.ModManifest,
                      pageId: "Basic",
                      text: () => "Basic",
                      tooltip: () => "Filter Basic"
                  );
                  configMenu.AddPageLink(
                      mod: this.ModManifest,
                      pageId: "Cooking",
                      text: () => "Cooking",
                      tooltip: () => "Filter Cooking"
                  );
                  configMenu.AddPageLink(
                      mod: this.ModManifest,
                      pageId: "Crafting",
                      text: () => "Crafting",
                      tooltip: () => "Filter Crafting"
                  );
                  configMenu.AddPageLink(
                      mod: this.ModManifest,
                      pageId: "Fish",
                      text: () => "Fish",
                      tooltip: () => "Filter Fish"
                  );
                  configMenu.AddPageLink(
                      mod: this.ModManifest,
                      pageId: "interactive",
                      text: () => "interactive",
                      tooltip: () => "Filter interactive"
                  );

                  configMenu.AddPageLink(
                      mod: this.ModManifest,
                      pageId: "Minerals",
                      text: () => "Minerals",
                      tooltip: () => "Filter Minerals"
                  );
                  configMenu.AddPageLink(
                      mod: this.ModManifest,
                      pageId: "Quest",
                      text: () => "Quest",
                      tooltip: () => "Filter Quest"
                  );
                  configMenu.AddPageLink(
                      mod: this.ModManifest,
                      pageId: "Ring",
                      text: () => "Ring",
                      tooltip: () => "Filter Ring"
                  );
                  configMenu.AddPageLink(
                      mod: this.ModManifest,
                      pageId: "Seeds",
                      text: () => "Seeds",
                      tooltip: () => "Filter Seeds"
                  );




                  //---------------------Seperate pages starts here ------------------------------------
                  //1.Sort Objects by Artifacts
                  configMenu.AddPage(
                       mod: this.ModManifest,
                       pageId: "Artifacts",
                       pageTitle: () => "Filter Artifacts"
                       );





                  configMenu.AddSectionTitle(this.ModManifest, () => "Filter -->[Artifacts]<-- ");
                  foreach (var item in this.Config.ObjectToFilter)
                  {


                          if (item.Category.Contains("Arch")){
                              configMenu.AddBoolOption(
                                  mod: this.ModManifest,
                                  name: () => $"{item.Name} ",
                                  getValue: () => item.ShouldFilter,
                              setValue: value => item.ShouldFilter = value
                              );
                          }



                  }


                  //2.Sort Objects by SkillBooks
                  configMenu.AddPage(
                       mod: this.ModManifest,
                       pageId: "SkillBooks",
                       pageTitle: () => "Filter SkillBooks"
                       );

                  configMenu.AddSectionTitle(this.ModManifest, () => "Filter -->[SkillBooks]<-- ");

                  foreach (var item in this.Config.ObjectToFilter)
                  {
                      if (item.Category.Contains("SkillBooks"))
                      {

                          configMenu.AddBoolOption(
                              mod: this.ModManifest,
                              name: () => $"{item.Name} ",
                              getValue: () => item.ShouldFilter,
                              setValue: value => item.ShouldFilter = value

                          );
                      }

                  }


                  //3.Sort Objects by Filter Basic
                  configMenu.AddPage(
                       mod: this.ModManifest,
                       pageId: "Basic",
                       pageTitle: () => "Filter Basic"
                       );
                  configMenu.AddSectionTitle(this.ModManifest, () => "Filter -->[Basic]<--");
                  foreach (var item in this.Config.ObjectToFilter)
                  {
                      if (item.Category.Contains("Basic"))
                      {

                          configMenu.AddBoolOption(
                              mod: this.ModManifest,
                              name: () => $"{item.Name} ",
                              getValue: () => item.ShouldFilter,
                              setValue: value => item.ShouldFilter = value

                          );
                      }

                  }

                  //4. Sort Objects by Cooking
                  configMenu.AddPage(
                       mod: this.ModManifest,
                       pageId: "Cooking",
                       pageTitle: () => "Filter Cooking"
                       );
                  configMenu.AddSectionTitle(this.ModManifest, () => "Filter --->[Cooking]<-- ");
                  foreach (var item in this.Config.ObjectToFilter)
                  {
                      if (item.Category.Contains("Cooking"))
                      {

                          configMenu.AddBoolOption(
                              mod: this.ModManifest,
                              name: () => $"{item.Name} ",
                              getValue: () => item.ShouldFilter,
                              setValue: value => item.ShouldFilter = value

                          );
                      }

                  }

                  //5.Sort Objects by Crafting
                  configMenu.AddPage(
                       mod: this.ModManifest,
                       pageId: "Crafting",
                       pageTitle: () => "Filter Crafting"
                       );
                  configMenu.AddSectionTitle(this.ModManifest, () => "Filter -->[Crafting]<-- ");

                  foreach (var item in this.Config.ObjectToFilter)
                  {
                      if (item.Category.Contains("Crafting"))
                      {

                          configMenu.AddBoolOption(
                              mod: this.ModManifest,
                              name: () => $"{item.Name} ",
                              getValue: () => item.ShouldFilter,
                              setValue: value => item.ShouldFilter = value

                          );
                      }

                  }
                  //6. Sort Objects by Fish
                  configMenu.AddPage(
                       mod: this.ModManifest,
                       pageId: "Fish",
                       pageTitle: () => "Filter Fish"
                       );
                  configMenu.AddSectionTitle(this.ModManifest, () => "Filter -->[Fish]<-- ");

                  foreach (var item in this.Config.ObjectToFilter)
                  {
                      if (item.Category.Contains("Fish"))
                      {

                          configMenu.AddBoolOption(
                              mod: this.ModManifest,
                              name: () => $"{item.Name} ",
                              getValue: () => item.ShouldFilter,
                              setValue: value => item.ShouldFilter = value

                          );
                      }

                  }


                  //7. Sort Objects by interactive
                  configMenu.AddPage(
                       mod: this.ModManifest,
                       pageId: "interactive",
                       pageTitle: () => "Filter interactive"
                       );
                  configMenu.AddSectionTitle(this.ModManifest, () => "Filter -->[interactive]<-- ");
                  foreach (var item in this.Config.ObjectToFilter)
                  {
                      if (item.Category.Contains("interactive"))
                      {

                          configMenu.AddBoolOption(
                              mod: this.ModManifest,
                              name: () => $"{item.Name} ",
                              getValue: () => item.ShouldFilter,
                              setValue: value => item.ShouldFilter = value

                          );
                      }

                  }




                  //9.Sort Objects by Minerals
                  configMenu.AddPage(
                       mod: this.ModManifest,
                       pageId: "Minerals",
                       pageTitle: () => "Filter Minerals"
                       );
                  configMenu.AddSectionTitle(this.ModManifest, () => " -->[Minerals]<-- ");

                  foreach (var item in this.Config.ObjectToFilter)
                  {
                      if (item.Category.Contains("Minerals"))
                      {

                          configMenu.AddBoolOption(
                              mod: this.ModManifest,
                              name: () => $"{item.Name} ",
                              getValue: () => item.ShouldFilter,
                              setValue: value => item.ShouldFilter = value

                          );
                      }

                  }
                  //10. Sort Objects by Quest
                  configMenu.AddPage(
                       mod: this.ModManifest,
                       pageId: "Quest",
                       pageTitle: () => "Filter Quest"
                       );
                  configMenu.AddSectionTitle(this.ModManifest, () => "-->[Quest]<-- ");

                  foreach (var item in this.Config.ObjectToFilter)
                  {
                      if (item.Category.Contains("Quest"))
                      {

                          configMenu.AddBoolOption(
                              mod: this.ModManifest,
                              name: () => $"{item.Name} ",
                              getValue: () => item.ShouldFilter,
                              setValue: value => item.ShouldFilter = value

                          );
                      }

                  }


                  //11. Sort Objects by Rings
                  configMenu.AddPage(
                       mod: this.ModManifest,
                       pageId: "Ring",
                       pageTitle: () => "Filter Ring"
                       );
                  configMenu.AddSectionTitle(this.ModManifest, () => "Filter -->[Ring]<--");

                  foreach (var item in this.Config.ObjectToFilter)
                  {
                      if (item.Category.Contains("Ring"))
                      {

                          configMenu.AddBoolOption(
                              mod: this.ModManifest,
                              name: () => $"{item.Name} ",
                              getValue: () => item.ShouldFilter,
                              setValue: value => item.ShouldFilter = value

                          );
                      }

                  }

                  //12. Sort Objects by Seeds
                  configMenu.AddPage(
                       mod: this.ModManifest,
                       pageId: "Seeds",
                       pageTitle: () => "Filter Seeds"
                       );
                  configMenu.AddSectionTitle(this.ModManifest, () => "Filter -->[Seeds]<--");

                  foreach (var item in this.Config.ObjectToFilter)
                  {
                      if (item.Category.Contains("Seeds"))
                      {

                          configMenu.AddBoolOption(
                              mod: this.ModManifest,
                              name: () => $"{item.Name} ",
                              getValue: () => item.ShouldFilter,
                              setValue: value => item.ShouldFilter = value

                          );
                      }

                  }








              }

              */
        
    private void Input_ButtonPressed(object? sender, StardewModdingAPI.Events.ButtonPressedEventArgs e)
        {
            // Check if the pressed button matches the configured keyboard key or gamepad button
            if (e.Button == Config.KeyboardHotkeyToTurnOffLootFiltering.ToSButton() ||
                e.Button == Config.GamePadHotkeyToTurnOffLootFiltering.ToSButton())
            {
                // Toggle the HotkeyPressedToTurnOffLootFilter state
                LootFilterOn = !LootFilterOn;

                // Display a message to the player
                string message = LootFilterOn
                    ? "Loot Filter is turned on" 
                    : "Loot Filter is turned off";

                int type = LootFilterOn ? 4 : 3;
                Game1.addHUDMessage(new HUDMessage(message, type));

                /*
                if (!LootFilterOn)
                {
                    //Instance = this;
                    ReloadConfig();
                    //configMenu.Unregister(Instance.ModManifest);
                    //RegisterAndAddLootFilterGenericModMenu();

                }
                */


            }



        }
    }
}

         /*
         public void ReloadConfig()
         {
             // Reload the config file
             Config = null;
             Config = Helper.ReadConfig<ModConfig>();

         }

        */



