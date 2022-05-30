using LogicGates.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGates.Gates
{
    public abstract class CircuitBase
    {
        public Point Position { get; set; }
        public string Name { get; set; }
        public int InputsCount { get; set; }
        public int OutputsCount { get; set; }
        public bool Status { get; set; }
        public List<InputPin> InputPins { get; set; }
        public List<OutputPin> OutputPins { get; set; }
        public Size GateSize { get; set; }

        public CircuitBase()
        {
            Status = false;
            InputPins = new List<InputPin>();
            OutputPins = new List<OutputPin>();
            GateSize = new Size();
        }

        public CircuitBase(int inPins, int outPins, string inName)
        {
            var Width = 80;
            var Height = inPins > outPins ? inPins * 20 : outPins * 20;
            GateSize = new Size(Width, Height);
            InputsCount = inPins;
            OutputsCount = outPins;
            Name = inName;
            InputPins = new List<InputPin>();
            OutputPins = new List<OutputPin>();


            if(InputsCount > OutputsCount)
            {
                for (int i = 0; i < InputsCount; ++i)
                {
                    InputPins.Add(new InputPin(new Point(this.Position.X, this.Position.Y + i * 20), this));
                }
            }
            else
            {
                var h = (GateSize.Height - (20 * InputsCount)) / 2;
                for (int i = 0; i < InputsCount; ++i)
                {
                    InputPins.Add(new InputPin(new Point(this.Position.X, h), this));
                    h += 20;
                }
            }

            if(OutputsCount > InputsCount)
            {
                for (int i = 0; i < OutputsCount; ++i)
                {
                    OutputPins.Add(new OutputPin(new Point(this.Position.X + 60, this.Position.Y + i * 20), this));
                }
            }
            else
            {
                var h = (GateSize.Height - (20 * OutputsCount)) / 2;
                for (int i = 0; i < OutputsCount; ++i)
                {
                    OutputPins.Add(new OutputPin(new Point(this.Position.X + 60, h), this));
                    h += 20;
                }
            }
            
        }

        public string GetName()
        {
            return Name;
        }

        public void SetPosition(Point pos)
        {
            this.Position = pos;
        }

        public Point GetPosition()
        {
            return Position;
        }

        public abstract CircuitBase GetInstance(Point pos);

        public abstract int Run();

        public virtual void PrecalculateValues()
        {

        }
    }
}
