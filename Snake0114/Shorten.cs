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
            lblitem.BackColor = Color.Yellow;
            Controls.Add(lblitem);
            item_x = x;
            item_y = y;
            OnEatAction = () =>
            {
                main.Snake.ShortenTail(Controls);
            };
        }

        

        public override void OnEat()
        {

            OnEatAction();
        }
    }

}
