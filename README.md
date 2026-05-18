# Автор
Бикмухаметов Таир Олегович, АВТ-314, НГТУ
# Оглавление 
- [Лабораторная работа №1](#лабораторная-работа-1-разработка-пользовательского-интерфейса-gui-для-языкового-процессора)
- [Лабораторная работа №2](#лабораторная-работа-2-разработка-лексического-анализатора-сканера)
- [Лабораторная работа №3](#лабораторная-работа-3-разработка-синтаксического-анализатора-парсера)
- [Лабораторная работа №4](#лабораторная-работа-4-реализация-алгоритма-поиска-подстрок-с-помощью-регулярных-выражений)
- [Лабораторная работа №5](#лабораторная-работа-5-построение-ast-и-проверка-контекстно-зависимых-условий)
- [Лабораторная работа №6](#лабораторная-работа-6-создание-внутренней-формы-представления-программы)
- [Лабораторная работа №7](#лабораторная-работа-7-анализ-и-преобразование-кода-с-использованием-clang-и-llvm)
# Лабораторная работа 1. Разработка пользовательского интерфейса (GUI) для языкового процессора
### Цель работы
Создание кроссплатформенного графического интерфейса (GUI) для языкового процессора в виде специализированного текстового редактора.

### Описание проекта
Разработка компилятора с графическим интерфейсом с обязательным функционалом интерфейса:
- Основное меню программы, в который входит такой функционал:
  * "Файл": Создание, открытие, сохранение, сохранение как, выход (с подтверждением сохранения изменений).
  * "Правка": Стандартные операции с текстом: отмена/возврат, вырезание, копирование, вставка, удаление, выделение всего текста.
  * "Справка": Вызов справочной системы (на данном этапе – описание реализованных функций) и окна "О программе".
  * "Текст" (в будущем): Постановка задачи, грамматика, классификация грамматики, иетод анализа, тестовый пример, список литературы, исходный код программы
- Панель инструментов с кнопками для быстрого доступа к часто используемым функциям.
- Область ввода/редактирования текста (текстовый редактор).
- Область отображения результатов работы языкового процессора (только для вывода, без возможности редактирования).

Дополнительный функционал:
- [x] Страничное отображение файлов и области вывода информации.
- [x] Отображение ошибок ввиде таблицы.
- [x] Увеличение размера текста по кнопкам в интерактивном меню и по сочетани клавиш: ctrl + MOUSEUP или ctrl + "+" для увелечения текста и ctrl + MOUSEDOWN или ctrl + "-" для уменьшения текста.
- [x] Нижнее меню отображения текущего состояния программы, выбранной раскладки клавиатуры и контроль нажатия CAPSLOCK.
- [x] Локализация: выбор языка (русский, английский), возможность добавлять свой перевод в общий json файл (language.json).
- [x] Весь функционал основного меню по сочетанию клавиш. Сtrl + O, Ctrl + N и тд. Сочетания клавиш отображаны в меню.
- [x] Нумерация строк в окне редактирования текста и подсветка выбранной строки.
- [x] Открытие файла(-ов) при перетаскивании иконки в окно программы.

### Используемые технологии
**Язык программирования**: С# версии .NET 8  
**Фреймворк**: Windows Forms  
**Среда разработки**: Microsoft Visual Studio 2026, версии 18.3.1, издание Community  

### Инструкция по сборке и запуску
- Запуск CompilerGUI.exe файла

### Руководство пользователя
Общий интерфейс программы:
<img width="1075" height="562" alt="image" src="https://github.com/user-attachments/assets/268aa946-7662-469c-97eb-c06abf51ba82" />
Сверху располагается основное меню с такими пунктами и подпунктами, как:
- Файл
  - Создать или Ctrl + N (создает вкладку, в которой располагается область ввода и вывода текста)
  - Открыть или Ctrl + O (создает вкладку с содержимым файла)
  - Сохранить или Ctrl + S (сохранить текст из области ввода в существующий путь, если он есть, иначе предложит сохранить по новому пути)
  - Сохранить как или Ctrl + Shift + S (сохранить текст из области ввода по новому пути)
  - Выход или Alt + F4 (выйти из программы)
- Правка
  - Отменить или Ctrl + Z (отменяет введенный текст в области ввода)
  - Вернуть или Ctrl + Y (возвращает отмененный текст в области ввода)
  - Вырезать или Ctrl + X (скопировать и удалить выделенный текст в области ввода)
  - Копировать или Ctrl + C (скопировать выделенный текст из области ввода в буфер обмена)
  - Вставить или Ctrl + V (вставить в область ввода текст из буфера обмена)
  - Удалить или Del (удалить выделенный текст из области ввода)
  - Выделить всё или Ctrl + A (выделяет весь текст из области ввода)
- Справка
  - Вызов справки или Ctrl + H (открывает окно "Справочник" с пояснением функционала программы (см. ниже))
  - О программе (открывает ссылку на данный Readme файл)
- Пуск (запуск программы)
- Настройки (открывает окно настроек для выбора языка (см. ниже))

Нижие располагается панель инструментов, дублирующая функционал основного меню (по порядку):  
<img width="1341" height="56" alt="image" src="https://github.com/user-attachments/assets/fae2edb2-c3f8-4717-a6b7-fa670907d765" />
- Отменить
- Вернуть
- Создать
- Открыть
- Сохранить
- Сохранить как
- Копировать
- Вырезать
- Выделить всё
- Увеличить текст или сочетаниями клавиш: Ctrl + "+" или Ctrl + MOUSEUP (колесо мыши вверх) (увеличивает текст для области ввода и вывода)
- Уменьшить текст или сочетаниями клавиш: Ctrl + "-" или Ctrl + MOUSEDOWN (колесо мыши вниз) (уменьшает текст для области ввода и вывода)
- Закрыть вкладку (закрывает текущую вкладку)
- Пуск
- Вызов справки
- О программе

Область ввода/вывода (вкладки):
<img width="1075" height="562" alt="image" src="https://github.com/user-attachments/assets/2289afaa-2118-4b2e-8553-b40dd054815a" />
- Область ввода располагается выше
- Область вывода располагается ниже, под областью ввода
- Каждая вкладка соответствует созданному или открытому файлу
- Для переключения между вкладками можно использовать сочетания клавиш: Ctrl + Tab (вперед) и Ctrl + Shift + Tab (назад) или при помощи мыши  

Таблица с ошибками (на данный момент используется заглушка)
<img width="1070" height="124" alt="image" src="https://github.com/user-attachments/assets/2b1c3c53-68fc-4d15-8c0e-5508d50e7dcb" />
- В таблице указываются ошибки по коду в области ввода

Drag and drop (тащи и вставляй)

<img width="610" height="93" alt="image" src="https://github.com/user-attachments/assets/e593e093-f037-4ccc-ab26-a0bbb078eb29" />
<img width="1075" height="562" alt="image" src="https://github.com/user-attachments/assets/4197916b-b021-4c86-898e-3b735578109c" />

- Файлы можно открыть, перетащив их в область окна
Строка состояние
<img width="1069" height="21" alt="image" src="https://github.com/user-attachments/assets/eeb582c5-262a-4830-a592-58e044294e49" />

- Отображает текущую информацию о состоянии работы приложения:
  - Состояние компилируемой программы (Готово - программа ничего не выполняет, ожидание действия пользователя; Ожидание - анализ, компиляция, сборка программы; Выполнение - программа выполняется)
  - Нажат ли CapsLock
  - Текущая раскладка клавиатуры
 
### Ограничения.
ОС: Windows 10 и новее 64-х битная.

# Лабораторная работа 2. Разработка лексического анализатора (сканера)
### Цель работы.
Изучить назначение и принципы работы лексического анализатора в структуре компилятора. 
Спроектировать алгоритм (диаграмму состояний) и выполнить программную реализацию сканера для выделения лексем из входного текста. 
Интегрировать разработанный модуль в ранее созданный графический интерфейс языкового процессора.
### Постановка задачи
1) Сделать диаграмму состояний
2) Разработать лексер, который будет возвращать такие свойства:
   * Условный код (числовой идентификатор типа лексемы).
   * Тип лексемы (текстовое описание).
   * Лексема (выделенная подстрока).
   * Местоположение (номер строки, начальная и конечная позиция символов).
3) Интегрировать его в приложение ввиде таблицы
4) При двойнном нажатии по строке таблицы, указатель мыши должен переместиться на соответствущую позицию в редакторе и должен выделиться выбранный токен
5) Разрабоать собственную грамматику и грамматику под flex&bison и сравнить их
6) Внедрить flex&bison в основную программу
### Вариант задания
№ 18. Объявление списка с инициализацией на языке Python<br>
Пример: List = [1, 2, 3.2, 'str'];
### Диаграмма состояний
<p align="center">
 <img src="https://raw.githubusercontent.com/Tairchik/Compiler/5b0269800ecab4058a75d08bae36579bde442ccd/diag.png"></img>
</p><br>

### Тестовые примеры
1. Корреткный ввод:<br>
 <img src="https://raw.githubusercontent.com/Tairchik/Compiler/9cb200c8427fa04e56f21bb86e0bc43a8554aea3/test_2_1.png">
2. Некорректный символ:<br>
 <img src="https://raw.githubusercontent.com/Tairchik/Compiler/9cb200c8427fa04e56f21bb86e0bc43a8554aea3/test_1_1.png">
3. Многострочная строка:<br>
 <img src="https://raw.githubusercontent.com/Tairchik/Compiler/9cb200c8427fa04e56f21bb86e0bc43a8554aea3/test3_1.png">

## Дополнительное задание
### Разработка грамматики
1) Разработанная мной:<br>
G\[Z] = {Vt, Vn, Z, P}<br>
Vt = {\[, \], True, False, пробел, +, -, ', Б, Ц, А, =, _, ","}, где:
- Б - латинские буквы
- Ц - цифры от 0 до 9
- A - ASCII символы<br>
Vn = {\<перемен\>, \<ЦБЗ\>, \<ВБЗ\>, \<Ц0\>, \<булевое\>, \<знак\>, \<строка\>, \<элементы\>, \<константа\>, \<символ\>}, где:
- ЦБЗ - целое без знака
- ВБЗ - вещественное без знака
- перемен - переменная<br>
P = {<br>
Z -\> \<перемен\> = \[\<элементы\>\];<br>
\<перемен\> -\> (\_\|Б)(Б\|Ц\|\_)*<br>
\<элементы\> -\> \<константа\>\|\<элементы\>, \<константа\><br>
\<константа\> -\> \<ЦБЗ\>\|\<ВБЗ\>\|\<знак\>\<ЦБЗ\>\|\<знак\>\<ВБЗ\>\|\<строка\>\|\<булевое\><br>
\<знак\> -\> + | -<br>
\<ЦБЗ\> -\> \<Ц0\>\<Ц\>\*|0<br> 
\<ВБЗ> -\> <ЦБЗ>.<Ц>+<br>
\<Ц0\> -\> 1|2|3|4|5|6|7|8|9<br>
\<строка\> -\> '\<символ\>\*'<br>
\<символ\> -\> A \^'<br>
\<булевое\> -\> True | False<br>
}
2) Переписанная под Flex&Bison:<br>
G\[Z] = {Vt, Vn, Z, P}<br>
Vt = {DIGIT, DIGIT0, LETTER, ID, INT, FLOAT, STRING, "True", "False", "\[", "\]", "=", ",", ";", "+", "-", PASS, ID}<br>
LETTER = \[a-zA-Z_\]<br>
ID = LETTER | (LETTER|DIGIT)\*<br>
INT = {DIGIT0}{DIGIT}\*|0<br>
FLOAT = INT.DIGIT+<br>
STRING = ' ASCII\* ^''<br>
PASS = \[\\n\\t\\r\]<br>
Vn = {\<statment\>, \<list_expr\>, \<elements\>, \<value\>, \<sign\>, \<boolean\>}<br>
P = {
Z -\> | \<statment\><br>
\<statment\> -\> ID = \<list_expr\>; | ;<br>
\<list_expr\> -\> \[ \] | \[\<elements\>\]<br>
\<elements\> -\> \<value\>\|\<elements\>, \<value\><br>
\<value\> -\> INT | \<sign\>INT | FLOAT | \<sign\>FLOAT | STRING | \<boolean\><br>
\<boolean\> -\> True | False<br>
\<sign\> -\> + | -<br>
}

