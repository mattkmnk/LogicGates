﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGates.Utils
{
    public class InputPin : Button
    {

        bool Status;
        Gate ParentGate;

        public InputPin(Point pos, Gate gate)
        {
            ParentGate = gate;
            Status = false;
            this.BackColor = Status ? Color.Green : Color.Red;

            this.Size = new Size(20, 20);
            this.Location = pos;
            this.Text = "I";
            this.TabStop = false;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
        }

        public bool GetStatus()
        {
            return Status;
        }

        public void SetStatus(bool status)
        {
            Status = status;
            this.BackColor = status ? Color.Green : Color.Red;
            ParentGate.Run();
        }

        public void SwitchStatus()
        {
            Status = !Status;
            this.BackColor = Status ? Color.Green : Color.Red;
            ParentGate.Run();
        }

        public void SetColor(Color color)
        {
            this.BackColor = color;
        }
    }
}