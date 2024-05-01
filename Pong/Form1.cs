using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Pong
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        Random spawnRand = new Random();

        //Drawing player 1 player 2 and ball assests

        Rectangle player1 = new Rectangle(100, 100, 30, 30);//left
        Rectangle player2 = new Rectangle(300, 250, 30, 30);//right

        Rectangle border = new Rectangle(30, 30, 390, 350); //border

        Rectangle speedOrb = new Rectangle(200, 200, 10, 10);//increase speed
        Rectangle doomOrb = new Rectangle(340, 100, 10, 10);//lower other players speed
        Rectangle point = new Rectangle(40, 300, 10, 10); // score



        // Sounds
        new SoundPlayer coins = new SoundPlayer(Properties.Resources.coins);
        new SoundPlayer doomed = new SoundPlayer(Properties.Resources.slowed);
        new SoundPlayer win = new SoundPlayer(Properties.Resources.win);

        //setting the player scores to start at 0
        int player1Score = 0;
        int player2Score = 0;

        //setting the player and ball properties
        int player1Speed = 4;
        int player2Speed = 4;

        //powerup speed
        int powerupXspeed = 4;
        int powerupYspeed = 4;

        //bool to check key pressed
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
        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush yellow = new SolidBrush(Color.Yellow);
        SolidBrush red = new SolidBrush(Color.Red);
        Pen whitePen = new Pen(Color.White, 10);
        
        public Form1()
        {
            InitializeComponent();

            int xRandom = spawnRand.Next(35, border.Width - 5);
            int yRandom = spawnRand.Next(35, border.Height - 5);
            point = new Rectangle(xRandom, yRandom, 7, 7);

            xRandom = spawnRand.Next(35, border.Width - 5);
            yRandom = spawnRand.Next(35, border.Height - 5);
            speedOrb = new Rectangle(xRandom, yRandom, 7, 7);

            xRandom = spawnRand.Next(35, border.Width - 5);
            yRandom = spawnRand.Next(35, border.Height - 5);
            doomOrb = new Rectangle(xRandom, yRandom, 7, 7);
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
            //move player 1 
            if (wPressed == true && player1.Y > 35)
            {
                player1.Y = player1.Y - player1Speed;
            }
            if (sPressed == true && player1.Y < border.Height - 5)
            {
                player1.Y = player1.Y + player1Speed;
            }
            if (aPressed == true && player1.X > 35)
            {
                player1.X = player1.X - player1Speed;
            }
            if (dPressed == true && player1.X < border.Width - 5)
            {
                player1.X = player1.X + player1Speed;
            }

            //move player 2 
            if (upPressed == true && player2.Y > 35)
            {
                player2.Y = player2.Y - player2Speed;
            }
            if (downPressed == true && player2.Y < border.Height - 5)
            {
                player2.Y = player2.Y + player2Speed;
            }
            if (leftPressed == true && player2.X > 35)
            {
                player2.X = player2.X - player2Speed;
            }
            if (rightPressed == true && player2.X < border.Width - 5)
            {
                player2.X = player2.X + player2Speed;
            }

            //Player 1 powerups

            //Point powerup
            if (player1.IntersectsWith(point))
            {
                coins.Play();
                player1Score = player1Score + 1;
                p1ScoreLabel.Text = $"{player1Score}";
                int xRandom = spawnRand.Next(35, border.Width - 5);
                int yRandom = spawnRand.Next(35, border.Height - 5);
                point = new Rectangle(xRandom, yRandom, 7, 7);
            }
            
            //speed powerup
            if (player1.IntersectsWith(speedOrb))
            {
                player1Speed = player1Speed + 1;
                int xRandom = spawnRand.Next(35, border.Width - 5);
                int yRandom = spawnRand.Next(35, border.Height - 5);
                speedOrb = new Rectangle(xRandom, yRandom, 7, 7);
            }

            //Slow powerup
            if (player1.IntersectsWith(doomOrb))
            {
                doomed.Play();  
                player2Speed = player2Speed - 1;
                int xRandom = spawnRand.Next(35, border.Width - 5);
                int yRandom = spawnRand.Next(35, border.Height - 5);
                doomOrb = new Rectangle(xRandom, yRandom, 7, 7);
            }

            //Player 2 powerups

            //Point powerup
            if (player2.IntersectsWith(point))
            {
                coins.Play();
                player2Score = player2Score + 1;
                p2ScoreLabel.Text = $"{player2Score}";
                int xRandom = spawnRand.Next(35, border.Width - 5);
                int yRandom = spawnRand.Next(35, border.Height - 5);
                point = new Rectangle(xRandom, yRandom, 7, 7);

            }

            //speed powerup
            if (player2.IntersectsWith(speedOrb))
            {
                player2Speed = player2Speed + 1;
                int xRandom = spawnRand.Next(35, border.Width - 5);
                int yRandom = spawnRand.Next(35, border.Height - 5);
                speedOrb = new Rectangle(xRandom, yRandom, 7, 7);
            }

            //Slow powerup
            if (player2.IntersectsWith(doomOrb))
            {
                doomed.Play();
                player1Speed = player1Speed - 1;
                int xRandom = spawnRand.Next(35, border.Width - 5);
                int yRandom = spawnRand.Next(35, border.Height - 5);
                doomOrb = new Rectangle(xRandom, yRandom, 7, 7);
            }
            
            //freeze player 
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
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(blueBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, point);
            e.Graphics.FillRectangle(yellow, speedOrb);
            e.Graphics.FillRectangle(red, doomOrb);
            e.Graphics.DrawRectangle(whitePen, border);
        }

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
    }
}
