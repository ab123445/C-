
using System.Windows.Forms;

namespace Snake0114
{

    public partial class MainForm : Form
    {
        const int MAX_WIDTH = 30;
        const int MAX_HEIGHT = 16;

        Dir NowDir;
        Snake snake;
        List<Food> Foods = new List<Food>();
        List<Wall> Walls = new List<Wall>();
        int Stage = 0;
        Random rand = new();
        int point = 0;
        int[,,] field = new int[MAX_WIDTH, MAX_HEIGHT, 2];
        int[] WallPosX;
        int[] WallPosY;

        public MainForm()
        {
            InitializeComponent();
        }

        enum Dir
        {
            None,
            Left,
            Right,
            Up,
            Down
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width += MAX_WIDTH * Snake.X - ClientRectangle.Width;
            this.Height += MAX_HEIGHT * Snake.Y - ClientRectangle.Height + menuStrip1.Height;

            NowDir = Dir.None;
            snake = new Snake(Controls, 2, 2, this);
            timer1.Start();
            timer2.Start();
            timer1.Interval = 200;
            timer2.Interval = 2000;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left && NowDir != Dir.Right)
            {
                NowDir = Dir.Left;
                return true;
            }
            else if (keyData == Keys.Right && NowDir != Dir.Left)
            {
                NowDir = Dir.Right;
                return true;
            }
            else if (keyData == Keys.Up && NowDir != Dir.Down)
            {
                NowDir = Dir.Up;
                return true;
            }
            else if (keyData == Keys.Down && NowDir != Dir.Up)
            {
                NowDir = Dir.Down;
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            snake.moveBody();
            if (NowDir == Dir.Left)
                snake.moveX(-Snake.X);
            else if (NowDir == Dir.Right)
                snake.moveX(+Snake.X);
            else if (NowDir == Dir.Up)
                snake.moveY(-Snake.Y);
            else if (NowDir == Dir.Down)
                snake.moveY(+Snake.Y);

            if (snake.ReachBorder() == true)
            {
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("Game Over");
            }

            if (snake.ReachBody() == true)
            {
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("Game Over");
            }
            for (int i = 0; i < Foods.Count; i++)
            {

                if (snake.Reach(Foods[i], this) == true)
                {
                    snake.MakeBody(Controls, Foods[i].food_x, Foods[i].food_y, this);
                    Controls.Remove(Foods[i]);
                    Foods.Remove(Foods[i]);
                    point += 100;
                    break;
                }
            }
            if (point % 1500 == 500 && Stage != point)
            {
                for (int i = 0; i < MAX_WIDTH; i++)
                {
                    for (int j = 0; j < MAX_HEIGHT; j++)
                    {
                        field[i, j, 1] = 0;
                    }
                }
                for (int i = 0; i < Walls.Count; i++)
                {
                    Controls.Remove(Walls[i]);
                }
                Walls.Clear();
                WallPosX = [1, 2, 27, 28];
                WallPosY = [1, 2, 13, 14];

                for (int i = 0; i < WallPosX.Length; i++)
                {
                    for (int j = 0; j < WallPosY.Length; j++)
                    {
                        Wall wall = new(Controls, WallPosX[i], WallPosY[j], this);
                        Walls.Add(wall);
                        Controls.Add(wall);
                        field[WallPosX[i], WallPosY[j], 1] = 1;
                    }
                }
                Stage = point;
            }

            else if (point % 1500 == 1000 && Stage != point)
            {
                for (int i = 0; i < MAX_WIDTH; i++)
                {
                    for (int j = 0; j < MAX_HEIGHT; j++)
                    {
                        field[i, j, 1] = 0;
                    }
                }
                for (int i = 0; i < Walls.Count; i++)
                {
                    Controls.Remove(Walls[i]);
                }
                Walls.Clear();
                WallPosX = [5, 6, 23, 24];
                WallPosY = [1, 2, 3, 4, 11, 12, 13, 14];

                for (int i = 0; i < WallPosX.Length; i++)
                {
                    for (int j = 0; j < WallPosY.Length; j++)
                    {
                        Wall wall = new(Controls, WallPosX[i], WallPosY[j], this);
                        Walls.Add(wall);
                        Controls.Add(wall);
                        field[WallPosX[i], WallPosY[j], 1] = 1;
                    }
                }
                WallPosX = [3, 4, 5, 6, 7, 8, 21, 22, 23, 24, 25, 26];
                WallPosY = [5, 10];

                for (int i = 0; i < WallPosX.Length; i++)
                {
                    for (int j = 0; j < WallPosY.Length; j++)
                    {
                        Wall wall = new(Controls, WallPosX[i], WallPosY[j], this);
                        Walls.Add(wall);
                        Controls.Add(wall);
                        field[WallPosX[i], WallPosY[j], 1] = 1;
                    }
                }

                Stage = point;
            }

            else if (point % 1500 == 0 && Stage != point)
            {
                for (int i = 0; i < MAX_WIDTH; i++)
                {
                    for (int j = 0; j < MAX_HEIGHT; j++)
                    {
                        field[i, j, 1] = 0;
                    }
                }
                for (int i = 0; i < Walls.Count; i++)
                {
                    Controls.Remove(Walls[i]);
                }
                Walls.Clear();
                WallPosX = [12, 13, 14, 15, 16, 17, 18];
                WallPosY = [5, 6, 7, 8, 9, 10, 11];

                for (int i = 0; i < WallPosX.Length; i++)
                {
                    for (int j = 0; j < WallPosY.Length; j++)
                    {
                        Wall wall = new(Controls, WallPosX[i], WallPosY[j], this);
                        Walls.Add(wall);
                        Controls.Add(wall);
                        field[WallPosX[i], WallPosY[j], 1] = 1;
                    }
                }

                WallPosX = [1, 2, 3, 26, 27, 28];
                WallPosY = [1, 2, 13, 14];

                for (int i = 0; i < WallPosX.Length; i++)
                {
                    for (int j = 0; j < WallPosY.Length; j++)
                    {
                        Wall wall = new(Controls, WallPosX[i], WallPosY[j], this);
                        Walls.Add(wall);
                        Controls.Add(wall);
                        field[WallPosX[i], WallPosY[j], 1] = 1;
                    }
                }
                Stage = point;
            }

            for (int i = 0; i < MAX_WIDTH; i++)
            {
                for (int j = 0; j < MAX_HEIGHT; j++)
                {
                    if (field[i,j,0] == 1 && field[i,j,1] == 1)
                    {
                        field[i, j, 0] = 0;
                        for (int k = 0; k < Foods.Count; k++)
                        {
                            if (Foods[k].food_x == i && Foods[k].food_y == j)
                            {
                                Controls.Remove(Foods[k]);
                                Foods.Remove(Foods[k]);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < Walls.Count; i++)
            {
                if (snake.ReachWall(Walls[i]) == true)
                {
                    timer1.Stop();
                    timer2.Stop();
                    MessageBox.Show("Game Over");
                }
            }

            Menu_Point.Text = $"{point}Á¡";

            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int[] pos = [rand.Next(0, MAX_WIDTH), rand.Next(0, MAX_HEIGHT)];
            Food food = new(Controls, pos[0], pos[1], this);
            field[pos[0], pos[1], 0] = 1;
            Foods.Add(food);

        }
    }
}
