using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoulderMod.Items
{
	public class StarPlasmaCanister : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Star Plasma Canister");
			Tooltip.SetDefault("Liquified fallen stars encased in a metal container");
		}

		public override void SetDefaults() 
		{
			item.value = 20;
			item.rare = 5;
            item.maxStack = 999;
			item.consumable = true;
			item.ammo = item.type;
		}

		public override void AddRecipes() 
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddIngredient(ItemID.Glass, 5);
			recipe.AddIngredient(ItemType<MercuryIngot>(), 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 250);
            recipe.AddRecipe();
        }


	}
}