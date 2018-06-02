using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CubeFlapps_Undermove
{
    public partial class Form1 : Form
    {

        int a = 1;
        int b = 0;
        const int gravity = 1;
        const int minPenWidth = 2;

        Bitmap bmp;
        Pen pen;
        Random rnd = new Random();
        Font f = SystemFonts.DefaultFont;

        Rectangle player;
        int playerVelocity = 0;
        int playerForce = 20;
        int score = 0;
        bool glow = true;

        Rectangle tube1;
        Rectangle tube2;
        Rectangle tube3;
        Rectangle tube4;
        Rectangle tube5;
        Rectangle tube6;
        int space = 150;
        int tubesVelocity = -3;

        bool exit = false;

        SoundPlayer soundPlayer;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pen = new Pen(Brushes.Aqua);
            player = new Rectangle(30, 30, 30, 30);
            tube1 = new Rectangle(300, 300, 80, 500);
            tube2 = new Rectangle(tube1.X, tube1.Y - tube1.Height - space, 80, 500);
            tube3 = new Rectangle(500, 400, 80, 500);
            tube4 = new Rectangle(tube3.X, tube3.Y - tube3.Height - space, 80, 500);
            tube5 = new Rectangle(700, 200, 80, 500);
            tube6 = new Rectangle(tube5.X, tube5.Y - tube5.Height - space, 80, 500);


            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream resourceStream = assembly.GetManifestResourceStream(@"CubeFlapps_Undermove.music.wav");
            soundPlayer = new SoundPlayer(resourceStream);
            soundPlayer.PlayLooping();

        }

        // Главный цикл игры. Отрисовка + логика 
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pen.Width > minPenWidth)
            {
                pen.Width--;
            }

            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);

            // Отрисовываем объекты из памяти
            Draw(g);

            pictureBox1.Image = bmp;
            g.Dispose();
        }

        private void Draw(Graphics g)
        {
            if (score == 0)
            {
                b = 0;
            }
            else if (score % 50 == 0)
            {
                b -= 1;
            }
            score++;
            if (a==1)
            {
                g.FillRectangle(Brushes.Red, tube1);
                g.FillRectangle(Brushes.Red, tube2);
                g.FillRectangle(Brushes.Red, tube3);
                g.FillRectangle(Brushes.Red, tube4);
                g.FillRectangle(Brushes.Red, tube5);
                g.FillRectangle(Brushes.Red, tube6);
            }
            else if (a==2)
            {
                g.FillRectangle(Brushes.Orange, tube1);
                g.FillRectangle(Brushes.Orange, tube2);
                g.FillRectangle(Brushes.Orange, tube3);
                g.FillRectangle(Brushes.Orange, tube4);
                g.FillRectangle(Brushes.Orange, tube5);
                g.FillRectangle(Brushes.Orange, tube6);
            }
            else if (a == 3)
            {
                g.FillRectangle(Brushes.Yellow, tube1);
                g.FillRectangle(Brushes.Yellow, tube2);
                g.FillRectangle(Brushes.Yellow, tube3);
                g.FillRectangle(Brushes.Yellow, tube4);
                g.FillRectangle(Brushes.Yellow, tube5);
                g.FillRectangle(Brushes.Yellow, tube6);

            }
            else if (a == 4)
            {
                g.FillRectangle(Brushes.Green, tube1);
                g.FillRectangle(Brushes.Green, tube2);
                g.FillRectangle(Brushes.Green, tube3);
                g.FillRectangle(Brushes.Green, tube4);
                g.FillRectangle(Brushes.Green, tube5);
                g.FillRectangle(Brushes.Green, tube6);
            }
            else if (a == 5)
            {
                g.FillRectangle(Brushes.Blue, tube1);
                g.FillRectangle(Brushes.Blue, tube2);
                g.FillRectangle(Brushes.Blue, tube3);
                g.FillRectangle(Brushes.Blue, tube4);
                g.FillRectangle(Brushes.Blue, tube5);
                g.FillRectangle(Brushes.Blue, tube6);
            }
            else if (a == 6)
            {
                g.FillRectangle(Brushes.Purple, tube1);
                g.FillRectangle(Brushes.Purple, tube2);
                g.FillRectangle(Brushes.Purple, tube3);
                g.FillRectangle(Brushes.Purple, tube4);
                g.FillRectangle(Brushes.Purple, tube5);
                g.FillRectangle(Brushes.Purple, tube6);
            }
            g.FillRectangle(Brushes.White, player);

            g.DrawRectangle(pen, player);
            g.DrawRectangle(pen, tube1);
            g.DrawRectangle(pen, tube2);
            g.DrawRectangle(pen, tube3);
            g.DrawRectangle(pen, tube4);
            g.DrawRectangle(pen, tube5);
            g.DrawRectangle(pen, tube6);
            g.DrawString(score.ToString(), f, Brushes.White, 400, 400);
        }

        private void TubesLogic()
        {
            // дигаем трубы
            tube1.X += tubesVelocity;
            tube2.X = tube1.X;

            tube3.X += tubesVelocity;
            tube4.X = tube3.X;

            tube5.X += tubesVelocity;
            tube6.X = tube5.X;

            // если правый край трубы зашел за левый край
            // то перемещаем трубы в правый край
            if (tube1.Right <= 0)
            {
                tube1.X = pictureBox1.Width;
                tube1.Y = rnd.Next(space + 30, pictureBox1.Height - 30);
                tube2.Y = tube1.Y - space - tube1.Height;
            }

            if (tube3.Right <= 0)
            {
                tube3.X = pictureBox1.Width;
                tube3.Y = rnd.Next(space + 30, pictureBox1.Height - 30);
                tube4.Y = tube3.Y - space - tube3.Height;
            }

            if (tube5.Right <= 0)
            {
                tube5.X = pictureBox1.Width;
                tube5.Y = rnd.Next(space + 30, pictureBox1.Height - 30);
                tube6.Y = tube5.Y - space - tube5.Height;
            }
        }

        private void PlayerLogic()
        {
            // Двигаем игрока с ускорением
            playerVelocity += gravity;
            player.Y += playerVelocity;

            // Если игрок нижней частью коснулся 
            // нижней части игрового поля,
            // то пермещаем его вверх и сбрасываем скорость
            // иначе если игрок коснулся потолка, то сбрасываем скорость 
            // и перемещаем его вплотную к потолку.
            if (player.Bottom >= pictureBox1.Height)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }
            else if (player.Y < 0)
            {
                playerVelocity = 0;
                player.Y = 0;
            }

            if (player.Right >= tube1.Left &&
                player.Bottom >= tube1.Top &&
                player.Left < tube1.Right) 
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }
            if (player.Right >= tube2.Left &&
                player.Top <= tube2.Bottom &&
                player.Left < tube2.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }

            if (player.Right >= tube3.Left &&
                player.Bottom >= tube3.Top &&
                player.Left < tube3.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }
            if (player.Right >= tube4.Left &&
                player.Top <= tube4.Bottom &&
                player.Left < tube4.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }

            if (player.Right >= tube5.Left &&
                player.Bottom >= tube5.Top &&
                player.Left < tube5.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }
            if (player.Right >= tube6.Left &&
                player.Top <= tube6.Bottom &&
                player.Left < tube6.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // Если нажат пробел, то добавляем скорость вверх
            if(e.KeyCode == Keys.Space)
            {
                if (label1.Visible == false)
                {
                    playerVelocity -= playerForce;
                    draw_timer.Start();
                    tubes_timer.Start();
                    player_timer.Start();

                    if (glow==true)
                    {
                        pen.Width = 10;
                    }
                }
                a++;
                if (a==7)
                {
                    a = 1;
                }
            }
            else if(e.KeyCode == Keys.Escape)
            {
                draw_timer.Enabled = !draw_timer.Enabled;
                player_timer.Enabled = !player_timer.Enabled;
                tubes_timer.Enabled = !tubes_timer.Enabled;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
            }
            else if(e.KeyCode == Keys.L)
            {
                draw_timer.Stop();
                player_timer.Stop();
                tubes_timer.Stop();
                new LeaderboardForm(score).Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);

            // Отрисовываем объекты из памяти
            Draw(g);

            pictureBox1.Image = bmp;
            g.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            draw_timer.Start();
            tubes_timer.Start();
            player_timer.Start();

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new LeaderboardForm(score).Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (exit==false)
            {
                new ExitForm().Show();
                exit = true;
            }
            else
            {
                Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new SettingsForm().Show();
        }

        private void tubes_timer_Tick(object sender, EventArgs e)
        {
            TubesLogic();
        }

        private void player_timer_Tick(object sender, EventArgs e)
        {
            PlayerLogic();
        }

        private void settingsUpdateTimer_Tick(object sender, EventArgs e)
        {
            string[] settings = File.ReadAllLines("settings");
            if (settings.Length >= 3)
            {
                if (b!=0)
                {
                    player_timer.Interval = Convert.ToInt32(settings[0]) + b;
                    tubes_timer.Interval = Convert.ToInt32(settings[1]) + b;
                    glow = Convert.ToBoolean(settings[2]);
                }
                else if(b==0)
                {
                    player_timer.Interval = 20;
                    tubes_timer.Interval = 20;
                    glow = Convert.ToBoolean(settings[2]);
                }
                File.WriteAllLines("settings", settings);
            }
        }

    }
}
