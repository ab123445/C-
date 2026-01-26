using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace Snake0114
{
    internal class Snake
    {
        public const int X = 30;
        public const int Y = 30;
        Label lblHead = new();
        List<Label> lblBodies = new List<Label>();
        List<Point> MovingLine = new List<Point>();


        public Snake(Control.ControlCollection Controls, int x, int y)
        {
            lblHead.AutoSize = false;
            lblHead.Location = new Point(x * X, MainForm.MENU_HEIGHT + y * Y);
            lblHead.Name = "lblHead";
            lblHead.Size = new Size(X, Y);
            lblHead.TabIndex = 7;
            lblHead.Text = ":";
            lblHead.BackColor = SystemColors.ActiveCaption;
            lblHead.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lblHead);
        }
        public void MakeBody(Control.ControlCollection Controls, int x, int y)
        {
            Label lblBody = new();
            lblBody.AutoSize = false;
            lblBody.Location = new Point(x * X, MainForm.MENU_HEIGHT + y * Y);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(X, Y);
            lblBody.TabIndex = 7;
            lblBody.Text = "";
            lblBody.BackColor = SystemColors.ActiveCaption;
            lblBody.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lblBody);
            lblBodies.Add(lblBody);
        }

        public void moveBody()
        {
            MovingLine.Add(lblHead.Location);
            for (int i = MovingLine.Count - lblBodies.Count - 1; i >= 0; i--)
            {
                MovingLine.Remove(MovingLine[i]);
            }
            for (int i = 0; i < lblBodies.Count; i++)
            {
                lblBodies[i].Location = MovingLine[i];
            }
        }

        public void moveX(int x)
        {
            lblHead.Left += x;
        }
        public void moveY(int y)
        {
            lblHead.Top += y;
        }
        public bool Reach(Food food)
        {
            if (lblHead.Left == food.food_x * Snake.X && lblHead.Top == food.food_y * Snake.Y + MainForm.MENU_HEIGHT)
            {
                return true;
            }
            else
                return false;
        }

        public bool ReachWall(Label wall)
        {
            if (lblHead.Location == wall.Location)
            {
                return true;
            }
            return false;
        }
        public bool ReachBody()
        {
            for (int i = 0; i < lblBodies.Count; i++)
            {
                if (lblHead.Location == lblBodies[i].Location)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
