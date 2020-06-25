using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoulderMod.Items
{
	public class Liquifier : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Liquifier");
			Tooltip.SetDefault("Used to liquify certain solids");
		}

		public override void SetDefaults() 
		{
            item.width = 44;
            item.height = 48;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
			item.value = 10000;
			item.rare = 2;
            item.consumable = true;
            item.maxStack = 999;
            item.createTile = mod.TileType("Liquifier");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverBar, 10);
            recipe.AddIngredient(ItemID.Lens, 5);
            recipe.AddIngredient(ItemID.Torch, 5);
            recipe.AddTile(16);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TungstenBar, 10);
            recipe.AddIngredient(ItemID.Lens, 5);
            recipe.AddIngredient(ItemID.Torch, 5);
            recipe.AddTile(16);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}