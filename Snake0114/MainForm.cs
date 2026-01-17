
using System.Windows.Forms;

namespace Snake0114
{

    public partial class MainForm : Form
    {
        Dir NowDir;
        Snake snake;
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
            NowDir = Dir.None;

            timer1.Start();
            snake = new Snake(Controls);
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                NowDir = Dir.Left;
                return true;
            }
            else if (keyData == Keys.Right)
            {
                NowDir = Dir.Right;
                return true;
            }
            else if (keyData == Keys.Up)
            {
                NowDir = Dir.Up;
                return true;
            }
            else if (keyData == Keys.Down)
            {
                NowDir = Dir.Down;
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (NowDir == Dir.Left)
                snake.moveX(-10);
            else if (NowDir == Dir.Right)
                snake.moveX(+10);
            else if (NowDir == Dir.Up)
                snake.moveY(-10);
            else if (NowDir == Dir.Down)
                snake.moveY(10);
        }
    }
}
