/*
* 
* Ayush Patel
* ICS3U
* Mr T
* May 08, 2023
* 
* Square Chaser Summative
* 
*/

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Pong
{
    public partial class Form1 : Form
    {
        //Creating Randoms and Stop Watch
        Random spawnRand = new Random();
        Stopwatch OrbMoveStopwatch = new Stopwatch();

        //Drawing player 1 player 2 and ball assests
        Image[] player1Images = {Properties.Resources.p1_up, Properties.Resources.p1_down, Properties.Resources.p1_left, Properties.Resources.p1_right};
        Image[] player2Images = {Properties.Resources.p2_up, Properties.Resources.p2_down, Properties.Resources.p2_left, Properties.Resources.p2_right};
        int player1FrameIndex = 0;
        int player2FrameIndex = 0;
        Image coin = Properties.Resources.coin;
        Image speed = Properties.Resources.speed;
        Image slow = Properties.Resources.slow;

        // Player 1 & 2 Rectangle
        Rectangle player1 = new Rectangle(100, 100, 40, 40);
        Rectangle player2 = new Rectangle(300, 250, 30, 30);

        //border
        Rectangle border = new Rectangle(30, 30, 390, 350);

        //Powerups
        Rectangle speedOrb = new Rectangle(200, 200, 20, 20);//increase speed
        Rectangle doomOrb = new Rectangle(340, 100, 20, 20);//lower other players speed

        //Coins
        Rectangle point = new Rectangle(40, 300, 20, 20); // score

        // Sounds
        new SoundPlayer coins = new SoundPlayer(Properties.Resources.coins);
        new SoundPlayer doomed = new SoundPlayer(Properties.Resources.slowed);
        new SoundPlayer win = new SoundPlayer(Properties.Resources.win);
        new SoundPlayer speedSound = new SoundPlayer(Properties.Resources.speedSound);

        //setting the player scores to start at 0
        int player1Score = 0;
        int player2Score = 0;

        //setting the player and ball properties
        int player1Speed = 4;
        int player2Speed = 4;

        //booleans to check key pressed
        bool wPressed = false;
        bool sPressed = false;
        bool aPressed = false;
        bool dPressed = false;
        
        bool upPressed = false;
        bool downPressed = false;
        bool leftPressed = false;
        bool rightPressed = false;

        bool player1Freeze = false;
        bool player2Freeze = false;

        //setting up the brush
        SolidBrush transparent = new SolidBrush(Color.Transparent);
        Pen whitePen = new Pen(Color.White, 10);
        
        public Form1()
        {
            InitializeComponent();

            //Spawning Powerups at random locations
            RespawnPointOrb();  
            RespawnSlowOrb();
            RespawnSpeedOrb();
            OrbMoveStopwatch.Start();
        }

        //when key is pressed
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.A:
                    aPressed = true;
                    break;
                case Keys.D:
                    dPressed = true;
                    break;

                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
                case Keys.Left:
                    leftPressed = true;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    break;
            }
        }

        //when key is not pressed
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;

                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            PlayerMovement();
            PlayerPowerups();
            DetermineWinner();    
            teleportOrbs();
            AutomaticPointMovement();

            //Freeze Player
            if (player1Speed == 0)
            {
                freeze.Start();
                player1Speed = 0;
                player1Freeze = true;
            }
            if (player2Speed == 0)
            {
                freeze.Start();
                player2Speed = 0;
                player2Freeze = true;
            }
            Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(transparent, player1);
            e.Graphics.FillRectangle(transparent, player2);
            e.Graphics.FillRectangle(transparent, point);
            e.Graphics.FillRectangle(transparent, speedOrb);
            e.Graphics.FillRectangle(transparent, doomOrb);
            e.Graphics.DrawRectangle(whitePen, border);
            e.Graphics.DrawImage(coin, point);
            e.Graphics.DrawImage(speed, speedOrb);
            e.Graphics.DrawImage(slow, doomOrb); 
            e.Graphics.DrawImage(player1Images[player1FrameIndex], player1);
            e.Graphics.DrawImage(player2Images[player2FrameIndex], player2);
        }
        //Freeze player for 1 sec
        private void freeze_Tick(object sender, EventArgs e)
        {
            if (player1Freeze == true)
            {
                player1Speed = 4;
                player1Freeze = false;
                freeze.Stop();
            }
            if (player2Freeze == true)
            {
                player2Speed = 4;
                player2Freeze = false;
                freeze.Stop();
            }
        }
        private void PlayerMovement() 
        {
            //move player 1 
            if (wPressed == true && player1.Y > 30)
            {
                player1FrameIndex = 0;
                player1.Y = player1.Y - player1Speed;

                if (player1.Y < 15)
                {
                    player1.Y = 15;
                }
            }
            if (sPressed == true && player1.Y < border.Height - 5)
            {
                player1FrameIndex = 1;
                player1.Y = player1.Y + player1Speed;

                if (player1.Y > border.Height)
                {
                    player1.Y = border.Height - 10;
                }
            }
            if (aPressed == true && player1.X > 30)
            {
                player1FrameIndex = 2;
                player1.X = player1.X - player1Speed;

                if (player1.Y < 30)
                {
                    player1.Y = border.Y - 15;
                }
            }
            if (dPressed == true && player1.X < border.Width - 5)
            {
                player1FrameIndex = 3;
                player1.X = player1.X + player1Speed;
            }

            //move player 2 
            if (upPressed == true && player2.Y > 35)
            {
                player2FrameIndex = 0;
                player2.Y = player2.Y - player2Speed;
            }
            if (downPressed == true && player2.Y < border.Height - 5)
            {
                player2FrameIndex = 1;
                player2.Y = player2.Y + player2Speed;
            }
            if (leftPressed == true && player2.X > 35)
            {
                player2FrameIndex = 2;
                player2.X = player2.X - player2Speed;
            }
            if (rightPressed == true && player2.X < border.Width - 5)
            {
                player2FrameIndex = 3;
                player2.X = player2.X + player2Speed;
            }
        }
        private void PlayerPowerups()
        {
            //Player 1 powerups
            //Point powerup
            if (player1.IntersectsWith(point))
            {
                coins.Play();
                player1Score = player1Score + 1;
                p1ScoreLabel.Text = $"{player1Score}";
                RespawnPointOrb();
            }
            //speed powerup
            if (player1.IntersectsWith(speedOrb))
            {
                speedSound.Play();
                player1Speed = player1Speed + 1;
                RespawnSpeedOrb();
            }
            //Slow powerup
            if (player1.IntersectsWith(doomOrb))
            {
                doomed.Play();
                player2Speed = player2Speed - 1;
                RespawnSlowOrb();  
            }
            //Player 2 powerups
            //Point powerup
            if (player2.IntersectsWith(point))
            {
                coins.Play();
                player2Score = player2Score + 1;
                p2ScoreLabel.Text = $"{player2Score}";
                RespawnPointOrb();
            }
            //speed powerup
            if (player2.IntersectsWith(speedOrb))
            {
                speedSound.Play();
                player2Speed = player2Speed + 1;
                RespawnSpeedOrb();
            }
            //Slow powerup
            if (player2.IntersectsWith(doomOrb))
            {
                doomed.Play();
                player1Speed = player1Speed - 1;
                RespawnSlowOrb();
            }
        }
        private void DetermineWinner()
        {
            //Determine the winner
            if (player1Score == 5)
            {
                gameTimer.Stop();
                winLabel.Text = "Player 1 Wins";
                win.Play();
            }
            if (player2Score == 5)
            {
                gameTimer.Stop();
                winLabel.Text = "Player 2 Wins";
                win.Play();
            }
        }
        private void RespawnPointOrb()
        {
            point.X = spawnRand.Next(35, border.Width - 5);
            point.Y = spawnRand.Next(35, border.Height - 5);
        }
        private void RespawnSpeedOrb()
        {
            speedOrb.X = spawnRand.Next(35, border.Width - 5) ;
            speedOrb.Y = spawnRand.Next(35, border.Height - 5);
        }
        private void RespawnSlowOrb()
        {
            doomOrb.X = spawnRand.Next(35, border.Width - 5);
            doomOrb.Y = spawnRand.Next(35, border.Height - 5);
        }
        private void teleportOrbs()
        {
            if (!player1.IntersectsWith(point) && !player2.IntersectsWith(point))
            {
                if (OrbMoveStopwatch.ElapsedMilliseconds >= 2000)
                {
                    int xRandom = spawnRand.Next(35, border.Width - 5);
                    int yRandom = spawnRand.Next(35, border.Height - 5);
                    point = new Rectangle(xRandom, yRandom, 20, 20);
                    OrbMoveStopwatch.Restart();
                }
            }
        }
        private void AutomaticPointMovement()
        {
            if (point.Y < border.Height -5 && point.Y > 35 && point.X < border.Width -5 && point.X > 35)
            {
                int xRandom = spawnRand.Next(-5, 5);
                int yRandom = spawnRand.Next(-5, 5);
                point.Y += yRandom;
                point.X += xRandom;

                if(point.Y > border.Height - 5)
                {
                    yRandom = spawnRand.Next(35, border.Height - 5);
                    point.Y = yRandom;
                }
                else if(point.Y < 35)
                {
                    yRandom = spawnRand.Next(35, border.Height - 5);
                    point.Y = yRandom;
                }
                else if(point.X < 35)
                {
                    xRandom = spawnRand.Next(50, border.Width - 5);
                    point.X = xRandom;
                }
                else if(point.X > border.Width - 5)
                {
                    xRandom = spawnRand.Next(50, border.Width - 5);
                    point.X = xRandom;
                }
            }
        }
    }  
}