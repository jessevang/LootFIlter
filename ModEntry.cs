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
        public String note001 { get; set; } = "Set keyboard or Gamepad hotkey that would toggle loot filter on and off inside game.";
        public Keys KeyboardHotkeyToTurnOffLootFiltering { get; set; } = Keys.Z;
        public Buttons GamePadHotkeyToTurnOffLootFiltering { get; set; } = Buttons.LeftStick;

        public String note010 { get; set; } = "Change ShouldFilter to True to filter Object Items on ground";

        public List<FilteredItem> ObjectToFilter { get; set; } = new List<FilteredItem>
        {
            new FilteredItem { ShouldFilter = false, ItemId ="587" , Name = "Amphibian Fossil", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="117" , Name = "Anchor", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="103" , Name = "Ancient Doll", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="123" , Name = "Ancient Drum", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="114" , Name = "Ancient Seed", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="109" , Name = "Ancient Sword", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="101" , Name = "Arrowhead", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="119" , Name = "Bone Flute", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="105" , Name = "Chewing Stick", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="113" , Name = "Chicken Statue", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="100" , Name = "Chipped Amphora", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="107" , Name = "Dinosaur Egg", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="116" , Name = "Dried Starfish", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="122" , Name = "Dwarf Gadget", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="96" , Name = "Dwarf Scroll I", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="97" , Name = "Dwarf Scroll II", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="98" , Name = "Dwarf Scroll III", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="99" , Name = "Dwarf Scroll IV", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="121" , Name = "Dwarvish Helm", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="104" , Name = "Elvish Jewelry", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="118" , Name = "Glass Shards", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="124" , Name = "Golden Mask", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="125" , Name = "Golden Relic", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="586" , Name = "Nautilus Fossil", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="106" , Name = "Ornamental Fan", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="588" , Name = "Palm Fossil", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="120" , Name = "Prehistoric Handaxe", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="583" , Name = "Prehistoric Rib", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="579" , Name = "Prehistoric Scapula", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="581" , Name = "Prehistoric Skull", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="580" , Name = "Prehistoric Tibia", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="115" , Name = "Prehistoric Tool", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="584" , Name = "Prehistoric Vertebra", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="108" , Name = "Rare Disc", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="112" , Name = "Rusty Cog", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="110" , Name = "Rusty Spoon", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="111" , Name = "Rusty Spur", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="582" , Name = "Skeletal Hand", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="585" , Name = "Skeletal Tail", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="126" , Name = "Strange Doll", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="127" , Name = "Strange Doll", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="589" , Name = "Trilobite", Category = "Arch"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_AnimalCatalogue" , Name = "Animal Catalogue", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="590" , Name = "Artifact Spot", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="SkillBook_1" , Name = "Bait And Bobber", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Mystery" , Name = "Book of Mysteries", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="PurpleBook" , Name = "Book Of Stars", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Artifact" , Name = "Book_Artifact", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Grass" , Name = "Book_Grass", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Horse" , Name = "Book_Horse", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="SkillBook_4" , Name = "Combat Quarterly", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Bombs" , Name = "Dwarvish Safety Manual", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Friendship" , Name = "Friendship 101", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="GoldenAnimalCracker" , Name = "Golden Animal Cracker", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Defense" , Name = "Jack Be Nimble, Jack Be Thick", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Roe" , Name = "Jewels Of The Sea", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="842" , Name = "Journal Scrap", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="102" , Name = "Lost Book", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Marlon" , Name = "Mapping Cave Systems", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="SkillBook_3" , Name = "Mining Monthly", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Void" , Name = "Monster Compendium", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_PriceCatalogue" , Name = "Price Catalogue", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_QueenOfSauce" , Name = "Queen Of Sauce Cookbook", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="79" , Name = "Secret Note", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="SeedSpot" , Name = "Seed Spot", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="SkillBook_0" , Name = "Stardew Valley Almanac", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="449" , Name = "Stone Base", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Trash" , Name = "The Alleyway Buffet", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Crabbing" , Name = "The Art O' Crabbing", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Diamonds" , Name = "The Diamond Hunter", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Speed" , Name = "Way Of The Wind pt. 1", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Speed2" , Name = "Way Of The Wind pt. 2", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_WildSeeds" , Name = "Ways Of The Wild", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="SkillBook_2" , Name = "Woodcutter's Weekly", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="Book_Woodcutting" , Name = "Woody's Secret", Category = "SkillBooks"},
            new FilteredItem { ShouldFilter = false, ItemId ="930" , Name = "???", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="447" , Name = "Aged Roe", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="300" , Name = "Amaranth", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="454" , Name = "Ancient Fruit", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="613" , Name = "Apple", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="633" , Name = "Apple Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="634" , Name = "Apricot", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="629" , Name = "Apricot Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="274" , Name = "Artichoke", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="275" , Name = "Artifact Trove", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="685" , Name = "Bait", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="SpecificBait" , Name = "Bait", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="91" , Name = "Banana", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="69" , Name = "Banana Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="691" , Name = "Barbed Hook", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="368" , Name = "Basic Fertilizer", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="370" , Name = "Basic Retaining Soil", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="767" , Name = "Bat Wing", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="787" , Name = "Battery Pack", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="346" , Name = "Beer", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="284" , Name = "Beet", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="410" , Name = "Blackberry", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="597" , Name = "Blue Jazz", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="413" , Name = "Blue Slime Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="258" , Name = "Blueberry", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="278" , Name = "Bok Choy", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="881" , Name = "Bone Fragment", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="458" , Name = "Bouquet", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="Broccoli" , Name = "Broccoli", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="684" , Name = "Bug Meat", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="ButterflyPowder" , Name = "Butterfly Powder", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="90" , Name = "Cactus Fruit", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="CalicoEgg" , Name = "Calico Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="Carrot" , Name = "Carrot", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="190" , Name = "Cauliflower", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="78" , Name = "Cave Carrot", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="445" , Name = "Caviar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="ChallengeBait" , Name = "Challenge Bait", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="281" , Name = "Chanterelle", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="424" , Name = "Cheese", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="638" , Name = "Cherry", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="628" , Name = "Cherry Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="848" , Name = "Cinder Shard", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="330" , Name = "Clay", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="428" , Name = "Cloth", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="382" , Name = "Coal", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="88" , Name = "Coconut", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="404" , Name = "Common Mushroom", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="334" , Name = "Copper Bar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="378" , Name = "Copper Ore", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="393" , Name = "Coral", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="695" , Name = "Cork Bobber", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="270" , Name = "Corn", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="282" , Name = "Cranberries", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="418" , Name = "Crocus", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="414" , Name = "Crystal Fruit", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="856" , Name = "Curiosity Lure", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="18" , Name = "Daffodil", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="22" , Name = "Dandelion", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="DeluxeBait" , Name = "Deluxe Bait", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="919" , Name = "Deluxe Fertilizer", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="920" , Name = "Deluxe Retaining Soil", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="466" , Name = "Deluxe Speed-Gro", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="807" , Name = "Dinosaur Mayonnaise", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="852" , Name = "Dragon Tooth", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="687" , Name = "Dressed Spinner", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="DriedFruit" , Name = "Dried", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="DriedMushrooms" , Name = "Dried", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="442" , Name = "Duck Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="444" , Name = "Duck Feather", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="307" , Name = "Duck Mayonnaise", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="176" , Name = "Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="180" , Name = "Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="272" , Name = "Eggplant", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="913" , Name = "Enricher", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="441" , Name = "Explosive Ammo", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="872" , Name = "Fairy Dust", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="595" , Name = "Fairy Rose", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="FarAwayStone" , Name = "Far Away Stone", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="771" , Name = "Fiber", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="259" , Name = "Fiddlehead Fern", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="823" , Name = "Fossilized Leg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="824" , Name = "Fossilized Ribs", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="820" , Name = "Fossilized Skull", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="821" , Name = "Fossilized Spine", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="822" , Name = "Fossilized Tail", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="536" , Name = "Frozen Geode", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="248" , Name = "Garlic", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="535" , Name = "Geode", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="829" , Name = "Ginger", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="426" , Name = "Goat Cheese", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="436" , Name = "Goat Milk", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="336" , Name = "Gold Bar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="GoldCoin" , Name = "Gold Coin", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="384" , Name = "Gold Ore", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="928" , Name = "Golden Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="GoldenMysteryBox" , Name = "Golden Mystery Box", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="373" , Name = "Golden Pumpkin", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="TroutDerbyTag" , Name = "Golden Tag", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="73" , Name = "Golden Walnut", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="398" , Name = "Grape", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="188" , Name = "Green Bean", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="680" , Name = "Green Slime Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="614" , Name = "Green Tea", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="709" , Name = "Hardwood", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="178" , Name = "Hay", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="408" , Name = "Hazelnut", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="283" , Name = "Holly", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="340" , Name = "Honey", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="304" , Name = "Hops", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="260" , Name = "Hot Pepper", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="918" , Name = "Hyper Speed-Gro", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="337" , Name = "Iridium Bar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="803" , Name = "Iridium Milk", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="386" , Name = "Iridium Ore", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="335" , Name = "Iron Bar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="380" , Name = "Iron Ore", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="344" , Name = "Jelly", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="350" , Name = "Juice", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="250" , Name = "Kale", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="438" , Name = "L. Goat Milk", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="174" , Name = "Large Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="182" , Name = "Large Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="186" , Name = "Large Milk", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="692" , Name = "Lead Bobber", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="20" , Name = "Leek", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="30" , Name = "Lumber", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="908" , Name = "Magic Bait", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="851" , Name = "Magma Cap", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="537" , Name = "Magma Geode", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="703" , Name = "Magnet", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="834" , Name = "Mango", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="835" , Name = "Mango Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="724" , Name = "Maple Syrup", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="306" , Name = "Mayonnaise", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="459" , Name = "Mead", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="254" , Name = "Melon", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="460" , Name = "Mermaid's Pendant", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="184" , Name = "Milk", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="257" , Name = "Morel", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="Moss" , Name = "Moss", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="809" , Name = "Movie Ticket", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="827" , Name = "Mummified Bat", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="828" , Name = "Mummified Frog", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="MysteryBox" , Name = "Mystery Box", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="MysticSyrup" , Name = "Mystic Syrup", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="392" , Name = "Nautilus Shell", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="725" , Name = "Oak Resin", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="247" , Name = "Oil", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="749" , Name = "Omni Geode", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="635" , Name = "Orange", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="630" , Name = "Orange Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="289" , Name = "Ostrich Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="303" , Name = "Pale Ale", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="24" , Name = "Parsnip", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="636" , Name = "Peach", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="631" , Name = "Peach Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="797" , Name = "Pearl", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="PetLicense" , Name = "Pet License", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="342" , Name = "Pickles", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="726" , Name = "Pine Tar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="832" , Name = "Pineapple", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="637" , Name = "Pomegranate", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="632" , Name = "Pomegranate Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="376" , Name = "Poppy", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="192" , Name = "Potato", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="Powdermelon" , Name = "Powdermelon", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="915" , Name = "Pressure Nozzle", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="PrizeTicket" , Name = "Prize Ticket", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="276" , Name = "Pumpkin", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="422" , Name = "Purple Mushroom", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="439" , Name = "Purple Slime Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="889" , Name = "Qi Fruit", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="858" , Name = "Qi Gem", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="917" , Name = "Qi Seasoning", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="877" , Name = "Quality Bobber", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="369" , Name = "Quality Fertilizer", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="371" , Name = "Quality Retaining Soil", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="446" , Name = "Rabbit's Foot", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="910" , Name = "Radioactive Bar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="909" , Name = "Radioactive Ore", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="264" , Name = "Radish", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="394" , Name = "Rainbow Shell", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="Raisins" , Name = "Raisins", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="266" , Name = "Red Cabbage", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="420" , Name = "Red Mushroom", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="437" , Name = "Red Slime Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="338" , Name = "Refined Quartz", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="252" , Name = "Rhubarb", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="423" , Name = "Rice", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="812" , Name = "Roe", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="747" , Name = "Rotten Plant", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="748" , Name = "Rotten Plant", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="296" , Name = "Salmonberry", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="92" , Name = "Sap", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="397" , Name = "Sea Urchin", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="766" , Name = "Slime", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="SmokedFish" , Name = "Smoked", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="825" , Name = "Snake Skull", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="826" , Name = "Snake Vertebrae", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="416" , Name = "Snow Yam", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="768" , Name = "Solar Essence", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="SonarBobber" , Name = "Sonar Bobber", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="465" , Name = "Speed-Gro", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="396" , Name = "Spice Berry", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="686" , Name = "Spinner", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="399" , Name = "Spring Onion", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="814" , Name = "Squid Ink", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="StardropTea" , Name = "Stardrop Tea", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="268" , Name = "Starfruit", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="390" , Name = "Stone", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="400" , Name = "Strawberry", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="245" , Name = "Sugar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="593" , Name = "Summer Spangle", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="SummerSquash" , Name = "Summer Squash", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="421" , Name = "Sunflower", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="417" , Name = "Sweet Gem Berry", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="402" , Name = "Sweet Pea", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="830" , Name = "Taro Root", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="815" , Name = "Tea Leaves", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="251" , Name = "Tea Sapling", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="341" , Name = "Tea Set", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="857" , Name = "Tiger Slime Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="256" , Name = "Tomato", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="694" , Name = "Trap Bobber", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="166" , Name = "Treasure Chest", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="693" , Name = "Treasure Hunter", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="805" , Name = "Tree Fertilizer", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="430" , Name = "Truffle", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="432" , Name = "Truffle Oil", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="591" , Name = "Tulip", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="271" , Name = "Unmilled Rice", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="419" , Name = "Vinegar", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="305" , Name = "Void Egg", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="769" , Name = "Void Essence", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="808" , Name = "Void Ghost Pendant", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="308" , Name = "Void Mayonnaise", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="262" , Name = "Wheat", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="246" , Name = "Wheat Flour", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="774" , Name = "Wild Bait", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="16" , Name = "Wild Horseradish", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="406" , Name = "Wild Plum", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="277" , Name = "Wilted Bouquet", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="348" , Name = "Wine", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="412" , Name = "Winter Root", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="388" , Name = "Wood", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="440" , Name = "Wool", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="280" , Name = "Yam", Category = "Basic"},
            new FilteredItem { ShouldFilter = false, ItemId ="456" , Name = "Algae Soup", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="605" , Name = "Artichoke Dip", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="235" , Name = "Autumn's Bounty", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="198" , Name = "Baked Fish", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="904" , Name = "Banana Pudding", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="207" , Name = "Bean Hotpot", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="611" , Name = "Blackberry Cobbler", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="234" , Name = "Blueberry Tart", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="216" , Name = "Bread", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="618" , Name = "Bruschetta", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="209" , Name = "Carp Surprise", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="197" , Name = "Cheese Cauliflower", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="220" , Name = "Chocolate Cake", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="727" , Name = "Chowder", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="648" , Name = "Coleslaw", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="201" , Name = "Complete Breakfast", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="223" , Name = "Cookie", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="732" , Name = "Crab Cakes", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="612" , Name = "Cranberry Candy", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="238" , Name = "Cranberry Sauce", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="214" , Name = "Crispy Bass", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="242" , Name = "Dish O' The Sea", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="231" , Name = "Eggplant Parmesan", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="729" , Name = "Escargot", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="240" , Name = "Farmer's Lunch", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="649" , Name = "Fiddlehead Risotto", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="728" , Name = "Fish Stew", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="213" , Name = "Fish Taco", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="202" , Name = "Fried Calamari", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="225" , Name = "Fried Eel", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="194" , Name = "Fried Egg", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="205" , Name = "Fried Mushroom", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="610" , Name = "Fruit Salad", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="903" , Name = "Ginger Ale", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="208" , Name = "Glazed Yams", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="210" , Name = "Hashbrowns", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="233" , Name = "Ice Cream", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="773" , Name = "Life Elixir", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="730" , Name = "Lobster Bisque", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="204" , Name = "Lucky Lunch", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="279" , Name = "Magic Rock Candy", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="228" , Name = "Maki Roll", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="905" , Name = "Mango Sticky Rice", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="731" , Name = "Maple Bar", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="243" , Name = "Miner's Treat", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="MossSoup" , Name = "Moss Soup", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="772" , Name = "Oil of Garlic", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="195" , Name = "Omelet", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="457" , Name = "Pale Broth", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="211" , Name = "Pancakes", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="199" , Name = "Parsnip Soup", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="215" , Name = "Pepper Poppers", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="873" , Name = "Piña Colada", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="221" , Name = "Pink Cake", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="206" , Name = "Pizza", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="604" , Name = "Plum Pudding", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="906" , Name = "Poi", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="651" , Name = "Poppyseed Muffin", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="608" , Name = "Pumpkin Pie", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="236" , Name = "Pumpkin Soup", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="609" , Name = "Radish Salad", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="230" , Name = "Red Plate", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="222" , Name = "Rhubarb Pie", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="232" , Name = "Rice Pudding", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="607" , Name = "Roasted Hazelnuts", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="244" , Name = "Roots Platter", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="196" , Name = "Salad", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="212" , Name = "Salmon Dinner", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="227" , Name = "Sashimi", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="265" , Name = "Seafoam Pudding", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="733" , Name = "Shrimp Cocktail", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="224" , Name = "Spaghetti", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="226" , Name = "Spicy Eel", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="921" , Name = "Squid Ink Ravioli", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="606" , Name = "Stir Fry", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="203" , Name = "Strange Bun", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="239" , Name = "Stuffing", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="237" , Name = "Super Meal", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="241" , Name = "Survival Burger", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="218" , Name = "Tom Kha Soup", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="229" , Name = "Tortilla", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="253" , Name = "Triple Shot Espresso", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="907" , Name = "Tropical Curry", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="219" , Name = "Trout Soup", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="200" , Name = "Vegetable Medley", Category = "Cooking"},
            new FilteredItem { ShouldFilter = false, ItemId ="309" , Name = "Acorn", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="BlueGrassStarter" , Name = "Blue Grass Starter", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="287" , Name = "Bomb", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="293" , Name = "Brick Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="874" , Name = "Bug Steak", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="927" , Name = "Camping Stove", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="286" , Name = "Cherry Bomb", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="411" , Name = "Cobblestone Path", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="395" , Name = "Coffee", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="926" , Name = "Cookout Kit", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="710" , Name = "Crab Pot", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="333" , Name = "Crystal Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="409" , Name = "Crystal Path", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="461" , Name = "Decorative Pot", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="463" , Name = "Drum Block", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="326" , Name = "Dwarvish Translation Guide", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="349" , Name = "Energy Tonic", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="403" , Name = "Field Snack", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="895" , Name = "Fireworks (Green)", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="894" , Name = "Fireworks (Purple)", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="893" , Name = "Fireworks (Red)", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="464" , Name = "Flute Block", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="896" , Name = "Galaxy Soul", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="325" , Name = "Gate", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="297" , Name = "Grass Starter", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="407" , Name = "Gravel Path", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="298" , Name = "Hardwood Fence", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="929" , Name = "Hedge", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="911" , Name = "Horse Flute", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="645" , Name = "Iridium Sprinkler", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="324" , Name = "Iron Fence", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="746" , Name = "Jack-O-Lantern", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="292" , Name = "Mahogany Seed", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="310" , Name = "Maple Seed", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="288" , Name = "Mega Bomb", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="879" , Name = "Monster Musk", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="MossySeed" , Name = "Mossy Seed", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="351" , Name = "Muscle Remedy", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="891" , Name = "Mushroom Tree Seed", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="MysticTreeSeed" , Name = "Mystic Tree Seed", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="311" , Name = "Pine Cone", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="621" , Name = "Quality Sprinkler", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="681" , Name = "Rain Totem", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="840" , Name = "Rustic Plank Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="925" , Name = "Slime Crate", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="94" , Name = "Spirit Torch", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="599" , Name = "Sprinkler", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="434" , Name = "Stardrop", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="415" , Name = "Stepping Stone Path", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="323" , Name = "Stone Fence", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="329" , Name = "Stone Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="841" , Name = "Stone Walkway Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="401" , Name = "Straw Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="922" , Name = "SupplyCrate", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="923" , Name = "SupplyCrate", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="924" , Name = "SupplyCrate", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="TentKit" , Name = "Tent Kit", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="93" , Name = "Torch", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="TreasureTotem" , Name = "Treasure Totem", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="690" , Name = "Warp Totem: Beach", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="261" , Name = "Warp Totem: Desert", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="688" , Name = "Warp Totem: Farm", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="886" , Name = "Warp Totem: Island", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="689" , Name = "Warp Totem: Mountains", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="892" , Name = "Warp Totem: Qi's Arena", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="331" , Name = "Weathered Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="322" , Name = "Wood Fence", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="328" , Name = "Wood Floor", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="405" , Name = "Wood Path", Category = "Crafting"},
            new FilteredItem { ShouldFilter = false, ItemId ="705" , Name = "Albacore", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="129" , Name = "Anchovy", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="160" , Name = "Angler", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="800" , Name = "Blobfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="838" , Name = "Blue Discus", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="132" , Name = "Bream", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="171" , Name = "Broken CD", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="170" , Name = "Broken Glasses", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="700" , Name = "Bullhead", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="142" , Name = "Carp", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="143" , Name = "Catfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="CaveJelly" , Name = "Cave Jelly", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="702" , Name = "Chub", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="372" , Name = "Clam", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="718" , Name = "Cockle", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="717" , Name = "Crab", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="716" , Name = "Crayfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="159" , Name = "Crimsonfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="704" , Name = "Dorado", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="169" , Name = "Driftwood", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="148" , Name = "Eel", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="267" , Name = "Flounder", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="156" , Name = "Ghostfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="775" , Name = "Glacierfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="902" , Name = "Glacierfish Jr.", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="Goby" , Name = "Goby", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="153" , Name = "Green Algae", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="708" , Name = "Halibut", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="147" , Name = "Herring", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="161" , Name = "Ice Pip", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="167" , Name = "Joja Cola", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="136" , Name = "Largemouth Bass", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="162" , Name = "Lava Eel", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="163" , Name = "Legend", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="900" , Name = "Legend II", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="707" , Name = "Lingcod", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="837" , Name = "Lionfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="715" , Name = "Lobster", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="269" , Name = "Midnight Carp", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="798" , Name = "Midnight Squid", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="899" , Name = "Ms. Angler", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="719" , Name = "Mussel", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="682" , Name = "Mutant Carp", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="149" , Name = "Octopus", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="723" , Name = "Oyster", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="141" , Name = "Perch", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="722" , Name = "Periwinkle", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="144" , Name = "Pike", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="128" , Name = "Pufferfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="901" , Name = "Radioactive Carp", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="138" , Name = "Rainbow Trout", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="146" , Name = "Red Mullet", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="150" , Name = "Red Snapper", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="RiverJelly" , Name = "River Jelly", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="139" , Name = "Salmon", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="164" , Name = "Sandfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="131" , Name = "Sardine", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="165" , Name = "Scorpion Carp", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="154" , Name = "Sea Cucumber", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="SeaJelly" , Name = "Sea Jelly", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="152" , Name = "Seaweed", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="706" , Name = "Shad", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="720" , Name = "Shrimp", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="796" , Name = "Slimejack", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="137" , Name = "Smallmouth Bass", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="721" , Name = "Snail", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="172" , Name = "Soggy Newspaper", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="898" , Name = "Son of Crimsonfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="799" , Name = "Spook Fish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="151" , Name = "Squid", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="836" , Name = "Stingray", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="158" , Name = "Stonefish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="698" , Name = "Sturgeon", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="145" , Name = "Sunfish", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="155" , Name = "Super Cucumber", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="699" , Name = "Tiger Trout", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="701" , Name = "Tilapia", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="168" , Name = "Trash", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="130" , Name = "Tuna", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="795" , Name = "Void Salmon", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="140" , Name = "Walleye", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="157" , Name = "White Algae", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="734" , Name = "Woodskip", Category = "Fish"},
            new FilteredItem { ShouldFilter = false, ItemId ="PotOfGold" , Name = "PotOfGold", Category = "interactive"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds0" , Name = "GreenRainWeeds0", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds1" , Name = "GreenRainWeeds1", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds2" , Name = "GreenRainWeeds2", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds3" , Name = "GreenRainWeeds3", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds4" , Name = "GreenRainWeeds4", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds5" , Name = "GreenRainWeeds5", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds6" , Name = "GreenRainWeeds6", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="GreenRainWeeds7" , Name = "GreenRainWeeds7", Category = "Litter"},
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
            new FilteredItem { ShouldFilter = false, ItemId ="294" , Name = "Twig", Category = "Litter"},
            new FilteredItem { ShouldFilter = false, ItemId ="295" , Name = "Twig", Category = "Litter"},
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
            new FilteredItem { ShouldFilter = false, ItemId ="541" , Name = "Aerinite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="538" , Name = "Alamite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="66" , Name = "Amethyst", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="62" , Name = "Aquamarine", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="540" , Name = "Baryte", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="570" , Name = "Basalt", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="539" , Name = "Bixite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="542" , Name = "Calcite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="566" , Name = "Celestine", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="72" , Name = "Diamond", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="543" , Name = "Dolomite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="86" , Name = "Earth Crystal", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="60" , Name = "Emerald", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="544" , Name = "Esperite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="577" , Name = "Fairy Stone", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="565" , Name = "Fire Opal", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="82" , Name = "Fire Quartz", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="545" , Name = "Fluorapatite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="84" , Name = "Frozen Tear", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="546" , Name = "Geminite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="561" , Name = "Ghost Crystal", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="569" , Name = "Granite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="547" , Name = "Helvite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="573" , Name = "Hematite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="70" , Name = "Jade", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="549" , Name = "Jagoite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="548" , Name = "Jamborite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="563" , Name = "Jasper", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="550" , Name = "Kyanite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="554" , Name = "Lemon Stone", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="571" , Name = "Limestone", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="551" , Name = "Lunarite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="552" , Name = "Malachite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="567" , Name = "Marble", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="574" , Name = "Mudstone", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="555" , Name = "Nekoite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="553" , Name = "Neptunite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="575" , Name = "Obsidian", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="560" , Name = "Ocean Stone", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="564" , Name = "Opal", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="556" , Name = "Orpiment", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="557" , Name = "Petrified Slime", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="74" , Name = "Prismatic Shard", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="559" , Name = "Pyrite", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="80" , Name = "Quartz", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="64" , Name = "Ruby", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="568" , Name = "Sandstone", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="576" , Name = "Slate", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="572" , Name = "Soapstone", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="578" , Name = "Star Shards", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="558" , Name = "Thunder Egg", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="562" , Name = "Tigerseye", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="68" , Name = "Topaz", Category = "Minerals"},
            new FilteredItem { ShouldFilter = false, ItemId ="867" , Name = "Advanced TV Remote", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="868" , Name = "Arctic Shard", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="790" , Name = "Berry Basket", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="875" , Name = "Ectoplasm", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="GoldenBobber" , Name = "Golden Bobber", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="791" , Name = "Golden Coconut", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="865" , Name = "Gourmet Tomato Salt", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="742" , Name = "Haley's Lost Bracelet", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="788" , Name = "Lost Axe", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="789" , Name = "Lucky Purple Shorts", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="191" , Name = "Ornate Necklace", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="897" , Name = "Pierre's Missing Stocklist", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="870" , Name = "Pirate's Locket", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="876" , Name = "Prismatic Jelly", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="866" , Name = "Stardew Valley Rose", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="71" , Name = "Trimmed Lucky Purple Shorts", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="864" , Name = "War Memento", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="869" , Name = "Wriggling Worm", Category = "Quest"},
            new FilteredItem { ShouldFilter = false, ItemId ="529" , Name = "Amethyst Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="531" , Name = "Aquamarine Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="526" , Name = "Burglar's Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="880" , Name = "Combined Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="810" , Name = "Crabshell Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="533" , Name = "Emerald Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="517" , Name = "Glow Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="888" , Name = "Glowstone Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="860" , Name = "Hot Java Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="887" , Name = "Immunity Band", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="527" , Name = "Iridium Band", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="532" , Name = "Jade Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="528" , Name = "Jukebox Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="859" , Name = "Lucky Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="519" , Name = "Magnet Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="811" , Name = "Napalm Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="863" , Name = "Phoenix Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="861" , Name = "Protection Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="524" , Name = "Ring of Yoba", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="534" , Name = "Ruby Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="523" , Name = "Savage Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="520" , Name = "Slime Charmer Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="516" , Name = "Small Glow Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="518" , Name = "Small Magnet Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="862" , Name = "Soul Sapper Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="525" , Name = "Sturdy Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="839" , Name = "Thorns Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="530" , Name = "Topaz Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="522" , Name = "Vampire Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="521" , Name = "Warrior Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="801" , Name = "Wedding Ring", Category = "Ring"},
            new FilteredItem { ShouldFilter = false, ItemId ="299" , Name = "Amaranth Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="499" , Name = "Ancient Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="489" , Name = "Artichoke Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="473" , Name = "Bean Starter", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="494" , Name = "Beet Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="481" , Name = "Blueberry Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="491" , Name = "Bok Choy Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="BroccoliSeeds" , Name = "Broccoli Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="802" , Name = "Cactus Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="CarrotSeeds" , Name = "Carrot Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="474" , Name = "Cauliflower Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="433" , Name = "Coffee Bean", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="487" , Name = "Corn Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="493" , Name = "Cranberry Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="488" , Name = "Eggplant Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="425" , Name = "Fairy Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="497" , Name = "Fall Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="885" , Name = "Fiber Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="476" , Name = "Garlic Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="301" , Name = "Grape Starter", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="302" , Name = "Hops Starter", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="429" , Name = "Jazz Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="477" , Name = "Kale Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="479" , Name = "Melon Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="MixedFlowerSeeds" , Name = "Mixed Flower Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="770" , Name = "Mixed Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="472" , Name = "Parsnip Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="482" , Name = "Pepper Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="833" , Name = "Pineapple Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="453" , Name = "Poppy Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="475" , Name = "Potato Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="PowdermelonSeeds" , Name = "Powdermelon Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="490" , Name = "Pumpkin Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="890" , Name = "Qi Bean", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="484" , Name = "Radish Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="347" , Name = "Rare Seed", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="485" , Name = "Red Cabbage Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="478" , Name = "Rhubarb Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="273" , Name = "Rice Shoot", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="455" , Name = "Spangle Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="495" , Name = "Spring Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="486" , Name = "Starfruit Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="745" , Name = "Strawberry Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="496" , Name = "Summer Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="SummerSquashSeeds" , Name = "Summer Squash Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="431" , Name = "Sunflower Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="831" , Name = "Taro Tuber", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="480" , Name = "Tomato Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="427" , Name = "Tulip Bulb", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="483" , Name = "Wheat Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="498" , Name = "Winter Seeds", Category = "Seeds"},
            new FilteredItem { ShouldFilter = false, ItemId ="492" , Name = "Yam Seeds", Category = "Seeds"}

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
        public static ModEntry Instance { get; private set; }
        public ModConfig Config { get; private set; }
        public bool LootFilterOn = true;

        public override void Entry(IModHelper helper)
        {

            Instance = this; 
            Config = helper.ReadConfig<ModConfig>() ?? new ModConfig(); // Sample to call --> int somevalue = Instance.Config.Somevalues; 

            //Sample to Apply a Patch from patches folder. Used this if you want to use a replace an existing stardew valley function some other other code.
            HarmonyPatcher.Apply(this,
            new addItemToInventoryBoolPatch(Config, Instance)
            );

            helper.Events.Input.ButtonPressed += Input_ButtonPressed;
            helper.Events.GameLoop.GameLaunched += OnGameLaunched;
        }

        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            createGenericModMenu();
            //testMenu();

        }

        private void testMenu()
        {
            var configMenu = this.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");

            if (configMenu is null)
            {
                Monitor.Log("GMCM API not found!", LogLevel.Warn);
                return;
            }

            Monitor.Log("GMCM API successfully loaded!", LogLevel.Info);

            // Register the config menu
            configMenu.Register(
                mod: this.ModManifest,
                reset: () => this.Config = new ModConfig(),
                save: () => this.Helper.WriteConfig(this.Config)
            );

            Monitor.Log("GMCM menu registered!", LogLevel.Info);

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

            //createPageLinks(configMenu);



            // Add section for filtering options
            configMenu.AddSectionTitle(this.ModManifest, () => "Filter Loot Pick Up");

            foreach (var item in this.Config.ObjectToFilter)
            {
                configMenu.AddBoolOption(
                    mod: this.ModManifest,
                    name: () => $"{item.Name}  (:{item.Category})",
                    getValue: () => item.ShouldFilter,
                    setValue: value => item.ShouldFilter = value

                );

            }


            //goBackToMain(configMenu);

            // ✅ FIRST: Add main page before options
            configMenu.AddPage(this.ModManifest, "Main", () => "Loot Filter Settings");
            Monitor.Log("Main page added!", LogLevel.Info);

            // ✅ THEN: Add Page Links
            configMenu.AddPageLink(
                mod: this.ModManifest,
                pageId: "WeaponFilter",
                text: () => "Weapon Filter",
                tooltip: () => "Click to configure weapon filters"
            );

            Monitor.Log("Weapon Filter PageLink added!", LogLevel.Info);

            // ✅ NOW: Add options after pages are declared
            configMenu.AddSectionTitle(this.ModManifest, () => "Filtered Items");
            Monitor.Log("Section Title added!", LogLevel.Info);

            // Example option
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

            Monitor.Log("Test Bool Option added!", LogLevel.Info);

            // ✅ SECOND PAGE
            configMenu.AddPage(this.ModManifest, "WeaponFilter", () => "Weapon Filter");
            Monitor.Log("Weapon Filter Page added!", LogLevel.Info);

            configMenu.AddPageLink(
                mod: this.ModManifest,
                pageId: "Main",
                text: () => "Back",
                tooltip: () => "Return to main settings"
            );

            Monitor.Log("Back to Main PageLink added!", LogLevel.Info);
        }



        private void createGenericModMenu()
        {


            // Get Generic Mod Config Menu's API (if it's installed)
            var configMenu = this.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (configMenu is null)
                return;

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


            //Page Links on Main Page ---------------------------------------


           /* configMenu.AddSectionTitle(this.ModManifest, () => "Loot Filter Categories");
            configMenu.AddPageLink(
                mod: this.ModManifest,
                pageId: "AllItems",
                text: () => "All Items",
                tooltip: () => "Filter All Items"
            );
           */
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
                pageId: "Litter",
                text: () => "Litter",
                tooltip: () => "Filter Litter"
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


            //Before 0.5 . Sort All Objects
           /*
            configMenu.AddPage(
                 mod: this.ModManifest,
                 pageId: "AllItems",
                 pageTitle: () => "Filter All Items"
                 );
            configMenu.AddSectionTitle(this.ModManifest, () => "Filter -->[All Items]<--");

            
            foreach (var item in this.Config.ObjectToFilter)
            {
            

                    configMenu.AddBoolOption(
                        mod: this.ModManifest,
                        name: () => $"{item.Category}:{item.Name}",
                        getValue: () => item.ShouldFilter,
                        setValue: value => item.ShouldFilter = value

                    );
                

            }
           */

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

            //8. Sort Objects by Litter
            configMenu.AddPage(
                 mod: this.ModManifest,
                 pageId: "Litter",
                 pageTitle: () => "Filter Litter"
                 );
            configMenu.AddSectionTitle(this.ModManifest, () => " -->[Litter]<-- ");

            foreach (var item in this.Config.ObjectToFilter)
            {
                if (item.Category.Contains("Litter"))
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

        private void goBackToMain(IGenericModConfigMenuApi configMenu)
        {
            configMenu.AddPageLink(
                  mod: this.ModManifest,
                  pageId: "Main",
                  text: () => "Back",
                  tooltip: () => "Return to main settings"
              );

        }

        private void createPageLinks(IGenericModConfigMenuApi configMenu)
        {
            configMenu.AddPageLink(
                  mod: this.ModManifest,
                  pageId: "Object Filter",
                  text: () => "Object Filter",
                  tooltip: () => "Click to Configure Object Loot Filter"
              );
            configMenu.AddPageLink(
                  mod: this.ModManifest,
                  pageId: "Weapon Filters",
                  text: () => "Weapon Filters",
                  tooltip: () => "Click to Configure Weapon Loot Filter"
            );


        }


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
                   // Instance = this;
                   // ReloadConfig();
                   
                }
                

            }

           
        }

        public void ReloadConfig()
        {
            // Reload the config file
            Config = null;
           // Config = Helper.ReadConfig<ModConfig>();

            // Log a message to confirm the config was reloaded
            Monitor.Log("Config reloaded successfully!", LogLevel.Info);

          //  createGenericModMenu();


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
