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
using System.IO;

namespace BoulderMod.Enemies
{

	public class MercuryGolem : ModNPC
	{
		Random random = new Random();
		private int ai;
		//private int frame; // the current frame 

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mercury Golem");
			Main.npcFrameCount[npc.type] = 20;
		}

		public override void SetDefaults()
		{
			npc.width = 28;
			npc.height = 50;
			npc.aiStyle = 3;
			aiType = NPCID.GraniteGolem;
			animationType = NPCID.GraniteGolem;

			npc.boss = false;

			npc.npcSlots = 0.8f;

			npc.lifeMax = 950;
			npc.life = 950;
			npc.damage = 150;
			npc.defense = 40;
			npc.knockBackResist = 0.03f;
			npc.velocity.X = 0f;

			npc.value = Item.buyPrice(silver: 25);

			npc.lavaImmune = false;
			npc.noTileCollide = false;
			npc.noGravity = false;

			npc.HitSound = SoundID.NPCHit41;
			npc.DeathSound = SoundID.NPCDeath43;
		}

		/*public override void FindFrame(int frameHeight)
		{
			npc.frame.Y = frameHeight * frame;
		}*/

		public override void NPCLoot()
		{
			if (NPC.downedBoss2 && (random.Next(2) == 1))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MercuryOre"), random.Next(1,3));
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (World.mercuryTiles > 100)
			{
				return 100f;
			}
			else
			{
				return 0f;
			}
		}
	}
}