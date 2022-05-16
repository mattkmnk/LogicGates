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
            this.MainboardPanel = new System.Windows.Forms.Panel();
            this.TestButton = new System.Windows.Forms.Button();
            this.GatesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // MainboardPanel
            // 
            this.MainboardPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.MainboardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainboardPanel.Location = new System.Drawing.Point(12, 12);
            this.MainboardPanel.Name = "MainboardPanel";
            this.MainboardPanel.Size = new System.Drawing.Size(959, 643);
            this.MainboardPanel.TabIndex = 0;
            this.MainboardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainboardPanel_Paint);
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(896, 659);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(75, 23);
            this.TestButton.TabIndex = 1;
            this.TestButton.Text = "Test";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // GatesPanel
            // 
            this.GatesPanel.Location = new System.Drawing.Point(977, 12);
            this.GatesPanel.Name = "GatesPanel";
            this.GatesPanel.Size = new System.Drawing.Size(161, 670);
            this.GatesPanel.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(1144, 681);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.GatesPanel);
            this.Controls.Add(this.MainboardPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainboardPanel;
        private System.Windows.Forms.FlowLayoutPanel GatesPanel;
        private System.Windows.Forms.Button TestButton;
    }
}

