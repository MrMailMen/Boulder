using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BoulderMod.Tiles
{
    public class RubberBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            dustType = 4;
            drop = ItemType<Items.Rubber>();
            AddMapEntry(new Color(20, 20, 20));
            mineResist = 2f;
            minPick = 35;
        }
    }
}