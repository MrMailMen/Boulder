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
	public class SuspiciousLookingStone : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Suspicious Looking Stone");
			Tooltip.SetDefault("Summons a possesed boulder");
		}

		public override void SetDefaults() 
		{
			item.width = 12;
			item.height = 12;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 1;
			item.rare = 4;
            item.consumable = true;
            item.maxStack = 20;
        }

		public override bool CanUseItem(Player player)
        {
			return (!NPC.AnyNPCs(mod.NPCType("BoulderBoss")));
        }

		public override bool UseItem(Player player)
        {
			Main.PlaySound(SoundID.Roar, player.position);
			if(Main.netMode != 1)
            {
				NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("BoulderBoss"));
            }
			return true;
        }

		public override void AddRecipes() 
		{
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Boulder);
			recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


	}
}