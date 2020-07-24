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

	public class MercuryHead : ModNPC
	{
		Random random = new Random();
		private int ai;
		private int frame; // the current frame 

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mercury Head");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.width = 26;
			npc.height = 26;
			npc.aiStyle = 10;
			animationType = NPCID.MeteorHead;

			npc.boss = false;

			npc.npcSlots = 0.3f;

			npc.lifeMax = 125;
			npc.life = 250;
			npc.damage = 60;
			npc.defense = 30;
			npc.knockBackResist = 0.05f;
			npc.velocity.X = 0f;

			npc.value = Item.buyPrice(silver: 8, copper: 50);

			npc.lavaImmune = true;
			npc.noTileCollide = true;
			npc.noGravity = true;

			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath3;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frame.Y = frameHeight * frame;
		}

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
				return 100f;
			}
			else
			{
				return 0f;
			}
		}

		public override void AI()
        {

		}
	}
}