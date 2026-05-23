using System;
using System.Collections.Generic;
using System.Text;

namespace MineSearch
{
    public class Mine : Button
    {
        public const int X = 60;
        public const int Y = 60;

        public Mine(int x, int y)
        {
            this.Location = new Point(x*X, y*Y);
            this.Name = "btnMine";
            this.Size = new Size(X, Y);
            this.TabIndex = 0;
            this.Text = "";
            this.UseVisualStyleBackColor = true;
            this.Click += Mine_Click;
        }

        private void Mine_Click(object sender, EventArgs e)
        {
            this.Text = "X";
        }
    }
}
