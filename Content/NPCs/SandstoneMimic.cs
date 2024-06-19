using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MimicsPlus.Content.NPCs.SandstoneMimic
{
    public class SandstoneMimic : ModNPC
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sandstone Mimic");
            npc.width = 16;
            npc.height = 16;
            npc.aiStyle = NPCAiStyle.Mimic;
            npc.damage = 30;
            npc.lifeMax = 300;
            npc.defense = 12;
        }
    }
}