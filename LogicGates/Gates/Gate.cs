using LogicGates.Utils;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LogicGates
{
    public abstract class Gate
    {
        protected Point Position;
        protected string Name;
        protected Label GateHitbox;
        protected Panel Circuit;
        protected OutputPin Output;
        protected bool Status;

        public abstract void Draw(Panel panel);
        public abstract List<InputPin> GetInputs();
        public abstract void Run();
        public void SetStatus(bool status)
        {
            Status = status;
            Output.SetStatus(Status);
        }

        public Label GetBody()
        {
            return GateHitbox;
        }

        public string GetName()
        {
            return Name;
        }

        public abstract Gate GetInstance(Point pos, Panel panel);

        public Point GetPosition()
        {
            return Position;
        }

        public void SetPosition(Point pos)
        {
            Position = pos;
        }
    }
}