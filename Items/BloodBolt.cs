using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoulderMod.Items
{
	public class BloodBolt : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Blood Bolt");
			Tooltip.SetDefault("Casts multiple slow moving bolts of blood");
		}

		public override void SetDefaults() 
		{
			item.mana = 11;
			item.noMelee = true;
            item.damage = 34;
			item.magic = true;
			item.width = 28;
			item.height = 32;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 5f;
			item.value = 200000;
			item.rare = 6;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
            item.shootSpeed = 2.25f;
            item.maxStack = 1;
            item.shoot = mod.ProjectileType("BloodBolt");
        }

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 2;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25)); // 30 degree spread.
																												// If you want to randomize the speed to stagger the projectiles
																												// float scale = 1f - (Main.rand.NextFloat() * .3f);
																												// perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(5, 0);
		}
	}
}