### Тесты парсера и лексера
1\. Пример корректных данных<br>
<img src="https://raw.githubusercontent.com/Tairchik/Compiler/02c78773d03b4207c2a224be3c997f4754e09cf9/parser_corr.png">
2\. Пример ошибочных данных<br>
<img src="https://raw.githubusercontent.com/Tairchik/Compiler/02c78773d03b4207c2a224be3c997f4754e09cf9/parser_error.png">

# Лабораторная работа 3. Разработка синтаксического анализатора (парсера)
### Цель работы
Изучить назначение и принципы работы синтаксического анализатора в структуре компилятора. Спроектировать грамматику, построить соответствующую схему метода анализа грамматики и выполнить программную реализацию парсера с нейтрализацией синтаксических ошибок методом Айронса. Интегрировать разработанный модуль в ранее созданный графический интерфейс языкового процессора.

### Постановка задачи.
Разработать синтаксический анализатор (парсер) в соответствии с индивидуальным вариантом курсовой (расчетно-графической) работы, интегрировать его в приложение из лабораторной работы №1 и обеспечить наглядный вывод результатов анализа.<br><br>
Требования к разработке парсера:
- Разработать грамматику для заданной синтаксической конструкции.
- Построить схему метода анализа на основе разработанной грамматики.
- Выполнить программную реализацию алгоритма работы синтаксического анализа.
- Реализовать алгоритм нейтрализации синтаксических ошибок методом Айронса.
- Входные данные — строка (текст программного кода) из области редактирования.<br><br>
Выходные данные:
- При успешном анализе корректной строки — сообщение об отсутствии ошибок.
- При обнаружении ошибок — таблица с описанием каждой ошибки.<br><br>
Требования к интеграции и интерфейсу:
- Встроить парсер в ранее разработанный интерфейс (ЛР1) и связать его с кнопкой «Пуск» (или отдельной кнопкой для синтаксического анализа).
- Окно вывода результатов должно содержать таблицу ошибок со следующими столбцами:
- Неверный фрагмент (символ или фрагмент, вызвавший ошибку).
- Местоположение (номер строки, позиция символа).
- Описание ошибки (опционально).
- В окне вывода также отображается общее количество найденных ошибок.
- Реализовать навигацию по ошибкам: при щелчке на строке таблицы курсор в области редактирования должен устанавливаться на позицию ошибочного фрагмента. <br>
### Вариант задания 
Номер варианта: 18. Объявление списка с инициализацией на языке Python <br>
Примеры:
1) a = [];
2) b = [1.2];
3) c = [1, -2, 'string', True, False, +12.2, 0]

