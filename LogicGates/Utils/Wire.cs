using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGates.Utils
{
    public delegate void WireNotify();

    public class Wire
    {
        public event WireNotify WireChangedStatus;

        public Pin From;
        public Pin To;
        public bool Status;

        public Wire(Pin from, Pin to)
        {
            From = from;
            To = to;
        }

        public void Propagate()
        {
            Status = From.GetStatus();
            To.SetStatus(Status);
            OnStatusChanged();
        }

        protected virtual void OnStatusChanged()
        {
            WireChangedStatus?.Invoke();
        }
        
    }
}
