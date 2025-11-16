using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace TranslateApp
{
    public partial class Form1 : Form
    {
        [DllImport("uxtheme.dll", EntryPoint = "#95", CharSet = CharSet.Unicode)]
        private static extern uint SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const uint WM_THEMECHANGED = 0x031A;

        private TranslationService translationService = null!;
        private Dictionary<string, string> languages = null!;
        private System.Windows.Forms.Timer autoTranslateTimer = null!;
        private bool isTranslating = false;
        private bool isInitializing = true;
        private bool isAutoTranslate = false;
        private bool isDarkTheme = false;

        public Form1()
        {
            InitializeComponent();
            translationService = new TranslationService();
            InitializeLanguages();
            LoadLanguages();
            InitializeAutoTranslateTimer();
            InitializeScrollbarTheme();
        }

        private void InitializeScrollbarTheme()
        {
            sourceTextBox.HandleCreated += TextBox_HandleCreated;
            targetTextBox.HandleCreated += TextBox_HandleCreated;
        }

        private void TextBox_HandleCreated(object? sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                UpdateScrollbarTheme(textBox);
            }
        }

        private void UpdateScrollbarTheme(TextBox textBox)
        {
            if (textBox.IsHandleCreated)
            {
                if (isDarkTheme)
                {
                    SetWindowTheme(textBox.Handle, "DarkMode_Explorer", null);
                }
                else
                {
                    SetWindowTheme(textBox.Handle, "", null);
                }
            }
        }


        private void GroupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox ?? throw new InvalidOperationException();
            
            using (SolidBrush brush = new SolidBrush(groupBox.BackColor))
            {
                e.Graphics.FillRectangle(brush, groupBox.ClientRectangle);
            }
            
            SizeF textSize = e.Graphics.MeasureString(groupBox.Text, groupBox.Font);
            int textHeight = (int)textSize.Height;
            int textWidth = (int)textSize.Width;
            int titleY = (textHeight / 2);
            
            using (SolidBrush brush = new SolidBrush(groupBox.BackColor))
            {
                e.Graphics.FillRectangle(brush, 8, 0, textWidth + 4, textHeight);
            }
            
            using (SolidBrush textBrush = new SolidBrush(groupBox.ForeColor))
            {
                e.Graphics.DrawString(groupBox.Text, groupBox.Font, textBrush, 10, 0);
            }
            
            Color borderColor = isDarkTheme ? Color.FromArgb(70, 70, 70) : Color.FromArgb(200, 200, 200);
            using (Pen pen = new Pen(borderColor, 1))
            {
                e.Graphics.DrawLine(pen, textWidth + 14, titleY, groupBox.Width - 1, titleY);
                e.Graphics.DrawLine(pen, 0, titleY, 0, groupBox.Height - 1);
                e.Graphics.DrawLine(pen, groupBox.Width - 1, titleY, groupBox.Width - 1, groupBox.Height - 1);
                e.Graphics.DrawLine(pen, 0, groupBox.Height - 1, groupBox.Width - 1, groupBox.Height - 1);
            }
        }

        private void InitializeAutoTranslateTimer()
        {
            autoTranslateTimer = new System.Windows.Forms.Timer();
            autoTranslateTimer.Interval = 1500;
            autoTranslateTimer.Tick += AutoTranslateTimer_Tick;
        }

        private void InitializeLanguages()
        {
            languages = new Dictionary<string, string>
            {
                { "Türkçe", "tr" },
                { "İngilizce", "en" },
                { "Almanca", "de" },
                { "Fransızca", "fr" },
                { "İspanyolca", "es" },
                { "İtalyanca", "it" },
                { "Rusça", "ru" },
                { "Japonca", "ja" },
                { "Korece", "ko" },
                { "Çince", "zh" },
                { "Arapça", "ar" },
                { "Portekizce", "pt" },
                { "Hollandaca", "nl" },
                { "Yunanca", "el" },
                { "İsveççe", "sv" },
                { "Norveççe", "no" },
                { "Fince", "fi" },
                { "Lehçe", "pl" },
                { "Çekçe", "cs" },
                { "Macarca", "hu" },
                { "Hintçe", "hi" },
                { "Urduca", "ur" },
                { "Bengalce", "bn" },
                { "Vietnamca", "vi" },
                { "Tayca", "th" },
                { "Endonezce", "id" },
                { "İbranice", "he" },
                { "Romence", "ro" },
                { "Bulgarca", "bg" },
                { "Hırvatça", "hr" },
                { "Sırpça", "sr" },
                { "Slovakça", "sk" },
                { "Danca", "da" },
                { "Katalanca", "ca" },
                { "Ukraynaca", "uk" },
                { "Estonca", "et" },
                { "Litvanca", "lt" },
                { "Letonca", "lv" },
                { "Slovence", "sl" },
                { "Malayca", "ms" },
                { "Filipince", "tl" },
                { "Afrikanca", "af" },
                { "Baskça", "eu" },
                { "Galce", "cy" },
                { "İrlandaca", "ga" },
                { "Maltaca", "mt" },
                { "İzlandaca", "is" }
            };
        }

        private void LoadLanguages()
        {
            isInitializing = true;
            sourceLanguageCombo.DataSource = new List<string>(languages.Keys);
            targetLanguageCombo.DataSource = new List<string>(languages.Keys);
            
            sourceLanguageCombo.SelectedItem = "Türkçe";
            targetLanguageCombo.SelectedItem = "İngilizce";
            isInitializing = false;
        }

        private void SourceLanguageCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInitializing)
            {
                TriggerAutoTranslate();
            }
        }

        private void TargetLanguageCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInitializing)
            {
                TriggerAutoTranslate();
            }
        }

        private void SourceTextBox_TextChanged(object sender, EventArgs e)
        {
            TriggerAutoTranslate();
        }

        private void TriggerAutoTranslate()
        {
            if (isTranslating || string.IsNullOrWhiteSpace(sourceTextBox.Text))
            {
                autoTranslateTimer.Stop();
                return;
            }

            autoTranslateTimer.Stop();
            autoTranslateTimer.Start();
        }

        private async void AutoTranslateTimer_Tick(object sender, EventArgs e)
        {
            autoTranslateTimer.Stop();
            
            if (string.IsNullOrWhiteSpace(sourceTextBox.Text) ||
                sourceLanguageCombo.SelectedItem == null ||
                targetLanguageCombo.SelectedItem == null)
            {
                return;
            }

            string sourceLang = languages[sourceLanguageCombo.SelectedItem.ToString()!];
            string targetLang = languages[targetLanguageCombo.SelectedItem.ToString()!];

            if (sourceLang == targetLang)
            {
                return;
            }

            isAutoTranslate = true;
            await PerformTranslation();
            isAutoTranslate = false;
        }


        private async System.Threading.Tasks.Task PerformTranslation()
        {
            if (isTranslating) return;

            string sourceLang = languages[sourceLanguageCombo.SelectedItem!.ToString()!];
            string targetLang = languages[targetLanguageCombo.SelectedItem!.ToString()!];

            isTranslating = true;
            statusLabel.Text = "Çeviriliyor...";
            targetTextBox.Text = "";
            targetTextBox.ForeColor = isDarkTheme ? System.Drawing.Color.FromArgb(150, 150, 150) : System.Drawing.Color.FromArgb(97, 97, 97);

            try
            {
                string translatedText = await translationService.TranslateAsync(sourceTextBox.Text, sourceLang, targetLang);
                targetTextBox.Text = translatedText;
                targetTextBox.ForeColor = isDarkTheme ? System.Drawing.Color.FromArgb(220, 220, 220) : System.Drawing.Color.FromArgb(33, 33, 33);
                statusLabel.Text = "Çeviri tamamlandı.";
            }
            catch (Exception ex)
            {
                targetTextBox.Text = $"Hata: {ex.Message}";
                targetTextBox.ForeColor = System.Drawing.Color.FromArgb(211, 47, 47);
                statusLabel.Text = "Çeviri hatası oluştu.";
            }
            finally
            {
                isTranslating = false;
            }
        }

        private void SwapButton_Click(object sender, EventArgs e)
        {
            autoTranslateTimer.Stop();
            
            var sourceText = sourceTextBox.Text;
            var sourceLang = sourceLanguageCombo.SelectedItem;
            var targetLang = targetLanguageCombo.SelectedItem;

            sourceLanguageCombo.SelectedItem = targetLang;
            targetLanguageCombo.SelectedItem = sourceLang;
            sourceTextBox.Text = targetTextBox.Text;
            
            if (string.IsNullOrWhiteSpace(targetTextBox.Text) || targetTextBox.Text == "Çeviri sonucu burada görünecek...")
            {
                targetTextBox.Text = sourceText;
                targetTextBox.ForeColor = isDarkTheme ? System.Drawing.Color.FromArgb(220, 220, 220) : System.Drawing.Color.FromArgb(33, 33, 33);
            }
            else
            {
                targetTextBox.Text = sourceText;
                if (!string.IsNullOrWhiteSpace(sourceText))
                {
                    targetTextBox.ForeColor = isDarkTheme ? System.Drawing.Color.FromArgb(220, 220, 220) : System.Drawing.Color.FromArgb(33, 33, 33);
                }
            }
        }

        private void ThemeButton_Click(object sender, EventArgs e)
        {
            isDarkTheme = !isDarkTheme;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            if (isDarkTheme)
            {
                this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(100, 181, 246);
                
                this.sourceGroupBox.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
                this.sourceGroupBox.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
                this.targetGroupBox.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
                this.targetGroupBox.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
                
                this.sourceTextBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
                this.sourceTextBox.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
                this.targetTextBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
                this.targetTextBox.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
                
                this.sourceLanguageCombo.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
                this.sourceLanguageCombo.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
                this.targetLanguageCombo.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
                this.targetLanguageCombo.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
                
                this.statusStrip.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
                this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
                
                this.swapButton.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
                this.swapButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 101, 170);
                this.themeButton.Text = "☀️ Açık";

                try
                {
                    int darkMode = 1;
                    DwmSetWindowAttribute(this.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref darkMode, sizeof(int));
                }
                catch { }

                if (this.sourceTextBox.IsHandleCreated)
                {
                    UpdateScrollbarTheme(this.sourceTextBox);
                    SendMessage(this.sourceTextBox.Handle, WM_THEMECHANGED, IntPtr.Zero, IntPtr.Zero);
                    this.sourceTextBox.Invalidate();
                }
                if (this.targetTextBox.IsHandleCreated)
                {
                    UpdateScrollbarTheme(this.targetTextBox);
                    SendMessage(this.targetTextBox.Handle, WM_THEMECHANGED, IntPtr.Zero, IntPtr.Zero);
                    this.targetTextBox.Invalidate();
                }
            }
            else
            {
                this.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
                this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
                
                this.sourceGroupBox.BackColor = System.Drawing.Color.White;
                this.sourceGroupBox.ForeColor = System.Drawing.Color.FromArgb(66, 66, 66);
                this.targetGroupBox.BackColor = System.Drawing.Color.White;
                this.targetGroupBox.ForeColor = System.Drawing.Color.FromArgb(66, 66, 66);
                
                this.sourceTextBox.BackColor = System.Drawing.Color.White;
                this.sourceTextBox.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
                this.targetTextBox.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
                this.targetTextBox.ForeColor = System.Drawing.Color.FromArgb(97, 97, 97);
                
                this.sourceLanguageCombo.BackColor = System.Drawing.Color.White;
                this.sourceLanguageCombo.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
                this.targetLanguageCombo.BackColor = System.Drawing.Color.White;
                this.targetLanguageCombo.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
                
                this.statusStrip.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
                this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(66, 66, 66);
                
                this.swapButton.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
                this.swapButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(21, 101, 192);
                this.themeButton.Text = "🌙 Koyu";

                try
                {
                    int darkMode = 0;
                    DwmSetWindowAttribute(this.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref darkMode, sizeof(int));
                }
                catch { }

                if (this.sourceTextBox.IsHandleCreated)
                {
                    UpdateScrollbarTheme(this.sourceTextBox);
                    SendMessage(this.sourceTextBox.Handle, WM_THEMECHANGED, IntPtr.Zero, IntPtr.Zero);
                    this.sourceTextBox.Invalidate();
                }
                if (this.targetTextBox.IsHandleCreated)
                {
                    UpdateScrollbarTheme(this.targetTextBox);
                    SendMessage(this.targetTextBox.Handle, WM_THEMECHANGED, IntPtr.Zero, IntPtr.Zero);
                    this.targetTextBox.Invalidate();
                }
            }

            this.sourceGroupBox.Invalidate();
            this.targetGroupBox.Invalidate();
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox comboBox = sender as ComboBox ?? throw new InvalidOperationException();
            
            e.DrawBackground();
            
            System.Drawing.Brush brush;
            if (isDarkTheme)
            {
                brush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(220, 220, 220));
                e.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(37, 37, 38)), e.Bounds);
            }
            else
            {
                brush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(33, 33, 33));
                e.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), e.Bounds);
            }

            if (e.Index < comboBox.Items.Count)
            {
                e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), e.Font, brush, e.Bounds, System.Drawing.StringFormat.GenericDefault);
            }

            e.DrawFocusRectangle();
            brush.Dispose();
        }
    }
}

