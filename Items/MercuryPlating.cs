using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace BoulderMod.Items
{
	public class MercuryPlating : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("MercuryPlating");
			//Tooltip.SetDefault("");
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
			item.value = 0;
			item.rare = 1;
            item.consumable = true;
            item.maxStack = 999;
            item.createTile = mod.TileType("MercuryPlating");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<MercuryOre>(), 1);
            recipe.AddIngredient(3, 10);
            recipe.AddTile(17);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<MercuryPlatingWall>(), 4);
            recipe.AddTile(18);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}