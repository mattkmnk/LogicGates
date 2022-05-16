﻿using System;
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
        public OR() : base(2, "OR")
        {

        }

        public OR(Point pos) : base(2, "OR")
        {

        }

        public override CircuitBase GetInstance(Point pos)
        {
            return new OR(pos);
        }
    }
}
