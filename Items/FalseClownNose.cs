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
	public class FalseClownNose : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("False Clown Nose");
			Tooltip.SetDefault("Showing this off during a blood moon may bring bring unwanted company");
		}

		public override void SetDefaults() 
		{
			item.width = 14;
			item.height = 14;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 1;
			item.rare = 4;
            item.consumable = true;
            item.maxStack = 20;
        }

		public override bool CanUseItem(Player player)
        {
			return (!NPC.AnyNPCs(mod.NPCType("MadClown")) && (Main.bloodMoon));
        }

		public override bool UseItem(Player player)
        {
			Main.PlaySound(SoundID.Roar, player.position);
			if(Main.netMode != 1)
            {
				NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("MadClown"));
            }
			return true;
        }

		public override void AddRecipes() 
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Rubber>(), 25);
			recipe.AddIngredient(521, 15);
			recipe.AddIngredient(ItemID.RedPaint);
			recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


	}
}