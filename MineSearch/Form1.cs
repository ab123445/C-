namespace MineSearch
{
    public partial class Form1 : Form
    {
        public const int MENU_HIGHT = 30;
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
            this.Height += 9 * Mine.Y - ClientRectangle.Height + MENU_HIGHT;


            for (int i = 0; i < 9; i++)
            {
                Mines.Add(new List<Mine>());
                for (int j = 0; j < 9; j++)
                {
                    Mine mine = new(i, j, button_MouseDown);
                    mine.GetMine();
                    Controls.Add(mine);
                    Mines[i].Add(mine);
                }
            }

        }

       // public void Mine

        public void button_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            Mine me = button.Tag as Mine;
            if (me == null) return;

            //Mines[me.Idx_X][me.Idx_Y]

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
