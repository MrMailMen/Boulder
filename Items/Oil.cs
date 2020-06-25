using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoulderMod.Items
{
	public class Oil : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Oil");
			Tooltip.SetDefault("It looks bad and smells terrible. It tastes even worse. And yet, it sells well for some strange reason");
		}

		public override void SetDefaults() 
		{
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
			item.value = 5000;
			item.rare = 1;
            item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coal, 4);
            recipe.AddTile(TileType<Tiles.Liquifier>());
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}