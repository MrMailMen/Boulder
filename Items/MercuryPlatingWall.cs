using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace BoulderMod.Items
{
	public class MercuryPlatingWall : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mercury Plating Wall");
			//Tooltip.SetDefault("");
		}

		public override void SetDefaults() 
		{
            item.width = 24;
            item.height = 24;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
			item.value = 0;
			item.rare = 1;
            item.consumable = true;
            item.maxStack = 999;
            item.createWall = mod.WallType("MercuryPlatingWall");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<MercuryPlating>(), 1);
            recipe.AddTile(18);
            recipe.SetResult(this, 4);
            recipe.AddRecipe();
        }
    }
}