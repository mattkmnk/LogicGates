using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGates.Gates
{
    public class NAND : CircuitBase
    {
        public NAND() : base(2, "NAND")
        {

        }

        public NAND(Point pos) : base(2, "NAND")
        {

        }

        public override CircuitBase GetInstance(Point pos)
        {
            return new NAND(pos);
        }

        public override void Run()
        {
            var res = !(InputPins[0].GetStatus() && InputPins[1].GetStatus());
            if (res != Status)
            {
                OutputPin.SetStatus(res);
                Status = res;
            }
        }
    }
}
