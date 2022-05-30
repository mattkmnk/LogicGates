using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGates.Gates
{
    public class NOT : CircuitBase
    {
        public NOT() : base(1, 1, "NOT")
        {

        }

        public NOT(Point pos) : base(1, 1, "NOT")
        {

        }

        public override CircuitBase GetInstance(Point pos)
        {
            return new NOT(pos);
        }

        public override int Run()
        {
            var res = !InputPins[0].GetStatus();
            if (res != Status)
            {
                OutputPins[0].SetStatus(res);
                Status = res;
            }
            return OutputPins[0].GetStatus() ? 1 : 0;
        }
    }
}
