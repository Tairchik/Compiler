using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CompilerGUI.Views
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            InitializeHelpContent();

            // Подписка на событие выбора раздела
            treeView1.AfterSelect += TreeView1_AfterSelect;

            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void InitializeHelpContent()
        {
            treeView1.Nodes.Clear();

            // Корень
            TreeNode root = new TreeNode("Содержание");

            // Раздел: Меню Файл
            TreeNode fileMenu = new TreeNode("Меню Файл");
            fileMenu.Nodes.Add("Создать");
            fileMenu.Nodes.Add("Открыть");
            fileMenu.Nodes.Add("Сохранение (Сохранить/Как)");
            fileMenu.Nodes.Add("Выход");

            // Раздел: Меню Правка
            TreeNode editMenu = new TreeNode("Меню Правка");
            editMenu.Nodes.Add("Отмена и повтор");
            editMenu.Nodes.Add("Работа с текстом (Буфер)");
            editMenu.Nodes.Add("Выделение и удаление");
            editMenu.Nodes.Add("Изменение размера текста");

            // Раздел: Функционал
            TreeNode functions = new TreeNode("Функции и окна");
            functions.Nodes.Add("Область редактирования");
            functions.Nodes.Add("Область результатов");
            functions.Nodes.Add("Команда Пуск");


            root.Nodes.Add(fileMenu);
            root.Nodes.Add(editMenu);
            root.Nodes.Add(functions);

            treeView1.Nodes.Add(root);
            root.ExpandAll(); // Разворачиваем дерево полностью
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Выбираем текст в зависимости от выбранного узла
            switch (e.Node.Text)
            {
                // ФАЙЛ
                case "Создать":
                    ShowHelp("Создать (Ctrl+N)",
                        "Очищает область редактирования для создания нового документа. \n\n" +
                        "Внимание: Если текущий текст был изменен, программа предложит сохранить изменения перед очисткой.");
                    break;
                case "Открыть":
                    ShowHelp("Открыть (Ctrl+O)",
                        "Вызывает стандартное диалоговое окно для выбора и загрузки текстового файла в редактор.");
                    break;
                case "Сохранение (Сохранить/Как)":
                    ShowHelp("Сохранить (Ctrl+S)",
                        "Команда 'Сохранить' записывает изменения в текущий файл. \n\n" +
                        "Команда 'Сохранить как' позволяет выбрать новое имя файла или местоположение.");
                    break;
                case "Выход":
                    ShowHelp("Выход (Alt+F4)",
                        "Завершает работу приложения. При наличии несохраненных правок выводится запрос на сохранение.");
                    break;

                // ПРАВКА
                case "Отмена и повтор":
                    ShowHelp("Отмена (Ctrl+Z) и Повтор (Ctrl+Y)",
                        "Позволяет перемещаться по истории изменений текста назад и вперед.");
                    break;
                case "Работа с текстом (Буфер)":
                    ShowHelp("Буфер обмена",
                        "- Вырезать (Ctrl+X): Перемещает текст в буфер.\n" +
                        "- Копировать (Ctrl+C): Копирует текст в буфер.\n" +
                        "- Вставить (Ctrl+V): Вставляет текст из буфера.");
                    break;
                case "Выделение и удаление":
                    ShowHelp("Выделение и удаление",
                        "- Удалить (Del): Удаляет выделенный фрагмент.\n" +
                        "- Выделить все (Ctrl+A): Выделяет весь текст в окне редактора.");
                    break;
                case "Изменение размера текста":
                    ShowHelp("Изменение размера текста",
                        "- Через соответсвующие кнопки (лупа со знаком + и лупа со знаком минус)\n" +
                        "- При помощи сочетания клавиш для увеличения текста: Ctrl+<+> (Ctrl+MOUSEUP)\n"+
                        "для уменьшения: Ctrl+<-> (Ctrl+MOUSEDOWN)");
                    break;

                // ДОПОЛНИТЕЛЬНО
                case "Область редактирования":
                    ShowHelp("Редактор текста",
                        "Основное окно для работы. Здесь реализована подсветка синтаксиса и базовая навигация.");
                    break;
                case "Область результатов":
                    ShowHelp("Окно вывода",
                        "Служит для отображения сообщений анализатора. При щелчке по сообщению об ошибке, курсор в редакторе автоматически переходит к проблемному месту.");
                    break;
                case "Команда Пуск":
                    ShowHelp("Пуск (Анализатор)",
                        "Запускает языковой процессор для анализа введенного текста. На текущем этапе функционал находится в разработке.");
                    break;

                default:
                    richTextBox1.Text = "Выберите раздел для просмотра справки.";
                    break;
            }
        }

        private void ShowHelp(string title, string content)
        {
            richTextBox1.Clear();

            // Форматируем заголовок
            richTextBox1.SelectionFont = new Font("Segoe UI", 12, FontStyle.Bold);
            richTextBox1.SelectionColor = Color.DarkBlue;
            richTextBox1.AppendText(title + Environment.NewLine + Environment.NewLine);

            // Форматируем основной текст
            richTextBox1.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.AppendText(content);
        }
    }
}