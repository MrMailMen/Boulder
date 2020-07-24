using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

//using BoulderMod.Buffs;
using BoulderMod.Items;
using BoulderMod.Projectiles;

namespace BoulderMod
{
    public class Players : ModPlayer
    {
        public bool mercuryBiome = false;

        public override void PostUpdate()
        {
            if (mercuryBiome) // Does stuff if mercury biome is true
            {

            }
            else
            {

            }

        }

        public override void UpdateBiomes()
        {
            mercuryBiome = (World.mercuryTiles > 100);
        }

        public override bool CustomBiomesMatch(Player other)
        {
            Players otherPlayer = other.GetModPlayer<Players>();
            return mercuryBiome == otherPlayer.mercuryBiome;
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            Players otherPlayer = other.GetModPlayer<Players>();
            otherPlayer.mercuryBiome = mercuryBiome;
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = mercuryBiome;
            writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            mercuryBiome = flags[0];
        }

        public override void UpdateBiomeVisuals()
        {

        }
    }
}

