using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CompilerGUI
{
    public class LocalizationService
    {
        private static Dictionary<string, Dictionary<string, string>> _languages;
        public static string CurrentLanguage { get; private set; }

        private static string SettingsPath => "appsettings.json";
        private static string LanguagesPath => "languages.json";
        private static string DefaultLanguagesJson => """
        {
          "ru": {
            "File": "Файл",
            "Edit": "Правка",
            "Run": "Пуск",
            "Settings": "Настройки",
            "Exit": "Выход",
            "Create": "Создать",
            "Open": "Открыть",
            "Save": "Сохранить",
            "SaveUs": "Сохранить как",
            "Help": "Справка",
            "Edit": "Правка",
            "Undo": "Отменить",
            "Redo": "Вернуть",
            "Cut": "Вырезать",
            "Copy": "Копировать",
            "Insert": "Вставить",
            "Delete": "Удалить",
            "SelectAll": "Выделить все",
            "Text": "Текст",
            "SettingTheTask": "Постановка задачи",
            "Grammatic": "Грамматика",
            "ClassificationGrammatic": "Классификация грамматики",
            "TheMethodOfAnalysis": "Метод анализа",
            "ATestCase": "Тестовый пример",
            "ListOfLiterature": "Список литературы",
            "TheSourceCodeOfTheProgram": "Исходный код программы",
            "CloseTab": "Закрыть вкладку",
            "Compiler": "Компилятор",
            "Warning": "Предупреждение",
            "Notification": "Уведомление",
            "Error": "Ошибка",
            "Message": "Сообщение",
            "Line": "Строка",
            "Column": "Колонка",
            "FilePath": "Путь к файлу",
            "SaveChangeInFile": "Сохранить изменения в файле?",
            "NotificationSavingFile": "Выберите файл, чтобы сохранить",
            "OpenFileTitle": "Открыть файл",
            "SaveFileTitle": "Сохранить файл",
            "ErrorRead": "Ошибка чтения файла",
            "ErrorSaveMessage": "Ошибка при сохранении файла",
            "NewFile": "Новый файл",
            "Language": "Язык",
            "Cancel": "Отмена"
          },

          "en": {
            "File": "File",
            "Edit": "Edit",
            "Run": "Run",
            "Settings": "Settings",
            "Exit": "Exit",
            "Create": "Create",
            "Open": "Open",
            "Save": "Save",
            "SaveUs": "Save us",
            "Help": "Help",
            "Edit": "Edit",
            "Undo": "Undo",
            "Redo": "Redo",
            "Cut": "Cut",
            "Copy": "Copy",
            "Insert": "Insert",
            "Delete": "Delete",
            "SelectAll": "Select all",
            "Text": "Text",
            "SettingTheTask": "Setting the task",
            "Grammatic": "Grammatic",
            "ClassificationGrammatic": "Classification grammatic",
            "TheMethodOfAnalysis": "The method of analysis",
            "CloseTab": "Close tab",
            "ATestCase": "A test case",
            "ListOfLiterature": "List of literature",
            "TheSourceCodeOfTheProgram": "The source code of the program",
            "Compiler": "Compiler",
            "Warning": "Warning",
            "Notification": "Notification",
            "Error": "Error",
            "Message": "Message",
            "Line": "Line",
            "Column": "Column",
            "FilePath": "File path",
            "SaveChangeInFile": "Save changes in file?",
            "NotificationSavingFile": "Select a file to save",
            "OpenFileTitle": "Open file",
            "SaveFileTitle": "Save file",
            "ErrorRead": "File read error",
            "ErrorSaveMessage": "Error while saving file",
            "NewFile": "New file",
            "Language": "Language",
            "Cancel": "Cancel"
          }
        }
        """;

        static LocalizationService()
        {
            EnsureLanguagesFile();
            EnsureSettingsFile();
            LoadLanguages();
            LoadSettings();
        }

        private static void EnsureLanguagesFile()
        {

            if (!File.Exists(LanguagesPath))
            {
                File.WriteAllText(LanguagesPath, DefaultLanguagesJson);
            }
        }

        private static void EnsureSettingsFile()
        {
            if (!File.Exists(SettingsPath))
            {
                var defaultSettings = new Dictionary<string, string>
                {
                    ["Language"] = "ru"
                };

                File.WriteAllText(SettingsPath,
                    JsonSerializer.Serialize(defaultSettings, new JsonSerializerOptions { WriteIndented = true }));
            }
        }

        private static void LoadLanguages()
        {
            try
            {
                string json = File.ReadAllText(LanguagesPath);
                _languages = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json);
            }
            catch
            {
                // если файл поврежден → восстановить
                File.WriteAllText(LanguagesPath, DefaultLanguagesJson);
                _languages = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(DefaultLanguagesJson);
            }
        }

        private static void LoadSettings()
        {
            try
            {
                var settings = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(SettingsPath));
                CurrentLanguage = settings["Language"];

                if (!_languages.ContainsKey(CurrentLanguage))
                    CurrentLanguage = "ru";
            }
            catch
            {
                CurrentLanguage = "ru";
            }
        }

        public static void ChangeLanguage(string lang)
        {
            if (!_languages.ContainsKey(lang))
                return;

            CurrentLanguage = lang;

            var settings = new Dictionary<string, string>
            {
                ["Language"] = CurrentLanguage
            };

            File.WriteAllText(SettingsPath,
                JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true }));
        }

        public static string Get(string key)
        {
            if (_languages.ContainsKey(CurrentLanguage)) 
                if (_languages[CurrentLanguage].ContainsKey(key))
                    return _languages[CurrentLanguage][key];

            return key; 
        }

        public static List<LanguageItem> GetLanguages()
        {
            return _languages.Keys
                .Select(code => new LanguageItem(code))
                .ToList();
        }
    }
}
