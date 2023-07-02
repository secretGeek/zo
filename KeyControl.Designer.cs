namespace zo
{
    partial class KeyControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblChar = new System.Windows.Forms.Label();
            this.lblBool = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblChar
            // 
            this.lblChar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChar.Font = new System.Drawing.Font("Courier New", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChar.Location = new System.Drawing.Point(0, 0);
            this.lblChar.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblChar.Name = "lblChar";
            this.lblChar.Size = new System.Drawing.Size(196, 131);
            this.lblChar.TabIndex = 1;
            this.lblChar.Text = "a";
            this.lblChar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBool
            // 
            this.lblBool.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBool.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBool.Location = new System.Drawing.Point(0, 100);
            this.lblBool.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblBool.Name = "lblBool";
            this.lblBool.Size = new System.Drawing.Size(196, 31);
            this.lblBool.TabIndex = 2;
            this.lblBool.Text = "00110011";
            this.lblBool.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // KeyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBool);
            this.Controls.Add(this.lblChar);
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "KeyControl";
            this.Size = new System.Drawing.Size(196, 131);
            this.Load += new System.EventHandler(this.KeyControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblChar;
        public System.Windows.Forms.Label lblBool;
    }
}
