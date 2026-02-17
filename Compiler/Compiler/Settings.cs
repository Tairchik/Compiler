using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompilerGUI
{
    public partial class Settings : Form
    {
        public string Language;

        public Settings(string currentLanguage)
        {
            InitializeComponent();

            UploadList();

            languageComboBox.SelectedItem = currentLanguage;

            buttonOk.Click += ButtonOk_Click;
            buttonCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        }

        private void UploadList()
        {
            languageComboBox.Items.Clear();

            var languages = LocalizationService.GetLanguages();

            foreach (var lang in languages)
                languageComboBox.Items.Add(lang);

            // Выбираем текущий язык
            languageComboBox.SelectedItem = languages
                .FirstOrDefault(l => l.Code == LocalizationService.CurrentLanguage);
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (languageComboBox.SelectedItem is LanguageItem item)
            {
                Language = item.Code;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
