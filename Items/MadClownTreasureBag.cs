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
	public class MadClownTreasureBag : ModItem
	{
		public override int BossBagNPC => mod.NPCType("MadClown");

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
			int choice = random.Next(3);
			player.QuickSpawnItem(ItemID.GoldCoin, 50);
			player.QuickSpawnItem(mod.ItemType("FoulGrinningIdol"), 1);
			player.QuickSpawnItem(mod.ItemType("ClownRubber"), Main.rand.Next(150, 200));
			if (choice == 0)
            {
				player.QuickSpawnItem(mod.ItemType("JugglerGlove"), 1);
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(mod.ItemType("Soundshot"), 1);
			}
			else if (choice == 2)
			{
				player.QuickSpawnItem(mod.ItemType("BloodBolt"), 1);
			}

		}
	}
}