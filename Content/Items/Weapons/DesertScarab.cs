using Microsoft.Xna.Framework;
using MimicsPlus.Content.Buffs;
using MimicsPlus.Content.Projectiles;
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
        public override void SetDefaults() {
			Item.damage = 45;
			Item.knockBack = 4f;
			Item.mana = 6;
			Item.width = 20;
			Item.height = 20;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.HoldUp; 
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item44; // What sound should play when using the item

			Item.noMelee = true; 
			Item.DamageType = DamageClass.Summon;
			Item.buffType = ModContent.BuffType<DesertScarabBuff>();
			Item.shoot = ModContent.ProjectileType<DesertScarabMinion>(); 
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            position = Main.MouseWorld;
        }
    }
}