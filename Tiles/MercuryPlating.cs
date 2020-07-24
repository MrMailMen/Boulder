using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BoulderMod.Tiles
{
    public class MercuryPlating : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            dustType = 11;
            drop = ItemType<Items.MercuryPlating>();
            AddMapEntry(new Color(200, 200, 200));
            mineResist = 1f;
            minPick = 35;
            soundType = 21;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.5f;
            g = 0.5f;
            b = 0.5f;
        }

    }
}