using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace BoulderMod.Tiles
{
    public class Liquifier : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            dustType = 11;
            AddMapEntry(new Color(50, 50, 50));
            minPick = 35;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            //TileObjectData.newTile.CoordinateHeights = new int[] { 24 };
            TileObjectData.addTile(Type);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("Liquifier"));
        }
    }
}