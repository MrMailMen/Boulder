using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoulderMod.Items
{
	public class MercuryOre : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mercury");
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
			item.value = 2000;
			item.rare = 5;
            item.consumable = true;
            item.maxStack = 999;
            item.createTile = mod.TileType("MercuryOre");
        }
	}
}