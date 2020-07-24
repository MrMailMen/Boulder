using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoulderMod.Items
{
	public class CactusGrenade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cactus Grenade");
			Tooltip.SetDefault("'Ow ow it hurts to hold'");
		}

		public override void SetDefaults() 
		{
            item.noMelee = true;
            item.damage = 45;
			item.ranged = true;
			item.width = 22;
			item.height = 22;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 1;
			item.knockBack = 7.5f;
			item.value = 85;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shootSpeed = 6.5f;
            item.consumable = true;
            item.maxStack = 999;
            item.shoot = mod.ProjectileType("CactusGrenade");
		}

		public override void AddRecipes() 
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Grenade, 5);
			recipe.AddIngredient(ItemID.Cactus, 1);
			recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }


	}
}