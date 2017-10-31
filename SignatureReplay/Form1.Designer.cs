namespace SignatureReplay
{
    partial class Form1
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
            this.tbSignatureB64 = new System.Windows.Forms.TextBox();
            this.btnReplay = new System.Windows.Forms.Button();
            this.nudThickness = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbJson = new System.Windows.Forms.CheckBox();
            this.cbDots = new System.Windows.Forms.CheckBox();
            this.cbDev = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudThickness)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSignatureB64
            // 
            this.tbSignatureB64.Location = new System.Drawing.Point(13, 13);
            this.tbSignatureB64.Multiline = true;
            this.tbSignatureB64.Name = "tbSignatureB64";
            this.tbSignatureB64.Size = new System.Drawing.Size(391, 207);
            this.tbSignatureB64.TabIndex = 0;
            // 
            // btnReplay
            // 
            this.btnReplay.Location = new System.Drawing.Point(301, 226);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(103, 35);
            this.btnReplay.TabIndex = 1;
            this.btnReplay.Text = "Replay";
            this.btnReplay.UseVisualStyleBackColor = true;
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // nudThickness
            // 
            this.nudThickness.Location = new System.Drawing.Point(13, 241);
            this.nudThickness.Name = "nudThickness";
            this.nudThickness.Size = new System.Drawing.Size(93, 20);
            this.nudThickness.TabIndex = 2;
            this.nudThickness.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thickness";
            // 
            // cbJson
            // 
            this.cbJson.AutoSize = true;
            this.cbJson.Checked = true;
            this.cbJson.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbJson.Location = new System.Drawing.Point(113, 244);
            this.cbJson.Name = "cbJson";
            this.cbJson.Size = new System.Drawing.Size(54, 17);
            this.cbJson.TabIndex = 4;
            this.cbJson.Text = "JSON";
            this.cbJson.UseVisualStyleBackColor = true;
            // 
            // cbDots
            // 
            this.cbDots.AutoSize = true;
            this.cbDots.Location = new System.Drawing.Point(165, 243);
            this.cbDots.Name = "cbDots";
            this.cbDots.Size = new System.Drawing.Size(48, 17);
            this.cbDots.TabIndex = 5;
            this.cbDots.Text = "Dots";
            this.cbDots.UseVisualStyleBackColor = true;
            // 
            // cbDev
            // 
            this.cbDev.AutoSize = true;
            this.cbDev.Checked = true;
            this.cbDev.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDev.Location = new System.Drawing.Point(209, 243);
            this.cbDev.Name = "cbDev";
            this.cbDev.Size = new System.Drawing.Size(46, 17);
            this.cbDev.TabIndex = 6;
            this.cbDev.Text = "Dev";
            this.cbDev.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 273);
            this.Controls.Add(this.cbDev);
            this.Controls.Add(this.cbDots);
            this.Controls.Add(this.cbJson);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudThickness);
            this.Controls.Add(this.btnReplay);
            this.Controls.Add(this.tbSignatureB64);
            this.Name = "Form1";
            this.Text = "Signature Replay";
            ((System.ComponentModel.ISupportInitialize)(this.nudThickness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSignatureB64;
        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.NumericUpDown nudThickness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbJson;
        private System.Windows.Forms.CheckBox cbDots;
        private System.Windows.Forms.CheckBox cbDev;
    }
}

