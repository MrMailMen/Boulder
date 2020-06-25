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
	public class CoalOre : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Coal Stone Block");
		}

		public override void SetDefaults() 
		{
            item.width = 18;
            item.height = 18;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
			item.value = 10;
			item.rare = 1;
            item.consumable = true;
            item.maxStack = 999;
            item.createTile = mod.TileType("CoalOre");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coal, 1);
            recipe.AddIngredient(ItemID.StoneBlock, 1);
            recipe.AddTile(412);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}