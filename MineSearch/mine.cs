using System;
using System.Collections.Generic;
using System.Text;

namespace MineSearch
{
    internal class mine
    {
        public const int X = 60;
        public const int Y = 60;
        Button btnMine = new();

        public mine(int x, int y)
        {
            btnMine.Location = new Point(x*X, y*Y);
            btnMine.Name = "btnMine";
            btnMine.Size = new Size(X, Y);
            btnMine.TabIndex = 0;
            btnMine.Text = "a";
            btnMine.UseVisualStyleBackColor = true;
        }
    }
}
