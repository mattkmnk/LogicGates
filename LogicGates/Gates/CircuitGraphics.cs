using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogicGates.Gates
{
    public class CircuitGraphics : Label
    {

        CircuitBase Gate;

        public CircuitGraphics(CircuitBase inGate, Point pos)
        {
            Gate = inGate;
            this.BackColor = Color.White;
            this.Text = Gate.GetName();
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Size = new Size(Gate.Size.Width, Gate.Size.Height);
            this.Location = pos;
            
            foreach(var pin in Gate.InputPins)
            {
                this.Controls.Add(pin);
            }

            this.Controls.Add(Gate.OutputPin);
        }

        public void SetPosition(int X, int Y)
        {
            this.Top += Y;
            this.Left += X;
            Gate.Position = new Point(this.Top, this.Left);
        }
    }
}
