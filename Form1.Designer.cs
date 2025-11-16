namespace TranslateApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox sourceLanguageCombo;
        private System.Windows.Forms.ComboBox targetLanguageCombo;
        private System.Windows.Forms.Button swapButton;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.TextBox targetTextBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.GroupBox sourceGroupBox;
        private System.Windows.Forms.GroupBox targetGroupBox;
        private System.Windows.Forms.Button themeButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.sourceGroupBox = new System.Windows.Forms.GroupBox();
            this.sourceLanguageCombo = new System.Windows.Forms.ComboBox();
            this.swapButton = new System.Windows.Forms.Button();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.targetGroupBox = new System.Windows.Forms.GroupBox();
            this.targetLanguageCombo = new System.Windows.Forms.ComboBox();
            this.targetTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.themeButton = new System.Windows.Forms.Button();
            this.sourceGroupBox.SuspendLayout();
            this.targetGroupBox.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.titleLabel.Location = new System.Drawing.Point(20, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(380, 45);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "🌐 Çoklu Çeviri Uygulaması";

            this.sourceGroupBox.Controls.Add(this.sourceLanguageCombo);
            this.sourceGroupBox.Controls.Add(this.swapButton);
            this.sourceGroupBox.Controls.Add(this.sourceTextBox);
            this.sourceGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sourceGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.sourceGroupBox.Location = new System.Drawing.Point(20, 80);
            this.sourceGroupBox.Name = "sourceGroupBox";
            this.sourceGroupBox.Padding = new System.Windows.Forms.Padding(15, 20, 15, 15);
            this.sourceGroupBox.Size = new System.Drawing.Size(860, 240);
            this.sourceGroupBox.TabIndex = 1;
            this.sourceGroupBox.TabStop = false;
            this.sourceGroupBox.Text = "📝 Kaynak Metin";
            this.sourceGroupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.GroupBox_Paint);

            this.sourceLanguageCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceLanguageCombo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceLanguageCombo.FormattingEnabled = true;
            this.sourceLanguageCombo.Location = new System.Drawing.Point(15, 35);
            this.sourceLanguageCombo.Name = "sourceLanguageCombo";
            this.sourceLanguageCombo.Size = new System.Drawing.Size(220, 28);
            this.sourceLanguageCombo.TabIndex = 0;
            this.sourceLanguageCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.sourceLanguageCombo.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            this.sourceLanguageCombo.SelectedIndexChanged += new System.EventHandler(this.SourceLanguageCombo_SelectedIndexChanged);

            this.swapButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.swapButton.FlatAppearance.BorderSize = 0;
            this.swapButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.swapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.swapButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.swapButton.ForeColor = System.Drawing.Color.White;
            this.swapButton.Location = new System.Drawing.Point(245, 33);
            this.swapButton.Name = "swapButton";
            this.swapButton.Size = new System.Drawing.Size(50, 32);
            this.swapButton.TabIndex = 1;
            this.swapButton.Text = "⇄";
            this.swapButton.UseVisualStyleBackColor = false;
            this.swapButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swapButton.Click += new System.EventHandler(this.SwapButton_Click);

            this.sourceTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceTextBox.Location = new System.Drawing.Point(15, 75);
            this.sourceTextBox.Multiline = true;
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sourceTextBox.Size = new System.Drawing.Size(830, 150);
            this.sourceTextBox.TabIndex = 2;
            this.sourceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourceTextBox.TextChanged += new System.EventHandler(this.SourceTextBox_TextChanged);

            this.targetGroupBox.Controls.Add(this.targetLanguageCombo);
            this.targetGroupBox.Controls.Add(this.targetTextBox);
            this.targetGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.targetGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.targetGroupBox.Location = new System.Drawing.Point(20, 340);
            this.targetGroupBox.Name = "targetGroupBox";
            this.targetGroupBox.Padding = new System.Windows.Forms.Padding(15, 20, 15, 15);
            this.targetGroupBox.Size = new System.Drawing.Size(860, 240);
            this.targetGroupBox.TabIndex = 3;
            this.targetGroupBox.TabStop = false;
            this.targetGroupBox.Text = "📄 Çeviri Sonucu";
            this.targetGroupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.GroupBox_Paint);

            this.targetLanguageCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetLanguageCombo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetLanguageCombo.FormattingEnabled = true;
            this.targetLanguageCombo.Location = new System.Drawing.Point(15, 35);
            this.targetLanguageCombo.Name = "targetLanguageCombo";
            this.targetLanguageCombo.Size = new System.Drawing.Size(220, 28);
            this.targetLanguageCombo.TabIndex = 0;
            this.targetLanguageCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.targetLanguageCombo.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            this.targetLanguageCombo.SelectedIndexChanged += new System.EventHandler(this.TargetLanguageCombo_SelectedIndexChanged);

            this.targetTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetTextBox.Location = new System.Drawing.Point(15, 75);
            this.targetTextBox.Multiline = true;
            this.targetTextBox.Name = "targetTextBox";
            this.targetTextBox.ReadOnly = true;
            this.targetTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.targetTextBox.Size = new System.Drawing.Size(830, 150);
            this.targetTextBox.TabIndex = 1;
            this.targetTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.targetTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.targetTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.targetTextBox.Text = "Çeviri sonucu burada görünecek...";

            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 666);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(900, 24);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));

            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 19);
            this.statusLabel.Text = "Hazır";

            this.themeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.themeButton.FlatAppearance.BorderSize = 0;
            this.themeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.themeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.themeButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.themeButton.ForeColor = System.Drawing.Color.White;
            this.themeButton.Location = new System.Drawing.Point(800, 20);
            this.themeButton.Name = "themeButton";
            this.themeButton.Size = new System.Drawing.Size(80, 35);
            this.themeButton.TabIndex = 5;
            this.themeButton.Text = "🌙 Koyu";
            this.themeButton.UseVisualStyleBackColor = false;
            this.themeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.themeButton.Click += new System.EventHandler(this.ThemeButton_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(900, 690);
            this.Controls.Add(this.themeButton);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.targetGroupBox);
            this.Controls.Add(this.sourceGroupBox);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Çoklu Çeviri Uygulaması";
            this.sourceGroupBox.ResumeLayout(false);
            this.sourceGroupBox.PerformLayout();
            this.targetGroupBox.ResumeLayout(false);
            this.targetGroupBox.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}


