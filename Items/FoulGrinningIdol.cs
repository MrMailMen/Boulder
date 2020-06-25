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
	public class FoulGrinningIdol : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Foul Grinning Idol");
			Tooltip.SetDefault("Enemies are more likely to target you\nProvides negative life regen\n17% increased damage\n17% increased critical strike chance");
		}

		public override void SetDefaults() 
		{
			item.expert = true;
			item.accessory = true;
			item.value = 80000;
			item.rare = -12;
        }

		public override void UpdateAccessory (Player player, bool hideVisual)
        {
			player.allDamage += 0.17f;
			player.meleeCrit += 17;
			player.rangedCrit += 17;
			player.magicCrit += 17;
			player.lifeRegen -= 10;
			player.aggro += 800;
		}
	}
}