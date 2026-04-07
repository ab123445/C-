using System;
using System.Collections.Generic;
using System.Text;

namespace Snake0114
{
    internal class SpeedUp : Item
    {
        public SpeedUp(Control.ControlCollection Controls, int x, int y, MainForm main) : base(Controls, x, y, main)
        {
            lblitem.Name = "lblSpeedUp";
            lblitem.BackColor = Color.Green;
        }

        public override void OnEat(MainForm main)
        {
            main.IncreaseSpeed();
        }
    }
}
