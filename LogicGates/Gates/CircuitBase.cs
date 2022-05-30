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
        public string Name;
        public int InputsCount { get; set; }
        public int OutputsCount { get; set; }
        public bool Status = false;
        public List<InputPin> InputPins { get; set; }
        public List<OutputPin> OutputPins { get; set; }
        public Size Size;
        protected List<Input> Relays = new List<Input>();

        public CircuitBase()
        {
            InputPins = new List<InputPin>();
            OutputPins = new List<OutputPin>();
        }

        public CircuitBase(int inPins, int outPins, string inName)
        {
            Size.Width = 80;
            Size.Height = inPins > outPins ? inPins * 20 : outPins * 20;
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
                if(InputsCount % 2 == 0)
                {
                    var h = this.Size.Height + 20 * (InputsCount / 2);

                    for (int i = 0; i < InputsCount; ++i)
                    {
                        InputPins.Add(new InputPin(new Point(this.Position.X, h), this));
                        h += 20;
                    }
                }else
                {
                    if (InputsCount % 2 == 0)
                    {
                        var h = 20 * (InputsCount / 2);

                        for (int i = 0; i < InputsCount; ++i)
                        {
                            InputPins.Add(new InputPin(new Point(this.Position.X, h), this));
                            h += 20;
                        }
                    }
                    else
                    {
                        var h = (Size.Height - (20 * InputsCount)) / 2;
                        for (int i = 0; i < InputsCount; ++i)
                        {
                            InputPins.Add(new InputPin(new Point(this.Position.X, h), this));
                            h += 20;
                        }
                    }
                }
            }

            if(OutputsCount > InputsCount)
            {
                for (int i = 0; i < OutputsCount; ++i)
                {
                    OutputPins.Add(new OutputPin(new Point(this.Position.X + 60, this.Position.Y + i * 20)));
                }
            }
            else
            {
                if (OutputsCount % 2 == 0)
                {
                    var h = 20 * (OutputsCount / 2);

                    for (int i = 0; i < OutputsCount; ++i)
                    {
                        OutputPins.Add(new OutputPin(new Point(this.Position.X + 60, h)));
                        h += 20;
                    }
                }
                else
                {
                    var h = (Size.Height - (20 * OutputsCount))/2;
                    for (int i = 0; i < OutputsCount; ++i)
                    {
                        OutputPins.Add(new OutputPin(new Point(this.Position.X + 60, h)));
                        h += 20;
                    }
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
