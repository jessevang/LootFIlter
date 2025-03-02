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
        //public String note001 { get; set; } = "Set keyboard or Gamepad hotkey that would toggle loot filter on and off inside game.";
        //public Keys KeyboardHotkeyToTurnOffLootFiltering { get; set; } = Keys.Z;
        //public Buttons GamePadHotkeyToTurnOffLootFiltering { get; set; } = Buttons.LeftStick;
        public int distanceFilterItemMovesAwayFromPlayer { get; set; } = 8;
        public String note002 { get; set; } = "Set ShouldFilter field to True to filter Items. After  Filter is Apply a restart is required. ";
        public List<FilteredItem> ObjectToFilter { get; set; } = new List<FilteredItem>
        {
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1136" , Name = "80's Shirt (F)"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1152" , Name = "80's Shirt (M)"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)40" , Name = "Abby's Planchette"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)AbigailsBow" , Name = "Abigail's Bow"},
            new FilteredItem { ShouldFilter = false, ItemId ="309" , Name = "Acorn"},
            new FilteredItem { ShouldFilter = false, ItemId ="867" , Name = "Advanced TV Remote"},
            new FilteredItem { ShouldFilter = false, ItemId ="541" , Name = "Aerinite"},
            new FilteredItem { ShouldFilter = false, ItemId ="447" , Name = "Aged Roe"},
            new FilteredItem { ShouldFilter = false, ItemId ="538" , Name = "Alamite"},
            new FilteredItem { ShouldFilter = false, ItemId ="705" , Name = "Albacore"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)25" , Name = "Alex's Bat"},
            new FilteredItem { ShouldFilter = false, ItemId ="456" , Name = "Algae Soup"},
            new FilteredItem { ShouldFilter = false, ItemId ="300" , Name = "Amaranth"},
            new FilteredItem { ShouldFilter = false, ItemId ="299" , Name = "Amaranth Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="66" , Name = "Amethyst"},
            new FilteredItem { ShouldFilter = false, ItemId ="529" , Name = "Amethyst Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="587" , Name = "Amphibian Fossil"},
            new FilteredItem { ShouldFilter = false, ItemId ="117" , Name = "Anchor"},
            new FilteredItem { ShouldFilter = false, ItemId ="129" , Name = "Anchovy"},
            new FilteredItem { ShouldFilter = false, ItemId ="103" , Name = "Ancient Doll"},
            new FilteredItem { ShouldFilter = false, ItemId ="123" , Name = "Ancient Drum"},
            new FilteredItem { ShouldFilter = false, ItemId ="454" , Name = "Ancient Fruit"},
            new FilteredItem { ShouldFilter = false, ItemId ="114" , Name = "Ancient Seed"},
            new FilteredItem { ShouldFilter = false, ItemId ="499" , Name = "Ancient Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)67" , Name = "Ancient Stool"},
            new FilteredItem { ShouldFilter = false, ItemId ="109" , Name = "Ancient Sword"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)66" , Name = "Ancient Table"},
            new FilteredItem { ShouldFilter = false, ItemId ="160" , Name = "Angler"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_AnimalCatalogue" , Name = "Animal Catalogue"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1227" , Name = "Antiquity Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)Anvil" , Name = "Anvil"},
            new FilteredItem { ShouldFilter = false, ItemId ="613" , Name = "Apple"},
            new FilteredItem { ShouldFilter = false, ItemId ="633" , Name = "Apple Sapling"},
            new FilteredItem { ShouldFilter = false, ItemId ="634" , Name = "Apricot"},
            new FilteredItem { ShouldFilter = false, ItemId ="629" , Name = "Apricot Sapling"},
            new FilteredItem { ShouldFilter = false, ItemId ="62" , Name = "Aquamarine"},
            new FilteredItem { ShouldFilter = false, ItemId ="531" , Name = "Aquamarine Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1009" , Name = "Aquamarine Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)60" , Name = "Arcane Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1215" , Name = "Arcane Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)35" , Name = "Archer's Cap"},
            new FilteredItem { ShouldFilter = false, ItemId ="868" , Name = "Arctic Shard"},
            new FilteredItem { ShouldFilter = false, ItemId ="101" , Name = "Arrowhead"},
            new FilteredItem { ShouldFilter = false, ItemId ="274" , Name = "Artichoke"},
            new FilteredItem { ShouldFilter = false, ItemId ="605" , Name = "Artichoke Dip"},
            new FilteredItem { ShouldFilter = false, ItemId ="489" , Name = "Artichoke Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="590" , Name = "Artifact Spot"},
            new FilteredItem { ShouldFilter = false, ItemId ="275" , Name = "Artifact Trove"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)165" , Name = "Auto-Grabber"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)272" , Name = "Auto-Petter"},
            new FilteredItem { ShouldFilter = false, ItemId ="235" , Name = "Autumn's Bounty"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1196" , Name = "Backpack Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)10" , Name = "Baggy Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="685" , Name = "Bait"},
            new FilteredItem { ShouldFilter = false, ItemId ="SpecificBait" , Name = "Bait"},
            new FilteredItem { ShouldFilter = false, ItemId ="SkillBook_1" , Name = "Bait And Bobber"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)BaitMaker" , Name = "Bait Maker"},
            new FilteredItem { ShouldFilter = false, ItemId ="198" , Name = "Baked Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="91" , Name = "Banana"},
            new FilteredItem { ShouldFilter = false, ItemId ="904" , Name = "Banana Pudding"},
            new FilteredItem { ShouldFilter = false, ItemId ="69" , Name = "Banana Sapling"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1293" , Name = "Banana Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1195" , Name = "Bandana Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1203" , Name = "Bandana Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1206" , Name = "Bandana Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="691" , Name = "Barbed Hook"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)118" , Name = "Barrel"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)120" , Name = "Barrel"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)122" , Name = "Barrel"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)124" , Name = "Barrel"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)174" , Name = "Barrel"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)262" , Name = "Barrel"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)150" , Name = "Barrel Brazier"},
            new FilteredItem { ShouldFilter = false, ItemId ="540" , Name = "Baryte"},
            new FilteredItem { ShouldFilter = false, ItemId ="570" , Name = "Basalt"},
            new FilteredItem { ShouldFilter = false, ItemId ="368" , Name = "Basic Fertilizer"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)35" , Name = "Basic Log"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1177" , Name = "Basic Pullover (F)"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1176" , Name = "Basic Pullover (M)"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)SoftEdgePullover" , Name = "Basic Pullover (M)"},
            new FilteredItem { ShouldFilter = false, ItemId ="370" , Name = "Basic Retaining Soil"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)BasiliskPaw" , Name = "Basilisk Paw"},
            new FilteredItem { ShouldFilter = false, ItemId ="767" , Name = "Bat Wing"},
            new FilteredItem { ShouldFilter = false, ItemId ="787" , Name = "Battery Pack"},
            new FilteredItem { ShouldFilter = false, ItemId ="207" , Name = "Bean Hotpot"},
            new FilteredItem { ShouldFilter = false, ItemId ="473" , Name = "Bean Starter"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)53" , Name = "Beanie"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)10" , Name = "Bee House"},
            new FilteredItem { ShouldFilter = false, ItemId ="346" , Name = "Beer"},
            new FilteredItem { ShouldFilter = false, ItemId ="284" , Name = "Beet"},
            new FilteredItem { ShouldFilter = false, ItemId ="494" , Name = "Beet Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1221" , Name = "Belted Coat"},
            new FilteredItem { ShouldFilter = false, ItemId ="790" , Name = "Berry Basket"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)BigChest" , Name = "Big Chest"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)40" , Name = "Big Green Cane"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)44" , Name = "Big Red Cane"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)BigStoneChest" , Name = "Big Stone Chest"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1134" , Name = "Bikini Top"},
            new FilteredItem { ShouldFilter = false, ItemId ="539" , Name = "Bixite"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1138" , Name = "Black Leather Jacket"},
            new FilteredItem { ShouldFilter = false, ItemId ="410" , Name = "Blackberry"},
            new FilteredItem { ShouldFilter = false, ItemId ="611" , Name = "Blackberry Cobbler"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1172" , Name = "Blacksmith Apron"},
            new FilteredItem { ShouldFilter = false, ItemId ="800" , Name = "Blobfish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)56" , Name = "Blobfish Mask"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)6" , Name = "Blue Bonnet"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)BlueBow" , Name = "Blue Bow"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1278" , Name = "Blue Buttoned Vest"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)37" , Name = "Blue Cowboy Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="838" , Name = "Blue Discus"},
            new FilteredItem { ShouldFilter = false, ItemId ="BlueGrassStarter" , Name = "Blue Grass Starter"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1161" , Name = "Blue Hoodie"},
            new FilteredItem { ShouldFilter = false, ItemId ="597" , Name = "Blue Jazz"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1242" , Name = "Blue Long Vest"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)BlueRibbon" , Name = "Blue Ribbon"},
            new FilteredItem { ShouldFilter = false, ItemId ="413" , Name = "Blue Slime Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="258" , Name = "Blueberry"},
            new FilteredItem { ShouldFilter = false, ItemId ="481" , Name = "Blueberry Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="234" , Name = "Blueberry Tart"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)80" , Name = "Bluebird Mask"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1245" , Name = "Bobo Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="278" , Name = "Bok Choy"},
            new FilteredItem { ShouldFilter = false, ItemId ="491" , Name = "Bok Choy Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="287" , Name = "Bomb"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1155" , Name = "Bomber Jacket"},
            new FilteredItem { ShouldFilter = false, ItemId ="119" , Name = "Bone Flute"},
            new FilteredItem { ShouldFilter = false, ItemId ="881" , Name = "Bone Fragment"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)90" , Name = "Bone Mill"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)5" , Name = "Bone Sword"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)74" , Name = "Bonfire"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)75" , Name = "Bongo"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Mystery" , Name = "Book of Mysteries"},
            new FilteredItem { ShouldFilter = false, ItemId ="PurpleBook" , Name = "Book Of Stars"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Artifact" , Name = "Book_Artifact"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Grass" , Name = "Book_Grass"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Horse" , Name = "Book_Horse"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)64" , Name = "Bookcase"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)78" , Name = "Boulder"},
            new FilteredItem { ShouldFilter = false, ItemId ="458" , Name = "Bouquet"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)1" , Name = "Bowler Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="216" , Name = "Bread"},
            new FilteredItem { ShouldFilter = false, ItemId ="132" , Name = "Bream"},
            new FilteredItem { ShouldFilter = false, ItemId ="293" , Name = "Brick Floor"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1265" , Name = "Bridal Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)69" , Name = "Bridal Veil"},
            new FilteredItem { ShouldFilter = false, ItemId ="Broccoli" , Name = "Broccoli"},
            new FilteredItem { ShouldFilter = false, ItemId ="BroccoliSeeds" , Name = "Broccoli Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="171" , Name = "Broken CD"},
            new FilteredItem { ShouldFilter = false, ItemId ="170" , Name = "Broken Glasses"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)51" , Name = "Broken Trident"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1018" , Name = "Brown Jacket"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1266" , Name = "Brown Overalls"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1237" , Name = "Brown Suit"},
            new FilteredItem { ShouldFilter = false, ItemId ="618" , Name = "Bruschetta"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)BucketHat" , Name = "Bucket Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="684" , Name = "Bug Meat"},
            new FilteredItem { ShouldFilter = false, ItemId ="874" , Name = "Bug Steak"},
            new FilteredItem { ShouldFilter = false, ItemId ="700" , Name = "Bullhead"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1247" , Name = "Burger Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="526" , Name = "Burglar's Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)18" , Name = "Burglar's Shank"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)14" , Name = "Butterfly Bow"},
            new FilteredItem { ShouldFilter = false, ItemId ="ButterflyPowder" , Name = "Butterfly Powder"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1140" , Name = "Button Down Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="90" , Name = "Cactus Fruit"},
            new FilteredItem { ShouldFilter = false, ItemId ="802" , Name = "Cactus Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="542" , Name = "Calcite"},
            new FilteredItem { ShouldFilter = false, ItemId ="CalicoEgg" , Name = "Calico Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)106" , Name = "Camera"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1274" , Name = "Camo Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)146" , Name = "Campfire"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)278" , Name = "Campfire"},
            new FilteredItem { ShouldFilter = false, ItemId ="927" , Name = "Camping Stove"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1231" , Name = "Canvas Jacket"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1239" , Name = "Captain's Uniform"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1218" , Name = "Cardigan"},
            new FilteredItem { ShouldFilter = false, ItemId ="142" , Name = "Carp"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1250" , Name = "Carp Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="209" , Name = "Carp Surprise"},
            new FilteredItem { ShouldFilter = false, ItemId ="Carrot" , Name = "Carrot"},
            new FilteredItem { ShouldFilter = false, ItemId ="CarrotSeeds" , Name = "Carrot Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)148" , Name = "Carved Brazier"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)16" , Name = "Carving Knife"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)163" , Name = "Cask"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)32" , Name = "Cat Ears"},
            new FilteredItem { ShouldFilter = false, ItemId ="143" , Name = "Catfish"},
            new FilteredItem { ShouldFilter = false, ItemId ="190" , Name = "Cauliflower"},
            new FilteredItem { ShouldFilter = false, ItemId ="474" , Name = "Cauliflower Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="78" , Name = "Cave Carrot"},
            new FilteredItem { ShouldFilter = false, ItemId ="CaveJelly" , Name = "Cave Jelly"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1156" , Name = "Caveman Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="445" , Name = "Caviar"},
            new FilteredItem { ShouldFilter = false, ItemId ="566" , Name = "Celestine"},
            new FilteredItem { ShouldFilter = false, ItemId ="ChallengeBait" , Name = "Challenge Bait"},
            new FilteredItem { ShouldFilter = false, ItemId ="281" , Name = "Chanterelle"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)114" , Name = "Charcoal Kiln"},
            new FilteredItem { ShouldFilter = false, ItemId ="424" , Name = "Cheese"},
            new FilteredItem { ShouldFilter = false, ItemId ="197" , Name = "Cheese Cauliflower"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)16" , Name = "Cheese Press"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1213" , Name = "Chef Coat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)61" , Name = "Chef Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="638" , Name = "Cherry"},
            new FilteredItem { ShouldFilter = false, ItemId ="286" , Name = "Cherry Bomb"},
            new FilteredItem { ShouldFilter = false, ItemId ="628" , Name = "Cherry Sapling"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)130" , Name = "Chest"},
            new FilteredItem { ShouldFilter = false, ItemId ="105" , Name = "Chewing Stick"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)10" , Name = "Chicken Mask"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)31" , Name = "Chicken Statue"},
            new FilteredItem { ShouldFilter = false, ItemId ="113" , Name = "Chicken Statue"},
            new FilteredItem { ShouldFilter = false, ItemId ="100" , Name = "Chipped Amphora"},
            new FilteredItem { ShouldFilter = false, ItemId ="220" , Name = "Chocolate Cake"},
            new FilteredItem { ShouldFilter = false, ItemId ="727" , Name = "Chowder"},
            new FilteredItem { ShouldFilter = false, ItemId ="702" , Name = "Chub"},
            new FilteredItem { ShouldFilter = false, ItemId ="848" , Name = "Cinder Shard"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)853" , Name = "Cinderclown Shoes"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1234" , Name = "Circuitboard Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="372" , Name = "Clam"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1000" , Name = "Classic Overalls"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1202" , Name = "Classy Top (F)"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1201" , Name = "Classy Top (M)"},
            new FilteredItem { ShouldFilter = false, ItemId ="330" , Name = "Clay"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)10" , Name = "Claymore"},
            new FilteredItem { ShouldFilter = false, ItemId ="428" , Name = "Cloth"},
            new FilteredItem { ShouldFilter = false, ItemId ="382" , Name = "Coal"},
            new FilteredItem { ShouldFilter = false, ItemId ="411" , Name = "Cobblestone Path"},
            new FilteredItem { ShouldFilter = false, ItemId ="718" , Name = "Cockle"},
            new FilteredItem { ShouldFilter = false, ItemId ="88" , Name = "Coconut"},
            new FilteredItem { ShouldFilter = false, ItemId ="395" , Name = "Coffee"},
            new FilteredItem { ShouldFilter = false, ItemId ="433" , Name = "Coffee Bean"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)246" , Name = "Coffee Maker"},
            new FilteredItem { ShouldFilter = false, ItemId ="648" , Name = "Coleslaw"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1248" , Name = "Collared Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)508" , Name = "Combat Boots"},
            new FilteredItem { ShouldFilter = false, ItemId ="SkillBook_4" , Name = "Combat Quarterly"},
            new FilteredItem { ShouldFilter = false, ItemId ="880" , Name = "Combined Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="404" , Name = "Common Mushroom"},
            new FilteredItem { ShouldFilter = false, ItemId ="201" , Name = "Complete Breakfast"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)39" , Name = "Cone Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="223" , Name = "Cookie"},
            new FilteredItem { ShouldFilter = false, ItemId ="926" , Name = "Cookout Kit"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)20" , Name = "Cool Cap"},
            new FilteredItem { ShouldFilter = false, ItemId ="334" , Name = "Copper Bar"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1149" , Name = "Copper Breastplate"},
            new FilteredItem { ShouldFilter = false, ItemId ="378" , Name = "Copper Ore"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)71" , Name = "Copper Pan"},
            new FilteredItem { ShouldFilter = false, ItemId ="393" , Name = "Coral"},
            new FilteredItem { ShouldFilter = false, ItemId ="695" , Name = "Cork Bobber"},
            new FilteredItem { ShouldFilter = false, ItemId ="270" , Name = "Corn"},
            new FilteredItem { ShouldFilter = false, ItemId ="487" , Name = "Corn Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)515" , Name = "Cowboy Boots"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)0" , Name = "Cowboy Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1131" , Name = "Cowboy Poncho"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)33" , Name = "Cowgal Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)34" , Name = "Cowpoke Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="717" , Name = "Crab"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1276" , Name = "Crab Cake Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="732" , Name = "Crab Cakes"},
            new FilteredItem { ShouldFilter = false, ItemId ="710" , Name = "Crab Pot"},
            new FilteredItem { ShouldFilter = false, ItemId ="810" , Name = "Crabshell Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="282" , Name = "Cranberries"},
            new FilteredItem { ShouldFilter = false, ItemId ="612" , Name = "Cranberry Candy"},
            new FilteredItem { ShouldFilter = false, ItemId ="238" , Name = "Cranberry Sauce"},
            new FilteredItem { ShouldFilter = false, ItemId ="493" , Name = "Cranberry Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)119" , Name = "Crate"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)121" , Name = "Crate"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)123" , Name = "Crate"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)125" , Name = "Crate"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)175" , Name = "Crate"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)263" , Name = "Crate"},
            new FilteredItem { ShouldFilter = false, ItemId ="716" , Name = "Crayfish"},
            new FilteredItem { ShouldFilter = false, ItemId ="159" , Name = "Crimsonfish"},
            new FilteredItem { ShouldFilter = false, ItemId ="214" , Name = "Crispy Bass"},
            new FilteredItem { ShouldFilter = false, ItemId ="418" , Name = "Crocus"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1133" , Name = "Crop Tank Top (F)"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1132" , Name = "Crop Tank Top (M)"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1141" , Name = "Crop Top Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)21" , Name = "Crystal Dagger"},
            new FilteredItem { ShouldFilter = false, ItemId ="333" , Name = "Crystal Floor"},
            new FilteredItem { ShouldFilter = false, ItemId ="414" , Name = "Crystal Fruit"},
            new FilteredItem { ShouldFilter = false, ItemId ="409" , Name = "Crystal Path"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)878" , Name = "Crystal Shoes"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)21" , Name = "Crystalarium"},
            new FilteredItem { ShouldFilter = false, ItemId ="856" , Name = "Curiosity Lure"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)219" , Name = "Cursed P.K. Arcade System"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)44" , Name = "Cutlass"},
            new FilteredItem { ShouldFilter = false, ItemId ="18" , Name = "Daffodil"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)29" , Name = "Daisy"},
            new FilteredItem { ShouldFilter = false, ItemId ="22" , Name = "Dandelion"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)DarkBallcap" , Name = "Dark Ballcap"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1262" , Name = "Dark Bandana Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)511" , Name = "Dark Boots"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)83" , Name = "Dark Cowboy Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1263" , Name = "Dark Highlight Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1211" , Name = "Dark Jacket"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1003" , Name = "Dark Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)39" , Name = "Dark Sign"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1194" , Name = "Dark Striped Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)2" , Name = "Dark Sword"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)DarkVelvetBow" , Name = "Dark Velvet Bow"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1289" , Name = "Darkness Suit"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)70" , Name = "Dead Tree"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)265" , Name = "Deconstructor"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)111" , Name = "Decorative Pitcher"},
            new FilteredItem { ShouldFilter = false, ItemId ="461" , Name = "Decorative Pot"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)76" , Name = "Decorative Spears"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)Dehydrator" , Name = "Dehydrator"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)12" , Name = "Delicate Bow"},
            new FilteredItem { ShouldFilter = false, ItemId ="DeluxeBait" , Name = "Deluxe Bait"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)81" , Name = "Deluxe Cowboy Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="919" , Name = "Deluxe Fertilizer"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)76" , Name = "Deluxe Pirate Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="920" , Name = "Deluxe Retaining Soil"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)167" , Name = "Deluxe Scarecrow"},
            new FilteredItem { ShouldFilter = false, ItemId ="466" , Name = "Deluxe Speed-Gro"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)DeluxeWormBin" , Name = "Deluxe Worm Bin"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1163" , Name = "Denim Jacket"},
            new FilteredItem { ShouldFilter = false, ItemId ="72" , Name = "Diamond"},
            new FilteredItem { ShouldFilter = false, ItemId ="107" , Name = "Dinosaur Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)43" , Name = "Dinosaur Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="807" , Name = "Dinosaur Mayonnaise"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)5" , Name = "Dinosaur Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1275" , Name = "Dirt Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="242" , Name = "Dish O' The Sea"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1229" , Name = "Doll Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="543" , Name = "Dolomite"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)79" , Name = "Door"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)80" , Name = "Door"},
            new FilteredItem { ShouldFilter = false, ItemId ="704" , Name = "Dorado"},
            new FilteredItem { ShouldFilter = false, ItemId ="852" , Name = "Dragon Tooth"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)855" , Name = "Dragonscale Boots"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)58" , Name = "Dragontooth Club"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)57" , Name = "Dragontooth Cutlass"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)59" , Name = "Dragontooth Shiv"},
            new FilteredItem { ShouldFilter = false, ItemId ="687" , Name = "Dressed Spinner"},
            new FilteredItem { ShouldFilter = false, ItemId ="DriedFruit" , Name = "Dried"},
            new FilteredItem { ShouldFilter = false, ItemId ="DriedMushrooms" , Name = "Dried"},
            new FilteredItem { ShouldFilter = false, ItemId ="116" , Name = "Dried Starfish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)112" , Name = "Dried Sunflowers"},
            new FilteredItem { ShouldFilter = false, ItemId ="169" , Name = "Driftwood"},
            new FilteredItem { ShouldFilter = false, ItemId ="463" , Name = "Drum Block"},
            new FilteredItem { ShouldFilter = false, ItemId ="442" , Name = "Duck Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="444" , Name = "Duck Feather"},
            new FilteredItem { ShouldFilter = false, ItemId ="307" , Name = "Duck Mayonnaise"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)56" , Name = "Dwarf Dagger"},
            new FilteredItem { ShouldFilter = false, ItemId ="122" , Name = "Dwarf Gadget"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)55" , Name = "Dwarf Hammer"},
            new FilteredItem { ShouldFilter = false, ItemId ="96" , Name = "Dwarf Scroll I"},
            new FilteredItem { ShouldFilter = false, ItemId ="97" , Name = "Dwarf Scroll II"},
            new FilteredItem { ShouldFilter = false, ItemId ="98" , Name = "Dwarf Scroll III"},
            new FilteredItem { ShouldFilter = false, ItemId ="99" , Name = "Dwarf Scroll IV"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)54" , Name = "Dwarf Sword"},
            new FilteredItem { ShouldFilter = false, ItemId ="121" , Name = "Dwarvish Helm"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Bombs" , Name = "Dwarvish Safety Manual"},
            new FilteredItem { ShouldFilter = false, ItemId ="326" , Name = "Dwarvish Translation Guide"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)11" , Name = "Earmuffs"},
            new FilteredItem { ShouldFilter = false, ItemId ="86" , Name = "Earth Crystal"},
            new FilteredItem { ShouldFilter = false, ItemId ="875" , Name = "Ectoplasm"},
            new FilteredItem { ShouldFilter = false, ItemId ="148" , Name = "Eel"},
            new FilteredItem { ShouldFilter = false, ItemId ="176" , Name = "Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="180" , Name = "Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="272" , Name = "Eggplant"},
            new FilteredItem { ShouldFilter = false, ItemId ="231" , Name = "Eggplant Parmesan"},
            new FilteredItem { ShouldFilter = false, ItemId ="488" , Name = "Eggplant Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)64" , Name = "Elegant Turban"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)20" , Name = "Elf Blade"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)35" , Name = "Elliott's Pencil"},
            new FilteredItem { ShouldFilter = false, ItemId ="104" , Name = "Elvish Jewelry"},
            new FilteredItem { ShouldFilter = false, ItemId ="60" , Name = "Emerald"},
            new FilteredItem { ShouldFilter = false, ItemId ="533" , Name = "Emerald Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)804" , Name = "Emily's Magic Boots"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)41" , Name = "Emily's Magic Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1127" , Name = "Emily's Magic Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)98" , Name = "Empty Capsule"},
            new FilteredItem { ShouldFilter = false, ItemId ="349" , Name = "Energy Tonic"},
            new FilteredItem { ShouldFilter = false, ItemId ="913" , Name = "Enricher"},
            new FilteredItem { ShouldFilter = false, ItemId ="729" , Name = "Escargot"},
            new FilteredItem { ShouldFilter = false, ItemId ="544" , Name = "Esperite"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1208" , Name = "Excavator Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="441" , Name = "Explosive Ammo"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)24" , Name = "Eye Patch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1279" , Name = "Faded Denim Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)FairyBox" , Name = "Fairy Box"},
            new FilteredItem { ShouldFilter = false, ItemId ="872" , Name = "Fairy Dust"},
            new FilteredItem { ShouldFilter = false, ItemId ="595" , Name = "Fairy Rose"},
            new FilteredItem { ShouldFilter = false, ItemId ="425" , Name = "Fairy Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="577" , Name = "Fairy Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1153" , Name = "Fake Muscles Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="497" , Name = "Fall Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1035" , Name = "Fancy Red Blouse"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)65" , Name = "Fancy Table"},
            new FilteredItem { ShouldFilter = false, ItemId ="FarAwayStone" , Name = "Far Away Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)239" , Name = "Farm Computer"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)0" , Name = "Farmer Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="240" , Name = "Farmer's Lunch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)47" , Name = "Fashion Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)19" , Name = "Fedora"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)99" , Name = "Feed Hopper"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)31" , Name = "Femur"},
            new FilteredItem { ShouldFilter = false, ItemId ="771" , Name = "Fiber"},
            new FilteredItem { ShouldFilter = false, ItemId ="885" , Name = "Fiber Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="259" , Name = "Fiddlehead Fern"},
            new FilteredItem { ShouldFilter = false, ItemId ="649" , Name = "Fiddlehead Risotto"},
            new FilteredItem { ShouldFilter = false, ItemId ="403" , Name = "Field Snack"},
            new FilteredItem { ShouldFilter = false, ItemId ="565" , Name = "Fire Opal"},
            new FilteredItem { ShouldFilter = false, ItemId ="82" , Name = "Fire Quartz"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)512" , Name = "Firewalker Boots"},
            new FilteredItem { ShouldFilter = false, ItemId ="895" , Name = "Fireworks (Green)"},
            new FilteredItem { ShouldFilter = false, ItemId ="894" , Name = "Fireworks (Purple)"},
            new FilteredItem { ShouldFilter = false, ItemId ="893" , Name = "Fireworks (Red)"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1158" , Name = "Fish Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)FishSmoker" , Name = "Fish Smoker"},
            new FilteredItem { ShouldFilter = false, ItemId ="728" , Name = "Fish Stew"},
            new FilteredItem { ShouldFilter = false, ItemId ="213" , Name = "Fish Taco"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)55" , Name = "Fishing Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1157" , Name = "Fishing Vest"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1226" , Name = "Flames Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1154" , Name = "Flannel Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)63" , Name = "Flat Topped Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)54" , Name = "Floppy Beanie"},
            new FilteredItem { ShouldFilter = false, ItemId ="267" , Name = "Flounder"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1235" , Name = "Fluffy Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="545" , Name = "Fluorapatite"},
            new FilteredItem { ShouldFilter = false, ItemId ="464" , Name = "Flute Block"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)90" , Name = "Forager's Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)15" , Name = "Forest Sword"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)162" , Name = "Foroguemon??"},
            new FilteredItem { ShouldFilter = false, ItemId ="823" , Name = "Fossilized Leg"},
            new FilteredItem { ShouldFilter = false, ItemId ="824" , Name = "Fossilized Ribs"},
            new FilteredItem { ShouldFilter = false, ItemId ="820" , Name = "Fossilized Skull"},
            new FilteredItem { ShouldFilter = false, ItemId ="821" , Name = "Fossilized Spine"},
            new FilteredItem { ShouldFilter = false, ItemId ="822" , Name = "Fossilized Tail"},
            new FilteredItem { ShouldFilter = false, ItemId ="202" , Name = "Fried Calamari"},
            new FilteredItem { ShouldFilter = false, ItemId ="225" , Name = "Fried Eel"},
            new FilteredItem { ShouldFilter = false, ItemId ="194" , Name = "Fried Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1246" , Name = "Fried Egg Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="205" , Name = "Fried Mushroom"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Friendship" , Name = "Friendship 101"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1283" , Name = "Fringed Vest"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)FrogEgg" , Name = "Frog Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)78" , Name = "Frog Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="536" , Name = "Frozen Geode"},
            new FilteredItem { ShouldFilter = false, ItemId ="84" , Name = "Frozen Tear"},
            new FilteredItem { ShouldFilter = false, ItemId ="610" , Name = "Fruit Salad"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)13" , Name = "Furnace"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)23" , Name = "Galaxy Dagger"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)29" , Name = "Galaxy Hammer"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)34" , Name = "Galaxy Slingshot"},
            new FilteredItem { ShouldFilter = false, ItemId ="896" , Name = "Galaxy Soul"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)4" , Name = "Galaxy Sword"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)66" , Name = "Garbage Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)62" , Name = "Garden Pot"},
            new FilteredItem { ShouldFilter = false, ItemId ="248" , Name = "Garlic"},
            new FilteredItem { ShouldFilter = false, ItemId ="476" , Name = "Garlic Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="325" , Name = "Gate"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1170" , Name = "Gaudy Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="546" , Name = "Geminite"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)8" , Name = "Genie Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)513" , Name = "Genie Shoes"},
            new FilteredItem { ShouldFilter = false, ItemId ="535" , Name = "Geode"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)182" , Name = "Geode Crusher"},
            new FilteredItem { ShouldFilter = false, ItemId ="561" , Name = "Ghost Crystal"},
            new FilteredItem { ShouldFilter = false, ItemId ="156" , Name = "Ghostfish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)GilsHat" , Name = "Gil's Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="829" , Name = "Ginger"},
            new FilteredItem { ShouldFilter = false, ItemId ="903" , Name = "Ginger Ale"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1292" , Name = "Ginger Overalls"},
            new FilteredItem { ShouldFilter = false, ItemId ="775" , Name = "Glacierfish"},
            new FilteredItem { ShouldFilter = false, ItemId ="902" , Name = "Glacierfish Jr."},
            new FilteredItem { ShouldFilter = false, ItemId ="118" , Name = "Glass Shards"},
            new FilteredItem { ShouldFilter = false, ItemId ="208" , Name = "Glazed Yams"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1284" , Name = "Globby Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="517" , Name = "Glow Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="888" , Name = "Glowstone Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)23" , Name = "Gnome's Cap"},
            new FilteredItem { ShouldFilter = false, ItemId ="426" , Name = "Goat Cheese"},
            new FilteredItem { ShouldFilter = false, ItemId ="436" , Name = "Goat Milk"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)9" , Name = "Goblin Mask"},
            new FilteredItem { ShouldFilter = false, ItemId ="Goby" , Name = "Goby"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)89" , Name = "Goggles"},
            new FilteredItem { ShouldFilter = false, ItemId ="336" , Name = "Gold Bar"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)145" , Name = "Gold Brazier"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1150" , Name = "Gold Breastplate"},
            new FilteredItem { ShouldFilter = false, ItemId ="GoldCoin" , Name = "Gold Coin"},
            new FilteredItem { ShouldFilter = false, ItemId ="384" , Name = "Gold Ore"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)GoldPanHat" , Name = "Gold Pan"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1222" , Name = "Gold Trimmed Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="GoldenAnimalCracker" , Name = "Golden Animal Cracker"},
            new FilteredItem { ShouldFilter = false, ItemId ="GoldenBobber" , Name = "Golden Bobber"},
            new FilteredItem { ShouldFilter = false, ItemId ="791" , Name = "Golden Coconut"},
            new FilteredItem { ShouldFilter = false, ItemId ="928" , Name = "Golden Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)75" , Name = "Golden Helmet"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)67" , Name = "Golden Mask"},
            new FilteredItem { ShouldFilter = false, ItemId ="124" , Name = "Golden Mask"},
            new FilteredItem { ShouldFilter = false, ItemId ="GoldenMysteryBox" , Name = "Golden Mystery Box"},
            new FilteredItem { ShouldFilter = false, ItemId ="373" , Name = "Golden Pumpkin"},
            new FilteredItem { ShouldFilter = false, ItemId ="125" , Name = "Golden Relic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)53" , Name = "Golden Scythe"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1238" , Name = "Golden Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)IridiumSpur" , Name = "Golden Spur"},
            new FilteredItem { ShouldFilter = false, ItemId ="TroutDerbyTag" , Name = "Golden Tag"},
            new FilteredItem { ShouldFilter = false, ItemId ="73" , Name = "Golden Walnut"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1008" , Name = "Good Grief Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)18" , Name = "Good Ol' Cap"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1188" , Name = "Goodnight Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="865" , Name = "Gourmet Tomato Salt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)GovernorsHat" , Name = "Governor's Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)68" , Name = "Grandfather Clock"},
            new FilteredItem { ShouldFilter = false, ItemId ="569" , Name = "Granite"},
            new FilteredItem { ShouldFilter = false, ItemId ="398" , Name = "Grape"},
            new FilteredItem { ShouldFilter = false, ItemId ="301" , Name = "Grape Starter"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)6" , Name = "Grass Skirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="297" , Name = "Grass Starter"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)47" , Name = "Grave Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="407" , Name = "Gravel Path"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1160" , Name = "Gray Hoodie"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1183" , Name = "Gray Suit"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1167" , Name = "Gray Vest"},
            new FilteredItem { ShouldFilter = false, ItemId ="153" , Name = "Green Algae"},
            new FilteredItem { ShouldFilter = false, ItemId ="188" , Name = "Green Bean"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1011" , Name = "Green Belted Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1189" , Name = "Green Belted Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1281" , Name = "Green Buttoned Vest"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)41" , Name = "Green Canes"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1255" , Name = "Green Flannel Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1270" , Name = "Green Jacket Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1007" , Name = "Green Overalls"},
            new FilteredItem { ShouldFilter = false, ItemId ="680" , Name = "Green Slime Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="614" , Name = "Green Tea"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1205" , Name = "Green Thumb Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1034" , Name = "Green Tunic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)72" , Name = "Green Turban"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1020" , Name = "Green Vest"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds0" , Name = "GreenRainWeeds0"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds1" , Name = "GreenRainWeeds1"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds2" , Name = "GreenRainWeeds2"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds3" , Name = "GreenRainWeeds3"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds4" , Name = "GreenRainWeeds4"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds5" , Name = "GreenRainWeeds5"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds6" , Name = "GreenRainWeeds6"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds7" , Name = "GreenRainWeeds7"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)49" , Name = "Hair Bone"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)42" , Name = "Haley's Iron"},
            new FilteredItem { ShouldFilter = false, ItemId ="742" , Name = "Haley's Lost Bracelet"},
            new FilteredItem { ShouldFilter = false, ItemId ="708" , Name = "Halibut"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1190" , Name = "Happy Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)27" , Name = "Hard Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="709" , Name = "Hardwood"},
            new FilteredItem { ShouldFilter = false, ItemId ="298" , Name = "Hardwood Fence"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)37" , Name = "Harvey's Mallet"},
            new FilteredItem { ShouldFilter = false, ItemId ="210" , Name = "Hashbrowns"},
            new FilteredItem { ShouldFilter = false, ItemId ="178" , Name = "Hay"},
            new FilteredItem { ShouldFilter = false, ItemId ="408" , Name = "Hazelnut"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1028" , Name = "Heart Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1210" , Name = "Heart Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)104" , Name = "Heater"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)HeavyFurnace" , Name = "Heavy Furnace"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)264" , Name = "Heavy Tapper"},
            new FilteredItem { ShouldFilter = false, ItemId ="929" , Name = "Hedge"},
            new FilteredItem { ShouldFilter = false, ItemId ="547" , Name = "Helvite"},
            new FilteredItem { ShouldFilter = false, ItemId ="573" , Name = "Hematite"},
            new FilteredItem { ShouldFilter = false, ItemId ="147" , Name = "Herring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1225" , Name = "High Heat Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1174" , Name = "High-Waisted Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1175" , Name = "High-Waisted Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)155" , Name = "HMTGF"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1186" , Name = "Holiday Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="283" , Name = "Holly"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)3" , Name = "Holy Blade"},
            new FilteredItem { ShouldFilter = false, ItemId ="340" , Name = "Honey"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)275" , Name = "Hopper"},
            new FilteredItem { ShouldFilter = false, ItemId ="304" , Name = "Hops"},
            new FilteredItem { ShouldFilter = false, ItemId ="302" , Name = "Hops Starter"},
            new FilteredItem { ShouldFilter = false, ItemId ="911" , Name = "Horse Flute"},
            new FilteredItem { ShouldFilter = false, ItemId ="860" , Name = "Hot Java Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="260" , Name = "Hot Pepper"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1295" , Name = "Hot Pink Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)0" , Name = "House Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)1" , Name = "House Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)2" , Name = "House Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)3" , Name = "House Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)4" , Name = "House Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)5" , Name = "House Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)6" , Name = "House Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)7" , Name = "House Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)15" , Name = "Hunter's Cap"},
            new FilteredItem { ShouldFilter = false, ItemId ="918" , Name = "Hyper Speed-Gro"},
            new FilteredItem { ShouldFilter = false, ItemId ="233" , Name = "Ice Cream"},
            new FilteredItem { ShouldFilter = false, ItemId ="161" , Name = "Ice Pip"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)IceRod" , Name = "Ice Rod"},
            new FilteredItem { ShouldFilter = false, ItemId ="887" , Name = "Immunity Band"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)101" , Name = "Incubator"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)62" , Name = "Infinity Blade"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)InfinityCrown" , Name = "Infinity Crown"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)64" , Name = "Infinity Dagger"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)63" , Name = "Infinity Gavel"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)13" , Name = "Insect Head"},
            new FilteredItem { ShouldFilter = false, ItemId ="527" , Name = "Iridium Band"},
            new FilteredItem { ShouldFilter = false, ItemId ="337" , Name = "Iridium Bar"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1151" , Name = "Iridium Breastplate"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1179" , Name = "Iridium Energy Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="803" , Name = "Iridium Milk"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)61" , Name = "Iridium Needle"},
            new FilteredItem { ShouldFilter = false, ItemId ="386" , Name = "Iridium Ore"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)IridiumPanHat" , Name = "Iridium Pan"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)66" , Name = "Iridium Scythe"},
            new FilteredItem { ShouldFilter = false, ItemId ="645" , Name = "Iridium Sprinkler"},
            new FilteredItem { ShouldFilter = false, ItemId ="335" , Name = "Iron Bar"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)17" , Name = "Iron Dirk"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)6" , Name = "Iron Edge"},
            new FilteredItem { ShouldFilter = false, ItemId ="324" , Name = "Iron Fence"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)153" , Name = "Iron Lamp-post"},
            new FilteredItem { ShouldFilter = false, ItemId ="380" , Name = "Iron Ore"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1297" , Name = "Island Bikini"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)221" , Name = "Item Pedestal"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Defense" , Name = "Jack Be Nimble, Jack Be Thick"},
            new FilteredItem { ShouldFilter = false, ItemId ="746" , Name = "Jack-O-Lantern"},
            new FilteredItem { ShouldFilter = false, ItemId ="70" , Name = "Jade"},
            new FilteredItem { ShouldFilter = false, ItemId ="532" , Name = "Jade Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="549" , Name = "Jagoite"},
            new FilteredItem { ShouldFilter = false, ItemId ="548" , Name = "Jamborite"},
            new FilteredItem { ShouldFilter = false, ItemId ="563" , Name = "Jasper"},
            new FilteredItem { ShouldFilter = false, ItemId ="429" , Name = "Jazz Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="344" , Name = "Jelly"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)JesterHat" , Name = "Jester Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1192" , Name = "Jester Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1230" , Name = "Jewelry Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Roe" , Name = "Jewels Of The Sea"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)JojaCap" , Name = "Joja Cap"},
            new FilteredItem { ShouldFilter = false, ItemId ="167" , Name = "Joja Cola"},
            new FilteredItem { ShouldFilter = false, ItemId ="842" , Name = "Journal Scrap"},
            new FilteredItem { ShouldFilter = false, ItemId ="350" , Name = "Juice"},
            new FilteredItem { ShouldFilter = false, ItemId ="528" , Name = "Jukebox Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)256" , Name = "Junimo Chest"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)JunimoHat" , Name = "Junimo Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)159" , Name = "Junimo Kart Arcade System"},
            new FilteredItem { ShouldFilter = false, ItemId ="250" , Name = "Kale"},
            new FilteredItem { ShouldFilter = false, ItemId ="477" , Name = "Kale Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)12" , Name = "Keg"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1168" , Name = "Kelp Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)50" , Name = "Knight's Helmet"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)46" , Name = "Kudgel"},
            new FilteredItem { ShouldFilter = false, ItemId ="550" , Name = "Kyanite"},
            new FilteredItem { ShouldFilter = false, ItemId ="438" , Name = "L. Goat Milk"},
            new FilteredItem { ShouldFilter = false, ItemId ="174" , Name = "Large Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="182" , Name = "Large Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="186" , Name = "Large Milk"},
            new FilteredItem { ShouldFilter = false, ItemId ="136" , Name = "Largemouth Bass"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)LaurelWreathCrown" , Name = "Laurel Wreath Crown"},
            new FilteredItem { ShouldFilter = false, ItemId ="162" , Name = "Lava Eel"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)9" , Name = "Lava Katana"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)36" , Name = "Lawn Flamingo"},
            new FilteredItem { ShouldFilter = false, ItemId ="692" , Name = "Lead Bobber"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)26" , Name = "Lead Rod"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1187" , Name = "Leafy Top"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)39" , Name = "Leah's Whittler"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)506" , Name = "Leather Boots"},
            new FilteredItem { ShouldFilter = false, ItemId ="20" , Name = "Leek"},
            new FilteredItem { ShouldFilter = false, ItemId ="163" , Name = "Legend"},
            new FilteredItem { ShouldFilter = false, ItemId ="900" , Name = "Legend II"},
            new FilteredItem { ShouldFilter = false, ItemId ="554" , Name = "Lemon Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)LeprechuanHat" , Name = "Leprechaun Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)806" , Name = "Leprechaun Shoes"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1137" , Name = "Letterman Jacket"},
            new FilteredItem { ShouldFilter = false, ItemId ="773" , Name = "Life Elixir"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1005" , Name = "Light Blue Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1026" , Name = "Light Blue Striped Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)9" , Name = "Lightning Rod"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1012" , Name = "Lime Green Striped Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1042" , Name = "Lime Green Tunic"},
            new FilteredItem { ShouldFilter = false, ItemId ="571" , Name = "Limestone"},
            new FilteredItem { ShouldFilter = false, ItemId ="707" , Name = "Lingcod"},
            new FilteredItem { ShouldFilter = false, ItemId ="837" , Name = "Lionfish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)40" , Name = "Living Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="715" , Name = "Lobster"},
            new FilteredItem { ShouldFilter = false, ItemId ="730" , Name = "Lobster Bisque"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)81" , Name = "Locked Door"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)82" , Name = "Locked Door"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)46" , Name = "Log Section"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)45" , Name = "Logo Cap"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)2" , Name = "Long Dress"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)17" , Name = "Loom"},
            new FilteredItem { ShouldFilter = false, ItemId ="788" , Name = "Lost Axe"},
            new FilteredItem { ShouldFilter = false, ItemId ="102" , Name = "Lost Book"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)7" , Name = "Luau Skirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)21" , Name = "Lucky Bow"},
            new FilteredItem { ShouldFilter = false, ItemId ="204" , Name = "Lucky Lunch"},
            new FilteredItem { ShouldFilter = false, ItemId ="789" , Name = "Lucky Purple Shorts"},
            new FilteredItem { ShouldFilter = false, ItemId ="859" , Name = "Lucky Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="30" , Name = "Lumber"},
            new FilteredItem { ShouldFilter = false, ItemId ="551" , Name = "Lunarite"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1291" , Name = "Magenta Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="908" , Name = "Magic Bait"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)73" , Name = "Magic Cowboy Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)MagicHairDye" , Name = "Magic Hair Gel"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)MagicQuiver" , Name = "Magic Quiver"},
            new FilteredItem { ShouldFilter = false, ItemId ="279" , Name = "Magic Rock Candy"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1997" , Name = "Magic Sprinkle Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)74" , Name = "Magic Turban"},
            new FilteredItem { ShouldFilter = false, ItemId ="851" , Name = "Magma Cap"},
            new FilteredItem { ShouldFilter = false, ItemId ="537" , Name = "Magma Geode"},
            new FilteredItem { ShouldFilter = false, ItemId ="703" , Name = "Magnet"},
            new FilteredItem { ShouldFilter = false, ItemId ="519" , Name = "Magnet Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="292" , Name = "Mahogany Seed"},
            new FilteredItem { ShouldFilter = false, ItemId ="228" , Name = "Maki Roll"},
            new FilteredItem { ShouldFilter = false, ItemId ="552" , Name = "Malachite"},
            new FilteredItem { ShouldFilter = false, ItemId ="834" , Name = "Mango"},
            new FilteredItem { ShouldFilter = false, ItemId ="835" , Name = "Mango Sapling"},
            new FilteredItem { ShouldFilter = false, ItemId ="905" , Name = "Mango Sticky Rice"},
            new FilteredItem { ShouldFilter = false, ItemId ="731" , Name = "Maple Bar"},
            new FilteredItem { ShouldFilter = false, ItemId ="310" , Name = "Maple Seed"},
            new FilteredItem { ShouldFilter = false, ItemId ="724" , Name = "Maple Syrup"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Marlon" , Name = "Mapping Cave Systems"},
            new FilteredItem { ShouldFilter = false, ItemId ="567" , Name = "Marble"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)151" , Name = "Marble Brazier"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)36" , Name = "Maru's Wrench"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)33" , Name = "Master Slingshot"},
            new FilteredItem { ShouldFilter = false, ItemId ="306" , Name = "Mayonnaise"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)24" , Name = "Mayonnaise Machine"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1017" , Name = "Mayoral Suspenders"},
            new FilteredItem { ShouldFilter = false, ItemId ="459" , Name = "Mead"},
            new FilteredItem { ShouldFilter = false, ItemId ="288" , Name = "Mega Bomb"},
            new FilteredItem { ShouldFilter = false, ItemId ="254" , Name = "Melon"},
            new FilteredItem { ShouldFilter = false, ItemId ="479" , Name = "Melon Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)65" , Name = "Meowmere"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)854" , Name = "Mermaid Boots"},
            new FilteredItem { ShouldFilter = false, ItemId ="460" , Name = "Mermaid's Pendant"},
            new FilteredItem { ShouldFilter = false, ItemId ="269" , Name = "Midnight Carp"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1285" , Name = "Midnight Dog Jacket"},
            new FilteredItem { ShouldFilter = false, ItemId ="798" , Name = "Midnight Squid"},
            new FilteredItem { ShouldFilter = false, ItemId ="184" , Name = "Milk"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1290" , Name = "Mineral Dog Jacket"},
            new FilteredItem { ShouldFilter = false, ItemId ="243" , Name = "Miner's Treat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)MiniForge" , Name = "Mini-Forge"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)216" , Name = "Mini-Fridge"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)209" , Name = "Mini-Jukebox"},
            new FilteredItem { ShouldFilter = false, ItemId ="SkillBook_3" , Name = "Mining Monthly"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)238" , Name = "Mini-Obelisk"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)248" , Name = "Mini-Shipping Bin"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1002" , Name = "Mint Blouse"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)42" , Name = "Mixed Cane"},
            new FilteredItem { ShouldFilter = false, ItemId ="MixedFlowerSeeds" , Name = "Mixed Flower Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="770" , Name = "Mixed Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Void" , Name = "Monster Compendium"},
            new FilteredItem { ShouldFilter = false, ItemId ="879" , Name = "Monster Musk"},
            new FilteredItem { ShouldFilter = false, ItemId ="257" , Name = "Morel"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1257" , Name = "Morel Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="Moss" , Name = "Moss"},
            new FilteredItem { ShouldFilter = false, ItemId ="MossSoup" , Name = "Moss Soup"},
            new FilteredItem { ShouldFilter = false, ItemId ="MossySeed" , Name = "Mossy Seed"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)31" , Name = "Mouse Ears"},
            new FilteredItem { ShouldFilter = false, ItemId ="809" , Name = "Movie Ticket"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)82" , Name = "Mr. Qi's Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="899" , Name = "Ms. Angler"},
            new FilteredItem { ShouldFilter = false, ItemId ="574" , Name = "Mudstone"},
            new FilteredItem { ShouldFilter = false, ItemId ="827" , Name = "Mummified Bat"},
            new FilteredItem { ShouldFilter = false, ItemId ="828" , Name = "Mummified Frog"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)MummyMask" , Name = "Mummy Mask"},
            new FilteredItem { ShouldFilter = false, ItemId ="351" , Name = "Muscle Remedy"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)128" , Name = "Mushroom Box"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)42" , Name = "Mushroom Cap"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)MushroomLog" , Name = "Mushroom Log"},
            new FilteredItem { ShouldFilter = false, ItemId ="891" , Name = "Mushroom Tree Seed"},
            new FilteredItem { ShouldFilter = false, ItemId ="719" , Name = "Mussel"},
            new FilteredItem { ShouldFilter = false, ItemId ="682" , Name = "Mutant Carp"},
            new FilteredItem { ShouldFilter = false, ItemId ="MysteryBox" , Name = "Mystery Box"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)MysteryHat" , Name = "Mystery Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)MysteryShirt" , Name = "Mystery Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="MysticSyrup" , Name = "Mystic Syrup"},
            new FilteredItem { ShouldFilter = false, ItemId ="MysticTreeSeed" , Name = "Mystic Tree Seed"},
            new FilteredItem { ShouldFilter = false, ItemId ="811" , Name = "Napalm Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="586" , Name = "Nautilus Fossil"},
            new FilteredItem { ShouldFilter = false, ItemId ="392" , Name = "Nautilus Shell"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1185" , Name = "Navy Tuxedo"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1087" , Name = "Neat Bow Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1173" , Name = "Neat Bow Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1220" , Name = "Necklace Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="555" , Name = "Nekoite"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)14" , Name = "Neptune's Glaive"},
            new FilteredItem { ShouldFilter = false, ItemId ="553" , Name = "Neptunite"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1016" , Name = "Night Sky Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="725" , Name = "Oak Resin"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1171" , Name = "Oasis Gown"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)29" , Name = "Obelisk"},
            new FilteredItem { ShouldFilter = false, ItemId ="575" , Name = "Obsidian"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)8" , Name = "Obsidian Edge"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)89" , Name = "Obsidian Vase"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1193" , Name = "Ocean Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="560" , Name = "Ocean Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="149" , Name = "Octopus"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1240" , Name = "Officer Uniform"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)5" , Name = "Official Cap"},
            new FilteredItem { ShouldFilter = false, ItemId ="247" , Name = "Oil"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)19" , Name = "Oil Maker"},
            new FilteredItem { ShouldFilter = false, ItemId ="772" , Name = "Oil of Garlic"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1256" , Name = "Oil Stained Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="195" , Name = "Omelet"},
            new FilteredItem { ShouldFilter = false, ItemId ="749" , Name = "Omni Geode"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1264" , Name = "Omni Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="564" , Name = "Opal"},
            new FilteredItem { ShouldFilter = false, ItemId ="635" , Name = "Orange"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1267" , Name = "Orange Bow Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1166" , Name = "Orange Gi"},
            new FilteredItem { ShouldFilter = false, ItemId ="630" , Name = "Orange Sapling"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1015" , Name = "Orange Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="106" , Name = "Ornamental Fan"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)45" , Name = "Ornamental Hay Bale"},
            new FilteredItem { ShouldFilter = false, ItemId ="191" , Name = "Ornate Necklace"},
            new FilteredItem { ShouldFilter = false, ItemId ="556" , Name = "Orpiment"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)60" , Name = "Ossified Blade"},
            new FilteredItem { ShouldFilter = false, ItemId ="289" , Name = "Ostrich Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)254" , Name = "Ostrich Incubator"},
            new FilteredItem { ShouldFilter = false, ItemId ="723" , Name = "Oyster"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)PageboyCap" , Name = "Pageboy Cap"},
            new FilteredItem { ShouldFilter = false, ItemId ="303" , Name = "Pale Ale"},
            new FilteredItem { ShouldFilter = false, ItemId ="457" , Name = "Pale Broth"},
            new FilteredItem { ShouldFilter = false, ItemId ="588" , Name = "Palm Fossil"},
            new FilteredItem { ShouldFilter = false, ItemId ="211" , Name = "Pancakes"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)36" , Name = "Panda Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)PaperHat" , Name = "Paper Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(TR)ParrotEgg" , Name = "Parrot Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="24" , Name = "Parsnip"},
            new FilteredItem { ShouldFilter = false, ItemId ="472" , Name = "Parsnip Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="199" , Name = "Parsnip Soup"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)57" , Name = "Party Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)58" , Name = "Party Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)59" , Name = "Party Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="636" , Name = "Peach"},
            new FilteredItem { ShouldFilter = false, ItemId ="631" , Name = "Peach Sapling"},
            new FilteredItem { ShouldFilter = false, ItemId ="797" , Name = "Pearl"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1224" , Name = "Pendant Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)38" , Name = "Penny's Fryer"},
            new FilteredItem { ShouldFilter = false, ItemId ="215" , Name = "Pepper Poppers"},
            new FilteredItem { ShouldFilter = false, ItemId ="482" , Name = "Pepper Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="141" , Name = "Perch"},
            new FilteredItem { ShouldFilter = false, ItemId ="722" , Name = "Periwinkle"},
            new FilteredItem { ShouldFilter = false, ItemId ="PetLicense" , Name = "Pet License"},
            new FilteredItem { ShouldFilter = false, ItemId ="557" , Name = "Petrified Slime"},
            new FilteredItem { ShouldFilter = false, ItemId ="863" , Name = "Phoenix Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="342" , Name = "Pickles"},
            new FilteredItem { ShouldFilter = false, ItemId ="897" , Name = "Pierre's Missing Stocklist"},
            new FilteredItem { ShouldFilter = false, ItemId ="144" , Name = "Pike"},
            new FilteredItem { ShouldFilter = false, ItemId ="873" , Name = "Piña Colada"},
            new FilteredItem { ShouldFilter = false, ItemId ="311" , Name = "Pine Cone"},
            new FilteredItem { ShouldFilter = false, ItemId ="726" , Name = "Pine Tar"},
            new FilteredItem { ShouldFilter = false, ItemId ="832" , Name = "Pineapple"},
            new FilteredItem { ShouldFilter = false, ItemId ="833" , Name = "Pineapple Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)77" , Name = "Pink Bow"},
            new FilteredItem { ShouldFilter = false, ItemId ="221" , Name = "Pink Cake"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1027" , Name = "Pink Striped Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)161" , Name = "Pinky Lemon"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)62" , Name = "Pirate Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="870" , Name = "Pirate's Locket"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)43" , Name = "Pirate's Sword"},
            new FilteredItem { ShouldFilter = false, ItemId ="206" , Name = "Pizza"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1216" , Name = "Plain Overalls"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1041" , Name = "Plain Shirt (F)"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1038" , Name = "Plain Shirt (M)"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)4" , Name = "Pleated Skirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)7" , Name = "Plum Chapeau"},
            new FilteredItem { ShouldFilter = false, ItemId ="604" , Name = "Plum Pudding"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)107" , Name = "Plush Bunny"},
            new FilteredItem { ShouldFilter = false, ItemId ="906" , Name = "Poi"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)22" , Name = "Polka Bow"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1272" , Name = "Polka Dot Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)14" , Name = "Polka Dot Shorts"},
            new FilteredItem { ShouldFilter = false, ItemId ="637" , Name = "Pomegranate"},
            new FilteredItem { ShouldFilter = false, ItemId ="632" , Name = "Pomegranate Sapling"},
            new FilteredItem { ShouldFilter = false, ItemId ="376" , Name = "Poppy"},
            new FilteredItem { ShouldFilter = false, ItemId ="453" , Name = "Poppy Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="651" , Name = "Poppyseed Muffin"},
            new FilteredItem { ShouldFilter = false, ItemId ="192" , Name = "Potato"},
            new FilteredItem { ShouldFilter = false, ItemId ="475" , Name = "Potato Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="PotOfGold" , Name = "PotOfGold"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1269" , Name = "Pour-Over Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="Powdermelon" , Name = "Powdermelon"},
            new FilteredItem { ShouldFilter = false, ItemId ="PowdermelonSeeds" , Name = "Powdermelon Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)141" , Name = "Prairie King Arcade System"},
            new FilteredItem { ShouldFilter = false, ItemId ="120" , Name = "Prehistoric Handaxe"},
            new FilteredItem { ShouldFilter = false, ItemId ="583" , Name = "Prehistoric Rib"},
            new FilteredItem { ShouldFilter = false, ItemId ="579" , Name = "Prehistoric Scapula"},
            new FilteredItem { ShouldFilter = false, ItemId ="581" , Name = "Prehistoric Skull"},
            new FilteredItem { ShouldFilter = false, ItemId ="580" , Name = "Prehistoric Tibia"},
            new FilteredItem { ShouldFilter = false, ItemId ="115" , Name = "Prehistoric Tool"},
            new FilteredItem { ShouldFilter = false, ItemId ="584" , Name = "Prehistoric Vertebra"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)15" , Name = "Preserves Jar"},
            new FilteredItem { ShouldFilter = false, ItemId ="915" , Name = "Pressure Nozzle"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_PriceCatalogue" , Name = "Price Catalogue"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)999" , Name = "Prismatic Genie Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="876" , Name = "Prismatic Jelly"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)998" , Name = "Prismatic Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="74" , Name = "Prismatic Shard"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1223" , Name = "Prismatic Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1998" , Name = "Prismatic Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1999" , Name = "Prismatic Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="PrizeTicket" , Name = "Prize Ticket"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)68" , Name = "Propeller Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="861" , Name = "Protection Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="128" , Name = "Pufferfish"},
            new FilteredItem { ShouldFilter = false, ItemId ="276" , Name = "Pumpkin"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)48" , Name = "Pumpkin Mask"},
            new FilteredItem { ShouldFilter = false, ItemId ="608" , Name = "Pumpkin Pie"},
            new FilteredItem { ShouldFilter = false, ItemId ="490" , Name = "Pumpkin Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="236" , Name = "Pumpkin Soup"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1197" , Name = "Purple Blouse"},
            new FilteredItem { ShouldFilter = false, ItemId ="422" , Name = "Purple Mushroom"},
            new FilteredItem { ShouldFilter = false, ItemId ="439" , Name = "Purple Slime Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="559" , Name = "Pyrite"},
            new FilteredItem { ShouldFilter = false, ItemId ="890" , Name = "Qi Bean"},
            new FilteredItem { ShouldFilter = false, ItemId ="889" , Name = "Qi Fruit"},
            new FilteredItem { ShouldFilter = false, ItemId ="858" , Name = "Qi Gem"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)86" , Name = "Qi Mask"},
            new FilteredItem { ShouldFilter = false, ItemId ="917" , Name = "Qi Seasoning"},
            new FilteredItem { ShouldFilter = false, ItemId ="877" , Name = "Quality Bobber"},
            new FilteredItem { ShouldFilter = false, ItemId ="369" , Name = "Quality Fertilizer"},
            new FilteredItem { ShouldFilter = false, ItemId ="371" , Name = "Quality Retaining Soil"},
            new FilteredItem { ShouldFilter = false, ItemId ="621" , Name = "Quality Sprinkler"},
            new FilteredItem { ShouldFilter = false, ItemId ="80" , Name = "Quartz"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_QueenOfSauce" , Name = "Queen Of Sauce Cookbook"},
            new FilteredItem { ShouldFilter = false, ItemId ="446" , Name = "Rabbit's Foot"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)RaccoonHat" , Name = "Raccoon Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="910" , Name = "Radioactive Bar"},
            new FilteredItem { ShouldFilter = false, ItemId ="901" , Name = "Radioactive Carp"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)84" , Name = "Radioactive Goggles"},
            new FilteredItem { ShouldFilter = false, ItemId ="909" , Name = "Radioactive Ore"},
            new FilteredItem { ShouldFilter = false, ItemId ="264" , Name = "Radish"},
            new FilteredItem { ShouldFilter = false, ItemId ="609" , Name = "Radish Salad"},
            new FilteredItem { ShouldFilter = false, ItemId ="484" , Name = "Radish Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1260" , Name = "Rain Coat"},
            new FilteredItem { ShouldFilter = false, ItemId ="681" , Name = "Rain Totem"},
            new FilteredItem { ShouldFilter = false, ItemId ="394" , Name = "Rainbow Shell"},
            new FilteredItem { ShouldFilter = false, ItemId ="138" , Name = "Rainbow Trout"},
            new FilteredItem { ShouldFilter = false, ItemId ="Raisins" , Name = "Raisins"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1241" , Name = "Ranger Uniform"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)49" , Name = "Rapier"},
            new FilteredItem { ShouldFilter = false, ItemId ="108" , Name = "Rare Disc"},
            new FilteredItem { ShouldFilter = false, ItemId ="347" , Name = "Rare Seed"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)110" , Name = "Rarecrow"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)113" , Name = "Rarecrow"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)126" , Name = "Rarecrow"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)136" , Name = "Rarecrow"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)137" , Name = "Rarecrow"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)138" , Name = "Rarecrow"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)139" , Name = "Rarecrow"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)140" , Name = "Rarecrow"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)20" , Name = "Recycling Machine"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1280" , Name = "Red Buttoned Vest"},
            new FilteredItem { ShouldFilter = false, ItemId ="266" , Name = "Red Cabbage"},
            new FilteredItem { ShouldFilter = false, ItemId ="485" , Name = "Red Cabbage Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)43" , Name = "Red Canes"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)38" , Name = "Red Cowboy Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)RedFez" , Name = "Red Fez"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1251" , Name = "Red Flannel Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1162" , Name = "Red Hoodie"},
            new FilteredItem { ShouldFilter = false, ItemId ="146" , Name = "Red Mullet"},
            new FilteredItem { ShouldFilter = false, ItemId ="420" , Name = "Red Mushroom"},
            new FilteredItem { ShouldFilter = false, ItemId ="230" , Name = "Red Plate"},
            new FilteredItem { ShouldFilter = false, ItemId ="437" , Name = "Red Slime Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="150" , Name = "Red Snapper"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1013" , Name = "Red Striped Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1184" , Name = "Red Tuxedo"},
            new FilteredItem { ShouldFilter = false, ItemId ="338" , Name = "Refined Quartz"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1243" , Name = "Regal Mantle"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)12" , Name = "Relaxed Fit Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)13" , Name = "Relaxed Fit Shorts"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1244" , Name = "Relic Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1039" , Name = "Retro Rainbow Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="252" , Name = "Rhubarb"},
            new FilteredItem { ShouldFilter = false, ItemId ="222" , Name = "Rhubarb Pie"},
            new FilteredItem { ShouldFilter = false, ItemId ="478" , Name = "Rhubarb Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="423" , Name = "Rice"},
            new FilteredItem { ShouldFilter = false, ItemId ="232" , Name = "Rice Pudding"},
            new FilteredItem { ShouldFilter = false, ItemId ="273" , Name = "Rice Shoot"},
            new FilteredItem { ShouldFilter = false, ItemId ="524" , Name = "Ring of Yoba"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)73" , Name = "Ritual Mask"},
            new FilteredItem { ShouldFilter = false, ItemId ="RiverJelly" , Name = "River Jelly"},
            new FilteredItem { ShouldFilter = false, ItemId ="607" , Name = "Roasted Hazelnuts"},
            new FilteredItem { ShouldFilter = false, ItemId ="812" , Name = "Roe"},
            new FilteredItem { ShouldFilter = false, ItemId ="244" , Name = "Roots Platter"},
            new FilteredItem { ShouldFilter = false, ItemId ="747" , Name = "Rotten Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="748" , Name = "Rotten Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)505" , Name = "Rubber Boots"},
            new FilteredItem { ShouldFilter = false, ItemId ="64" , Name = "Ruby"},
            new FilteredItem { ShouldFilter = false, ItemId ="534" , Name = "Ruby Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="840" , Name = "Rustic Plank Floor"},
            new FilteredItem { ShouldFilter = false, ItemId ="112" , Name = "Rusty Cog"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1233" , Name = "Rusty Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="110" , Name = "Rusty Spoon"},
            new FilteredItem { ShouldFilter = false, ItemId ="111" , Name = "Rusty Spur"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)0" , Name = "Rusty Sword"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1019" , Name = "Sailor Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1259" , Name = "Sailor Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1261" , Name = "Sailor Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)17" , Name = "Sailor's Cap"},
            new FilteredItem { ShouldFilter = false, ItemId ="196" , Name = "Salad"},
            new FilteredItem { ShouldFilter = false, ItemId ="139" , Name = "Salmon"},
            new FilteredItem { ShouldFilter = false, ItemId ="212" , Name = "Salmon Dinner"},
            new FilteredItem { ShouldFilter = false, ItemId ="296" , Name = "Salmonberry"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)30" , Name = "Sam's Old Guitar"},
            new FilteredItem { ShouldFilter = false, ItemId ="164" , Name = "Sandfish"},
            new FilteredItem { ShouldFilter = false, ItemId ="568" , Name = "Sandstone"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)25" , Name = "Santa Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="92" , Name = "Sap"},
            new FilteredItem { ShouldFilter = false, ItemId ="131" , Name = "Sardine"},
            new FilteredItem { ShouldFilter = false, ItemId ="227" , Name = "Sashimi"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1236" , Name = "Sauce-Stained Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="523" , Name = "Savage Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)8" , Name = "Scarecrow"},
            new FilteredItem { ShouldFilter = false, ItemId ="165" , Name = "Scorpion Carp"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)47" , Name = "Scythe"},
            new FilteredItem { ShouldFilter = false, ItemId ="154" , Name = "Sea Cucumber"},
            new FilteredItem { ShouldFilter = false, ItemId ="SeaJelly" , Name = "Sea Jelly"},
            new FilteredItem { ShouldFilter = false, ItemId ="397" , Name = "Sea Urchin"},
            new FilteredItem { ShouldFilter = false, ItemId ="265" , Name = "Seafoam Pudding"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)48" , Name = "Seasonal Decor"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)184" , Name = "Seasonal Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)188" , Name = "Seasonal Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)192" , Name = "Seasonal Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)196" , Name = "Seasonal Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)200" , Name = "Seasonal Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)204" , Name = "Seasonal Plant"},
            new FilteredItem { ShouldFilter = false, ItemId ="152" , Name = "Seaweed"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)41" , Name = "Seb's Lost Mace"},
            new FilteredItem { ShouldFilter = false, ItemId ="79" , Name = "Secret Note"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)25" , Name = "Seed Maker"},
            new FilteredItem { ShouldFilter = false, ItemId ="SeedSpot" , Name = "Seed Spot"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)247" , Name = "Sewing Machine"},
            new FilteredItem { ShouldFilter = false, ItemId ="706" , Name = "Shad"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)19" , Name = "Shadow Dagger"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1001" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1022" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1023" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1024" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1025" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1031" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1032" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1033" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1036" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1037" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1040" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1043" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1044" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1045" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1046" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1047" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1048" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1049" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1050" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1051" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1052" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1053" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1054" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1055" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1056" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1057" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1058" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1059" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1060" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1061" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1062" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1063" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1064" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1065" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1066" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1067" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1068" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1069" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1070" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1072" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1073" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1074" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1075" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1076" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1077" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1078" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1079" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1080" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1081" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1082" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1083" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1084" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1085" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1086" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1088" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1089" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1090" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1091" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1092" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1093" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1094" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1095" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1096" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1097" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1098" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1099" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1100" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1101" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1102" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1103" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1104" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1105" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1106" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1107" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1108" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1109" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1110" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1111" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1112" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1113" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1114" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1115" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1116" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1117" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1118" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1119" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1120" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1121" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1122" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1124" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1125" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1126" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1144" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1145" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1146" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1147" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1181" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1182" , Name = "Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1159" , Name = "Shirt And Belt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1123" , Name = "Shirt And Tie"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1214" , Name = "Shirt O' The Sea"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1191" , Name = "Shirt with Bow"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1271" , Name = "Short Jacket"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)1" , Name = "Shorts"},
            new FilteredItem { ShouldFilter = false, ItemId ="720" , Name = "Shrimp"},
            new FilteredItem { ShouldFilter = false, ItemId ="733" , Name = "Shrimp Cocktail"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1286" , Name = "Shrimp Enthusiast Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)34" , Name = "Sign Of The Vessel"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1277" , Name = "Silky Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)1" , Name = "Silver Saber"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)11" , Name = "Simple Dress"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)94" , Name = "Singing Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="582" , Name = "Skeletal Hand"},
            new FilteredItem { ShouldFilter = false, ItemId ="585" , Name = "Skeletal Tail"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)8" , Name = "Skeleton Mask"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)28" , Name = "Skeleton Model"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1014" , Name = "Skeleton Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)3" , Name = "Skirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)149" , Name = "Skull Brazier"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1004" , Name = "Skull Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="576" , Name = "Slate"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1217" , Name = "Sleeveless Overalls"},
            new FilteredItem { ShouldFilter = false, ItemId ="766" , Name = "Slime"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)56" , Name = "Slime Ball"},
            new FilteredItem { ShouldFilter = false, ItemId ="520" , Name = "Slime Charmer Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="925" , Name = "Slime Crate"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)158" , Name = "Slime Egg-Press"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)156" , Name = "Slime Incubator"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1207" , Name = "Slime Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="796" , Name = "Slimejack"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)32" , Name = "Slingshot"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)85" , Name = "Sloth Skeleton L"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)86" , Name = "Sloth Skeleton M"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)87" , Name = "Sloth Skeleton R"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)79" , Name = "Small Cap"},
            new FilteredItem { ShouldFilter = false, ItemId ="516" , Name = "Small Glow Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="518" , Name = "Small Magnet Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="137" , Name = "Smallmouth Bass"},
            new FilteredItem { ShouldFilter = false, ItemId ="SmokedFish" , Name = "Smoked"},
            new FilteredItem { ShouldFilter = false, ItemId ="721" , Name = "Snail"},
            new FilteredItem { ShouldFilter = false, ItemId ="825" , Name = "Snake Skull"},
            new FilteredItem { ShouldFilter = false, ItemId ="826" , Name = "Snake Vertebrae"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)504" , Name = "Sneakers"},
            new FilteredItem { ShouldFilter = false, ItemId ="416" , Name = "Snow Yam"},
            new FilteredItem { ShouldFilter = false, ItemId ="572" , Name = "Soapstone"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)117" , Name = "Soda Machine"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1228" , Name = "Soft Arrow Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="172" , Name = "Soggy Newspaper"},
            new FilteredItem { ShouldFilter = false, ItemId ="768" , Name = "Solar Essence"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)231" , Name = "Solar Panel"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)164" , Name = "Solid Gold Lewis"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)3" , Name = "Sombrero"},
            new FilteredItem { ShouldFilter = false, ItemId ="898" , Name = "Son of Crimsonfish"},
            new FilteredItem { ShouldFilter = false, ItemId ="SonarBobber" , Name = "Sonar Bobber"},
            new FilteredItem { ShouldFilter = false, ItemId ="862" , Name = "Soul Sapper Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)28" , Name = "Sou'wester"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)514" , Name = "Space Boots"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)SpaceHelmet" , Name = "Space Helmet"},
            new FilteredItem { ShouldFilter = false, ItemId ="224" , Name = "Spaghetti"},
            new FilteredItem { ShouldFilter = false, ItemId ="455" , Name = "Spangle Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="465" , Name = "Speed-Gro"},
            new FilteredItem { ShouldFilter = false, ItemId ="396" , Name = "Spice Berry"},
            new FilteredItem { ShouldFilter = false, ItemId ="226" , Name = "Spicy Eel"},
            new FilteredItem { ShouldFilter = false, ItemId ="686" , Name = "Spinner"},
            new FilteredItem { ShouldFilter = false, ItemId ="94" , Name = "Spirit Torch"},
            new FilteredItem { ShouldFilter = false, ItemId ="799" , Name = "Spook Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)SportsCap" , Name = "Sports Cap"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1209" , Name = "Sports Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)52" , Name = "Spotted Headscarf"},
            new FilteredItem { ShouldFilter = false, ItemId ="399" , Name = "Spring Onion"},
            new FilteredItem { ShouldFilter = false, ItemId ="495" , Name = "Spring Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1258" , Name = "Spring Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="599" , Name = "Sprinkler"},
            new FilteredItem { ShouldFilter = false, ItemId ="151" , Name = "Squid"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)SquidHat" , Name = "Squid Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="814" , Name = "Squid Ink"},
            new FilteredItem { ShouldFilter = false, ItemId ="921" , Name = "Squid Ink Ravioli"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)51" , Name = "Squire's Helmet"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)71" , Name = "Staircase"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)88" , Name = "Standing Geode"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)87" , Name = "Star Helmet"},
            new FilteredItem { ShouldFilter = false, ItemId ="578" , Name = "Star Shards"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1200" , Name = "Star Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)116" , Name = "Stardew Hero Trophy"},
            new FilteredItem { ShouldFilter = false, ItemId ="SkillBook_0" , Name = "Stardew Valley Almanac"},
            new FilteredItem { ShouldFilter = false, ItemId ="866" , Name = "Stardew Valley Rose"},
            new FilteredItem { ShouldFilter = false, ItemId ="434" , Name = "Stardrop"},
            new FilteredItem { ShouldFilter = false, ItemId ="StardropTea" , Name = "Stardrop Tea"},
            new FilteredItem { ShouldFilter = false, ItemId ="268" , Name = "Starfruit"},
            new FilteredItem { ShouldFilter = false, ItemId ="486" , Name = "Starfruit Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)StatueOfBlessings" , Name = "Statue Of Blessings"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)127" , Name = "Statue Of Endless Fortune"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)160" , Name = "Statue Of Perfection"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)StatueOfTheDwarfKing" , Name = "Statue Of The Dwarf King"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)280" , Name = "Statue Of True Perfection"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1148" , Name = "Steel Breastplate"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)50" , Name = "Steel Falchion"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)SteelPanHat" , Name = "Steel Pan"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)11" , Name = "Steel Smallsword"},
            new FilteredItem { ShouldFilter = false, ItemId ="415" , Name = "Stepping Stone Path"},
            new FilteredItem { ShouldFilter = false, ItemId ="836" , Name = "Stingray"},
            new FilteredItem { ShouldFilter = false, ItemId ="606" , Name = "Stir Fry"},
            new FilteredItem { ShouldFilter = false, ItemId ="2" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="4" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="6" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="8" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="10" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="12" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="14" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="32" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="34" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="36" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="38" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="40" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="42" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="44" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="46" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="48" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="50" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="52" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="54" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="56" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="58" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="75" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="76" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="77" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="95" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="290" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="343" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="390" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="450" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="668" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="670" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="751" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="760" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="762" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="764" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="765" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="25" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="816" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="817" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="818" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="819" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="843" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="844" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="845" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="846" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="847" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="849" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="850" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="CalicoEggStone_0" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="CalicoEggStone_1" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="CalicoEggStone_2" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="VolcanoGoldNode" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="VolcanoCoalNode0" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="VolcanoCoalNode1" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="BasicCoalNode0" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="BasicCoalNode1" , Name = "Stone"},
            new FilteredItem { ShouldFilter = false, ItemId ="449" , Name = "Stone Base"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)144" , Name = "Stone Brazier"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)32" , Name = "Stone Cairn"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)232" , Name = "Stone Chest"},
            new FilteredItem { ShouldFilter = false, ItemId ="323" , Name = "Stone Fence"},
            new FilteredItem { ShouldFilter = false, ItemId ="329" , Name = "Stone Floor"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)52" , Name = "Stone Frog"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)55" , Name = "Stone Junimo"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)54" , Name = "Stone Owl"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)95" , Name = "Stone Owl"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)53" , Name = "Stone Parrot"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)38" , Name = "Stone Sign"},
            new FilteredItem { ShouldFilter = false, ItemId ="841" , Name = "Stone Walkway Floor"},
            new FilteredItem { ShouldFilter = false, ItemId ="158" , Name = "Stonefish"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1030" , Name = "Store Owner's Jacket"},
            new FilteredItem { ShouldFilter = false, ItemId ="203" , Name = "Strange Bun"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)96" , Name = "Strange Capsule"},
            new FilteredItem { ShouldFilter = false, ItemId ="126" , Name = "Strange Doll"},
            new FilteredItem { ShouldFilter = false, ItemId ="127" , Name = "Strange Doll"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1139" , Name = "Strapped Top"},
            new FilteredItem { ShouldFilter = false, ItemId ="401" , Name = "Straw Floor"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)4" , Name = "Straw Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="400" , Name = "Strawberry"},
            new FilteredItem { ShouldFilter = false, ItemId ="745" , Name = "Strawberry Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1128" , Name = "Striped Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1169" , Name = "Studded Vest"},
            new FilteredItem { ShouldFilter = false, ItemId ="239" , Name = "Stuffing"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)147" , Name = "Stump Brazier"},
            new FilteredItem { ShouldFilter = false, ItemId ="525" , Name = "Sturdy Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="698" , Name = "Sturgeon"},
            new FilteredItem { ShouldFilter = false, ItemId ="245" , Name = "Sugar"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1254" , Name = "Sugar Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)33" , Name = "Suit Of Armor"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1010" , Name = "Suit Top"},
            new FilteredItem { ShouldFilter = false, ItemId ="496" , Name = "Summer Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="593" , Name = "Summer Spangle"},
            new FilteredItem { ShouldFilter = false, ItemId ="SummerSquash" , Name = "Summer Squash"},
            new FilteredItem { ShouldFilter = false, ItemId ="SummerSquashSeeds" , Name = "Summer Squash Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="145" , Name = "Sunfish"},
            new FilteredItem { ShouldFilter = false, ItemId ="421" , Name = "Sunflower"},
            new FilteredItem { ShouldFilter = false, ItemId ="431" , Name = "Sunflower Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)88" , Name = "Sunglasses"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1212" , Name = "Sunset Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="155" , Name = "Super Cucumber"},
            new FilteredItem { ShouldFilter = false, ItemId ="237" , Name = "Super Meal"},
            new FilteredItem { ShouldFilter = false, ItemId ="922" , Name = "SupplyCrate"},
            new FilteredItem { ShouldFilter = false, ItemId ="923" , Name = "SupplyCrate"},
            new FilteredItem { ShouldFilter = false, ItemId ="924" , Name = "SupplyCrate"},
            new FilteredItem { ShouldFilter = false, ItemId ="241" , Name = "Survival Burger"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)85" , Name = "Swashbuckler Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="417" , Name = "Sweet Gem Berry"},
            new FilteredItem { ShouldFilter = false, ItemId ="402" , Name = "Sweet Pea"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)22" , Name = "Table Piece L"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)23" , Name = "Table Piece R"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)72" , Name = "Tall Torch"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1006" , Name = "Tan Striped Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1130" , Name = "Tank Top (F)"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1129" , Name = "Tank Top (M)"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)105" , Name = "Tapper"},
            new FilteredItem { ShouldFilter = false, ItemId ="830" , Name = "Taro Root"},
            new FilteredItem { ShouldFilter = false, ItemId ="831" , Name = "Taro Tuber"},
            new FilteredItem { ShouldFilter = false, ItemId ="815" , Name = "Tea Leaves"},
            new FilteredItem { ShouldFilter = false, ItemId ="251" , Name = "Tea Sapling"},
            new FilteredItem { ShouldFilter = false, ItemId ="341" , Name = "Tea Set"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1287" , Name = "Tea Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)69" , Name = "Teddy Timer"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)214" , Name = "Telephone"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)52" , Name = "Tempered Broadsword"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)7" , Name = "Templar's Blade"},
            new FilteredItem { ShouldFilter = false, ItemId ="TentKit" , Name = "Tent Kit"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)TextSign" , Name = "Text Sign"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Trash" , Name = "The Alleyway Buffet"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Crabbing" , Name = "The Art O' Crabbing"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Diamonds" , Name = "The Diamond Hunter"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)28" , Name = "The Slammer"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)510" , Name = "Thermal Boots"},
            new FilteredItem { ShouldFilter = false, ItemId ="839" , Name = "Thorns Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="558" , Name = "Thunder Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)26" , Name = "Tiara"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1143" , Name = "Tie Dye Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)91" , Name = "Tiger Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="857" , Name = "Tiger Slime Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="699" , Name = "Tiger Trout"},
            new FilteredItem { ShouldFilter = false, ItemId ="562" , Name = "Tigerseye"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)9" , Name = "Tight Pants"},
            new FilteredItem { ShouldFilter = false, ItemId ="701" , Name = "Tilapia"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1249" , Name = "Toasted Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1199" , Name = "Toga Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="218" , Name = "Tom Kha Soup"},
            new FilteredItem { ShouldFilter = false, ItemId ="256" , Name = "Tomato"},
            new FilteredItem { ShouldFilter = false, ItemId ="480" , Name = "Tomato Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1282" , Name = "Tomato Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)2" , Name = "Top Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="68" , Name = "Topaz"},
            new FilteredItem { ShouldFilter = false, ItemId ="530" , Name = "Topaz Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="93" , Name = "Torch"},
            new FilteredItem { ShouldFilter = false, ItemId ="229" , Name = "Tortilla"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1252" , Name = "Tortilla Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)44" , Name = "Totem Mask"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1164" , Name = "Track Jacket"},
            new FilteredItem { ShouldFilter = false, ItemId ="694" , Name = "Trap Bobber"},
            new FilteredItem { ShouldFilter = false, ItemId ="168" , Name = "Trash"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1232" , Name = "Trash Can Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="166" , Name = "Treasure Chest"},
            new FilteredItem { ShouldFilter = false, ItemId ="693" , Name = "Treasure Hunter"},
            new FilteredItem { ShouldFilter = false, ItemId ="TreasureTotem" , Name = "Treasure Totem"},
            new FilteredItem { ShouldFilter = false, ItemId ="805" , Name = "Tree Fertilizer"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)TricornHat" , Name = "Tricorn Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="589" , Name = "Trilobite"},
            new FilteredItem { ShouldFilter = false, ItemId ="(P)15" , Name = "Trimmed Lucky Purple Shorts"},
            new FilteredItem { ShouldFilter = false, ItemId ="71" , Name = "Trimmed Lucky Purple Shorts"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1288" , Name = "Trinket Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="253" , Name = "Triple Shot Espresso"},
            new FilteredItem { ShouldFilter = false, ItemId ="907" , Name = "Tropical Curry"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1296" , Name = "Tropical Sunrise Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)13" , Name = "Tropiclip"},
            new FilteredItem { ShouldFilter = false, ItemId ="219" , Name = "Trout Soup"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)16" , Name = "Trucker Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="430" , Name = "Truffle"},
            new FilteredItem { ShouldFilter = false, ItemId ="432" , Name = "Truffle Oil"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)108" , Name = "Tub o' Flowers"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1142" , Name = "Tube Top"},
            new FilteredItem { ShouldFilter = false, ItemId ="591" , Name = "Tulip"},
            new FilteredItem { ShouldFilter = false, ItemId ="427" , Name = "Tulip Bulb"},
            new FilteredItem { ShouldFilter = false, ItemId ="130" , Name = "Tuna"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)509" , Name = "Tundra Boots"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1180" , Name = "Tunnelers Jersey"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1178" , Name = "Turtleneck Sweater"},
            new FilteredItem { ShouldFilter = false, ItemId ="294" , Name = "Twig"},
            new FilteredItem { ShouldFilter = false, ItemId ="295" , Name = "Twig"},
            new FilteredItem { ShouldFilter = false, ItemId ="271" , Name = "Unmilled Rice"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1204" , Name = "Vacation Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="522" , Name = "Vampire Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="200" , Name = "Vegetable Medley"},
            new FilteredItem { ShouldFilter = false, ItemId ="419" , Name = "Vinegar"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1198" , Name = "Vintage Polo"},
            new FilteredItem { ShouldFilter = false, ItemId ="305" , Name = "Void Egg"},
            new FilteredItem { ShouldFilter = false, ItemId ="769" , Name = "Void Essence"},
            new FilteredItem { ShouldFilter = false, ItemId ="808" , Name = "Void Ghost Pendant"},
            new FilteredItem { ShouldFilter = false, ItemId ="308" , Name = "Void Mayonnaise"},
            new FilteredItem { ShouldFilter = false, ItemId ="795" , Name = "Void Salmon"},
            new FilteredItem { ShouldFilter = false, ItemId ="140" , Name = "Walleye"},
            new FilteredItem { ShouldFilter = false, ItemId ="864" , Name = "War Memento"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1253" , Name = "Warm Flannel Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="690" , Name = "Warp Totem: Beach"},
            new FilteredItem { ShouldFilter = false, ItemId ="261" , Name = "Warp Totem: Desert"},
            new FilteredItem { ShouldFilter = false, ItemId ="688" , Name = "Warp Totem: Farm"},
            new FilteredItem { ShouldFilter = false, ItemId ="886" , Name = "Warp Totem: Island"},
            new FilteredItem { ShouldFilter = false, ItemId ="689" , Name = "Warp Totem: Mountains"},
            new FilteredItem { ShouldFilter = false, ItemId ="892" , Name = "Warp Totem: Qi's Arena"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)93" , Name = "Warrior Helmet"},
            new FilteredItem { ShouldFilter = false, ItemId ="521" , Name = "Warrior Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)30" , Name = "Watermelon Band"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Speed" , Name = "Way Of The Wind pt. 1"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Speed2" , Name = "Way Of The Wind pt. 2"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_WildSeeds" , Name = "Ways Of The Wild"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)46" , Name = "Wearable Dwarf Helm"},
            new FilteredItem { ShouldFilter = false, ItemId ="331" , Name = "Weathered Floor"},
            new FilteredItem { ShouldFilter = false, ItemId ="801" , Name = "Wedding Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="0" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="313" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="314" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="315" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="316" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="317" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="318" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="319" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="320" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="321" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="452" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="674" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="675" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="676" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="677" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="678" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="679" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="750" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="784" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="785" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="786" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="792" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="793" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="794" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="882" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="883" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="884" , Name = "Weeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="262" , Name = "Wheat"},
            new FilteredItem { ShouldFilter = false, ItemId ="246" , Name = "Wheat Flour"},
            new FilteredItem { ShouldFilter = false, ItemId ="483" , Name = "Wheat Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="157" , Name = "White Algae"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)WhiteBow" , Name = "White Bow"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1273" , Name = "White Dot Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1165" , Name = "White Gi"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1268" , Name = "White Overalls"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1071" , Name = "White Overalls Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)65" , Name = "White Turban"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)45" , Name = "Wicked Kris"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)83" , Name = "Wicked Statue"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)84" , Name = "Wicked Statue"},
            new FilteredItem { ShouldFilter = false, ItemId ="774" , Name = "Wild Bait"},
            new FilteredItem { ShouldFilter = false, ItemId ="16" , Name = "Wild Horseradish"},
            new FilteredItem { ShouldFilter = false, ItemId ="406" , Name = "Wild Plum"},
            new FilteredItem { ShouldFilter = false, ItemId ="277" , Name = "Wilted Bouquet"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)22" , Name = "Wind Spire"},
            new FilteredItem { ShouldFilter = false, ItemId ="348" , Name = "Wine"},
            new FilteredItem { ShouldFilter = false, ItemId ="412" , Name = "Winter Root"},
            new FilteredItem { ShouldFilter = false, ItemId ="498" , Name = "Winter Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(H)70" , Name = "Witch Hat"},
            new FilteredItem { ShouldFilter = false, ItemId ="388" , Name = "Wood"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)26" , Name = "Wood Chair"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)27" , Name = "Wood Chair"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)211" , Name = "Wood Chipper"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)24" , Name = "Wood Club"},
            new FilteredItem { ShouldFilter = false, ItemId ="322" , Name = "Wood Fence"},
            new FilteredItem { ShouldFilter = false, ItemId ="328" , Name = "Wood Floor"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)152" , Name = "Wood Lamp-post"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)27" , Name = "Wood Mallet"},
            new FilteredItem { ShouldFilter = false, ItemId ="405" , Name = "Wood Path"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)37" , Name = "Wood Sign"},
            new FilteredItem { ShouldFilter = false, ItemId ="SkillBook_2" , Name = "Woodcutter's Weekly"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)12" , Name = "Wooden Blade"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)143" , Name = "Wooden Brazier"},
            new FilteredItem { ShouldFilter = false, ItemId ="734" , Name = "Woodskip"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Woodcutting" , Name = "Woody's Secret"},
            new FilteredItem { ShouldFilter = false, ItemId ="440" , Name = "Wool"},
            new FilteredItem { ShouldFilter = false, ItemId ="(B)507" , Name = "Work Boots"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1029" , Name = "Work Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)208" , Name = "Workbench"},
            new FilteredItem { ShouldFilter = false, ItemId ="(BC)154" , Name = "Worm Bin"},
            new FilteredItem { ShouldFilter = false, ItemId ="869" , Name = "Wriggling Worm"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1135" , Name = "Wumbus Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="280" , Name = "Yam"},
            new FilteredItem { ShouldFilter = false, ItemId ="492" , Name = "Yam Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1021" , Name = "Yellow and Green Shirt"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1294" , Name = "Yellow Suit"},
            new FilteredItem { ShouldFilter = false, ItemId ="(W)48" , Name = "Yeti Tooth"},
            new FilteredItem { ShouldFilter = false, ItemId ="(S)1219" , Name = "Yoba Shirt"}

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

        }


    }
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
        /* 
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
                     ? "Loot Filter is turned on set to "+ LootFilterOn
                     : "Loot Filter is turned on set to " + LootFilterOn;

                 int type = LootFilterOn ? 4 : 3;
                 Game1.addHUDMessage(new HUDMessage(message , type));

                 if (!LootFilterOn)
                 {
                     //Instance = this;
                      ReloadConfig();
                     //configMenu.Unregister(Instance.ModManifest);
                     //RegisterAndAddLootFilterGenericModMenu();

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



