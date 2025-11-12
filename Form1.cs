using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TranslateApp
{
    public partial class Form1 : Form
    {
        private TranslationService translationService = null!;
        private Dictionary<string, string> languages = null!;

        public Form1()
        {
            InitializeComponent();
            translationService = new TranslationService();
            InitializeLanguages();
            LoadLanguages();
            SetupButtonStyles();
        }

        private void SetupButtonStyles()
        {
            // Disabled button styling
            translateButton.FlatAppearance.MouseOverBackColor = translateButton.BackColor;
            translateButton.FlatAppearance.MouseDownBackColor = translateButton.BackColor;
            
            // Update button state to apply disabled styling
            UpdateTranslateButtonState();
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
                { "Macarca", "hu" }
            };
        }

        private void LoadLanguages()
        {
            sourceLanguageCombo.DataSource = new List<string>(languages.Keys);
            targetLanguageCombo.DataSource = new List<string>(languages.Keys);
            
            sourceLanguageCombo.SelectedItem = "Türkçe";
            targetLanguageCombo.SelectedItem = "İngilizce";
        }

        private void SourceLanguageCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTranslateButtonState();
        }

        private void TargetLanguageCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTranslateButtonState();
        }

        private void SourceTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateTranslateButtonState();
        }

        private void UpdateTranslateButtonState()
        {
            bool canTranslate = !string.IsNullOrWhiteSpace(sourceTextBox.Text) &&
                               sourceLanguageCombo.SelectedItem != null &&
                               targetLanguageCombo.SelectedItem != null &&
                               sourceLanguageCombo.SelectedItem.ToString() != targetLanguageCombo.SelectedItem.ToString();
            
            translateButton.Enabled = canTranslate;
            
            // Update button appearance based on state
            if (canTranslate)
            {
                translateButton.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
                translateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(21, 101, 192);
                translateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(13, 71, 161);
            }
            else
            {
                translateButton.BackColor = System.Drawing.Color.FromArgb(189, 189, 189);
                translateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(189, 189, 189);
                translateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(189, 189, 189);
            }
        }

        private async void TranslateButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sourceTextBox.Text))
            {
                MessageBox.Show("Lütfen çevrilecek metni girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sourceLanguageCombo.SelectedItem == null || targetLanguageCombo.SelectedItem == null)
            {
                MessageBox.Show("Lütfen kaynak ve hedef dilleri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sourceLang = languages[sourceLanguageCombo.SelectedItem.ToString()!];
            string targetLang = languages[targetLanguageCombo.SelectedItem.ToString()!];

            if (sourceLang == targetLang)
            {
                MessageBox.Show("Kaynak ve hedef dil aynı olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            translateButton.Enabled = false;
            statusLabel.Text = "Çeviriliyor...";
            targetTextBox.Text = "";
            targetTextBox.ForeColor = System.Drawing.Color.FromArgb(97, 97, 97);

            try
            {
                string translatedText = await translationService.TranslateAsync(sourceTextBox.Text, sourceLang, targetLang);
                targetTextBox.Text = translatedText;
                targetTextBox.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
                statusLabel.Text = "Çeviri tamamlandı.";
            }
            catch (Exception ex)
            {
                targetTextBox.Text = $"Hata: {ex.Message}";
                targetTextBox.ForeColor = System.Drawing.Color.FromArgb(211, 47, 47);
                statusLabel.Text = "Çeviri hatası oluştu.";
                MessageBox.Show($"Çeviri sırasında bir hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                translateButton.Enabled = true;
            }
        }

        private void SwapButton_Click(object sender, EventArgs e)
        {
            var sourceText = sourceTextBox.Text;
            var sourceLang = sourceLanguageCombo.SelectedItem;
            var targetLang = targetLanguageCombo.SelectedItem;

            sourceLanguageCombo.SelectedItem = targetLang;
            targetLanguageCombo.SelectedItem = sourceLang;
            sourceTextBox.Text = targetTextBox.Text;
            
            if (string.IsNullOrWhiteSpace(targetTextBox.Text) || targetTextBox.Text == "Çeviri sonucu burada görünecek...")
            {
                targetTextBox.Text = sourceText;
                targetTextBox.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            }
            else
            {
                targetTextBox.Text = sourceText;
                if (!string.IsNullOrWhiteSpace(sourceText))
                {
                    targetTextBox.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
                }
            }
        }
    }
}

