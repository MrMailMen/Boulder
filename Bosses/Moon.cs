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
	[AutoloadBossHead]

	public class Moon : ModNPC
	{
		Random random = new Random();
		private float speed;
		private int ai;
		private int frame; // the current frame 

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.width = 1010;
			npc.height = 1010;
			npc.scale = 1;

			npc.boss = true;
			npc.aiStyle = -1;
			npc.npcSlots = -100f;

			npc.lifeMax = 2147483647;
			npc.life = 2147483647; // Max Integer
			npc.damage = 214748364;
			npc.defense = 2147483647;
			npc.knockBackResist = 0f;
			npc.velocity.X = 0f;

			npc.value = Item.buyPrice(silver: 1, copper: 50);

			npc.lavaImmune = true;
			npc.noTileCollide = true;
			npc.noGravity = true;

			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			music = MusicID.MartianMadness;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frame.Y = frameHeight * frame;
		}
		public override bool CheckActive()
        {
			return false;
        }
		public override void NPCLoot()
		{
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return 0f;
		}

		public override void AI()
        {
			Vector2 targetPosition = Main.player[npc.target].position;
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];

			if (targetPosition.Y - (npc.height / 2) < npc.position.Y)
			{
				npc.velocity.Y -= 5f;
			}

			else if (targetPosition.Y - (npc.height / 2) > npc.position.Y)
			{
				npc.velocity.Y += 5f;
			}

			if (targetPosition.X - (npc.height / 2) < npc.position.X)
			{
				npc.velocity.X -= 5f;
			}

			else if (targetPosition.X - (npc.height / 2) > npc.position.X)
			{
				npc.velocity.X += 5f;
			}

			if (npc.velocity.X > 100)
            {
				npc.velocity.X = 100;
            }
			if (npc.velocity.X < -100)
			{
				npc.velocity.X = -100;
			}
			if (npc.velocity.Y > 100)
			{
				npc.velocity.Y = 100;
			}
			if (npc.velocity.Y < -100)
			{
				npc.velocity.Y = -100;
			}

			/*if (frame == 1)
			{
				frame = 0;
			}
			else
			{
				frame = 1;
			}*/
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 2147483647;
			npc.life = 2147483647;
			npc.damage = 214748364;
		}
	}
}