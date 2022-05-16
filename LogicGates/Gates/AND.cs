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
        public AND() : base(2, "AND")
        {

        }

        public AND(Point pos) : base(2, "AND")
        {

        }

        public override CircuitBase GetInstance(Point pos)
        {
            return new AND(pos);
        }
    }
}
