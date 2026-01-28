using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Snake0114
{
    internal class Wall : Label
    {
        public Wall(Control.ControlCollection Controls, int x, int y, MainForm main)
        {
            this.AutoSize = false;
            this.Location = new Point(x * Snake.X, main.menuStrip1.Height + y * Snake.Y);
            this.Name = "lblWall";
            this.Size = new Size(Snake.X, Snake.Y);
            this.TabIndex = 7;
            this.Text = "";
            this.BackColor = SystemColors.WindowFrame;
            this.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(this);
        }
        //public void ClearWall(Control.ControlCollection Controls, List<Wall> Walls)
        //{
        //    for (int i = 0; i < Walls.Count; i++)
        //    {
        //        Controls.Remove(Walls[i]);
        //    }
        //    Walls.Clear();
        //}
    }
}
