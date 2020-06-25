using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoulderMod.Items
{
	public class JuggleBall : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Juggle Ball");
			Tooltip.SetDefault("Use to throw a bouncing juggle ball.");
		}

		public override void SetDefaults() 
		{
            item.noMelee = true;
            item.damage = 65;
			item.ranged = true;
			item.width = 14;
			item.height = 14;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 7.5f;
			item.value = 2;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shootSpeed = 7f;
            item.consumable = true;
            item.maxStack = 999;
            item.shoot = mod.ProjectileType("JuggleBallRanger");
        }

		public override void AddRecipes() 
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<ClownRubber>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }


	}
}