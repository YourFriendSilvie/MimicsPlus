using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MimicsPlus.Content.Items.Weapons
{
    public class DesertScarab : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
        }
    }
}