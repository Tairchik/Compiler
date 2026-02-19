using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Controllers
{
    public class KeyController
    {

        public event EventHandler<string> CapsLockChanged;
        public event EventHandler<string> InputLanguageChanged;

        private bool _lastCapsState = Control.IsKeyLocked(Keys.CapsLock);
        public void Initialize()
        {
            bool currentCapsState = Control.IsKeyLocked(Keys.CapsLock);
            string capsMessage = currentCapsState ? "Клавиша CapsLock нажата" : "Клавиша CapsLock не нажата";
            CapsLockChanged?.Invoke(this, capsMessage);

            var culture = InputLanguage.CurrentInputLanguage.Culture;
            string lang = culture.TwoLetterISOLanguageName.ToUpper();
            string langMessage = lang == "RU" ? "Язык ввода Русский" : "Язык ввода Английский";
            InputLanguageChanged?.Invoke(this, langMessage);
        }

        public void OnKeyDown(Keys key)
        {
            if (key == Keys.CapsLock)
            {
                bool currentState = Control.IsKeyLocked(Keys.CapsLock);
                if (currentState != _lastCapsState)
                {
                    _lastCapsState = currentState;
                    string statusMessage = currentState ? "Клавиша CapsLock нажата" : "Клавиша CapsLock не нажата";
                    CapsLockChanged?.Invoke(this, statusMessage);
                }
            }
            else if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
                if (key == Keys.O)
                {
                    // Открыть файл
                }
                else if (key == Keys.N)
                {
                    // Создать новый файл
                }
            }
        }

        public void OnInputLanguageChanged()
        {
            var culture = InputLanguage.CurrentInputLanguage.Culture;
            string lang = culture.TwoLetterISOLanguageName.ToUpper();

            string res = lang == "RU" ? "Язык ввода Русский" : "Язык ввода Английский";
            InputLanguageChanged?.Invoke(this, res);
        }
    }
}
