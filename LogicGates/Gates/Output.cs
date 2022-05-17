﻿using LogicGates.Utils;
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

        public Output() : base(1, "O")
        {
            this.Size = new Size(40, 20);
            InputPins.Add(new InputPin(new Point(0, 0), this));
            OutputPin = new OutputPin(new Point(20, 0));
        }

        public Output(Point pos) : base(1, "O")
        {
            this.Position = pos;
            this.Size = new Size(40, 20);
            InputPins.Add(new InputPin(new Point(0, 0), this));
            OutputPin = new OutputPin(new Point(20, 0));
        }

        public override CircuitBase GetInstance(Point pos)
        {
            return new Output(Position);
        }

        public override void Run()
        {
            OutputPin.SetStatus(InputPins[0].GetStatus());
            this.Status = InputPins[0].GetStatus();
        }
    }
}
