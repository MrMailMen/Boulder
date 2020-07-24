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

	public class MercurySlime : ModNPC
	{
		Random random = new Random();
		private int ai;
		private int frame; // the current frame 
		private int jumptime = -1;
		private int moment;
		private float lastX;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mercury Slime");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.width = 44;
			npc.height = 68;
			npc.aiStyle = -1;

			npc.boss = false;

			npc.npcSlots = 0.4f;

			npc.lifeMax = 700;
			npc.life = 700;
			npc.damage = 60;
			npc.defense = 25;
			npc.knockBackResist = 0.05f;
			npc.velocity.X = 0f;

			npc.value = Item.buyPrice(silver: 8, copper: 50);

			npc.lavaImmune = false;
			npc.noTileCollide = false;
			npc.noGravity = false;

			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frame.Y = frameHeight * frame;
		}

		public override void NPCLoot()
		{
			if ((random.Next(2) == 1))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MercuryOre"), 1);
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

		public override void AI()
        {
			if (npc.velocity.Y == 0)
            {
				npc.velocity.X = (float)(npc.velocity.X / 5f);
				moment = 0;
            }
			npc.spriteDirection = 1;
			Vector2 targetPosition = Main.player[npc.target].position;
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];

			if (jumptime < 1 && npc.velocity.Y == 0)
            {
				npc.velocity.Y -= (float)random.Next(5, 12);

				if (targetPosition.X - (npc.width / 2) < npc.position.X)
				{
					npc.velocity.X -= 5f;
					moment = -1;
				}
				else if (targetPosition.X - (npc.width / 2) > npc.position.X)
				{
					npc.velocity.X += 5f;
					moment = 1;
				}
				
				jumptime = random.Next(50, 100);
			}

			jumptime = jumptime - 1;

			if (((jumptime % 4) == 0) || (!(npc.velocity.Y == 0)) && ((jumptime % 8) == 0))
            {
				if (frame == 1)
                {
					frame = 0;
                }
				else
                {
					frame = 1;
                }
            }

			if (!(npc.position.X == lastX))
            {
				moment = 0;
            }

			if (moment == 1)
            {
				npc.velocity.X = 5;
            }
			if (moment == -1)
			{
				npc.velocity.X = -5;
			}

			npc.spriteDirection = -1;

			lastX = npc.position.X;
		}
	}
}