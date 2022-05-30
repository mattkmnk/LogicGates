namespace LogicGates
{
    partial class LGStore
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
            this.LoadedGates = new System.Windows.Forms.Panel();
            this.ImportGates = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoadedGates
            // 
            this.LoadedGates.AutoScroll = true;
            this.LoadedGates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LoadedGates.Location = new System.Drawing.Point(12, 38);
            this.LoadedGates.Name = "LoadedGates";
            this.LoadedGates.Size = new System.Drawing.Size(219, 389);
            this.LoadedGates.TabIndex = 0;
            // 
            // ImportGates
            // 
            this.ImportGates.AutoScroll = true;
            this.ImportGates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ImportGates.Location = new System.Drawing.Point(237, 38);
            this.ImportGates.Name = "ImportGates";
            this.ImportGates.Size = new System.Drawing.Size(221, 389);
            this.ImportGates.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Your Gates";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(234, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Download";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LGStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(470, 462);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ImportGates);
            this.Controls.Add(this.LoadedGates);
            this.Name = "LGStore";
            this.Text = "LGStore";
            this.Leave += new System.EventHandler(this.LGStore_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LoadedGates;
        private System.Windows.Forms.Panel ImportGates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}