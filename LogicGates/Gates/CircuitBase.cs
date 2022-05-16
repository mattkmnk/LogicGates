using LogicGates.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGates.Gates
{
    public abstract class CircuitBase
    {
        public Point Position { get; set; }
        protected string Name;
        public int NumOfInputPins { get; set; }
        protected bool Status;
        public List<InputPin> InputPins { get; set; }
        public OutputPin OutputPin { get; set; }
        public Size Size;

        public CircuitBase(int inPins, string inName)
        {
            Size.Width = 80;
            Size.Height = inPins * 20;
            NumOfInputPins = inPins;
            Name = inName;
            InputPins = new List<InputPin>();
            for (int i = 0; i < NumOfInputPins; ++i)
            {
                InputPins.Add(new InputPin(new Point(this.Position.X, this.Position.Y + i * 20), this));
            }
            OutputPin = new OutputPin(new Point(60, Size.Height / 2 - 10));
        }

        public string GetName()
        {
            return Name;
        }

        public void SetPosition(Point pos)
        {
            this.Position = pos;
        }

        public Point GetPosition()
        {
            return Position;
        }

        public abstract CircuitBase GetInstance(Point pos);

        public virtual void Run()
        {

        }
    }
}
