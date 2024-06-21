using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MimicsPlus.Content.Buffs
{
    public class DesertScarabBuff : ModBuff
    {
        public override void SetStaticDefaults() {
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
    }
    
}