### Разработка грамматики
G[Z] = {Vt, Vn, Z, P}<br>
Vt = {\[, \], +, -, ', A...Z, a...z, 0...9, =, \_, \",", ascii}<br>
Vn = {Z,\<id\>, \<start_list\>, \<end_list\>, \<const_int\>, \<const_float\>, \<float\>, \<end\>, \<sign>, \<string>, \<body_list>, \<elements>, \<const>, \<letter>, \<digit>, \<digit0>, \<zero>}<br>
P = {<br>
Z -> \<letter>\<id><br>
Z -> '\_'\<id><br>
\<id> -> '=' \<start_list><br>
\<id> -> \<letter>\<id><br>
\<id> -> '\_' \<id><br>
\<id> -> \<digit>\<id><br>
\<start_list> -> '\[' \<elements><br>
\<elements> -> \<digit0>\<const_int><br>
\<elements> -> '''\<string><br>
\<elements> -> '0'\<zero><br>
\<elements> -> '+' \<sign><br>
\<elements> -> '-' \<sign>v
\<elements> -> 'True' \<const><br>
\<elements> -> 'False' \<const><br>
\<elements> -> '\]' \<end_list><br>
\<string> -> '''\<const><br>
\<string> -> \<ascii>\<string><br>
\<zero> -> '.'\<float><br>
\<zero> -> ']' \<end_list><br>
\<sign> -> '0' \<zero><br>
\<sign> -> \<digit0>\<const_int><br>
\<const_int> -> '.'\<float><br>
\<const_int> -> ']'\<end_list><br>
\<const_int> -> ','\<body_list><br>
\<const_int> ->  \<digit>\<const_int><br>
\<float> -> \<digit> \<const_float><br>
\<const_float> -> ','\<body_list><br>
\<const_float> -> ']'\<end_list><br>
\<const_float> -> \<digit>\<end_list><br>
\<const> -> ','\<body_list><br>
\<const> -> ']'\<end_list><br>
\<body_list> -> \<digit0>\<const_int><br>
\<body_list> -> '''\<string><br>
\<body_list> -> '0'\<zero><br>
\<body_list> -> '+'\<sign><br>
\<body_list> -> '-'\<sign><br>
\<body_list> -> 'True'\<const><br>
\<body_list> -> 'False'\<const><br>
\<end_list> -> ';' \<end><br>
\<digit> -> '0' |'1' |'2' |'3' |'4' |'5' |'6' |'7' |'8' |'9'<br>
\<digit0> ->'1' |'2' |'3' |'4' |'5' |'6' |'7' |'8' |'9' <br>
\<letter> -> 'A' | 'B' ... | 'Z' | 'a' | 'b' ... | 'z'<br>
}<br>
### Классификация грамматики (по Хомскому).
Грамматика является автоматной, третий тип
### Метод анализа
Граф автоматной грамматики <br>
<img width="967" height="790" alt="image" src="https://github.com/user-attachments/assets/64c1e499-8c3d-49e1-a829-30158acc9ffb" />
### Диагностика и нейтрализация синтаксических ошибок.
Метод Айронса. <br>
Разрабатываемый синтаксический анализатор построен на базе автоматной грамматики. При нахождении лексемы, которая не соответствует грамматике предлагается свести алгоритм нейтрализации к последовательному удалению следующего символа во входной цепочке до тех пор, пока следующий символ не окажется одним из допустимых в данный момент разбора.
### Тесты
<img width="1920" height="1020" alt="image" src="https://github.com/user-attachments/assets/d70a223e-dacf-445d-86d4-70368c9a253d" />
<img width="1920" height="1020" alt="image" src="https://github.com/user-attachments/assets/2571004a-cc3f-4aae-b0c4-909ad591559c" />
<img width="1920" height="1020" alt="image" src="https://github.com/user-attachments/assets/6d0b4aaa-b000-4cdd-9923-e5482d007d10" />
<img width="1920" height="1020" alt="image" src="https://github.com/user-attachments/assets/58384bd2-ee5b-44ea-b95b-0ab184517bb0" />

# Лабораторная работа 4. Реализация алгоритма поиска подстрок с помощью регулярных выражений
### Цель
Изучить теоретические основы регулярных выражений и их применение для поиска и извлечения подстрок из текста. Освоить практические навыки использования библиотечных средств работы с регулярными выражениями, а также интеграцию алгоритмов поиска в графический интерфейс приложения.

### Постановка задачи
Разработать модуль поиска подстрок с использованием регулярных выражений, интегрировать его в существующее приложение (текстовый редактор) и обеспечить наглядный вывод результатов.<br>
Студент получает индивидуальный вариант, содержащий 3 задачи на поиск подстрок определенных форматов.
### Задание 1
Построить РВ, описывающее пароль (набор строчных и прописных русских букв, цифр и символов).
### Регулярное выражение:
\[А-Яа-яЁё0-9!@#$№%^&*()_\-+=\[{\]};:'"",.<>/?\\|`~]+ <br>
Где:
- "\[" открытие набора символов
- "\]" зыкретие набора символов
- "+" 1 и более символов из набора
- "А-Яа-яЁё" все буквы русского алфавита
- "0-9" все цифры
- "!@#$№%^&*()_\\-+=" спецсимволы
### Верные примеры
- Пароль123
- 2024@#$%^&*Тест_Пароль
- 12345!!!
### Неверные примеры
- Qweytwd
- (пустая строка)
### Тестирование программы
<img width="1919" height="1030" alt="image" src="https://github.com/user-attachments/assets/a0971ec1-cb88-42f6-9662-1065cc405457"><br>
### Задание 2
Построить РВ, описывающее имя пользователя (набор букв и цифр длиной от 4 до 20 символов, первым символом должен быть @).
### Регулярное выражение:
\@\[A-Za-z0-9\]\{4,20\}
<br> Где:
- "\[" открытие набора символов
- "\]" зыкретие набора символов
- "0-9"  все цифры
- "A-Za-z" все буквы английского алфавита
- "\{4,20\}" ограничение по количеству сииволов из набора от 4 до 20 включительно
- "@" первый символ выражения 
### Верные примеры
- @user123
- @user
- @2026
### Неверные примеры
- user
- @abc
- @123
### Тестирование программы
<img width="1918" height="1030" alt="image" src="https://github.com/user-attachments/assets/f2d0a5c8-0d44-4723-8f04-37aaeeb4d503"><br>
### Дополнительное задание. Автомат:
<img width="761" height="462" alt="Снимок экрана 2026-04-05 190126" src="https://github.com/user-attachments/assets/c6a45da8-5ebb-4431-afef-d868952dde5b"><br>
### Тестирование алгоритма
<img width="1919" height="1018" alt="image" src="https://github.com/user-attachments/assets/0ae4547b-1375-4e2e-9d53-8a10635e6270"><br>
### Задание 3
Построить РВ для поиска номеров социального страхования Великобритании (NIN), учесть корректные значения на месте.
### Регулярное выражение:
(?!BG|GB|NK|KN|TN|NT|ZZ)\[ABCEGHJ-PR-TW-Z\]\[ABCEGHJ-NPR-TW-Z\]\\d{6}\[A-D\]?
<br> Где:
- "\[" открытие набора символов
- "\]" зыкретие набора символов
- "(?!...)" негативная проверка (запрещённые комбинации)
- "BG|GB|NK|KN|TN|NT|ZZ" запрещённые префиксы
- "\[ABCEGHJ-PR-TW-Z\]" первая буква
- "\[ABCEGHJ-NPR-TW-Z\]" вторая буква
- "\\d{6}" ровно 6 цифр
- "\[A-D\]"? — необязательная буква в конце
### Верные примеры
- AB123456C
- JK654321
- MN123456A
### Неверные примеры
- BG123456A (запрещённый префикс)
- A123456 (не хватает буквы)
- AB12345 (мало цифр)
- AB123456E (недопустимая последняя буква)
### Тестирование программы
<img width="1919" height="1030" alt="image" src="https://github.com/user-attachments/assets/159e5245-3a70-4839-b0ab-5cf6587b5dbf"><br>

# Лабораторная работа 5. Построение AST и проверка контекстно-зависимых условий
### Цель
Изучить назначение и принципы работы семантического анализатора в структуре компилятора. Освоить методы построения абстрактного синтаксического дерева (AST) и проверки контекстно-зависимых условий (семантических правил) для заданной синтаксической конструкции.

### Постановка задачи
Развить ранее созданный синтаксический анализатор (парсер) до семантического: построить абстрактное синтаксическое дерево (AST) и реализовать проверку контекстно-зависимых условий в соответствии с индивидуальным вариантом курсовой работы.

### Вариант
Тема: Инициализация списков в Python.<br>
Пример корректных строк:
- a =  \[1, 2, 3];
- my_list = \['hello', 2.05, True];
- empty_list = \[];

### Контекстно-зависимые условия
Условие | Описание | Пример ошибки | Ожидаемое сообщение
--- | --- | --- | ---
Уникальность имен | Повторное объявление идентификатора в пределах одной программы запрещено. | a = \[1]; a = \[2]; | СЕМАНТИКА: Идентификатор 'a' уже объявлен ранее
Допустимые значения | Проверка вещественных чисел (Float) на соответствие диапазону double. | x = \[1.8e308]; | СЕМАНТИКА: Значение float выходит за границы диапазона
Синтаксическая чистота | "AST строится только для строк, не содержащих ошибок (включая проверку структуры [ ])." | x = test; | Строка игнорируется (не соответствует структуре инициализации списка)

### Структура AST
Описание типов узлов
= ProgramNode: Корневой узел дерева. Содержит список всех корректных инструкций программы (Nodes).
- ListInitNode: Узел инициализации списка. Хранит имя переменной (Id) и список вложенных элементов (Elements).
- LiteralNode: Листовой узел, представляющий конкретное значение. Хранит тип (int, float, string, bool) и само значение.
<img width="773" height="579" alt="image" src="https://github.com/user-attachments/assets/3a939bef-e3cb-4717-a151-438476721a7e">
Формат вывода AST в программе.<br>
a = [1, 2.023, True, False, 'str'];<br>
Program<br>
└── Assignment (id: a)<br>
    ├── Literal (Целочисленная константа без знака: 1)<br>
    ├── Literal (Вещественная константа без знака: 2.023)<br>
    ├── Literal (Логическая константа: True)<br>
    ├── Literal (Логическая константа: False)<br>
    └── Literal (Строковая константа: 'str')<br>

### Примеры
1) Корректный ввод <img width="1920" height="1032" alt="image" src="https://github.com/user-attachments/assets/f69e6936-b047-4600-a7df-8d80f358da8f">
2) Ошибка в семантике (некорректное значение в константе) <img width="1920" height="1032" alt="image" src="https://github.com/user-attachments/assets/78c0612f-38e8-47db-98df-0906203f7feb"> <img width="1916" height="54" alt="image" src="https://github.com/user-attachments/assets/ec571e27-79a2-4c4b-a784-29132c57f6c1">
3) Ошибка в семантике (неуникальный идентификатор) <img width="1920" height="1032" alt="image" src="https://github.com/user-attachments/assets/bec7ff17-190d-44c3-8c9b-ca8cc4f1a1ea"> <img width="362" height="169" alt="image" src="https://github.com/user-attachments/assets/08e97206-7bd2-4930-aa37-97d7114c5bbe">

### Инструкция по запуску
1) Запустить exe.
2) Создать файл или открыть файл txt.
3) Запустить файл по нажатию «Пуск».

# Лабораторная работа 6. Создание внутренней формы представления программы
### Вариант задания
1. Язык программирования: Python
2. Определения КС-грамматики:
```
E → TA
A → ; | + TA | - TA
T → FB
B → ε | * FB | / FB | % FB
F → num | id | (E)
id → letter {letter | digit}
num → digit {digit}
```
3. Примеры верный строк:
   - 1 + b * 3;
   - (10 + 20) ** 3 / 2;
   - x ** 2 % 10;
   - ((a + b) % (10 - 3);
### Лексические и синтаксические ошибки
1. Диаграмма лексера
<img width="546" height="1011" alt="lab6-Страница-1" src="https://github.com/user-attachments/assets/3074e395-d21e-4efe-9829-6dccb3c74ac5"><br>
2. Схема рекурсивного спуска для парсера<br>
<img width="628" height="843" alt="image" src="https://github.com/user-attachments/assets/9a074f0e-2147-4254-81ab-e5ae85f48293"><br>
3. Тестовые примеры<br>
  3.1 Лексер<br><br>
  <img width="1920" height="1032" alt="image" src="https://github.com/user-attachments/assets/13e48519-9894-4c2b-a6a3-93dd8fb7c836"><br>
  3.2 Парсер<br><br>
  <img width="1920" height="1032" alt="image" src="https://github.com/user-attachments/assets/4d900047-3ffe-4c9a-99d9-efa6a046e2f7"><br>
  <img width="1920" height="1032" alt="image" src="https://github.com/user-attachments/assets/1bb53299-9e3d-4dc3-b617-a60716daf030"><br>
  <img width="1920" height="1032" alt="image" src="https://github.com/user-attachments/assets/d8d53407-1f2a-46dc-b932-32fcce84c90f"><br>

### Внутренняя форма представления программы (тетрады)
<img width="1920" height="1032" alt="image" src="https://github.com/user-attachments/assets/d1e5417d-97ca-4be4-a1de-9a295127608b"><br>
<img width="1920" height="1032" alt="image" src="https://github.com/user-attachments/assets/fdcbc8df-b958-4a66-b6f0-0877aef5215a"><br>
<img width="1920" height="1032" alt="image" src="https://github.com/user-attachments/assets/eb58b910-e764-4d26-8df5-3e9077a2197c"><br>

### ПОЛИЗ 
<img width="1920" height="1032" alt="image" src="https://github.com/user-attachments/assets/6cc99169-c5ae-4453-86ae-85e94b500430"><br>

# Лабораторная работа 7. Анализ и преобразование кода с использованием Clang и LLVM
### Постановка задачи
1. Установка среды: Установить Clang, LLVM, opt и Graphviz (например, в Ubuntu 26.04).
2. Работа с AST: Сгенерировать абстрактное синтаксическое дерево для заданного C/C++‑файла.
3. Генерация LLVM IR: Получить промежуточное представление кода без оптимизаций (-O0) и с оптимизациями (-O2).
4. Оптимизация IR: Применить оптимизации с помощью opt и/или флагов Clang, сравнить изменения.
5. Построение CFG: Построить граф потока управления для одной или нескольких функций.
6. Индивидуальное задание (по варианту): Выполнить анализ конкретной синтаксической конструкции в соответствии с вариантом. Сформулировать, как LLVM обрабатывает выбранную конструкцию, какие оптимизации применяются.
Выводы
7. Ответить на контрольные вопросы
## Общее задание
### Исходный код
```
#include <stdio.h>

int square(int x)
{
    return x * x;
}

int main()
{
    int a = 5;
    int b = square(a);
    printf("%d\n", b);
    return 0;
}
```
### Получение AST
Команда:
```
clang -Xclang -ast-dump -fsyntax-only main.c
```
Результат: <br> <br>
<img width="1074" height="533" alt="image" src="https://github.com/user-attachments/assets/d6e6b11e-0d11-4599-b011-001dcb72b567">
### Генерация LLVM IR
Команда:
```
clang -S -emit-llvm main.c -o main.ll
```
Результат (main.ll):
```
; ModuleID = 'main.c'
source_filename = "main.c"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-i128:128-f80:128-n8:16:32:64-S128"
target triple = "x86_64-pc-linux-gnu"

@.str = private unnamed_addr constant [4 x i8] c"%d\0A\00", align 1

; Function Attrs: mustprogress nofree norecurse nosync nounwind willreturn memory(none) uwtable
define dso_local i32 @square(i32 noundef %0) local_unnamed_addr #0 {
  %2 = mul nsw i32 %0, %0
  ret i32 %2
}

; Function Attrs: nofree nounwind uwtable
define dso_local noundef i32 @main() local_unnamed_addr #1 {
  %1 = tail call i32 (ptr, ...) @printf(ptr noundef nonnull dereferenceable(1) @.str, i32 noundef 25)
  ret i32 0
}

; Function Attrs: nofree nounwind
declare noundef i32 @printf(ptr nocapture noundef readonly, ...) local_unnamed_addr #2

attributes #0 = { mustprogress nofree norecurse nosync nounwind willreturn memory(none) uwtable "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #1 = { nofree nounwind uwtable "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #2 = { nofree nounwind "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }

!llvm.module.flags = !{!0, !1, !2, !3}
!llvm.ident = !{!4}

!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 8, !"PIC Level", i32 2}
!2 = !{i32 7, !"PIE Level", i32 2}
!3 = !{i32 7, !"uwtable", i32 2}
!4 = !{!"Ubuntu clang version 18.1.3 (1ubuntu1)"}
```
### Оптимизация IR
Оптимизация -O0:
```
clang -O0 -S -emit-llvm main.c -o main_O0.ll
```
Результат (main_O0.ll):
```
; ModuleID = 'main.c'
source_filename = "main.c"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-i128:128-f80:128-n8:16:32:64-S128"
target triple = "x86_64-pc-linux-gnu"

@.str = private unnamed_addr constant [4 x i8] c"%d\0A\00", align 1

; Function Attrs: mustprogress nofree norecurse nosync nounwind willreturn memory(none) uwtable
define dso_local i32 @square(i32 noundef %0) local_unnamed_addr #0 {
  %2 = mul nsw i32 %0, %0
  ret i32 %2
}

; Function Attrs: nofree nounwind uwtable
define dso_local noundef i32 @main() local_unnamed_addr #1 {
  %1 = tail call i32 (ptr, ...) @printf(ptr noundef nonnull dereferenceable(1) @.str, i32 noundef 25)
  ret i32 0
}

; Function Attrs: nofree nounwind
declare noundef i32 @printf(ptr nocapture noundef readonly, ...) local_unnamed_addr #2

attributes #0 = { mustprogress nofree norecurse nosync nounwind willreturn memory(none) uwtable "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #1 = { nofree nounwind uwtable "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #2 = { nofree nounwind "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }

!llvm.module.flags = !{!0, !1, !2, !3}
!llvm.ident = !{!4}

!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 8, !"PIC Level", i32 2}
!2 = !{i32 7, !"PIE Level", i32 2}
!3 = !{i32 7, !"uwtable", i32 2}
!4 = !{!"Ubuntu clang version 18.1.3 (1ubuntu1)"}
```
Оптимизация O2:
```
clang -O2 -S -emit-llvm main.c -o main_O2.ll
```
Результат (main_O2.ll):
```
; ModuleID = 'main.c'
source_filename = "main.c"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-i128:128-f80:128-n8:16:32:64-S128"
target triple = "x86_64-pc-linux-gnu"

@.str = private unnamed_addr constant [4 x i8] c"%d\0A\00", align 1

; Function Attrs: mustprogress nofree norecurse nosync nounwind willreturn memory(none) uwtable
define dso_local i32 @square(i32 noundef %0) local_unnamed_addr #0 {
  %2 = mul nsw i32 %0, %0
  ret i32 %2
}

; Function Attrs: nofree nounwind uwtable
define dso_local noundef i32 @main() local_unnamed_addr #1 {
  %1 = tail call i32 (ptr, ...) @printf(ptr noundef nonnull dereferenceable(1) @.str, i32 noundef 25)
  ret i32 0
}

; Function Attrs: nofree nounwind
declare noundef i32 @printf(ptr nocapture noundef readonly, ...) local_unnamed_addr #2

attributes #0 = { mustprogress nofree norecurse nosync nounwind willreturn memory(none) uwtable "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #1 = { nofree nounwind uwtable "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #2 = { nofree nounwind "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }

!llvm.module.flags = !{!0, !1, !2, !3}
!llvm.ident = !{!4}

!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 8, !"PIC Level", i32 2}
!2 = !{i32 7, !"PIE Level", i32 2}
!3 = !{i32 7, !"uwtable", i32 2}
!4 = !{!"Ubuntu clang version 18.1.3 (1ubuntu1)"}
```
### Сравнение O0 и O2
Команда: 
```
diff main_O0.ll main_O2.ll
```
Результат:<br><br>
<img width="1729" height="953" alt="image" src="https://github.com/user-attachments/assets/f778b046-269d-453b-ae54-77a35119e408">
### Граф потока управления программы. Построение CFG
Команда для генерации оптимизированного LLVM IR:
```
clang -O2 -S -emit-llvm main.c -o main.ll
```
Команда для генерации .dot-файлов CFG для функций:
```
opt -dot-cfg -disable-output main.ll
```
Результат (.main.dot):
```
digraph "CFG for 'main' function" {
	label="CFG for 'main' function";

	Node0x557bf1b56630 [shape=record,color="#b70d28ff", style=filled, fillcolor="#b70d2870" fontname="Courier",label="{0:\l|  %1 = tail call i32 (ptr, ...) @printf(ptr noundef nonnull\l... dereferenceable(1) @.str, i32 noundef 25)\l  ret i32 0\l}"];
}
```
Результат (.square.dot):
```
digraph "CFG for 'square' function" {
	label="CFG for 'square' function";

	Node0x557bf1b54710 [shape=record,color="#b70d28ff", style=filled, fillcolor="#b70d2870" fontname="Courier",label="{1:\l|  %2 = mul nsw i32 %0, %0\l  ret i32 %2\l}"];
}
}
```
Команды для преобразования файлов с расширением .dot в .png с
помощью Graphviz:
```
dot -Tpng .main.dot -o cfg_main.png
dot -Tpng .square.dot -o cfg_square.png
```
Результат (main.cfg): <br><br>
<img width="660" height="144" alt="image" src="https://github.com/user-attachments/assets/1c3511fa-4f9d-4ce8-8644-fa4667101bb4"><br><br>
Результат (square.cfg): <br><br>
<img width="285" height="124" alt="image" src="https://github.com/user-attachments/assets/127f9449-3588-4c54-8b9a-c72a4d87d94c"><br>
## Индивидуальное задание
Вариант: Списки / массивы / словари <br>
Исходный код:
```
#include <iostream>
#include <array>

int main()
{
    std::array<int, 5> data = {1, 2, 3, 4, 5};
    int sum = 0;
    for (int i = 0; i < data.size(); ++i)
    {
        sum += data[i];
    }
    std::cout << sum << std::endl;
    return 0;
}
```
### Получение IR для -O0 и -O2.
IR без оптимизации, команда:
```
clang++ -S -emit-llvm -O0 -Xclang -disable-O0-optnone main.cpp -o main_O0.ll
```
Результат (main_O0.ll):
```
; ModuleID = 'main.cpp'
source_filename = "main.cpp"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-i128:128-f80:128-n8:16:32:64-S128"
target triple = "x86_64-pc-linux-gnu"

module asm ".globl _ZSt21ios_base_library_initv"

%"struct.std::array" = type { [5 x i32] }
%"class.std::basic_ostream" = type { ptr, %"class.std::basic_ios" }
%"class.std::basic_ios" = type { %"class.std::ios_base", ptr, i8, i8, ptr, ptr, ptr, ptr }
%"class.std::ios_base" = type { ptr, i64, i64, i32, i32, i32, ptr, %"struct.std::ios_base::_Words", [8 x %"struct.std::ios_base::_Words"], i32, ptr, %"class.std::locale" }
%"struct.std::ios_base::_Words" = type { ptr, i64 }
%"class.std::locale" = type { ptr }

$_ZNSt5arrayIiLm5EEixEm = comdat any

@__const.main.data = private unnamed_addr constant %"struct.std::array" { [5 x i32] [i32 1, i32 2, i32 3, i32 4, i32 5] }, align 4
@_ZSt4cout = external global %"class.std::basic_ostream", align 8

; Function Attrs: mustprogress noinline norecurse uwtable
define dso_local noundef i32 @main() #0 {
  %1 = alloca ptr, align 8
  %2 = alloca i32, align 4
  %3 = alloca %"struct.std::array", align 4
  %4 = alloca i32, align 4
  %5 = alloca i32, align 4
  store i32 0, ptr %2, align 4
  call void @llvm.memcpy.p0.p0.i64(ptr align 4 %3, ptr align 4 @__const.main.data, i64 20, i1 false)
  store i32 0, ptr %4, align 4
  store i32 0, ptr %5, align 4
  br label %6

6:                                                ; preds = %18, %0
  %7 = load i32, ptr %5, align 4
  %8 = sext i32 %7 to i64
  store ptr %3, ptr %1, align 8
  %9 = load ptr, ptr %1, align 8
  %10 = icmp ult i64 %8, 5
  br i1 %10, label %11, label %21

11:                                               ; preds = %6
  %12 = load i32, ptr %5, align 4
  %13 = sext i32 %12 to i64
  %14 = call noundef nonnull align 4 dereferenceable(4) ptr @_ZNSt5arrayIiLm5EEixEm(ptr noundef nonnull align 4 dereferenceable(20) %3, i64 noundef %13) #4
  %15 = load i32, ptr %14, align 4
  %16 = load i32, ptr %4, align 4
  %17 = add nsw i32 %16, %15
  store i32 %17, ptr %4, align 4
  br label %18

18:                                               ; preds = %11
  %19 = load i32, ptr %5, align 4
  %20 = add nsw i32 %19, 1
  store i32 %20, ptr %5, align 4
  br label %6, !llvm.loop !6

21:                                               ; preds = %6
  %22 = load i32, ptr %4, align 4
  %23 = call noundef nonnull align 8 dereferenceable(8) ptr @_ZNSolsEi(ptr noundef nonnull align 8 dereferenceable(8) @_ZSt4cout, i32 noundef %22)
  %24 = call noundef nonnull align 8 dereferenceable(8) ptr @_ZNSolsEPFRSoS_E(ptr noundef nonnull align 8 dereferenceable(8) %23, ptr noundef @_ZSt4endlIcSt11char_traitsIcEERSt13basic_ostreamIT_T0_ES6_)
  ret i32 0
}

; Function Attrs: nocallback nofree nounwind willreturn memory(argmem: readwrite)
declare void @llvm.memcpy.p0.p0.i64(ptr noalias nocapture writeonly, ptr noalias nocapture readonly, i64, i1 immarg) #1

; Function Attrs: mustprogress noinline nounwind uwtable
define linkonce_odr dso_local noundef nonnull align 4 dereferenceable(4) ptr @_ZNSt5arrayIiLm5EEixEm(ptr noundef nonnull align 4 dereferenceable(20) %0, i64 noundef %1) #2 comdat align 2 {
  %3 = alloca ptr, align 8
  %4 = alloca i64, align 8
  store ptr %0, ptr %3, align 8
  store i64 %1, ptr %4, align 8
  %5 = load ptr, ptr %3, align 8
  %6 = getelementptr inbounds %"struct.std::array", ptr %5, i32 0, i32 0
  %7 = load i64, ptr %4, align 8
  %8 = getelementptr inbounds [5 x i32], ptr %6, i64 0, i64 %7
  ret ptr %8
}

declare noundef nonnull align 8 dereferenceable(8) ptr @_ZNSolsEi(ptr noundef nonnull align 8 dereferenceable(8), i32 noundef) #3

declare noundef nonnull align 8 dereferenceable(8) ptr @_ZNSolsEPFRSoS_E(ptr noundef nonnull align 8 dereferenceable(8), ptr noundef) #3

declare noundef nonnull align 8 dereferenceable(8) ptr @_ZSt4endlIcSt11char_traitsIcEERSt13basic_ostreamIT_T0_ES6_(ptr noundef nonnull align 8 dereferenceable(8)) #3

attributes #0 = { mustprogress noinline norecurse uwtable "frame-pointer"="all" "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #1 = { nocallback nofree nounwind willreturn memory(argmem: readwrite) }
attributes #2 = { mustprogress noinline nounwind uwtable "frame-pointer"="all" "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #3 = { "frame-pointer"="all" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #4 = { nounwind }

!llvm.module.flags = !{!0, !1, !2, !3, !4}
!llvm.ident = !{!5}

!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 8, !"PIC Level", i32 2}
!2 = !{i32 7, !"PIE Level", i32 2}
!3 = !{i32 7, !"uwtable", i32 2}
!4 = !{i32 7, !"frame-pointer", i32 2}
!5 = !{!"Ubuntu clang version 18.1.3 (1ubuntu1)"}
!6 = distinct !{!6, !7}
!7 = !{!"llvm.loop.mustprogress"}
```
IR с оптимизацие, команда: 
```
clang++ -S -emit-llvm -O2 main.cpp -o main_O2.ll
```
Результат (main_O2.ll):
```
; ModuleID = 'main.cpp'
source_filename = "main.cpp"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-i128:128-f80:128-n8:16:32:64-S128"
target triple = "x86_64-pc-linux-gnu"

module asm ".globl _ZSt21ios_base_library_initv"

%"class.std::basic_ostream" = type { ptr, %"class.std::basic_ios" }
%"class.std::basic_ios" = type { %"class.std::ios_base", ptr, i8, i8, ptr, ptr, ptr, ptr }
%"class.std::ios_base" = type { ptr, i64, i64, i32, i32, i32, ptr, %"struct.std::ios_base::_Words", [8 x %"struct.std::ios_base::_Words"], i32, ptr, %"class.std::locale" }
%"struct.std::ios_base::_Words" = type { ptr, i64 }
%"class.std::locale" = type { ptr }
%"class.std::ctype" = type <{ %"class.std::locale::facet.base", [4 x i8], ptr, i8, [7 x i8], ptr, ptr, ptr, i8, [256 x i8], [256 x i8], i8, [6 x i8] }>
%"class.std::locale::facet.base" = type <{ ptr, i32 }>

@_ZSt4cout = external global %"class.std::basic_ostream", align 8

; Function Attrs: mustprogress norecurse uwtable
define dso_local noundef i32 @main() local_unnamed_addr #0 {
  %1 = tail call noundef nonnull align 8 dereferenceable(8) ptr @_ZNSolsEi(ptr noundef nonnull align 8 dereferenceable(8) @_ZSt4cout, i32 noundef 15)
  %2 = load ptr, ptr %1, align 8, !tbaa !5
  %3 = getelementptr i8, ptr %2, i64 -24
  %4 = load i64, ptr %3, align 8
  %5 = getelementptr inbounds i8, ptr %1, i64 %4
  %6 = getelementptr inbounds %"class.std::basic_ios", ptr %5, i64 0, i32 5
  %7 = load ptr, ptr %6, align 8, !tbaa !8
  %8 = icmp eq ptr %7, null
  br i1 %8, label %9, label %10

9:                                                ; preds = %0
  tail call void @_ZSt16__throw_bad_castv() #3
  unreachable

10:                                               ; preds = %0
  %11 = getelementptr inbounds %"class.std::ctype", ptr %7, i64 0, i32 8
  %12 = load i8, ptr %11, align 8, !tbaa !20
  %13 = icmp eq i8 %12, 0
  br i1 %13, label %17, label %14

14:                                               ; preds = %10
  %15 = getelementptr inbounds %"class.std::ctype", ptr %7, i64 0, i32 9, i64 10
  %16 = load i8, ptr %15, align 1, !tbaa !23
  br label %22

17:                                               ; preds = %10
  tail call void @_ZNKSt5ctypeIcE13_M_widen_initEv(ptr noundef nonnull align 8 dereferenceable(570) %7)
  %18 = load ptr, ptr %7, align 8, !tbaa !5
  %19 = getelementptr inbounds ptr, ptr %18, i64 6
  %20 = load ptr, ptr %19, align 8
  %21 = tail call noundef signext i8 %20(ptr noundef nonnull align 8 dereferenceable(570) %7, i8 noundef signext 10)
  br label %22

22:                                               ; preds = %14, %17
  %23 = phi i8 [ %16, %14 ], [ %21, %17 ]
  %24 = tail call noundef nonnull align 8 dereferenceable(8) ptr @_ZNSo3putEc(ptr noundef nonnull align 8 dereferenceable(8) %1, i8 noundef signext %23)
  %25 = tail call noundef nonnull align 8 dereferenceable(8) ptr @_ZNSo5flushEv(ptr noundef nonnull align 8 dereferenceable(8) %24)
  ret i32 0
}

declare noundef nonnull align 8 dereferenceable(8) ptr @_ZNSolsEi(ptr noundef nonnull align 8 dereferenceable(8), i32 noundef) local_unnamed_addr #1

declare noundef nonnull align 8 dereferenceable(8) ptr @_ZNSo3putEc(ptr noundef nonnull align 8 dereferenceable(8), i8 noundef signext) local_unnamed_addr #1

declare noundef nonnull align 8 dereferenceable(8) ptr @_ZNSo5flushEv(ptr noundef nonnull align 8 dereferenceable(8)) local_unnamed_addr #1

; Function Attrs: noreturn
declare void @_ZSt16__throw_bad_castv() local_unnamed_addr #2

declare void @_ZNKSt5ctypeIcE13_M_widen_initEv(ptr noundef nonnull align 8 dereferenceable(570)) local_unnamed_addr #1

attributes #0 = { mustprogress norecurse uwtable "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #1 = { "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #2 = { noreturn "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #3 = { noreturn }

!llvm.module.flags = !{!0, !1, !2, !3}
!llvm.ident = !{!4}

!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 8, !"PIC Level", i32 2}
!2 = !{i32 7, !"PIE Level", i32 2}
!3 = !{i32 7, !"uwtable", i32 2}
!4 = !{!"Ubuntu clang version 18.1.3 (1ubuntu1)"}
!5 = !{!6, !6, i64 0}
!6 = !{!"vtable pointer", !7, i64 0}
!7 = !{!"Simple C++ TBAA"}
!8 = !{!9, !15, i64 240}
!9 = !{!"_ZTSSt9basic_iosIcSt11char_traitsIcEE", !10, i64 0, !15, i64 216, !12, i64 224, !19, i64 225, !15, i64 232, !15, i64 240, !15, i64 248, !15, i64 256}
!10 = !{!"_ZTSSt8ios_base", !11, i64 8, !11, i64 16, !13, i64 24, !14, i64 28, !14, i64 32, !15, i64 40, !16, i64 48, !12, i64 64, !17, i64 192, !15, i64 200, !18, i64 208}
!11 = !{!"long", !12, i64 0}
!12 = !{!"omnipotent char", !7, i64 0}
!13 = !{!"_ZTSSt13_Ios_Fmtflags", !12, i64 0}
!14 = !{!"_ZTSSt12_Ios_Iostate", !12, i64 0}
!15 = !{!"any pointer", !12, i64 0}
!16 = !{!"_ZTSNSt8ios_base6_WordsE", !15, i64 0, !11, i64 8}
!17 = !{!"int", !12, i64 0}
!18 = !{!"_ZTSSt6locale", !15, i64 0}
!19 = !{!"bool", !12, i64 0}
!20 = !{!21, !12, i64 56}
!21 = !{!"_ZTSSt5ctypeIcE", !22, i64 0, !15, i64 16, !19, i64 24, !15, i64 32, !15, i64 40, !15, i64 48, !12, i64 56, !12, i64 57, !12, i64 313, !12, i64 569}
!22 = !{!"_ZTSNSt6locale5facetE", !17, i64 8}
!23 = !{!12, !12, i64 0}
```
### Исследуйте, разворачивается ли цикл (-unroll).
> Цикл был полностью развернут и удален (Full Unrolling).
> В IR-коде отсутствуют инструкции сравнения icmp и обратные переходы br, относящиеся к счетчику цикла.
### Постройте CFG для main с -O0 и с -O2
Комнады:
```
# Для -O0
opt -passes=dot-cfg -disable-output main_O0.ll
dot -Tpng .main.dot -o cfg_O0.png

# Для -O2
opt -passes=dot-cfg -disable-output main_O2.ll
dot -Tpng .main.dot -o cfg_O2.png
```
Результат (-O0): <br><br>
<img width="1845" height="1007" alt="image" src="https://github.com/user-attachments/assets/ba59a8c3-4741-49ff-b4da-835df6ffee0d"><br><br>
Результат (-O2): <br><br>
<img width="1761" height="1017" alt="image" src="https://github.com/user-attachments/assets/93089f51-c8d3-428a-972d-a679ad313313"><br><br>
### Примените дополнительно -loop-rotate, -licm и опишите изменения.
Команда:
```
opt -S -passes='loop(loop-rotate),loop-mssa(licm)' main_O0.ll -o main_opt.ll
opt -passes=dot-cfg -disable-output main_opt.ll
dot -Tpng .main.dot -o cfg_opt.png
```
Результат (main_opt.ll):
```
; ModuleID = 'main_O0.ll'
source_filename = "main.cpp"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-i128:128-f80:128-n8:16:32:64-S128"
target triple = "x86_64-pc-linux-gnu"

module asm ".globl _ZSt21ios_base_library_initv"

%"struct.std::array" = type { [5 x i32] }
%"class.std::basic_ostream" = type { ptr, %"class.std::basic_ios" }
%"class.std::basic_ios" = type { %"class.std::ios_base", ptr, i8, i8, ptr, ptr, ptr, ptr }
%"class.std::ios_base" = type { ptr, i64, i64, i32, i32, i32, ptr, %"struct.std::ios_base::_Words", [8 x %"struct.std::ios_base::_Words"], i32, ptr, %"class.std::locale" }
%"struct.std::ios_base::_Words" = type { ptr, i64 }
%"class.std::locale" = type { ptr }

$_ZNSt5arrayIiLm5EEixEm = comdat any

@__const.main.data = private unnamed_addr constant %"struct.std::array" { [5 x i32] [i32 1, i32 2, i32 3, i32 4, i32 5] }, align 4
@_ZSt4cout = external global %"class.std::basic_ostream", align 8

; Function Attrs: mustprogress noinline norecurse uwtable
define dso_local noundef i32 @main() #0 {
  %1 = alloca ptr, align 8
  %2 = alloca i32, align 4
  %3 = alloca %"struct.std::array", align 4
  %4 = alloca i32, align 4
  %5 = alloca i32, align 4
  store i32 0, ptr %2, align 4
  call void @llvm.memcpy.p0.p0.i64(ptr align 4 %3, ptr align 4 @__const.main.data, i64 20, i1 false)
  store i32 0, ptr %4, align 4
  store i32 0, ptr %5, align 4
  %6 = load i32, ptr %5, align 4
  %7 = sext i32 %6 to i64
  store ptr %3, ptr %1, align 8
  %8 = load ptr, ptr %1, align 8
  %9 = icmp ult i64 %7, 5
  br i1 %9, label %.lr.ph, label %21

.lr.ph:                                           ; preds = %0
  %.promoted = load i32, ptr %5, align 4
  %.promoted1 = load i32, ptr %4, align 4
  br label %10

10:                                               ; preds = %.lr.ph, %17
  %11 = phi i32 [ %.promoted1, %.lr.ph ], [ %16, %17 ]
  %12 = phi i32 [ %.promoted, %.lr.ph ], [ %18, %17 ]
  %13 = sext i32 %12 to i64
  %14 = call noundef nonnull align 4 dereferenceable(4) ptr @_ZNSt5arrayIiLm5EEixEm(ptr noundef nonnull align 4 dereferenceable(20) %3, i64 noundef %13) #4
  %15 = load i32, ptr %14, align 4
  %16 = add nsw i32 %11, %15
  br label %17

17:                                               ; preds = %10
  %18 = add nsw i32 %12, 1
  %19 = sext i32 %18 to i64
  %20 = icmp ult i64 %19, 5
  br i1 %20, label %10, label %._crit_edge, !llvm.loop !6

._crit_edge:                                      ; preds = %17
  %.lcssa2 = phi i32 [ %16, %17 ]
  %.lcssa = phi i32 [ %18, %17 ]
  store i32 %.lcssa, ptr %5, align 4
  store i32 %.lcssa2, ptr %4, align 4
  store ptr %3, ptr %1, align 1
  br label %21

21:                                               ; preds = %._crit_edge, %0
  %22 = load i32, ptr %4, align 4
  %23 = call noundef nonnull align 8 dereferenceable(8) ptr @_ZNSolsEi(ptr noundef nonnull align 8 dereferenceable(8) @_ZSt4cout, i32 noundef %22)
  %24 = call noundef nonnull align 8 dereferenceable(8) ptr @_ZNSolsEPFRSoS_E(ptr noundef nonnull align 8 dereferenceable(8) %23, ptr noundef @_ZSt4endlIcSt11char_traitsIcEERSt13basic_ostreamIT_T0_ES6_)
  ret i32 0
}

; Function Attrs: nocallback nofree nounwind willreturn memory(argmem: readwrite)
declare void @llvm.memcpy.p0.p0.i64(ptr noalias nocapture writeonly, ptr noalias nocapture readonly, i64, i1 immarg) #1

; Function Attrs: mustprogress noinline nounwind uwtable
define linkonce_odr dso_local noundef nonnull align 4 dereferenceable(4) ptr @_ZNSt5arrayIiLm5EEixEm(ptr noundef nonnull align 4 dereferenceable(20) %0, i64 noundef %1) #2 comdat align 2 {
  %3 = alloca ptr, align 8
  %4 = alloca i64, align 8
  store ptr %0, ptr %3, align 8
  store i64 %1, ptr %4, align 8
  %5 = load ptr, ptr %3, align 8
  %6 = getelementptr inbounds %"struct.std::array", ptr %5, i32 0, i32 0
  %7 = load i64, ptr %4, align 8
  %8 = getelementptr inbounds [5 x i32], ptr %6, i64 0, i64 %7
  ret ptr %8
}

declare noundef nonnull align 8 dereferenceable(8) ptr @_ZNSolsEi(ptr noundef nonnull align 8 dereferenceable(8), i32 noundef) #3

declare noundef nonnull align 8 dereferenceable(8) ptr @_ZNSolsEPFRSoS_E(ptr noundef nonnull align 8 dereferenceable(8), ptr noundef) #3

declare noundef nonnull align 8 dereferenceable(8) ptr @_ZSt4endlIcSt11char_traitsIcEERSt13basic_ostreamIT_T0_ES6_(ptr noundef nonnull align 8 dereferenceable(8)) #3

attributes #0 = { mustprogress noinline norecurse uwtable "frame-pointer"="all" "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #1 = { nocallback nofree nounwind willreturn memory(argmem: readwrite) }
attributes #2 = { mustprogress noinline nounwind uwtable "frame-pointer"="all" "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #3 = { "frame-pointer"="all" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #4 = { nounwind }

!llvm.module.flags = !{!0, !1, !2, !3, !4}
!llvm.ident = !{!5}

!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 8, !"PIC Level", i32 2}
!2 = !{i32 7, !"PIE Level", i32 2}
!3 = !{i32 7, !"uwtable", i32 2}
!4 = !{i32 7, !"frame-pointer", i32 2}
!5 = !{!"Ubuntu clang version 18.1.3 (1ubuntu1)"}
!6 = distinct !{!6, !7}
!7 = !{!"llvm.loop.mustprogress"}
```
Результат (cfg_opt.png): <br><br>
<img width="1249" height="1499" alt="image" src="https://github.com/user-attachments/assets/52ff43d1-91e6-4d0d-ae8f-2cb96174e0ec"><br><br>
Изменения: 
> К циклу (Loop Rotate): оптимизация изменила структуру цикла с while на do-while.
> Был создан специальный предварительный блок-заголовок label %.lr.ph.
> Теперь проверка условия выхода из цикла происходит в конце итерации (label %17),
> что сокращает количество безусловных переходов (br) на каждой итерации.
### Вывод - какие оптимизации применились к массиву и циклу?
1. К массиву:
> Компилятор понял, что массив статичен и его значения известны заранее.
> Вместо выделения памяти на стеке, он подставил значения напрямую туда, где они используются.
> А так как сам массив после этого нигде не нужен, он был полностью удален как "мертвый код".
2. К циклу:
> Компилятор полностью развернул цикл (Unrolling), проанализировал арифметические операции внутри (сложение 1+2+3+4+5)
> и вычислил результат еще на этапе компиляции (Constant Folding / Свертка констант).
## Дополнительное задание
### Выбранная синтаксическая конструкция
В качестве целевой конструкции используется инициализация списка (массива), поддерживающая различные типы литералов:
``` 
arr = [1, "string", 1.2, -3, +3, True, False];
```
### Построение абстрактного синтаксического дерева (AST)
> Синтаксический анализ и построение AST были реализованы в рамках Лабораторной работы №5.
> Для целевой конструкции сканер формирует узлы ListInitNode, содержащие идентификатор списка и коллекцию элементов LiteralNode.
> Структура дерева визуализируется в графическом интерфейсе программы (вкладка «AST дерево»).
### Генерация промежуточного представления (IR)
Для выполнения оптимизаций исходное AST транслируется в промежуточное представление — список виртуальных инструкций (трехадресный код).<br>
#### Набор используемых инструкций:
- ALLOC_LIST — выделение памяти под список и привязка к переменной (например, arr = []).
- ASSIGN — создание временной переменной для хранения значения литерала (например, t1 = 1).
- APPEND — добавление значения временной переменной в список (например, APPEND arr, t1).
### Локальные оптимизации
#### Оптимизация 1: Свертка констант (Удаление унарного плюса)
- ***Описание***. Данная оптимизация вычисляет константные выражения на этапе компиляции, приводя их к каноническому виду. В рамках грамматики списка устраняются избыточные унарные плюсы перед числами (например, лексема +3 преобразуется в 3).
- ***Сохранение семантики***. С математической и логической точек зрения +X полностью эквивалентно X.
#### Обобщенная блок-схема
<img width="340" height="412" alt="lab7-Страница-1" src="https://github.com/user-attachments/assets/78675755-967e-4c3f-a249-2e17bd5a2cb6"><br>
#### Оптимизация 2: Удаление дубликатов в списке (Канонизация множества)
- ***Описание***. Если инициализируемый список семантически трактуется как множество, наличие дублирующихся элементов является избыточным. Проход анализирует значения, присваиваемые временным переменным, и при попытке добавить (APPEND) уже существующее значение, отбрасывает эту инструкцию.
- ***Сохранение семантики***. После удаления дублирующих инструкций APPEND, удаляются также "мертвые" присваивания ASSIGN для временных переменных, которые больше нигде не используются.
#### Обобщенная блок-схема
<img width="519" height="770" alt="lab7-Страница-2" src="https://github.com/user-attachments/assets/cbca6e99-87d0-4baa-9d52-0aec0a2be850"> <br>
### Скриншоты работы программы
Пример: ```a = [1, +3, 'str', -2.2, True, +3];``` <br><br>
Результат:<br><br>
<img width="1899" height="610" alt="image" src="https://github.com/user-attachments/assets/ca37371a-a072-451b-9ab3-502fad33592f"><br>
### Ответы на контрольные вопросы
1. Что такое Clang, и какова его роль в процессе компиляции программ?
> Clang — это фронтенд-компилятор для языков семейства C, ответственный за разбор исходного кода, проверку синтаксиса и семантический анализ. Его главная роль заключается в превращении высокоуровневого кода, написанного человеком, в низкоуровневое промежуточное представление LLVM IR, понятное оптимизатору.

2. Что представляет собой LLVM и как он используется в современных компиляторах?
> LLVM — это универсальная модульная инфраструктура для создания компиляторов, которая предоставляет общие инструменты для оптимизации кода и генерации машинных инструкций под разные процессоры. Современные компиляторы используют LLVM как мощный «бэкенд», что позволяет им поддерживать множество архитектур (x86, ARM, RISC-V), не переписывая систему оптимизации с нуля.

3. Чем отличается абстрактное синтаксическое дерево (AST) от промежуточного представления LLVM IR?
> AST отражает иерархическую структуру исходного текста и сильно привязано к правилам конкретного языка программирования, сохраняя много лишних синтаксических деталей. LLVM IR — это линейное, машинно-независимое представление, которое больше похоже на ассемблер и предназначено для математического анализа и трансформаций перед генерацией кода.

4. Для чего необходимо промежуточное представление (IR) в процессе компиляции?
> Промежуточное представление служит универсальным «общим языком», который позволяет отделить анализ исходного кода (фронтенд) от генерации под конкретное железо (бэкенд). Благодаря IR можно один раз написать сложную оптимизацию и применять её для любого входного языка, будь то C++, Rust или Swift.

5. Что делает инструкция alloca в LLVM IR, и зачем она используется в функциях?
> Инструкция alloca выделяет память для переменной непосредственно в стековом кадре текущей функции. Она используется для работы с локальными переменными, позволяя обращаться к ним по адресу памяти до того, как оптимизатор (например, SROA) попытается заменить их быстрыми виртуальными регистрами.

6. Зачем нужна оптимизация кода в компиляторе, и какие основные цели она преследует?
> Оптимизация нужна для того, чтобы сделать программу более эффективной без изменения её логики. Основными целями являются увеличение скорости выполнения кода, уменьшение размера исполняемого файла и снижение потребления энергии или памяти.

7. Что такое SSA-форма и почему она важна при оптимизации программ?
> SSA (Static Single Assignment) — это форма представления кода, в которой каждой переменной значение присваивается ровно один раз. Это критически важно для оптимизации, так как SSA-форма делает зависимости между данными явными, позволяя компилятору легко отслеживать, откуда пришло значение переменной в любой точке программы.

8. Что такое граф потока управления (CFG) и как он помогает анализировать поведение программы?
> Граф потока управления — это структура, где узлы являются базовыми блоками кода, а ребра показывают возможные переходы (прыжки) между ними. CFG помогает компилятору анализировать логику ветвлений, находить циклы, обнаруживать недостижимый код и эффективно распределять ресурсы процессора.

9. Как устроено представление арифметических операций в LLVM IR (например, умножение, сложение)?
> Арифметические операции представлены в виде трехадресного кода, где инструкция (например, add или mul) принимает два операнда и сохраняет результат в новую виртуальную переменную. Каждая такая операция типизирована, что исключает ошибки несоответствия типов данных на уровне промежуточного кода.

10. Почему функции в LLVM IR обычно представляют собой отдельные единицы анализа и оптимизации?
> Функции обладают естественными границами видимости и управления стеком, что позволяет компилятору эффективно обрабатывать их по отдельности, экономя время и память. Такой подход упрощает локальный анализ переменных и позволяет параллельно оптимизировать разные части программы.

11. Что происходит с функцией в LLVM IR, если она вызывается один раз и очень короткая?
> В таком случае компилятор обычно применяет инлайнинг (Inlining) — он вставляет тело функции напрямую в место вызова. Это убирает накладные расходы на вызов функции (подготовку стека и передачу аргументов), что значительно ускоряет выполнение программы.

12. Какие преимущества даёт использование IR и CFG для автоматических оптимизаций по сравнению с анализом исходного текста на C?
> IR и CFG предоставляют «очищенную» от синтаксического шума структуру, где все зависимости и пути выполнения представлены в явном математическом виде. Это позволяет автоматическим алгоритмам работать быстрее и точнее, так как им не нужно разбираться в сложностях макросов, шаблонов или неоднозначностей исходного текста на C.
