using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGates.Utils
{
    public class OutputPin : Button
    {
        bool Status;

        public OutputPin(Point pos)
        {
            Status = false;

            this.Size = new Size(20, 40);
            this.Location = pos;
            this.Text = "O";
            this.TabStop = false;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
        }

        public void SetStatus(bool status)
        {
            Status = status;
            this.BackColor = Status ? Color.Green : Color.Red;
        }

        public void SwitchStatus()
        {
            Status = !Status;
            this.BackColor = Status ? Color.Green : Color.Red;
        }
    }
}
