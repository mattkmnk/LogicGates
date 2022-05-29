﻿using LogicGates.Gates;
using LogicGates.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LogicGates
{

    public delegate void GateAddedHandler(CustomCircuit gate);

    public partial class LGStore : Form
    {
        StorageManager manager;
        public event GateAddedHandler GateAdded;

        public LGStore(List<CircuitBase> gates)
        {
            InitializeComponent();

            LoadGates(gates, LoadedGates);

            manager = new StorageManager();

            var dbGates = new List<CircuitBase>();
            dbGates = manager.LoadGatesFromDB();

            LoadGates(dbGates, ImportGates);
        }

        private void LoadGates(List<CircuitBase> gates, Panel panel)
        {
            panel.Controls.Clear();
            int x = 5;
            int y = 5;
            foreach (var gate in gates)
            {
                var btn = new BlueprintButton(gate);
                btn.Name = gate.GetName();
                btn.Text = gate.GetName();
                btn.ForeColor = Color.White;
                btn.Location = new Point(x, y);
                btn.Size = new Size(panel.Size.Width - 10, 50);
                if(panel.Name == "LoadedGates")
                {
                    btn.MouseDown += Btn_MouseDownSaveToDB;
                }
                else
                {
                    btn.MouseDown += Btn_MouseDownLoadFromDB;
                }
                
                panel.Controls.Add(btn);
                y += 50;
            }
        }

        private void Btn_MouseDownLoadFromDB(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip cm = new ContextMenuStrip();
                ToolStripMenuItem SaveToDB = new ToolStripMenuItem("Load From DB");
                SaveToDB.Click += (sender2, e2) => FromDB(sender2, e2, sender as BlueprintButton);

                cm.Items.Add(SaveToDB);
                ((BlueprintButton)sender).ContextMenuStrip = cm;
            }
        }

        private void FromDB(object sender2, EventArgs e2, BlueprintButton blueprintButton)
        {
            GateAddedHandler handler = GateAdded;
            handler?.Invoke(blueprintButton.GetGate() as CustomCircuit);
        }

        private void Btn_MouseDownSaveToDB(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ContextMenuStrip cm = new ContextMenuStrip();
                ToolStripMenuItem SaveToDB = new ToolStripMenuItem("Save to DB");
                SaveToDB.Click += (sender2, e2) => ToDB(sender2, e2, sender as BlueprintButton);

                cm.Items.Add(SaveToDB);
                ((BlueprintButton)sender).ContextMenuStrip = cm;
            }
        }

        private void ToDB(object sender2, EventArgs e2, BlueprintButton blueprintButton)
        {
            var gate = blueprintButton.GetGate() as CustomCircuit;
            string name = gate.GetName();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml($"<Circuit></Circuit>");
            XmlElement InputCount = doc.CreateElement("InputCount");
            InputCount.InnerText = gate.NumOfInputPins.ToString();
            doc.DocumentElement.AppendChild(InputCount);
            for(int i = 0; i < gate.GetResultTable(name).Results.Count; ++i)
            {
                XmlElement newElem = doc.CreateElement("Case");
                XmlElement input = doc.CreateElement("Input");
                input.InnerText = i.ToString();
                XmlElement output = doc.CreateElement("Output");
                output.InnerText = gate.GetResultTable(name).Results[i].ToString();
                newElem.AppendChild(input);
                newElem.AppendChild(output);
                doc.DocumentElement.AppendChild(newElem);
            }

            doc.PreserveWhitespace = true;
            doc.Save($"{name}.xml");
            manager.Save(name, doc);
        }
    }
}
