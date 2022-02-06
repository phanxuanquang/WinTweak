namespace WinTweak
{
    partial class MainUI
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
            this.Banner = new System.Windows.Forms.Panel();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.MinimalizeButton = new Guna.UI2.WinForms.Guna2ImageButton();
            this.ExitButton = new Guna.UI2.WinForms.Guna2ImageButton();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.Automation_MenuButton = new Guna.UI2.WinForms.Guna2TileButton();
            this.SettingButton = new Guna.UI2.WinForms.Guna2GradientButton();
            this.Applycations_MenuButton = new Guna.UI2.WinForms.Guna2TileButton();
            this.System_MenuButton = new Guna.UI2.WinForms.Guna2TileButton();
            this.Appearance_MenuButton = new Guna.UI2.WinForms.Guna2TileButton();
            this.Home_MenuButton = new Guna.UI2.WinForms.Guna2TileButton();
            this.ContainPanel = new System.Windows.Forms.Panel();
            this.DragWindow = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.Banner.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Banner
            // 
            this.Banner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.Banner.Controls.Add(this.guna2ImageButton1);
            this.Banner.Controls.Add(this.label1);
            this.Banner.Controls.Add(this.MinimalizeButton);
            this.Banner.Controls.Add(this.ExitButton);
            this.Banner.Dock = System.Windows.Forms.DockStyle.Top;
            this.Banner.Location = new System.Drawing.Point(0, 0);
            this.Banner.Name = "Banner";
            this.Banner.Size = new System.Drawing.Size(954, 30);
            this.Banner.TabIndex = 3;
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ImageButton1.CheckedState.Parent = this.guna2ImageButton1;
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(17, 17);
            this.guna2ImageButton1.HoverState.Parent = this.guna2ImageButton1;
            this.guna2ImageButton1.Image = global::WinTweak.Properties.Resources.HOME;
            this.guna2ImageButton1.ImageSize = new System.Drawing.Size(17, 17);
            this.guna2ImageButton1.Location = new System.Drawing.Point(5, 0);
            this.guna2ImageButton1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(17, 17);
            this.guna2ImageButton1.PressedState.Parent = this.guna2ImageButton1;
            this.guna2ImageButton1.Size = new System.Drawing.Size(30, 30);
            this.guna2ImageButton1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "WinTweak  -  Customize and optimizing your Windows";
            // 
            // MinimalizeButton
            // 
            this.MinimalizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimalizeButton.BackColor = System.Drawing.Color.Transparent;
            this.MinimalizeButton.CheckedState.Parent = this.MinimalizeButton;
            this.MinimalizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimalizeButton.HoverState.ImageSize = new System.Drawing.Size(17, 17);
            this.MinimalizeButton.HoverState.Parent = this.MinimalizeButton;
            this.MinimalizeButton.Image = global::WinTweak.Properties.Resources.HOME;
            this.MinimalizeButton.ImageSize = new System.Drawing.Size(15, 15);
            this.MinimalizeButton.Location = new System.Drawing.Point(896, 0);
            this.MinimalizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.MinimalizeButton.Name = "MinimalizeButton";
            this.MinimalizeButton.PressedState.ImageSize = new System.Drawing.Size(15, 15);
            this.MinimalizeButton.PressedState.Parent = this.MinimalizeButton;
            this.MinimalizeButton.Size = new System.Drawing.Size(29, 30);
            this.MinimalizeButton.TabIndex = 6;
            this.MinimalizeButton.UseTransparentBackground = true;
            this.MinimalizeButton.Click += new System.EventHandler(this.MinimalizeButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.CheckedState.Parent = this.ExitButton;
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.HoverState.ImageSize = new System.Drawing.Size(17, 17);
            this.ExitButton.HoverState.Parent = this.ExitButton;
            this.ExitButton.Image = global::WinTweak.Properties.Resources.HOME;
            this.ExitButton.ImageSize = new System.Drawing.Size(15, 15);
            this.ExitButton.Location = new System.Drawing.Point(925, 0);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.PressedState.ImageSize = new System.Drawing.Size(15, 15);
            this.ExitButton.PressedState.Parent = this.ExitButton;
            this.ExitButton.Size = new System.Drawing.Size(29, 30);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.UseTransparentBackground = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.menuPanel.Controls.Add(this.Automation_MenuButton);
            this.menuPanel.Controls.Add(this.SettingButton);
            this.menuPanel.Controls.Add(this.Applycations_MenuButton);
            this.menuPanel.Controls.Add(this.System_MenuButton);
            this.menuPanel.Controls.Add(this.Appearance_MenuButton);
            this.menuPanel.Controls.Add(this.Home_MenuButton);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 30);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(120, 638);
            this.menuPanel.TabIndex = 4;
            // 
            // Automation_MenuButton
            // 
            this.Automation_MenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Automation_MenuButton.Animated = true;
            this.Automation_MenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Automation_MenuButton.CheckedState.Parent = this.Automation_MenuButton;
            this.Automation_MenuButton.CustomImages.Parent = this.Automation_MenuButton;
            this.Automation_MenuButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Automation_MenuButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Automation_MenuButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Automation_MenuButton.ForeColor = System.Drawing.Color.White;
            this.Automation_MenuButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Automation_MenuButton.HoverState.Parent = this.Automation_MenuButton;
            this.Automation_MenuButton.Image = global::WinTweak.Properties.Resources.HOME;
            this.Automation_MenuButton.Location = new System.Drawing.Point(0, 360);
            this.Automation_MenuButton.Name = "Automation_MenuButton";
            this.Automation_MenuButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.Automation_MenuButton.ShadowDecoration.Parent = this.Automation_MenuButton;
            this.Automation_MenuButton.Size = new System.Drawing.Size(120, 90);
            this.Automation_MenuButton.TabIndex = 7;
            this.Automation_MenuButton.Text = "AUTOMATION";
            this.Automation_MenuButton.TextOffset = new System.Drawing.Point(0, 5);
            this.Automation_MenuButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // SettingButton
            // 
            this.SettingButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingButton.Animated = true;
            this.SettingButton.BackColor = System.Drawing.Color.Transparent;
            this.SettingButton.CheckedState.Parent = this.SettingButton;
            this.SettingButton.CustomImages.Parent = this.SettingButton;
            this.SettingButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.SettingButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.SettingButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.SettingButton.ForeColor = System.Drawing.Color.White;
            this.SettingButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.SettingButton.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.SettingButton.HoverState.Parent = this.SettingButton;
            this.SettingButton.Image = global::WinTweak.Properties.Resources.HOME;
            this.SettingButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SettingButton.ImageOffset = new System.Drawing.Point(7, 0);
            this.SettingButton.Location = new System.Drawing.Point(0, 588);
            this.SettingButton.Margin = new System.Windows.Forms.Padding(0);
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.SettingButton.ShadowDecoration.Parent = this.SettingButton;
            this.SettingButton.Size = new System.Drawing.Size(120, 50);
            this.SettingButton.TabIndex = 5;
            this.SettingButton.Text = "SETTING";
            this.SettingButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SettingButton.TextOffset = new System.Drawing.Point(-7, 0);
            this.SettingButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // Applycations_MenuButton
            // 
            this.Applycations_MenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Applycations_MenuButton.Animated = true;
            this.Applycations_MenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Applycations_MenuButton.CheckedState.Parent = this.Applycations_MenuButton;
            this.Applycations_MenuButton.CustomImages.Parent = this.Applycations_MenuButton;
            this.Applycations_MenuButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Applycations_MenuButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Applycations_MenuButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Applycations_MenuButton.ForeColor = System.Drawing.Color.White;
            this.Applycations_MenuButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Applycations_MenuButton.HoverState.Parent = this.Applycations_MenuButton;
            this.Applycations_MenuButton.Image = global::WinTweak.Properties.Resources.HOME;
            this.Applycations_MenuButton.Location = new System.Drawing.Point(0, 270);
            this.Applycations_MenuButton.Name = "Applycations_MenuButton";
            this.Applycations_MenuButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.Applycations_MenuButton.ShadowDecoration.Parent = this.Applycations_MenuButton;
            this.Applycations_MenuButton.Size = new System.Drawing.Size(120, 90);
            this.Applycations_MenuButton.TabIndex = 6;
            this.Applycations_MenuButton.Text = "APPLYCATIONS";
            this.Applycations_MenuButton.TextOffset = new System.Drawing.Point(0, 5);
            this.Applycations_MenuButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // System_MenuButton
            // 
            this.System_MenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.System_MenuButton.Animated = true;
            this.System_MenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.System_MenuButton.CheckedState.Parent = this.System_MenuButton;
            this.System_MenuButton.CustomImages.Parent = this.System_MenuButton;
            this.System_MenuButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.System_MenuButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.System_MenuButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.System_MenuButton.ForeColor = System.Drawing.Color.White;
            this.System_MenuButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.System_MenuButton.HoverState.Parent = this.System_MenuButton;
            this.System_MenuButton.Image = global::WinTweak.Properties.Resources.HOME;
            this.System_MenuButton.Location = new System.Drawing.Point(0, 180);
            this.System_MenuButton.Name = "System_MenuButton";
            this.System_MenuButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.System_MenuButton.ShadowDecoration.Parent = this.System_MenuButton;
            this.System_MenuButton.Size = new System.Drawing.Size(120, 90);
            this.System_MenuButton.TabIndex = 5;
            this.System_MenuButton.Text = "SYSTEM";
            this.System_MenuButton.TextOffset = new System.Drawing.Point(0, 5);
            this.System_MenuButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // Appearance_MenuButton
            // 
            this.Appearance_MenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Appearance_MenuButton.Animated = true;
            this.Appearance_MenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Appearance_MenuButton.CheckedState.Parent = this.Appearance_MenuButton;
            this.Appearance_MenuButton.CustomImages.Parent = this.Appearance_MenuButton;
            this.Appearance_MenuButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Appearance_MenuButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Appearance_MenuButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Appearance_MenuButton.ForeColor = System.Drawing.Color.White;
            this.Appearance_MenuButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Appearance_MenuButton.HoverState.Parent = this.Appearance_MenuButton;
            this.Appearance_MenuButton.Image = global::WinTweak.Properties.Resources.HOME;
            this.Appearance_MenuButton.Location = new System.Drawing.Point(0, 90);
            this.Appearance_MenuButton.Name = "Appearance_MenuButton";
            this.Appearance_MenuButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.Appearance_MenuButton.ShadowDecoration.Parent = this.Appearance_MenuButton;
            this.Appearance_MenuButton.Size = new System.Drawing.Size(120, 90);
            this.Appearance_MenuButton.TabIndex = 4;
            this.Appearance_MenuButton.Text = "APPEARANCE";
            this.Appearance_MenuButton.TextOffset = new System.Drawing.Point(0, 5);
            this.Appearance_MenuButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // Home_MenuButton
            // 
            this.Home_MenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Home_MenuButton.Animated = true;
            this.Home_MenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Home_MenuButton.CheckedState.Parent = this.Home_MenuButton;
            this.Home_MenuButton.CustomImages.Parent = this.Home_MenuButton;
            this.Home_MenuButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Home_MenuButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Home_MenuButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Home_MenuButton.ForeColor = System.Drawing.Color.White;
            this.Home_MenuButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Home_MenuButton.HoverState.Parent = this.Home_MenuButton;
            this.Home_MenuButton.Image = global::WinTweak.Properties.Resources.HOME;
            this.Home_MenuButton.Location = new System.Drawing.Point(0, 0);
            this.Home_MenuButton.Name = "Home_MenuButton";
            this.Home_MenuButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.Home_MenuButton.ShadowDecoration.Parent = this.Home_MenuButton;
            this.Home_MenuButton.Size = new System.Drawing.Size(120, 90);
            this.Home_MenuButton.TabIndex = 3;
            this.Home_MenuButton.Text = "HOME";
            this.Home_MenuButton.TextOffset = new System.Drawing.Point(0, 5);
            this.Home_MenuButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // ContainPanel
            // 
            this.ContainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainPanel.Location = new System.Drawing.Point(120, 30);
            this.ContainPanel.Name = "ContainPanel";
            this.ContainPanel.Size = new System.Drawing.Size(834, 638);
            this.ContainPanel.TabIndex = 5;
            // 
            // DragWindow
            // 
            this.DragWindow.TargetControl = this.Banner;
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(954, 668);
            this.Controls.Add(this.ContainPanel);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.Banner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainUI";
            this.Banner.ResumeLayout(false);
            this.Banner.PerformLayout();
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Banner;
        private System.Windows.Forms.Panel menuPanel;
        private Guna.UI2.WinForms.Guna2TileButton Applycations_MenuButton;
        private Guna.UI2.WinForms.Guna2TileButton System_MenuButton;
        private Guna.UI2.WinForms.Guna2TileButton Appearance_MenuButton;
        private Guna.UI2.WinForms.Guna2TileButton Home_MenuButton;
        private Guna.UI2.WinForms.Guna2ImageButton ExitButton;
        private Guna.UI2.WinForms.Guna2GradientButton SettingButton;
        private System.Windows.Forms.Panel ContainPanel;
        private Guna.UI2.WinForms.Guna2TileButton Automation_MenuButton;
        private Guna.UI2.WinForms.Guna2ImageButton MinimalizeButton;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DragControl DragWindow;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
    }
}

