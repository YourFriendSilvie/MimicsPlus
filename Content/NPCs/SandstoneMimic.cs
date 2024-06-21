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
            NPC.width = 16;
            NPC.height = 22;
            NPC.damage = 80;
            NPC.defense = 30;
            NPC.lifeMax = 500;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath6;       
            NPC.knockBackResist = 0.7f;
            NPC.aiStyle = 25;
            NPC.rarity = 4;
            NPC.value = 100000f;

            AIType = NPCID.Mimic;
            AnimationType = NPCID.Mimic;
            
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.DesertCave.Chance * (1f /70f);
            
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            IItemDropRule[] primaryDrops = [
            ItemDropRule.Common(ItemID.MagicConch, 1, 1, 1),
            ItemDropRule.Common(ItemID.MysticCoilSnake, 1, 1, 1),
            ItemDropRule.Common(ItemID.SandBoots, 1, 1, 1),
            ItemDropRule.Common(ItemID.AncientChisel, 1, 1, 1),
            ItemDropRule.Common(ItemID.CatBast, 1, 1, 1) //Bast Statue
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
                    Vector2 vel = NPC.velocity + new Vector2(Main.rand.Next(1,3));
					Gore.NewGore(NPC.GetSource_Death(), pos, vel, type);
                }
            }
        }
    }
}
