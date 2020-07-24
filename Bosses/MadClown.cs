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

	public class MadClown : ModNPC
	{
		Random random = new Random();
		private float speed;
		private float accel;
		private int ai;
		private int mode; // 1 is default, 2 is blocking, 3 is jabbing, 4 is juggling, 5 is pouncing
		private bool showtime; // lowered defence, but higher speed and damage
		private int timer = 30000; // time before phase changes
		private int frame; // the current frame 
		private int ftimer; // time before animation changes
		private int mad; // animation change rate
		private double damagemult = 1; // multiplier for damage in expert mode
		private float army = 1f;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mad Clown");
			Main.npcFrameCount[npc.type] = 16;
		}

		public override void SetDefaults()
		{
			npc.width = 58;
			npc.height = 104;

			npc.boss = true;
			npc.aiStyle = 3;
			npc.npcSlots = -5f;

			npc.lifeMax = 20500;
			npc.life = 20500;
			npc.damage = 50;
			npc.defense = 50;
			npc.knockBackResist = 0f;
            npc.velocity.X = 0f;
            npc.stepSpeed = 0f;

        npc.value = Item.buyPrice(gold: 25);

			npc.lavaImmune = true;
			npc.noTileCollide = false;
			npc.noGravity = false;

			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			music = MusicID.Boss4;

			bossBag = mod.ItemType("MadClownTreasureBag");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = ((int)(15000 + numPlayers * 15000));
			damagemult = 1.3;
			army = 2f;
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
				int choice = random.Next(3);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ClownRubber"), random.Next(150, 200)); 
				if (choice == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("JugglerGlove"), 1);
				}
				else if (choice == 1)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Soundshot"), 1);
				}
				else if (choice == 2)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodBolt"), 1);
				}
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

            if (2 * npc.life < npc.lifeMax)
			{
				showtime = true;
			}
			else
			{
				showtime = false;
			}

			if (showtime)
			{
				mad = 8;
				npc.npcSlots = -10f * army;
			}
			else
			{
				mad = 12;
				npc.npcSlots = -5f * army;
			}
            if (timer == 301 || timer == 601 || timer == 901)
            {
				mode = random.Next(1, 7);
				if (Main.expertMode)
				{
					
				}
			}
            else if (timer > 1200)
            {
                mode = 6;
                timer = 0;
            }

			if (targetPosition.X - (npc.width / 2) < npc.position.X && npc.velocity.X > -speed)
			{
				npc.spriteDirection = -1;
				npc.velocity.X -= accel;
			}

			else if (targetPosition.X - (npc.width/2) > npc.position.X && npc.velocity.X < speed)
			{
				npc.spriteDirection = 1;
				npc.velocity.X += accel;
			}

			else if (npc.velocity.X > speed)
			{
				npc.velocity.X = speed;
			}

			else if (npc.velocity.X < -speed)
			{
				npc.velocity.X = -speed;
			}

			if (npc.velocity.Y == 0) // Y Movement
			{
				if (targetPosition.Y < npc.position.Y)
				{
					npc.velocity.Y -= 18f;
				}
				else
				{
					npc.velocity.Y -= 8f;
				}
			}

            npc.rotation = 0.0f;
			npc.netAlways = true;
			npc.TargetClosest(true);

			if (npc.life >= npc.lifeMax)
				npc.life = npc.lifeMax;

			if (mode == 1) // Neutral (Balanced)
			{
				if (showtime)
				{
					if ((ftimer >= mad) && (frame == 4))
					{
						frame = 5;
					}
					else if (ftimer >= mad)
					{
						frame = 4;
					}
					npc.damage = (int)(75 * damagemult);
					npc.defense = 30;
					speed = 15f;
					accel = 0.75f;
				}
				else
				{
					if ((ftimer >= mad) && (frame == 2))
					{
						frame = 3;
					}
					else if (ftimer >= mad)
					{
						frame = 2;
					}
					npc.damage = (int)(50 * damagemult);
					npc.defense = 50;
					speed = 12f;
					accel = 0.5f;
				}
			}
			else if (mode == 2) // Blocking (Defensive)
			{
				if (showtime)
				{
					if ((ftimer >= mad) && (frame == 15))
					{
						frame = 1;
					}
					else if (ftimer >= mad)
					{
						frame = 15;
					}
					npc.damage = (int)(40 * damagemult);
					npc.defense = 100;
					speed = 5f;
					accel = 0.5f;
				}
				else
				{
					if ((ftimer >= mad) && (frame == 14))
					{
						frame = 0;
					}
					else if (ftimer >= mad)
					{
						frame = 14;
					}
					npc.damage = (int)(20 * damagemult);
					npc.defense = 120;
					speed = 3f;
					accel = 0.25f;
				}
			}
			else if (mode == 3) // Jabbing (Offensive)
			{
				if (showtime)
				{
					if ((ftimer >= mad) && (frame == 4))
					{
						frame = 7;
					}
					else if (ftimer >= mad)
					{
						frame = 4;
					}
					npc.damage = (int)(100 * damagemult);
					npc.defense = 10;
					speed = 18f;
					accel = 1.25f;
				}
				else
				{
					if ((ftimer >= mad) && (frame == 2))
					{
						frame = 6;
					}
					else if (ftimer >= mad)
					{
						frame = 2;
					}
					npc.damage = (int)(75 * damagemult);
					npc.defense = 30;
					speed = 15f;
					accel = 1f;
				}
			}
			else if (mode == 4) // Juggling (Stands still and throws balls)
			{
				if (showtime)
				{
					if ((ftimer >= mad) && (frame == 10))
					{
						frame = 11;
					}
					else if (ftimer >= mad)
					{
						frame = 10;
					}
					npc.damage = (int)(40 * damagemult);
					npc.defense = 15;
					speed = 2f;
					accel = 0.05f;
				}
				else
				{
					if ((ftimer >= mad) && (frame == 8))
					{
						frame = 9;
					}
					else if (ftimer >= mad)
					{
						frame = 8;
					}
					npc.damage = (int)(25 * damagemult);
					npc.defense = 30;
					speed = 1f;
					accel = 0.02f;
				}

                if (timer == 400 || timer == 405 || timer == 410 || timer == 450 || timer == 455 || timer == 460 || timer == 500 || timer == 505 || timer == 510 || timer == 550 || timer == 555 || timer == 560 /**/ || timer == 700 || timer == 705 || timer == 710 || timer == 750 || timer == 755 || timer == 760 || timer == 800 || timer == 805 || timer == 810 || timer == 850 || timer == 855 || timer == 860 /**/ || timer == 1000 || timer == 1005 || timer == 1010 || timer == 1050 || timer == 1055 || timer == 1060 || timer == 1100 || timer == 1105 || timer == 1110 || timer == 1150 || timer == 1155 || timer == 1160)
				{
                    Vector2 direction = npc.DirectionTo(player.Center); //thedirection
                    direction *= 7f;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("JuggleBallEvil"), 30, 0f, Main.myPlayer, player.Center.X, player.Center.Y);
                }
			}
			else if (mode == 5) // Pounce (Does a powerful leap attack)
			{
				if (showtime)
				{

					frame = 13;

					npc.damage = (int)(150 * damagemult);
					npc.defense = 10;
					speed = 20f;
					accel = 0.25f;
				}
				else
				{
					frame = 12;

					npc.damage = (int)(100 * damagemult);
					npc.defense = 30;
					speed = 18f;
					accel = 0.125f;
				}
			}

            else if (mode == 6) // Flies in the players direction
            {
                if (showtime)
                {
                    frame = 13;

                    npc.damage = (int)(100 * damagemult);
                    npc.defense = 10;
                    speed = 10f;
                    accel = 0.35f;
                }
                else
                {
                    frame = 12;

                    npc.damage = (int)(50 * damagemult);
                    npc.defense = 30;
                    speed = 8f;
                    accel = 0.25f;
                }

                if (targetPosition.Y - (npc.height / 2) < npc.position.Y && npc.velocity.Y > -speed)
                {
                    npc.velocity.Y -= accel;
                }

                else if (targetPosition.Y - (npc.height / 2) > npc.position.Y && npc.velocity.Y < speed)
                {
                    npc.velocity.Y += accel;
                }
            }

            if (mode == 6)
            {
                npc.noTileCollide = true;
                npc.noGravity = true;
            }
            else
            {
                npc.noTileCollide = false;
                npc.noGravity = false;
            }

            if (ftimer >= mad)
			{
				ftimer = 0;
			}

			ftimer = ftimer + 1;

            npc.stepSpeed = npc.velocity.X;

			if (!Main.bloodMoon)
			{
				npc.noTileCollide = true;
				npc.noGravity = false;
			}
			if (!player.active)
			{
				npc.noTileCollide = true;
				npc.noGravity = false;
			}

			timer = timer + 1;

        }
	}
}

