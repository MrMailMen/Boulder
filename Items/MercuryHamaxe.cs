
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BoulderMod.Items
{
	public class MercuryHamaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mercury Hamaxe");
		}

		public override void SetDefaults()
		{
			item.damage = 45;
			item.melee = true;
			item.width = 36;
			item.height = 34;
			item.useTime = 9;
			item.useAnimation = 26;
			item.useStyle = 1;
			item.knockBack = 4.5f;
			item.value = 100000;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.scale = 1.2f;
			item.axe = 30;
			item.hammer = 100;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<MercuryIngot>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			// Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
			// 60 frames = 1 second
			// target.AddBuff(BuffID.Bleeding, 1800);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(1))
			{
				//Emit dusts when the sword is swung
				//Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 11);

				// Cursed: 74
				// Shadow: 27
				// Frozen: 137
			}
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6.5f, +4f);
		}
	}
}