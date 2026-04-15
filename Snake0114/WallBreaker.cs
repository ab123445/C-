using System;
using System.Collections.Generic;
using System.Text;

namespace Snake0114
{
    internal class WallBreaker : Item
    {
        public WallBreaker(Control.ControlCollection Controls, int x, int y, MainForm main)
        {
            lblitem.Location = new Point(x * Snake.X, main.menuStrip1.Height + y * Snake.Y);
            lblitem.Name = "lblWallBreaker";
            lblitem.BackColor = Color.Blue;
            Controls.Add(lblitem);
            item_x = x;
            item_y = y;
        }

        public void OnEat(MainForm main)
        {
            main.AddWallBreaks(2);
        }
    }
}
