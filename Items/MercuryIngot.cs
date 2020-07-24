using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoulderMod.Items
{
	public class MercuryIngot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mercury Bar");
			Tooltip.SetDefault("'Wet and toxic to the touch'");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.value = 10000;
			item.rare = 2;
			//item.consumable = true;
			item.maxStack = 999;
			//item.createTile = mod.TileType("ClownRubberBlock");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<MercuryOre>(), 6);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}