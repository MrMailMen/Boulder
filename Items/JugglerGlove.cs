using Terraria.ID;
using Terraria.ModLoader;

namespace BoulderMod.Items
{
	public class JugglerGlove : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Juggler's Glove");
			Tooltip.SetDefault("Swinging releases a small juggling ball.");
		}

		public override void SetDefaults() 
		{
			item.damage = 50;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 27;
			item.useAnimation = 9;
			item.useStyle = 1;
			item.knockBack = 7.5f;
			item.value = 200000;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shootSpeed = 6f;
            item.shoot = mod.ProjectileType("JuggleBallMelee");
        }

		public override void AddRecipes() 
		{
			//ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID.DirtBlock, 10);
			//recipe.AddTile(TileID.WorkBenches);
			//recipe.SetResult(this);
			//recipe.AddRecipe();
		}


	}
}