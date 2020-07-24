using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.PlayerHeadDrawInfo;

namespace BoulderMod.Items
{
	public class PlasmaCannon : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Plasma Cannon");
			Tooltip.SetDefault("Fires streams of electricity erratically");
		}

		public override void SetDefaults() 
		{
			item.noMelee = true;
            item.damage = 50;
			item.ranged = true;
			item.width = 78;
			item.height = 20;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 5;
			item.knockBack = 5f;
			item.value = 200000;
			item.rare = 5;
			item.UseSound = SoundID.Item61;
			item.autoReuse = true;
            item.shootSpeed = 10f;
            item.maxStack = 1;
            item.shoot = mod.ProjectileType("StarPlasmaCanister");
			item.useAmmo = (ItemType<StarPlasmaCanister>());
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 70f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-20, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddIngredient(ItemID.Shotgun, 1);
			recipe.AddIngredient(ItemType<MercuryIngot>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}