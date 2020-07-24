using static Terraria.ModLoader.ModContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.ComponentModel;

namespace BoulderMod.Tiles
{
    public class CoalOre : ModTile
    {
        public override void SetDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
            Main.tileValue[Type] = 110; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
            //Main.tileShine2[Type] = true; // Modifies the draw color slightly.
            //Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
            Main.tileMergeDirt[Type] = true;
            //Main.tileMergeStone[Type] = true;
            Main.tileSolid[Type] = true;
            dustType = 1;
            drop = ItemID.Coal;
            AddMapEntry(new Color(35, 35, 35));
            mineResist = 1f;
            minPick = 35;
            soundType = 21;
            Main.tileBlockLight[Type] = true;
        }
    }
}