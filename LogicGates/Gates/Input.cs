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

        public Input() : base(1, 1, "I")
        {
            this.GateSize = new Size(40, 20);
            InputPins.Add(new InputPin(this.Position, this));
            OutputPins.Add(new OutputPin(new Point(this.Position.X + 20, 0), this));
        }

        public Input(InputPin input) : base(1, 1, "I")
        {
            this.GateSize = new Size(40, 20);
            input.ParentGate = this;
            InputPins.Add(input);
            OutputPins.Add(new OutputPin(new Point(20, 0), this));
        }

        public Input(Point pos)
        {
            this.Position = pos;
            this.GateSize = new Size(40, 20);
            InputPins.Add(new InputPin(new Point(0, 0), this));
            OutputPins.Add(new OutputPin(new Point(20, 0), this));
        }

        public override CircuitBase GetInstance(Point pos)
        {
            return new Input(pos);
        }

        public override int Run()
        {
            this.Status = InputPins[0].GetStatus();
            OutputPins[0].SetStatus(this.Status);
            return OutputPins[0].GetStatus() ? 1 : 0;
            
        }
    }
}
