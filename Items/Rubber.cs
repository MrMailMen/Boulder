using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace BoulderMod.Items
{
	public class Rubber : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Rubber");
			Tooltip.SetDefault("Authentic!");
		}

		public override void SetDefaults() 
		{
            item.width = 16;
            item.height = 16;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
			item.value = 10;
			item.rare = 2;
            item.consumable = true;
            item.maxStack = 999;
            item.createTile = mod.TileType("RubberBlock");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Oil>(), 6);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}