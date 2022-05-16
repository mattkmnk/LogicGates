using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGates.Utils
{
    public abstract class Pin : Button
    {
        public abstract bool GetStatus();

        public abstract void SetStatus(bool status);
    }
}
