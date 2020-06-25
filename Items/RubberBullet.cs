using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoulderMod.Items
{
	public class RubberBullet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Rubber Bullet");
			Tooltip.SetDefault("Bounces Everywhere");
		}

		public override void SetDefaults() 
		{
			item.damage = 2;
			item.ranged = true;
			item.knockBack = 7.5f;
			item.value = 2;
			item.rare = 2;
            item.shootSpeed = 12f;
            item.consumable = true;
            item.maxStack = 999;
            item.shoot = ProjectileType<Projectiles.RubberBullet>();
            item.ammo = AmmoID.Bullet;
        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 100);
            recipe.AddIngredient(ItemType<ClownRubber>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 100);
			recipe.AddRecipe();
		}


	}
}