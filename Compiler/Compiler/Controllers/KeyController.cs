using CompilerGUI.HelpClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Controllers
{
    public class KeyController
    {

        public event EventHandler<string>? CapsLockChanged;
        public event EventHandler<string>? InputLanguageChanged;
        public event Action? CtrlOPressed;
        public event Action? CtrlNPressed;
        public event Action? CtrlSPressed;
        public event Action? CtrlShiftSPressed;
        public event Action? CtrlHPressed;


        private bool _lastCapsState = Control.IsKeyLocked(Keys.CapsLock);
        public void Initialize()
        {
            bool currentCapsState = Control.IsKeyLocked(Keys.CapsLock);
            string capsMessage = currentCapsState ? LocalizationService.Get("CapsLockPressed") : LocalizationService.Get("CapsLockNotPressed");
            CapsLockChanged?.Invoke(this, capsMessage);

            var culture = InputLanguage.CurrentInputLanguage.Culture;
            string lang = culture.TwoLetterISOLanguageName.ToUpper();
            string langMessage = lang == "RU" ? LocalizationService.Get("InputLanguageRu") : LocalizationService.Get("InputLanguageEn");
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
                    string statusMessage = currentState ? LocalizationService.Get("CapsLockPressed") : LocalizationService.Get("CapsLockNotPressed");
                    CapsLockChanged?.Invoke(this, statusMessage);
                }
            }
            else if (Control.ModifierKeys.HasFlag(Keys.Control) && Control.ModifierKeys.HasFlag(Keys.Shift))
            {
                if (key == Keys.S)
                {
                    CtrlShiftSPressed?.Invoke();
                }
            }
            else if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
                if (key == Keys.O)
                {
                    CtrlOPressed?.Invoke();
                }
                else if (key == Keys.N)
                {
                    CtrlNPressed?.Invoke();
                }
                else if (key == Keys.S)
                {
                    CtrlSPressed?.Invoke();
                }
                else if (key == Keys.N)
                {
                    CtrlNPressed?.Invoke();
                }
                else if (key == Keys.H) 
                {
                    CtrlHPressed?.Invoke();
                }
            }
        }

        public void OnInputLanguageChanged()
        {
            var culture = InputLanguage.CurrentInputLanguage.Culture;
            string lang = culture.TwoLetterISOLanguageName.ToUpper();

            string res = lang == "RU" ? LocalizationService.Get("InputLanguageRu"): LocalizationService.Get("InputLanguageEn");
            InputLanguageChanged?.Invoke(this, res);
        }
    }
}
