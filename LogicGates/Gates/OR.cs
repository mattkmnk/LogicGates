using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGates.Gates
{
    class OR : CircuitBase
    {
        public OR() : base(2, 1, "OR")
        {
            GateSize = new Size(80, GateSize.Height);
        }

        public OR(Point pos) : base(2, 1, "OR")
        {
            GateSize = new Size(80, GateSize.Height);
        }

        public override CircuitBase GetInstance(Point pos)
        {
            return new OR(pos);
        }

        public override int Run()
        {
            var res = InputPins[0].GetStatus() || InputPins[1].GetStatus();
            if (res != Status)
            {
                OutputPins[0].SetStatus(res);
                Status = res;
            }
            return OutputPins[0].GetStatus() ? 1 : 0;
        }
    }
}
