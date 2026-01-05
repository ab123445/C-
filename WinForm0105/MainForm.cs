namespace WinForm0105
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            char ch = (char)e.KeyCode;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
