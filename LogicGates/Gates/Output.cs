using LogicGates.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGates.Gates
{
    public class Output : CircuitBase
    {

        public Output() : base(1, 1, "O")
        {
            this.GateSize = new Size(40, 20);
            InputPins.Add(new InputPin(new Point(0, 0), this));
            OutputPins.Add(new OutputPin(new Point(20, 0), this));
        }

        public Output(Point pos)
        {
            this.Position = pos;
            this.GateSize = new Size(40, 20);
            InputPins.Add(new InputPin(new Point(0, 0), this));
            OutputPins.Add(new OutputPin(new Point(20, 0), this));
        }

        public override CircuitBase GetInstance(Point pos)
        {
            return new Output(Position);
        }

        public override int Run()
        {
            OutputPins[0].SetStatus(InputPins[0].GetStatus());
            this.Status = InputPins[0].GetStatus();
            return OutputPins[0].GetStatus() ? 1 : 0;
        }
    }
}
