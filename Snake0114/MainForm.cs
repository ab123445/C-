namespace Snake0114
{
    delegate void FieldGetter(out int x, out int y);
    public partial class MainForm : Form
    {
        public const int MAX_WIDTH = 30;
        public const int MAX_HEIGHT = 16;
        int WallBreaks = 0;

        Dir NowDir;
        Snake snake;
        int HighRecord = 0;
        List<Food> Foods = new List<Food>();
        List<Wall> Walls = new List<Wall>();
        List<Item> Items = new List<Item>();
        int Stage = 0;
        Random rand = new();
        int point = 0;
        int[,,] field = new int[MAX_WIDTH, MAX_HEIGHT, 2];
        int[] WallPosX;
        int[] WallPosY;
        public void snakeRemoveTail()
        {
            snake.RemoveTail(1);
        }

        public MainForm()
        {
            InitializeComponent();
        }

        public void AddWallBreaks(int x)
        {
            WallBreaks += x;
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
            using (StreamReader reading =
                new StreamReader(
                    new FileStream("record.txt", FileMode.Open)))
            {
                string line;
                while ((line = reading.ReadLine()) != null)
                {
                    if (int.Parse(line) > HighRecord)
                        HighRecord = int.Parse(line);
                }
            }
            this.Width += MAX_WIDTH * Snake.X - ClientRectangle.Width;
            this.Height += MAX_HEIGHT * Snake.Y - ClientRectangle.Height + menuStrip1.Height;

            NowDir = Dir.None;
            snake = new Snake(Controls, 2, 2, this);
            timer1.Start();
            timer2.Start();
            timer1.Interval = 200;
            timer2.Interval = 1000;
        }

        public void AddPoint(int x)
        {
            point += x;
        }
        public void IncreaseSpeed()
        {
            timer1.Interval -= timer1.Interval / 10;
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
        public void timer1_Tick(object sender, EventArgs e)
        {
            Menu_Record.Text = $"최고 기록 : {HighRecord}점";
            IgnoreWall_txt.Text = $"벽 넘어가기 : {WallBreaks}회";

            Action clearWalls = () =>
            {
                for (int i = 0; i < MAX_WIDTH; i++)
                    for (int j = 0; j < MAX_HEIGHT; j++)
                        field[i, j, 1] = 0;

                for (int i = 0; i < Walls.Count; i++)
                    Controls.Remove(Walls[i]);

                Walls.Clear();
            };

            StreamWriter sr =
                new StreamWriter(new FileStream("record.txt", FileMode.Append));

            snake.moveBody();
            if (NowDir == Dir.Left)
                snake.moveX(-Snake.X);
            else if (NowDir == Dir.Right)
                snake.moveX(+Snake.X);
            else if (NowDir == Dir.Up)
                snake.moveY(-Snake.Y);
            else if (NowDir == Dir.Down)
                snake.moveY(+Snake.Y);

            if (snake.ReachBorder(this) == true)
            {
                timer1.Stop();
                timer2.Stop();
                sr.Write($"\n{point}");
                MessageBox.Show($"Game Over\n{point}점");
            }

            if (snake.ReachBody() == true)
            {
                timer1.Stop();
                timer2.Stop();
                sr.Write($"\n{point}");
                MessageBox.Show($"Game Over\n{point}점");
            }
            for (int i = 0; i < Foods.Count; i++)
            {

                if (snake.ReachFood(Foods[i], this) == true)
                {
                    snake.MakeBody(Controls, Foods[i].food_x, Foods[i].food_y, this);
                    Controls.Remove(Foods[i]);
                    Foods.Remove(Foods[i]);
                    point += 100;
                    break;
                }
            }
            for (int i = 0; i < Items.Count; i++)
            {

                if (snake.ReachItem(Items[i], this) == true)
                {
                    Items[i].OnEat(this);
                    Controls.Remove(Items[i].GetLabel());
                    Items.Remove(Items[i]);
                    break;
                }
            }
            if (point % 1500 == 500 && Stage != point)
            {
                clearWalls();
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
                clearWalls();
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
                clearWalls();
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
                    if (field[i, j, 0] == 1 && field[i, j, 1] == 1)
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
            for (int i = 0; i < Foods.Count; i++)
            {
                if (isfieldPoint(Foods[i].Location) == true)
                {
                    Controls.Remove(Foods[i]);
                    Foods.Remove(Foods[i]);
                }
            }
            if (Walls.Any(x => snake.ReachWall(x)))
                {
                    if (WallBreaks > 0)
                    {
                        WallBreaks--;
                    }
                    else {

                        timer1.Stop();
                        timer2.Stop();
                        sr.Write($"\n{point}");
                        MessageBox.Show($"Game Over\n{point}점");
                    }
                    
                }

            Menu_Point.Text = $"{point}점";

            sr.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            FieldGetter fieldgetter;
            fieldgetter = delegate (out int x, out int y)
            {
                List<Point> Bodies = snake.GetBody();
                Point FoodPoint;
                x = rand.Next(0, MAX_WIDTH);
                y = rand.Next(0, MAX_HEIGHT);
                FoodPoint = new Point(x, y);
                for (int i = 0; i < Bodies.Count; i++)
                {
                    if (FoodPoint == Bodies[i])
                    {
                        x = rand.Next(0, MAX_WIDTH);
                        y = rand.Next(0, MAX_HEIGHT);
                        FoodPoint = new Point(x, y);
                        i -= 1;
                    }
                }
                for (int i = 0; i < Foods.Count; i++)
                {
                    if (FoodPoint == Foods[i].Location)
                    {
                        x = rand.Next(0, MAX_WIDTH);
                        y = rand.Next(0, MAX_HEIGHT);
                        FoodPoint = new Point(x, y);
                        i -= 1;
                    }
                }
            };
            int[] pos = [0, 0];
            fieldgetter(out pos[0], out pos[1]);
            Food food;
            food = new(Controls, pos[0], pos[1], this);
            field[pos[0], pos[1], 0] = 1;
            Foods.Add(food);

            if (rand.Next(0, 100) < 30)
            {
                fieldgetter(out pos[0], out pos[1]);
                SpeedUp item = new SpeedUp(Controls, pos[0], pos[1], this);
                Items.Add(item);
            }
            if (rand.Next(0, 100) < 30)
            {
                fieldgetter(out pos[0], out pos[1]);
                WallBreaker item = new WallBreaker(Controls, pos[0], pos[1], this);
                Items.Add(item);
            }
        }



        private bool isfieldPoint(Point point)
        {
            int Overlap = 0;
            List<Point> Bodies = snake.GetBody();
            for (int i = 0; i < Bodies.Count; i++)
            {
                if (point == Bodies[i])
                    return true;
            }
            for (int i = 0; i < Foods.Count; i++)
            {
                if (point == Foods[i].Location)
                    Overlap += 1;
            }
            if (Overlap == 2)
                return true;
            return false;
        }

        private void Menu_Restart_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            for (int i = Walls.Count - 1; i >= 0; i--)
            {
                Walls[i].Dispose();
                Controls.Remove(Walls[i]);
                Walls.Remove(Walls[i]);
            }
            for (int i = Foods.Count - 1; i >= 0; i--)
            {
                Foods[i].Dispose();
                Controls.Remove(Foods[i]);
                Foods.Remove(Foods[i]);
            }
            for (int i = Items.Count - 1; i >= 0; i--)
            {
                Items[i].GetLabel().Dispose();
                Controls.Remove(Items[i].GetLabel());
                Items.Remove(Items[i]);
            }
            NowDir = Dir.None;
            snake.Reset(Controls);
            snake = new Snake(Controls, 2, 2, this);
            Stage = 0;
            rand = new();
            point = 0;
            field = new int[MAX_WIDTH, MAX_HEIGHT, 2];
            WallPosX = [];
            WallPosY = [];
        }
    }
}
