using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Terraria.DataStructures;
using Terraria.Localization;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace BoulderMod
{
    public class globalitem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.Coal)
            {
                item.maxStack = 999;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coal, 1);
            recipe.AddRecipeGroup("Wood", 5);
            recipe.SetResult(ItemID.Torch, 10);
            recipe.AddRecipe();
        }
    }
}