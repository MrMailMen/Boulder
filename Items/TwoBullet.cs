using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoulderMod.Items
{
	public class TwoBullet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Twin Bullet");
			Tooltip.SetDefault("Fires two bullets instead of 1, but is innacurrate");
		}

		public override void SetDefaults() 
		{
			item.damage = 0;
			item.ranged = true;
			item.knockBack = 1f;
			item.value = 10;
			item.rare = 3;
            item.shootSpeed = 12f;
            item.consumable = true;
            item.maxStack = 999;
            item.shoot = ProjectileType<Projectiles.TwoBullet>();
            item.ammo = AmmoID.Bullet;
        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 2);
            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}


	}
}