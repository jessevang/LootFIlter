using StardewModdingAPI;
using StardewValley;
using HarmonyLib;
using Spacechase.Shared.Patching;
using LootFilter;
using Microsoft.Xna.Framework;
using StardewValley.Locations;
using System.Reflection;
using StardewValley.Extensions;
using static StardewValley.Debris;

[HarmonyPatch(typeof(Debris), "updateChunks")]
public class Debris_UpdateChunk_Patch
{
    public static readonly FieldInfo TimeBeforeReturnField = typeof(Debris)
        .GetField("timeBeforeReturnToDroppingPlayer", BindingFlags.NonPublic | BindingFlags.Instance);

    public static void Prefix(Debris __instance)
    {
        if (TimeBeforeReturnField != null)
        {
            // Get the current value of the private field
            float timeBeforeReturn = (float)TimeBeforeReturnField.GetValue(__instance);

            // Log the current value (optional, for debugging)
            //ModEntry.ModMonitor.Log($"Before Update: timeBeforeReturnToDroppingPlayer = {timeBeforeReturn}");

            // Modify the value (example: adding 5 seconds)
            float modifiedValue = timeBeforeReturn + 5f;

            // Set the modified value back to the instance
            TimeBeforeReturnField.SetValue(__instance, modifiedValue);

            // Log the modified value (optional, for debugging)
            //ModEntry.ModMonitor.Log($"After Update: timeBeforeReturnToDroppingPlayer = {modifiedValue}");
        }
        else
        {
            // Log an error if the field isn't found
           // ModEntry.ModMonitor.Log("Failed to find timeBeforeReturnToDroppingPlayer field.");
        }
    }
}

internal class addItemToInventoryBoolPatch : BasePatcher
{
    public readonly ModConfig _config;
    public static ModEntry Instance;

    public addItemToInventoryBoolPatch(ModConfig Config)
    {
        _config = Config;
    }

    public override void Apply(Harmony harmony, IMonitor monitor)
    {
        harmony.Patch(
            original: this.RequireMethod<Debris>(nameof(Debris.updateChunks)),
            prefix: this.GetHarmonyMethod(nameof(prefixUpdateChunk))
        );
    }



