using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TranslateApp
{
    public partial class Form1 : Form
    {
        private TranslationService translationService = null!;
        private Dictionary<string, string> languages = null!;
        private System.Windows.Forms.Timer autoTranslateTimer = null!;
        private bool isTranslating = false;
        private bool isInitializing = true;
        private bool isAutoTranslate = false;

        public Form1()
        {
            InitializeComponent();
            translationService = new TranslationService();
            InitializeLanguages();
            LoadLanguages();
            InitializeAutoTranslateTimer();
        }

        private void InitializeAutoTranslateTimer()
        {
            autoTranslateTimer = new System.Windows.Forms.Timer();
            autoTranslateTimer.Interval = 1500; // 1.5 saniye bekle
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
            // Eğer çeviri yapılıyorsa veya metin boşsa otomatik çeviri yapma
            if (isTranslating || string.IsNullOrWhiteSpace(sourceTextBox.Text))
            {
                autoTranslateTimer.Stop();
                return;
            }

            // Timer'ı sıfırla ve yeniden başlat (debounce)
            autoTranslateTimer.Stop();
            autoTranslateTimer.Start();
        }

        private async void AutoTranslateTimer_Tick(object sender, EventArgs e)
        {
            autoTranslateTimer.Stop();
            
            // Çeviri koşullarını kontrol et
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

            // Otomatik çeviriyi başlat
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

            // Dil değiştiğinde otomatik çeviri tetiklenecek (SelectedIndexChanged event'i sayesinde)
        }
    }
}

