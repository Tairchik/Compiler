#include <stdlib.h>
#include <string.h>

extern int yyparse();
extern void* yy_scan_string(const char* str);
extern void yy_delete_buffer(void* buffer);
extern int yylineno;

// Теперь передаем два аргумента: номер строки и само сообщение
typedef void (*ErrorCallback)(int line, const char* message);
ErrorCallback global_error_callback = NULL;

static int has_errors = 0;

void yyerror(const char* s) {
    has_errors = 1;
    if (global_error_callback) {
        // Просто пробрасываем данные в C# без snprintf и русского текста в Си
        global_error_callback(yylineno, s);
    }
}

#define EXPORT __declspec(dllexport)

#ifdef __cplusplus
extern "C" {
#endif

    EXPORT int ParseSourceCode(const char* sourceCode, ErrorCallback errorCb) {
        global_error_callback = errorCb;
        has_errors = 0;
        yylineno = 1;

        void* buffer = yy_scan_string(sourceCode);
        int bison_result = yyparse();
        yy_delete_buffer(buffer);

        global_error_callback = NULL;
        return (bison_result != 0 || has_errors != 0) ? 1 : 0;
    }

#ifdef __cplusplus
}
#endif