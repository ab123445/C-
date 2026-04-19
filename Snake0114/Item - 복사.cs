using System;
using System.Collections.Generic;
using System.Text;

namespace Snake0114
{
    internal class Shorten : Item
    {
        public Shorten(Control.ControlCollection Controls, int x, int y, MainForm main)
        {
            lblitem.Location = new Point(x * Snake.X, main.menuStrip1.Height + y * Snake.Y);
            lblitem.BackColor = Color.Purple;
            Controls.Add(lblitem);
            item_x = x;
            item_y = y;
        }

        public override void OnEat(MainForm main)
        {
            main.snake.RemoveTail(3);
        }
    }

}
