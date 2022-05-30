using System.Drawing;
using System.Windows.Forms;

namespace LogicGates
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GatesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SaveCircuit_button = new System.Windows.Forms.Button();
            this.CircuitName_TextBox = new System.Windows.Forms.TextBox();
            this.NumOfInputs_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfInputs_NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // GatesPanel
            // 
            this.GatesPanel.Location = new System.Drawing.Point(986, 45);
            this.GatesPanel.Name = "GatesPanel";
            this.GatesPanel.Size = new System.Drawing.Size(140, 624);
            this.GatesPanel.TabIndex = 0;
            // 
            // SaveCircuit_button
            // 
            this.SaveCircuit_button.Location = new System.Drawing.Point(790, 659);
            this.SaveCircuit_button.Name = "SaveCircuit_button";
            this.SaveCircuit_button.Size = new System.Drawing.Size(74, 21);
            this.SaveCircuit_button.TabIndex = 2;
            this.SaveCircuit_button.Text = "Save";
            this.SaveCircuit_button.UseVisualStyleBackColor = true;
            this.SaveCircuit_button.Click += new System.EventHandler(this.SaveCircuit_button_Click);
            // 
            // CircuitName_TextBox
            // 
            this.CircuitName_TextBox.Location = new System.Drawing.Point(870, 659);
            this.CircuitName_TextBox.Name = "CircuitName_TextBox";
            this.CircuitName_TextBox.Size = new System.Drawing.Size(100, 20);
            this.CircuitName_TextBox.TabIndex = 3;
            // 
            // NumOfInputs_NumericUpDown
            // 
            this.NumOfInputs_NumericUpDown.Location = new System.Drawing.Point(12, 659);
            this.NumOfInputs_NumericUpDown.Name = "NumOfInputs_NumericUpDown";
            this.NumOfInputs_NumericUpDown.Size = new System.Drawing.Size(32, 20);
            this.NumOfInputs_NumericUpDown.TabIndex = 4;
            this.NumOfInputs_NumericUpDown.ValueChanged += new System.EventHandler(this.NumOfInputs_NumericUpDown_ValueChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.CausesValidation = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(989, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 27);
            this.button1.TabIndex = 5;
            this.button1.TabStop = false;
            this.button1.Text = "LGStore";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.LGStore_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(1144, 681);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NumOfInputs_NumericUpDown);
            this.Controls.Add(this.CircuitName_TextBox);
            this.Controls.Add(this.SaveCircuit_button);
            this.Controls.Add(this.GatesPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "MainWindow";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NumOfInputs_NumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel GatesPanel;
        private System.Windows.Forms.Button SaveCircuit_button;
        private System.Windows.Forms.TextBox CircuitName_TextBox;
        private System.Windows.Forms.NumericUpDown NumOfInputs_NumericUpDown;
        private Button button1;
    }
}

