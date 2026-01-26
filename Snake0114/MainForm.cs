
using System.Windows.Forms;

namespace Snake0114
{

    public partial class MainForm : Form
    {
        Dir NowDir;
        Snake snake;
        List<Food> Foods = new List<Food>();
        Random rand = new();
        public const int MENU_HEIGHT = 24;
        int point = 0;

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
            this.Width += 30 * Snake.X - ClientRectangle.Width;
            this.Height += 16 *Snake.Y - ClientRectangle.Height + MENU_HEIGHT;

            NowDir = Dir.None;
            snake = new Snake(Controls, 2, 2);
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

            if (snake.ReachBody() == true)
            {
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("Game Over");
            }
            for (int i = 0; i < Foods.Count; i++)
            {
                if (snake.Reach(Foods[i]) == true)
                {
                    snake.MakeBody(Controls, Foods[i].food_x, Foods[i].food_y);
                    Controls.Remove(Foods[i]);
                    Foods.Remove(Foods[i]);
                    point += 100;
                    break;
                }
            }

            Menu_Point.Text = $"{point}Á¡";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int[] pos = [rand.Next(0, 30), rand.Next(0, 16)];
            Food food = new(Controls, pos[0], pos[1]);
            Foods.Add(food);

        }
    }
}
