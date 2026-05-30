namespace MineSearch
{
    public partial class Form1 : Form
    {
        List<List<Mine>> Mines = new();
        Random rand = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ClientRectangle.Width
            this.Width += 9 * Mine.X - ClientRectangle.Width;
            this.Height += 9 * Mine.Y - ClientRectangle.Height;


            for (int i = 0; i < 9; i++)
            {
                Mines.Add(new List<Mine>());
                for (int j = 0; j < 9; j++)
                {
                    int r = rand.Next(0, 100);
                    Mine mine = new(i, j, r, button_MouseDown);
                    Controls.Add(mine);
                    Mines[i].Add(mine);
                }
            }

        }

        public void button_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            Mine me = button.Tag as Mine;
            if (me == null) return;


            if (e.Button == MouseButtons.Left)
            {
                me.Text_Change();
            }
            else if (e.Button == MouseButtons.Right)
            {
                me.Set_Flag();
            }
        }

        private void txtRulebox_Click(object sender, EventArgs e)
        {
            
        }
    }
}
