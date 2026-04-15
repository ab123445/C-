using System;
using System.Collections.Generic;
using System.Text;

namespace Snake0114
{
    internal class SpeedUp : Item
    {
        public SpeedUp(Control.ControlCollection Controls, int x, int y, MainForm main)
        {
            lblitem.Location = new Point(x * Snake.X, main.menuStrip1.Height + y * Snake.Y);
            lblitem.Name = "lblSpeedUp";
            lblitem.BackColor = Color.Green;
            Controls.Add(lblitem);
            item_x = x;
            item_y = y;
        }

        public void OnEat(MainForm main)
        {
            main.IncreaseSpeed();
            main.AddPoint(200);
        }
    }
}
