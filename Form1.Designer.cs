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
        private System.Windows.Forms.Button translateButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.GroupBox sourceGroupBox;
        private System.Windows.Forms.GroupBox targetGroupBox;

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
            this.translateButton = new System.Windows.Forms.Button();
            this.targetGroupBox = new System.Windows.Forms.GroupBox();
            this.targetLanguageCombo = new System.Windows.Forms.ComboBox();
            this.targetTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.sourceGroupBox.SuspendLayout();
            this.targetGroupBox.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(280, 29);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "🌐 Çoklu Çeviri Uygulaması";

            this.sourceGroupBox.Controls.Add(this.sourceLanguageCombo);
            this.sourceGroupBox.Controls.Add(this.swapButton);
            this.sourceGroupBox.Controls.Add(this.sourceTextBox);
            this.sourceGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceGroupBox.Location = new System.Drawing.Point(12, 50);
            this.sourceGroupBox.Name = "sourceGroupBox";
            this.sourceGroupBox.Size = new System.Drawing.Size(860, 220);
            this.sourceGroupBox.TabIndex = 1;
            this.sourceGroupBox.TabStop = false;
            this.sourceGroupBox.Text = "Kaynak Metin";

            this.sourceLanguageCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceLanguageCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceLanguageCombo.FormattingEnabled = true;
            this.sourceLanguageCombo.Location = new System.Drawing.Point(6, 22);
            this.sourceLanguageCombo.Name = "sourceLanguageCombo";
            this.sourceLanguageCombo.Size = new System.Drawing.Size(200, 24);
            this.sourceLanguageCombo.TabIndex = 0;
            this.sourceLanguageCombo.SelectedIndexChanged += new System.EventHandler(this.SourceLanguageCombo_SelectedIndexChanged);

            this.swapButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.swapButton.FlatAppearance.BorderSize = 0;
            this.swapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.swapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.swapButton.ForeColor = System.Drawing.Color.White;
            this.swapButton.Location = new System.Drawing.Point(212, 20);
            this.swapButton.Name = "swapButton";
            this.swapButton.Size = new System.Drawing.Size(40, 28);
            this.swapButton.TabIndex = 1;
            this.swapButton.Text = "⇄";
            this.swapButton.UseVisualStyleBackColor = false;
            this.swapButton.Click += new System.EventHandler(this.SwapButton_Click);

            this.sourceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceTextBox.Location = new System.Drawing.Point(6, 54);
            this.sourceTextBox.Multiline = true;
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sourceTextBox.Size = new System.Drawing.Size(848, 160);
            this.sourceTextBox.TabIndex = 2;
            this.sourceTextBox.TextChanged += new System.EventHandler(this.SourceTextBox_TextChanged);

            this.translateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.translateButton.FlatAppearance.BorderSize = 0;
            this.translateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.translateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.translateButton.ForeColor = System.Drawing.Color.White;
            this.translateButton.Location = new System.Drawing.Point(12, 276);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(860, 45);
            this.translateButton.TabIndex = 2;
            this.translateButton.Text = "Çevir";
            this.translateButton.UseVisualStyleBackColor = false;
            this.translateButton.Enabled = false;
            this.translateButton.Click += new System.EventHandler(this.TranslateButton_Click);

            this.targetGroupBox.Controls.Add(this.targetLanguageCombo);
            this.targetGroupBox.Controls.Add(this.targetTextBox);
            this.targetGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetGroupBox.Location = new System.Drawing.Point(12, 327);
            this.targetGroupBox.Name = "targetGroupBox";
            this.targetGroupBox.Size = new System.Drawing.Size(860, 220);
            this.targetGroupBox.TabIndex = 3;
            this.targetGroupBox.TabStop = false;
            this.targetGroupBox.Text = "Çeviri Sonucu";

            this.targetLanguageCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetLanguageCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetLanguageCombo.FormattingEnabled = true;
            this.targetLanguageCombo.Location = new System.Drawing.Point(6, 22);
            this.targetLanguageCombo.Name = "targetLanguageCombo";
            this.targetLanguageCombo.Size = new System.Drawing.Size(200, 24);
            this.targetLanguageCombo.TabIndex = 0;
            this.targetLanguageCombo.SelectedIndexChanged += new System.EventHandler(this.TargetLanguageCombo_SelectedIndexChanged);

            this.targetTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetTextBox.Location = new System.Drawing.Point(6, 54);
            this.targetTextBox.Multiline = true;
            this.targetTextBox.Name = "targetTextBox";
            this.targetTextBox.ReadOnly = true;
            this.targetTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.targetTextBox.Size = new System.Drawing.Size(848, 160);
            this.targetTextBox.TabIndex = 1;
            this.targetTextBox.Text = "Çeviri sonucu burada görünecek...";

            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 554);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(884, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";

            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 17);
            this.statusLabel.Text = "Hazır";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(884, 576);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.targetGroupBox);
            this.Controls.Add(this.translateButton);
            this.Controls.Add(this.sourceGroupBox);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
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

