using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGates.Gates
{
    public class AND : CircuitBase
    {
        public AND() : base(2, 1, "AND")
        {
            GateSize = new Size(80, GateSize.Height);
        }

        public AND(Point pos) : base(2, 1, "AND")
        {
            this.Position = pos;
        }

        public override CircuitBase GetInstance(Point pos)
        {
            return new AND(pos);
        }

        public override int Run()
        {
            var res = InputPins[0].GetStatus() && InputPins[1].GetStatus();
            if (res != Status)
            {
                OutputPins[0].SetStatus(res);
                Status = res;
            }
            return OutputPins[0].GetStatus() ? 1 : 0;
        }
    }
}
