using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CompilerGUI.HelpClass
{
    public class LocalizationService
    {
        private static Dictionary<string, Dictionary<string, string>> _languages;
        public static string CurrentLanguage { get; private set; }
        static public bool isInit = true;
        private static string SettingsPath => Path.Combine(appDataPath, "appsettings.json");
        private static string LanguagesPath => Path.Combine(appDataPath, "languages.json");
        private static string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CompilierGUI");
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
            "Menu": "Меню",
            "Insert": "Вставить",
            "Delete": "Удалить",
            "SelectAll": "Выделить все",
            "CallingHelp": "Вызов справки",
            "AboutProgram": "О программе",
            "EnlargeText": "Увеличить текст",
            "ReduceText": "Уменьшить текст",  
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
            "Cancel": "Отмена",
            "InputLanguageRu": "Язык ввода Русский", 
            "InputLanguageEn": "Язык ввода Английский",
            "CapsLockPressed": "Клавиша CapsLock нажата",
            "CapsLockNotPressed": "Клавиша CapsLock не нажата",
            "Ready": "Готово",
            "RunStatus": "Запущено",
            "Load": "Загрузка",
            "Wait": "Ожидание",
            "Assembling": "Сборка",
            "Help_Contents": "Содержание",
            "Help_MenuFile": "Меню Файл",
            "Help_MenuEdit": "Меню Правка",
            "Help_FunctionsWindows": "Функции и окна",
            "Help_SaveTitle": "Сохранение (Сохранить/Как)",
            "Help_UndoRedo": "Отмена и повтор",
            "Help_Clipboard": "Работа с текстом (Буфер)",
            "Help_SelectionDelete": "Выделение и удаление",
            "Help_TextSize": "Изменение размера текста",
            "Help_EditArea": "Область редактирования",
            "Help_ResultsArea": "Область результатов",
            "Help_RunCommand": "Команда Пуск",
            "Help_Create_Title": "Создать (Ctrl+N)",
            "Help_Open_Title": "Открыть (Ctrl+O)",
            "Help_Save_Short_Title": "Сохранить (Ctrl+S)",
            "Help_Exit_Title": "Выход (Alt+F4)",
            "Help_UndoRedo_Title": "Отмена (Ctrl+Z) и Повтор (Ctrl+Y)",
            "Help_Clipboard_Title": "Буфер обмена",
            "Help_SelectionDelete_Title": "Выделение и удаление",
            "Help_TextSize_Title": "Изменение размера текста",
            "Help_Editor_Title": "Редактор текста",
            "Help_Output_Title": "Окно вывода",
            "Help_Run_Title": "Пуск (Анализатор)",
            "Help_Create_Content": "Очищает область редактирования для создания нового документа.\n\nВнимание: Если текущий текст был изменен, программа предложит сохранить изменения перед очисткой.",
            "Help_Open_Content": "Вызывает стандартное диалоговое окно для выбора и загрузки текстового файла в редактор.",
            "Help_Save_Content": "Команда 'Сохранить' записывает изменения в текущий файл.\n\nКоманда 'Сохранить как' позволяет выбрать новое имя файла или местоположение.",
            "Help_Exit_Content": "Завершает работу приложения. При наличии несохраненных правок выводится запрос на сохранение.",
            "Help_UndoRedo_Content": "Позволяет перемещаться по истории изменений текста назад и вперед.",
            "Help_Clipboard_Content": "- Вырезать (Ctrl+X): Перемещает текст в буфер.\n- Копировать (Ctrl+C): Копирует текст в буфер.\n- Вставить (Ctrl+V): Вставляет текст из буфера.",
            "Help_SelectionDelete_Content": "- Удалить (Del): Удаляет выделенный фрагмент.\n- Выделить все (Ctrl+A): Выделяет весь текст в окне редактора.",
            "Help_TextSize_Content": "- Через соответствующие кнопки (лупа со знаком + и лупа со знаком минус)\n- При помощи сочетания клавиш для увеличения текста: Ctrl+<+> (Ctrl+MOUSEUP)\nдля уменьшения: Ctrl+<-> (Ctrl+MOUSEDOWN)",
            "Help_Editor_Content": "Основное окно для работы. Здесь реализована подсветка синтаксиса и базовая навигация.",
            "Help_Output_Content": "Служит для отображения сообщений анализатора. При щелчке по сообщению об ошибке, курсор в редакторе автоматически переходит к проблемному месту.",
            "Help_Run_Content": "Запускает языковой процессор для анализа введенного текста. На текущем этапе функционал находится в разработке.",
            "Help_Default_Content": "Выберите раздел для просмотра справки.",
            "Guide": "Справочник"
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
            "Menu": "Menu",
            "Insert": "Insert",
            "Delete": "Delete",
            "SelectAll": "Select all",
            "Text": "Text",
            "CallingHelp": "Calling Help",
            "EnlargeText": "Enlarge text",
            "ReduceText": "Reduce text",
            "AboutProgram": "About program",
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
            "Cancel": "Cancel",
            "InputLanguageRu": "Input language Russia", 
            "InputLanguageEn": "Input language English",
            "CapsLockPressed": "CapsLock key is pressed",
            "CapsLockNotPressed": "CapsLock key is not pressed",
            "Ready": "Ready",
            "RunStatus": "Run",
            "Load": "Load",
            "Wait": "Wait",
            "Assembling": "Assembling",
            "Help_Contents": "Contents",
            "Help_MenuFile": "File Menu",
            "Help_MenuEdit": "Edit Menu",
            "Help_FunctionsWindows": "Functions and Windows",
            "Help_SaveTitle": "Save (Save/Save As)",
            "Help_UndoRedo": "Undo and Redo",
            "Help_Clipboard": "Working with Text (Clipboard)",
            "Help_SelectionDelete": "Selection and Deletion",
            "Help_TextSize": "Changing Text Size",
            "Help_EditArea": "Editing Area",
            "Help_ResultsArea": "Results Area",
            "Help_RunCommand": "Run Command",
            "Help_Create_Title": "Create (Ctrl+N)",
            "Help_Open_Title": "Open (Ctrl+O)",
            "Help_Save_Short_Title": "Save (Ctrl+S)",
            "Help_Exit_Title": "Exit (Alt+F4)",
            "Help_UndoRedo_Title": "Undo (Ctrl+Z) and Redo (Ctrl+Y)",
            "Help_Clipboard_Title": "Clipboard",
            "Help_SelectionDelete_Title": "Selection and Deletion",
            "Help_TextSize_Title": "Changing Text Size",
            "Help_Editor_Title": "Text Editor",
            "Help_Output_Title": "Output Window",
            "Help_Run_Title": "Run (Analyzer)",
            "Help_Create_Content": "Clears the editing area to create a new document.\n\nNote: If the current text has been modified, the program will prompt you to save changes before clearing.",
            "Help_Open_Content": "Opens the standard dialog box to select and load a text file into the editor.",
            "Help_Save_Content": "The 'Save' command writes changes to the current file.\n\nThe 'Save As' command allows you to choose a new file name or location.",
            "Help_Exit_Content": "Exits the application. If there are unsaved changes, a prompt to save will be displayed.",
            "Help_UndoRedo_Content": "Allows navigating backward and forward through the text change history.",
            "Help_Clipboard_Content": "- Cut (Ctrl+X): Moves text to the clipboard.\n- Copy (Ctrl+C): Copies text to the clipboard.\n- Paste (Ctrl+V): Inserts text from the clipboard.",
            "Help_SelectionDelete_Content": "- Delete (Del): Deletes the selected fragment.\n- Select All (Ctrl+A): Selects all text in the editor window.",
            "Help_TextSize_Content": "- Via corresponding buttons (magnifying glass with + and - signs)\n- Using keyboard shortcuts to increase text: Ctrl+<+> (Ctrl+MOUSE WHEEL UP)\nto decrease: Ctrl+<-> (Ctrl+MOUSE WHEEL DOWN)",
            "Help_Editor_Content": "Main window for work. Syntax highlighting and basic navigation are implemented here.",
            "Help_Output_Content": "Used to display analyzer messages. When clicking on an error message, the cursor in the editor automatically jumps to the problematic location.",
            "Help_Run_Content": "Launches the language processor to analyze the entered text. Currently, this functionality is under development.",
            "Help_Default_Content": "Select a section to view help.",
            "Guide": "Guide"
          }
        }
        """;

        static LocalizationService()
        {
            if (isInit)
            {
                CrearDirAppData();
                EnsureLanguagesFile();
                EnsureSettingsFile();
                LoadLanguages();
                LoadSettings();
                isInit = false;
            }
        }
        private static void CrearDirAppData() 
        {
            if (!Directory.Exists(appDataPath)) Directory.CreateDirectory(appDataPath);
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
