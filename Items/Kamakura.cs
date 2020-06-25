using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using static Terraria.ModLoader.PlayerHeadDrawInfo;
namespace BoulderMod.Items
{
	public class Kamakura : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Kamakura");
			Tooltip.SetDefault("'Why are swords made of liquids able to even exist'");
		}

		public override void SetDefaults() 
		{
			item.damage = 34;
			item.melee = true;
			item.width = 58;
			item.height = 58;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 1;
			item.knockBack = 2.5f;
			item.value = 40000;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.scale = 1.1f;
        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<ClownRubber>(), 50);
            recipe.AddIngredient(ItemID.Muramasa, 1);
            recipe.AddTile(TileID.CrystalBall);
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
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 5);

                // Cursed: 74
                // Shadow: 27
                // Frozen: 137
            }
        }
    }
}