using static Terraria.ModLoader.ModContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.ComponentModel;

namespace BoulderMod.Items
{
	public class Soundshot : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Soundshot");
			Tooltip.SetDefault("'Are you really going to use that as a gun?'");
		}

		public override void SetDefaults() 
		{
			item.damage = 24;
			item.ranged = true;
            item.noMelee = true;
            item.width = 38;
			item.height = 28;
            item.useTime = 34;
			item.useAnimation = 34;
			item.useStyle = 5;
			item.knockBack = 2f;
			item.value = 200000;
			item.rare = 6;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
            item.shootSpeed = 6f;
            item.shoot = 10;
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			int numberProjectiles = 7 + Main.rand.Next(3); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(45)); // 30 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                                                                                                                // float scale = 1f - (Main.rand.NextFloat() * .3f);
                                                                                                                // perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
			return true;
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
    }
}
 