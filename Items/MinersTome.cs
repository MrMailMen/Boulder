using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;

namespace BoulderMod.Items
{
	public class MinersTome : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Miner's book of knowledge");
			Tooltip.SetDefault("Enemies are less likely to target you\nIncreases mining speed by 30%\n5 defence\n'Contains knowledge of old mining techniques and survivial strategies'");
		}

		public override void SetDefaults() 
		{
			item.expert = true;
			item.accessory = true;
			item.value = 5000;
			item.rare = -12;
        }

		public override void UpdateAccessory (Player player, bool hideVisual)
        {
			player.statDefense += 5;
			player.pickSpeed *= 0.7f;
			player.aggro -= 400;
		}
	}
}