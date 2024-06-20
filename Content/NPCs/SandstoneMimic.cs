using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Microsoft.Xna.Framework;

namespace MimicsPlus.Content.NPCs
{
    public class SandstoneMimic : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.IceMimic];
        }
        public override void SetDefaults()
        {
            NPC.width = 24;
            NPC.height = 24;
            NPC.damage = 80;
            NPC.defense = 30;
            NPC.lifeMax = 500;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath6;
            NPC.value = 100000f;
            NPC.knockBackResist = 0.7f;
            NPC.aiStyle = 25;
            NPC.rarity = 4;

            AIType = NPCID.Mimic;
            AnimationType = NPCID.Mimic;
            
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.DesertCave.Chance * SpawnCondition.UndergroundMimic.Chance;
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            IItemDropRule[] primaryDrops = [
            ItemDropRule.Common(ItemID.MagicConch, 7, 1, 1),
            ItemDropRule.Common(ItemID.MysticCoilSnake, 7, 1, 1),
            ItemDropRule.Common(ItemID.SandBoots, 7, 1, 1),
            ItemDropRule.Common(ItemID.AncientChisel, 7, 1, 1),
            ItemDropRule.Common(ItemID.CatBast, 7, 1, 1) //Bast Statue
            ]; 
            npcLoot.Add(new OneFromRulesRule(1, primaryDrops));

            IItemDropRule[] secondaryDrops = [
                ItemDropRule.Common(ItemID.DesertMinecart, 15, 1, 1), ItemDropRule.Common(ItemID.UncumberingStone, 7, 1, 1)
            ];
            npcLoot.Add(new OneFromRulesRule(1, secondaryDrops));
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    int type = Main.rand.Next(11, 13);
                    Vector2 pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Vector2 vel = NPC.velocity + new Vector2(Main.rand.Next(3,5));
					Gore.NewGore(NPC.GetSource_Death(), pos, vel, type);
                }
            }
        }
    }
}
