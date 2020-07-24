using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BoulderMod.Tiles
{
    public class ClownRubberBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            dustType = 5;
            drop = ItemType<Items.ClownRubber>();
            AddMapEntry(new Color(200, 0, 0));
            mineResist = 10f;
            minPick = 35;
            Main.tileBlockLight[Type] = true;
        }
    }
}