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

	public class MercuryElemental : ModNPC
	{
		Random random = new Random();
		private int ai;
		//private int frame; // the current frame 

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mercury Elemental");
			Main.npcFrameCount[npc.type] = 22;
		}

		public override void SetDefaults()
		{
			npc.width = 10;
			npc.height = 16;
			npc.aiStyle = 91;
			aiType = 483;
			animationType = 483;

			npc.boss = false;

			npc.npcSlots = 0.2f;

			npc.lifeMax = 300;
			npc.life = 300;
			npc.damage = 40;
			npc.defense = 20;
			npc.knockBackResist = 0.1f;
			//npc.velocity.X = 0f;

			npc.value = Item.buyPrice(silver: 8, copper: 50);

			npc.lavaImmune = true;
			npc.noTileCollide = false;
			npc.noGravity = true;

			//npc.HitSound = SoundID.NPCHit41;
			//npc.DeathSound = SoundID.NPCDeath43;
		}

		/*public override void FindFrame(int frameHeight)
		{
			npc.frame.Y = frameHeight * frame;
		}*/

		public override void NPCLoot()
		{
			if (NPC.downedBoss2 && (random.Next(5) == 1))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MercuryOre"), 1);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (World.mercuryTiles > 100)
			{
				return 0f;
			}
			else
			{
				return 0f;
			}
		}
	}
}