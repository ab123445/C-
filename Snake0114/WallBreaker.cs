using System;
using System.Collections.Generic;
using System.Text;

namespace Snake0114
{
    internal class WallBreaker : Item
    {
        public WallBreaker(Control.ControlCollection Controls, int x, int y, MainForm main) : base(Controls, x, y, main)
        {
            lblitem.Name = "lblWallBreaker";
            lblitem.BackColor = Color.Blue;
        }

        public override void OnEat(MainForm main)
        {
            main.WallBreaks += 2;
        }
    }
}