    public static bool prefixUpdateChunk(Debris __instance, GameTime time, GameLocation location, ref bool __result)
    {
        
        float timeBeforeReturnToDroppingPlayer = 1200f;
        // Call the reflection patch method to modify the timeBeforeReturnToDroppingPlayer value.
        var fieldInfo = typeof(Debris).GetField("timeBeforeReturnToDroppingPlayer", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        if (fieldInfo != null)
        {
            // Get the current value of 'timeBeforeReturnToDroppingPlayer'
            var timeBeforeReturn = fieldInfo.GetValue(__instance);


            // Now, timeBeforeReturn will hold the current value of 'timeBeforeReturnToDroppingPlayer'.
            // If it's a float, you can do something with it, like logging it:
            if (timeBeforeReturn is float currentValue)
            {
                timeBeforeReturnToDroppingPlayer = currentValue;
                //Console.WriteLine($"Current value of timeBeforeReturnToDroppingPlayer: {currentValue}");
            }
        }
        



        if (__instance.Chunks.Count == 0)
        {
            __result = true;
        
            return false;
        }

        __instance.timeSinceDoneBouncing += time.ElapsedGameTime.Milliseconds;
        if (__instance.timeSinceDoneBouncing >= (__instance.floppingFish.Value ? 2500f : ((__instance.debrisType.Value == Debris.DebrisType.SPRITECHUNKS || __instance.debrisType.Value == Debris.DebrisType.NUMBERS) ? 1800f : 600f)))
        {
            switch (__instance.debrisType.Value)
            {
                case Debris.DebrisType.LETTERS:
                case Debris.DebrisType.SPRITECHUNKS:
                case Debris.DebrisType.NUMBERS:
                    __result=  true;
                    return false;
                case Debris.DebrisType.CHUNKS:
                    if (__instance.chunkType.Value != 8)
                    {
                        __result = true;
                        return false;
                    }

                    __instance.chunksMoveTowardPlayer = true;
                    break;
                case Debris.DebrisType.ARCHAEOLOGY:
                case Debris.DebrisType.OBJECT:
                case Debris.DebrisType.RESOURCE:
                    __instance.chunksMoveTowardPlayer = true;
                    break;
            }

            __instance.timeSinceDoneBouncing = 0f;
        }

        if (!location.farmers.Any() && !location.IsTemporary)
        {
            __result = false;
            return false;
        }


        //approximatePosition is private, so I replaced it 
        Vector2 position = approximatePosition(__instance);
        Farmer farmer = __instance.player.Value;
        if (__instance.isEssentialItem() && __instance.shouldControlThis(location) && farmer == null)
        {
            //findbestplayer is private will replace it
            farmer = findBestPlayer(__instance,location);
        }
        //private timeBeforeReturnToDroppingPlayer which is set to 1200, which is going to just manuall set now to 1200

        //timeBeforeReturnToDroppingPlayer = 1200;

        /*
        if (shouldItemBeFiltered(__instance)){
            timeBeforeReturnToDroppingPlayer = 5000;
        }
        */

        if (__instance.chunksMoveTowardPlayer)
        {
            
            if (timeBeforeReturnToDroppingPlayer > 0)
            {
                timeBeforeReturnToDroppingPlayer -= (int)time.ElapsedGameTime.TotalMilliseconds;
            }

            if (!__instance.isEssentialItem())
            {
                if (__instance.player.Value != null && __instance.player.Value == Game1.player && !playerInRange(__instance,position, __instance.player.Value))
                {
                    __instance.player.Value = null;
                    farmer = null;
                }

                if (__instance.shouldControlThis(location))
                {
                    if (__instance.player.Value != null && __instance.player.Value.currentLocation != location)
                    {
                        __instance.player.Value = null;
                        farmer = null;
                    }

                    if (farmer == null)
                    {
                        farmer = findBestPlayer(__instance, location);
                    }
                }

                if (farmer != null && timeBeforeReturnToDroppingPlayer > 0 && farmer.UniqueMultiplayerID == __instance.DroppedByPlayerID.Value)
                {
                    farmer = null;
                }
            }
        }
  
        
        float animationTimer = 0.0f;
        bool flag = false;
        for (int num = __instance.Chunks.Count - 1; num >= 0; num--)
        {
            Chunk chunk = __instance.Chunks[num];
            chunk.position.UpdateExtrapolation(chunk.getSpeed());
            if (chunk.alpha > 0.1f && (__instance.debrisType.Value == Debris.DebrisType.SPRITECHUNKS || __instance.debrisType.Value == Debris.DebrisType.NUMBERS) && __instance.timeSinceDoneBouncing > 600f)
            {
                chunk.alpha = (1800f - __instance.timeSinceDoneBouncing) / 1000f;
            }

            if (chunk.position.X < -128f || chunk.position.Y < -64f || chunk.position.X >= (float)(location.map.DisplayWidth + 64) || chunk.position.Y >= (float)(location.map.DisplayHeight + 64))
            {
                __instance.Chunks.RemoveAt(num);
            }
            else
            {
                if (__instance.item?.QualifiedItemId == "(O)GoldCoin")
                {
                    animationTimer += (int)time.ElapsedGameTime.TotalMilliseconds;
                    if (animationTimer > 700f)
                    {
                        animationTimer = 0f;
                        location.temporarySprites.Add(new TemporaryAnimatedSprite("LooseSprites\\Cursors_1_6", new Rectangle(144, 249, 7, 7), 100f, 6, 1, Utility.getRandomPositionInThisRectangle(new Rectangle((int)chunk.position.X + 32 - 4, (int)chunk.position.Y + 32 - 4, 32, 28), Game1.random), flicker: false, flipped: false, ((float)(__instance.chunkFinalYLevel + 64 + 8) + (chunk.position.X + 1f) / 10000f) / 10000f, 0f, Color.White, 4f, 0f, 0f, 0f));
                    }
                }

                bool flag2 = farmer != null;
                if (flag2)
                {
                    switch (__instance.debrisType.Value)
                    {
                        case Debris.DebrisType.ARCHAEOLOGY:
                        case Debris.DebrisType.OBJECT:
                            if (__instance.item != null)
                            {
                                flag2 = farmer.couldInventoryAcceptThisItem(__instance.item);
                                break;
                            }

                            flag2 = farmer.couldInventoryAcceptThisItem(__instance.itemId.Value, 1, __instance.itemQuality);
                            if (__instance.itemId.Value == "(O)102" && farmer.hasMenuOpen.Value)
                            {
                                flag2 = false;
                            }

                            break;
                        case Debris.DebrisType.RESOURCE:
                            flag2 = farmer.couldInventoryAcceptThisItem(__instance.itemId.Value, 1);
                            break;
                        default:
                            flag2 = true;
                            break;
                    }

                    flag = flag || flag2;
                    if (flag2 && __instance.shouldControlThis(location))
                    {
                        __instance.player.Value = farmer;
                    }
                }

                if ((__instance.chunksMoveTowardPlayer || __instance.isFishable) && flag2 && __instance.player.Value != null)
                {
                    if (__instance.player.Value.IsLocalPlayer)
                    {
                        if (chunk.position.X < __instance.player.Value.Position.X - 12f)
                        {
                            chunk.xVelocity.Value = Math.Min(chunk.xVelocity.Value + 0.8f, 8f);
                        }
                        else if (chunk.position.X > __instance.player.Value.Position.X + 12f)
                        {
                            chunk.xVelocity.Value = Math.Max(chunk.xVelocity.Value - 0.8f, -8f);
                        }

                        int y = __instance.player.Value.StandingPixel.Y;
                        if (chunk.position.Y + 32f < (float)(y - 12))
                        {
                            chunk.yVelocity.Value = Math.Max(chunk.yVelocity.Value - 0.8f, -8f);
                        }
                        else if (chunk.position.Y + 32f > (float)(y + 12))
                        {
                            chunk.yVelocity.Value = Math.Min(chunk.yVelocity.Value + 0.8f, 8f);
                        }

                        chunk.position.X += chunk.xVelocity.Value;
                        chunk.position.Y -= chunk.yVelocity.Value;
                        Point standingPixel = __instance.player.Value.StandingPixel;
                        if (Math.Abs(chunk.position.X + 32f - (float)standingPixel.X) <= 64f && Math.Abs(chunk.position.Y + 32f - (float)standingPixel.Y) <= 64f)
                        {
                            Item item = __instance.item;
                            if (__instance.collect(__instance.player.Value, chunk))
                            {
                                if (Game1.debrisSoundInterval <= 0f)
                                {
                                    Game1.debrisSoundInterval = 10f;
                                    if (item?.QualifiedItemId != "(O)73" && __instance.itemId.Value != "(O)73")
                                    {
                                        location.localSound("coin");
                                    }
                                }

                                __instance.Chunks.RemoveAt(num);
                            }
                        }
                    }
                }
                else
                {
                    if (__instance.debrisType.Value == Debris.DebrisType.NUMBERS)
                    {
                        __instance.updateHoverPosition(chunk);
                    }

                    chunk.position.X += chunk.xVelocity.Value;
                    chunk.position.Y -= chunk.yVelocity.Value;
                    if (__instance.movingFinalYLevel)
                    {
                        __instance.chunkFinalYLevel -= (int)Math.Ceiling(chunk.yVelocity.Value / 2f);
                        if (__instance.chunkFinalYLevel <= __instance.chunkFinalYTarget)
                        {
                            __instance.chunkFinalYLevel = __instance.chunkFinalYTarget;
                            __instance.movingFinalYLevel = false;
                        }
                    }

                    if (chunk.bounces <= (__instance.floppingFish.Value ? 65 : 2))
                    {
                        if (__instance.debrisType.Value == Debris.DebrisType.SPRITECHUNKS)
                        {
                            chunk.yVelocity.Value -= 0.25f;
                        }
                        else
                        {
                            chunk.yVelocity.Value -= 0.4f;
                        }
                    }

                    bool flag3 = false;
                    bool movingUp = false;
                    if (chunk.position.Y >= (float)__instance.chunkFinalYLevel && chunk.hasPassedRestingLineOnce.Value)
                    {
                        Vector2 chunkTile = new Vector2((int)((chunk.position.X + 32f) / 64f), (int)((chunk.position.Y + 32f) / 64f));
                        bool flag4 = chunk.bounces <= (__instance.floppingFish.Value ? 65 : 2);
                        if (flag4)
                        {
                            Point tile = new Point((int)chunk.position.X / 64, __instance.chunkFinalYLevel / 64);
                            if (Game1.currentLocation is IslandNorth && (__instance.debrisType.Value == Debris.DebrisType.ARCHAEOLOGY || __instance.debrisType.Value == Debris.DebrisType.OBJECT || __instance.debrisType.Value == Debris.DebrisType.RESOURCE || __instance.debrisType.Value == Debris.DebrisType.CHUNKS) && Game1.currentLocation.isTileOnMap(tile.X, tile.Y) && !Game1.currentLocation.hasTileAt(tile, "Back"))
                            {
                                __instance.chunkFinalYLevel += 48;
                            }

                            chunk.bounces++;
                            if (__instance.floppingFish.Value)
                            {
                                chunk.yVelocity.Value = Math.Abs(chunk.yVelocity.Value) * ((movingUp && chunk.bounces < 2) ? 0.6f : 0.9f);
                                chunk.xVelocity.Value = (float)Game1.random.Next(-250, 250) / 100f;
                            }
                            else
                            {
                                chunk.yVelocity.Value = Math.Abs(chunk.yVelocity.Value * 2f / 3f);
                                chunk.rotationVelocity = (Game1.random.NextBool() ? (chunk.rotationVelocity / 2f) : ((0f - chunk.rotationVelocity) * 2f / 3f));
                                chunk.xVelocity.Value -= chunk.xVelocity.Value / 2f;
                            }

                            if (__instance.debrisType.Value != DebrisType.LETTERS && __instance.debrisType.Value != DebrisType.SPRITECHUNKS && __instance.debrisType.Value != DebrisType.NUMBERS && location.doesTileSinkDebris((int)chunkTile.X, (int)chunkTile.Y, __instance.debrisType.Value))
                            {
                                flag3 = location.sinkDebris(__instance, chunkTile, chunk.position.Value);
                                if (__instance.isSinking.Value)
                                {
                                    chunk.xVelocity.Value = 0f;
                                    chunk.yVelocity.Value = 0f;
                                }
                            }
                            else if (__instance.debrisType.Value != Debris.DebrisType.LETTERS && __instance.debrisType.Value != Debris.DebrisType.NUMBERS && __instance.debrisType.Value != Debris.DebrisType.SPRITECHUNKS && (__instance.debrisType.Value != 0 || __instance.chunkType.Value == 8) && __instance.shouldControlThis(location))
                            {
                                location.playSound("shiny4");
                            }
                        }
                        if (__instance.isSinking.Value)
                        {
                            if (!flag4)
                            {
                                chunk.bob = (float)Math.Sin(Game1.currentGameTime.TotalGameTime.TotalSeconds * 1.25 + (double)(position.X / 32f)) * 4f;
                            }

                            chunk.sinkTimer.Value -= time.ElapsedGameTime.Milliseconds;
                            if (chunk.sinkTimer.Value <= 0)
                            {
                                flag3 = location.sinkDebris(__instance, chunkTile, chunk.position.Value);
                            }
                        }
                    }

                    int num2 = (int)((chunk.position.X + 32f) / 64f);
                    int num3 = (int)((chunk.position.Y + 32f) / 64f);
                    if ((!chunk.hitWall && location.Map.RequireLayer("Buildings").Tiles[num2, num3] != null && location.doesTileHaveProperty(num2, num3, "Passable", "Buildings") == null) || location.Map.RequireLayer("Back").Tiles[num2, num3] == null)
                    {
                        chunk.xVelocity.Value = 0f - chunk.xVelocity.Value;
                        chunk.hitWall = true;
                    }

                    if (chunk.position.Y < (float)__instance.chunkFinalYLevel)
                    {
                        chunk.hasPassedRestingLineOnce.Value = true;
                    }

                    if (chunk.bounces > (__instance.floppingFish.Value ? 65 : 2))
                    {
                        chunk.yVelocity.Value = 0f;
                        chunk.xVelocity.Value = 0f;
                        chunk.rotationVelocity = 0f;
                    }

                    chunk.rotation += chunk.rotationVelocity;
                    if (flag3)
                    {
                        __instance.Chunks.RemoveAt(num);
                    }
                }
            }
        }

        if (!flag && __instance.shouldControlThis(location))
        {
            __instance.player.Value = null;
        }

        if (__instance.Chunks.Count == 0)
        {
            __result = false;
            return false;
        }

        __result = false;
        return false;
        
  
        
    }



    //used to replace the private function
    public static Vector2 approximatePosition(Debris Chunks)
    {

        Vector2 vector = default(Vector2);
        foreach (Chunk chunk in Chunks.Chunks)
        {
            vector += chunk.position.Value;
        }

        return vector / Chunks.Chunks.Count;
    }

    //use to replace the private function
    public static Farmer findBestPlayer(Debris __Instance, GameLocation location)
    {
        if (location?.IsTemporary ?? false)
        {
            return Game1.player;
        }

        Vector2 vector = approximatePosition(__Instance);
        float num = float.MaxValue;
        Farmer farmer = null;
        foreach (Farmer farmer2 in location.farmers)
        {
            if ((farmer2.UniqueMultiplayerID != __Instance.DroppedByPlayerID.Value || farmer == null) && playerInRange(__Instance, vector, farmer2))
            {
                float num2 = (farmer2.Position - vector).LengthSquared();
                if (num2 < num || (farmer != null && farmer.UniqueMultiplayerID == __Instance.DroppedByPlayerID.Value))
                {
                    farmer = farmer2;
                    num = num2;
                }
            }
        }

        return farmer;
    }


    //is private in original code so creating it here
    public static bool playerInRange(Debris __Instance, Vector2 position, Farmer farmer)
    {
        if (__Instance.isEssentialItem())
        {
            return true;
        }

        int appliedMagneticRadius = farmer.GetAppliedMagneticRadius();
        Point standingPixel = farmer.StandingPixel;
        if (Math.Abs(position.X + 32f - (float)standingPixel.X) <= (float)appliedMagneticRadius)
        {
            return Math.Abs(position.Y + 32f - (float)standingPixel.Y) <= (float)appliedMagneticRadius;
        }

        return false;
    }


    //Don't edit anymore works with items
    public static bool PrefixaddItemToInventoryBool(Debris __instance, Item item, ref bool __result, bool makeActiveObject = false)
    {
        if (item == null)
        {
            return true;
        }
        
        // if filter is on then don't run this ending scrip instead continue to check filters
        if (!Instance.LootFilterOn)
        {
            return true;
        }
        
        var filteredItem = Instance.Config.ObjectToFilter.FirstOrDefault(f =>
            f.ItemId.Contains(item.ItemId) && f.ShouldFilter);

        if (filteredItem != null)
        {
           
            if (filteredItem.ShouldFilter)
            {

               __result = true;  //true will remove item debris

               
                Farmer player = Game1.player;
                int randomNumber = Game1.random.Next(Instance.Config.distanceFilterItemMovesAwayFromPlayer, Instance.Config.distanceFilterItemMovesAwayFromPlayer+2);
    
                // Calculate a position a bit away from the player
                int tileX = (int)player.Tile.X + randomNumber; // random tiles to the right
                int tileY = (int)player.Tile.Y; // Same Y level

                // Spawn the object at the specified location
                Game1.createObjectDebris(item.ItemId, tileX, tileY, player.UniqueMultiplayerID);

                return false;
            }

        }
        
        return true;
    }



    public static bool shouldItemBeFiltered(Debris __instance)
    {
     var filteredItem = Instance.Config.ObjectToFilter.FirstOrDefault(f =>
     f.ItemId.Contains(__instance.item.ItemId) && f.ShouldFilter);

        if (filteredItem != null)
        {

            if (filteredItem.ShouldFilter)
            {

                return true;  //Yes Item should be filtered

                
                
            }

        }

    return false;

    }


}