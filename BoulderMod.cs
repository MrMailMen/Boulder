using BoulderMod.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

namespace BoulderMod
{
    public class BoulderMod : Mod
    {
        public override void UpdateMusic(ref int music)
        {
            if (Main.LocalPlayer.GetModPlayer<Players>().mercuryBiome)
            {
                music = 2;
            }
        }
    }
}