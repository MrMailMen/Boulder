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

namespace BoulderMod.Enemies
{

	public class Cinderblock : ModNPC
	{
		Random random = new Random();
		private float speed;
		private int ai;
		private int frame; // the current frame 
		private int pivot;
		private float roll = 0.6f;
		private float lastX;
		private float lastV;
		private float lastY;
		private bool climbing;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cinderblock");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.width = 24;
			npc.height = 24;

			npc.boss = false;
			npc.aiStyle = -1;
			npc.npcSlots = 0.5f;

			npc.lifeMax = 195;
			npc.life = 195;
			npc.damage = 45;
			npc.defense = 15;
			npc.knockBackResist = 0f;
			npc.velocity.X = 0f;

			npc.value = Item.buyPrice(silver: 1, copper: 50);

			npc.lavaImmune = true;
			npc.noTileCollide = false;
			npc.noGravity = false;

			npc.HitSound = SoundID.NPCHit52;
			npc.DeathSound = SoundID.NPCDeath14;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frame.Y = frameHeight * frame;
		}

		public override void NPCLoot()
		{
			if (NPC.downedBoss2 && (random.Next(25) == 1))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hellstone);
			}

			if (random.Next(65) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Meteorite);
			}

			if (random.Next(15) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Obsidian);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (spawnInfo.player.ZoneUnderworldHeight)
			{
				return 0.7f;
			}
			else
			{
				return 0f;
			}
		}

		public override void AI()
        {
			Vector2 targetPosition = Main.player[npc.target].position;
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 6);

			if (true)
			{
				if (targetPosition.X - (npc.width / 2) < npc.position.X) // Turn
				{
					pivot -= 1;
				}

				else if (targetPosition.X - (npc.width / 2) > npc.position.X) // Turn
				{
					pivot += 1;
				}
				if (pivot == 13 || pivot == -13)
				{
					pivot = 0;
				}
				if (pivot == 0) // Neutral
				{
					npc.velocity.X = 0f * roll;
					frame = 5;
				}

				if (pivot == 1) // Start of positive Pivot
				{
					npc.velocity.X = 1f * roll;
					frame = 4;
					npc.spriteDirection = 1;
				}

				if (pivot == 2)
				{
					npc.velocity.X = 2f * roll;
					frame = 3;
					npc.spriteDirection = 1;
				}

				if (pivot == 3)
				{
					npc.velocity.X = 3f * roll;
					frame = 4;
					npc.spriteDirection = 1;
				}

				if (pivot == 4)
				{
					npc.velocity.X = 4f * roll;
					frame = 3;
					npc.spriteDirection = 1;
				}

				if (pivot == 5)
				{
					npc.velocity.X = 5f * roll;
					frame = 2;
					npc.spriteDirection = 1;
				}

				if (pivot == 6)
				{
					npc.velocity.X = 6f * roll;
					frame = 1;
					npc.spriteDirection = 1;
				}

				if (pivot == 7)
				{
					npc.velocity.X = 7f * roll;
					frame = 0;
				}

				if (pivot == 8)
				{
					npc.velocity.X = 8f * roll;
					frame = 1;
					npc.spriteDirection = -1;
				}

				if (pivot == 9)
				{
					npc.velocity.X = 9f * roll;
					frame = 2;
					npc.spriteDirection = -1;
				}

				if (pivot == 10)
				{
					npc.velocity.X = 10f * roll;
					frame = 3;
					npc.spriteDirection = -1;
				}

				if (pivot == 11)
				{
					npc.velocity.X = 11f * roll;
					frame = 4;
					npc.spriteDirection = -1;
				}

				if (pivot == 12)
				{
					npc.velocity.X = 12f * roll;
					frame = 5;
					npc.spriteDirection = -1;
				}

				if (pivot == -1) // Start of negative Pivot
				{
					npc.velocity.X = -1f * roll;
					frame = 4;
					npc.spriteDirection = -1;
				}

				if (pivot == -2)
				{
					npc.velocity.X = -2f * roll;
					frame = 3;
					npc.spriteDirection = -1;
				}

				if (pivot == -3)
				{
					npc.velocity.X = -3f * roll;
					frame = 4;
					npc.spriteDirection = -1;
				}

				if (pivot == -4)
				{
					npc.velocity.X = -4f * roll;
					frame = 3;
					npc.spriteDirection = -1;
				}

				if (pivot == -5)
				{
					npc.velocity.X = -5f * roll;
					frame = 2;
					npc.spriteDirection = -1;
				}

				if (pivot == -6)
				{
					npc.velocity.X = -6f * roll;
					frame = 1;
					npc.spriteDirection = -1;
				}

				if (pivot == -7)
				{
					npc.velocity.X = -7f * roll;
					frame = 0;
				}

				if (pivot == -8)
				{
					npc.velocity.X = -8f * roll;
					frame = 1;
					npc.spriteDirection = 1;
				}

				if (pivot == -9)
				{
					npc.velocity.X = -9f * roll;
					frame = 2;
					npc.spriteDirection = 1;
				}

				if (pivot == -10)
				{
					npc.velocity.X = -10f * roll;
					frame = 3;
					npc.spriteDirection = 1;
				}

				if (pivot == -11)
				{
					npc.velocity.X = -11f * roll;
					frame = 4;
					npc.spriteDirection = 1;
				}

				if (pivot == -12)
				{
					npc.velocity.X = -12f * roll;
					frame = 5;
					npc.spriteDirection = 1;
				}
			}
			if (!(pivot == 0) && !(pivot == 1) && !(pivot == -1) && npc.position.X == lastX)
			{
				npc.velocity.Y -= 0.5f;
				climbing = true;
            }
			else
            {
				climbing = false;
            }
			if (!(npc.velocity.X == 0) && !(npc.velocity.Y == 0) && !climbing)
            {
				npc.velocity.X = lastV;
            }

			lastX = npc.position.X;
			lastV = npc.velocity.X;
			lastY = npc.position.Y;
		}
	}
}