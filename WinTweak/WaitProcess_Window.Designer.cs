namespace WinTweak
{
    partial class WaitProcess_Window
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
            this.components = new System.ComponentModel.Container();
            this.Noti = new System.Windows.Forms.Label();
            this.WindowBadge = new System.Windows.Forms.Panel();
            this.Elipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.ShadowForm = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.SuspendLayout();
            // 
            // Noti
            // 
            this.Noti.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Noti.AutoSize = true;
            this.Noti.BackColor = System.Drawing.Color.Transparent;
            this.Noti.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Noti.ForeColor = System.Drawing.Color.White;
            this.Noti.Location = new System.Drawing.Point(74, 40);
            this.Noti.Name = "Noti";
            this.Noti.Size = new System.Drawing.Size(166, 37);
            this.Noti.TabIndex = 2;
            this.Noti.Text = "Please Wait";
            // 
            // WindowBadge
            // 
            this.WindowBadge.BackColor = System.Drawing.Color.White;
            this.WindowBadge.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.WindowBadge.Location = new System.Drawing.Point(0, 111);
            this.WindowBadge.Name = "WindowBadge";
            this.WindowBadge.Size = new System.Drawing.Size(314, 5);
            this.WindowBadge.TabIndex = 3;
            // 
            // Elipse
            // 
            this.Elipse.BorderRadius = 10;
            this.Elipse.TargetControl = this;
            // 
            // WaitProcess_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(314, 116);
            this.Controls.Add(this.WindowBadge);
            this.Controls.Add(this.Noti);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WaitProcess_Window";
            this.Opacity = 0.98D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processing . . .";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Noti;
        private System.Windows.Forms.Panel WindowBadge;
        private Guna.UI2.WinForms.Guna2Elipse Elipse;
        private Guna.UI2.WinForms.Guna2ShadowForm ShadowForm;
    }
}