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
    public class Input : CircuitBase
    {

        public Input() : base(1, "I")
        {
            this.Size = new Size(40, 20);
            InputPins.Add(new InputPin(this.Position, this));
            OutputPin = new OutputPin(new Point(20, 0));
        }

        public Input(InputPin input) : base(1, "I")
        {
            this.Size = new Size(40, 20);
            input.ParentGate = this;
            InputPins.Add(input);
            OutputPin = new OutputPin(new Point(20, 0));
        }

        public Input(Point pos) : base(1, "I")
        {
            this.Position = pos;
            this.Size = new Size(40, 20);
            InputPins.Add(new InputPin(this.Position, this));
            OutputPin = new OutputPin(new Point(20, 0));
        }

        public override CircuitBase GetInstance(Point pos)
        {
            return new Input(pos);
        }

        public override void Run()
        {
            OutputPin.SetStatus(InputPins[0].GetStatus());
            this.Status = InputPins[0].GetStatus();
        }
    }
}
