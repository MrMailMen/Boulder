using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace BoulderMod.Items
{
	public class BoulderTreasureBag : ModItem
	{
		public override int BossBagNPC => mod.NPCType("BoulderBoss");

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("<right> to open");
		}

		public override void SetDefaults() 
		{
			item.width = 36;
			item.height = 32;
			item.expert = true;
			item.rare = 9;
            item.consumable = true;
            item.maxStack = 999;
        }

		public override void OpenBossBag(Player player)
        {
			Random random = new Random();
			player.QuickSpawnItem(ItemID.GoldCoin, 1);
			player.QuickSpawnItem(mod.ItemType("MinersTome"), 1);
			player.QuickSpawnItem(999, random.Next(3, 5));
			player.QuickSpawnItem(182, random.Next(3, 5));
			player.QuickSpawnItem(178, random.Next(3, 5));
			player.QuickSpawnItem(179, random.Next(3, 5));
			player.QuickSpawnItem(177, random.Next(3, 5));
			player.QuickSpawnItem(180, random.Next(3, 5));
			player.QuickSpawnItem(181, random.Next(3, 5));
		}
	}
}