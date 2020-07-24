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

namespace BoulderMod.Bosses
{
	//[AutoloadBossHead]

	public class BoulderBoss : ModNPC
	{
		Random random = new Random();
		private float speed;
		private float accel;
		private int ai;
		private int mode = 1; // 1 is default, 2 is blocking, 3 is jabbing, 4 is juggling, 5 is pouncing
		private int timer = 0; // time before phase changes
		private int frame; // the current frame 
		private float army = 1f;
		private int npcSpawned;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flying Boulder");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.width = 32;
			npc.height = 32;

			npc.boss = true;
			npc.aiStyle = -1;
			npc.npcSlots = 5f;

			npc.lifeMax = 1500;
			npc.life = 1500;
			npc.damage = 50;
			npc.defense = 10;
			npc.knockBackResist = 0f;
            npc.velocity.X = 0f;
            npc.stepSpeed = 0f;

        npc.value = Item.buyPrice(gold: 1);

			npc.lavaImmune = true;
			npc.noTileCollide = true;
			npc.noGravity = true;

			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath3;
			music = MusicID.Boss5;

			bossBag = mod.ItemType("BoulderTreasureBag");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = ((int)(2350 + (numPlayers * 1300)));
			npc.damage = 80;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frame.Y = frameHeight * frame;
		}

		public override void NPCLoot()
        {
			if (Main.expertMode)
            {
				npc.DropBossBags();
            }
			else
            {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 999, random.Next(3, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 182, random.Next(3, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 178, random.Next(3, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 179, random.Next(3, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 177, random.Next(3, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 180, random.Next(3, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 181, random.Next(3, 5));

			}
		}

		public override void BossLoot(ref string name, ref int potionType)
        {
			potionType = ItemID.GreaterHealingPotion;
        }

        public override void AI()
        {
            Vector2 targetPosition = Main.player[npc.target].position;
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];

			if(mode == 1)
            {
				npc.noTileCollide = true;
				npc.noGravity = true;
				if (targetPosition.Y < npc.position.Y)
				{
					npc.velocity.Y -= 0.2f;
				}

				else if (targetPosition.Y > npc.position.Y)
				{
					npc.velocity.Y += 0.2f;
				}

				if (targetPosition.X < npc.position.X)
				{
					npc.velocity.X -= 0.2f;
				}

				else if (targetPosition.X > npc.position.X)
				{
					npc.velocity.X += 0.2f;
				}

				if (npc.velocity.X > 6)
				{
					npc.velocity.X = 6;
				}
				if (npc.velocity.X < -6)
				{
					npc.velocity.X = -6;
				}
				if (npc.velocity.Y > 6)
				{
					npc.velocity.Y = 6;
				}
				if (npc.velocity.Y < -6)
				{
					npc.velocity.Y = -6;
				}
				if ((npc.position.X - 4 < targetPosition.X) && (npc.position.X + 4 > targetPosition.X) && (npc.position.Y < targetPosition.Y) && (timer > 300))
                {
					mode = 2;
					timer = 0;
                }
			}

			if(mode == 2)
            {
				if (timer > 60)
                {
					mode = 1;
                }
				npc.velocity.X = npc.velocity.X / 2;
				npc.noTileCollide = false;
				npc.noGravity = false;
			}
			timer = timer + 1;

			if((npcSpawned < 1) && ((1.5 * npc.life) < npc.lifeMax))
            {
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("Boulderling"));
				npcSpawned = npcSpawned + 1;
			}
			if ((npcSpawned < 2) && ((2 * npc.life) < npc.lifeMax))
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("Boulderling"));
				npcSpawned = npcSpawned + 1;
			}
			if ((npcSpawned < 3) && ((3 * npc.life) < npc.lifeMax))
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("Boulderling"));
				npcSpawned = npcSpawned + 1;
			}
			if ((npcSpawned < 4) && ((4 * npc.life) < npc.lifeMax))
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("Boulderling"));
				npcSpawned = npcSpawned + 1;
			}

			if (NPC.AnyNPCs(mod.NPCType("Boulderling")))
			{
				npc.defense = 100;
			}
			else
			{
				npc.defense = 10;
			}

			if (!player.active)
			{
				npc.noTileCollide = true;
				npc.noGravity = false;
			}
		}
	}
}

