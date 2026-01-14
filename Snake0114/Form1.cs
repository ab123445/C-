
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Snake0114
{
    public partial class Form1 : Form
    {
        Dir NowDir;
        Label lblHead = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            makelabel();
            timer1.Start();
            NowDir = Dir.None;
        }
        enum Dir
        {
            None,
            Left,
            Right,
            Up,
            Down
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
                lblHead.Left -= 10;
            else if (NowDir == Dir.Right)
                lblHead.Left += 10;
            else if (NowDir == Dir.Up)
                lblHead.Top -= 10;
            else if (NowDir == Dir.Down)
                lblHead.Top += 10;
        }
        private void makelabel()
        {

            lblHead.AutoSize = true;
            lblHead.Location = new Point(380, 177);
            lblHead.Name = "lblHead";
            lblHead.Size = new Size(100, 100);
            lblHead.TabIndex = 7;
            lblHead.Text = ":";
            lblHead.BackColor = SystemColors.ActiveCaption;
            lblHead.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lblHead);
        }

    }
}
