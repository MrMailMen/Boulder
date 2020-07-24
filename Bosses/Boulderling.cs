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

	public class Boulderling : ModNPC
	{
		Random random = new Random();
		private float speed;
		private float accel;
		private int ai;
		private int mode = 1; // 1 is default, 2 is blocking, 3 is jabbing, 4 is juggling, 5 is pouncing
		private int timer = 0; // time before phase changes
		private int frame; // the current frame 

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lesser Flying Boulder");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.width = 24;
			npc.height = 24;

			npc.boss = false;
			npc.aiStyle = -1;
			npc.npcSlots = 2f;

			npc.lifeMax = 400;
			npc.life = 400;
			npc.damage = 50;
			npc.defense = 5;
			npc.knockBackResist = 0f;
            npc.velocity.X = 0f;
            npc.stepSpeed = 0f;

        npc.value = Item.buyPrice(gold: 0);

			npc.lavaImmune = true;
			npc.noTileCollide = true;
			npc.noGravity = true;

			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath3;
			music = MusicID.Boss5;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = ((int)(650));
			npc.damage = 80;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frame.Y = frameHeight * frame;
		}

		public override void NPCLoot()
        {

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
					npc.velocity.Y -= 0.25f;
				}

				else if (targetPosition.Y > npc.position.Y)
				{
					npc.velocity.Y += 0.25f;
				}

				if (targetPosition.X < npc.position.X)
				{
					npc.velocity.X -= 0.25f;
				}

				else if (targetPosition.X > npc.position.X)
				{
					npc.velocity.X += 0.25f;
				}

				if (npc.velocity.X > 5)
				{
					npc.velocity.X = 5;
				}
				if (npc.velocity.X < -5)
				{
					npc.velocity.X = -5;
				}
				if (npc.velocity.Y > 5)
				{
					npc.velocity.Y = 5;
				}
				if (npc.velocity.Y < -5)
				{
					npc.velocity.Y = -5;
				}
				if ((npc.position.X - 4 < targetPosition.X) && (npc.position.X + 4 > targetPosition.X) && (npc.position.Y < targetPosition.Y) && (timer > 120))
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
		}
	}
}

