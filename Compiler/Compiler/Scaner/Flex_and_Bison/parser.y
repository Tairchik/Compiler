%{
#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

extern int yylex();
extern int yylineno;
extern FILE *yyin;

void yyerror(const char *s);

int line_error = 0;
%}

%define parse.error verbose

%union {
    char* str_val;
}

%token <str_val> ID "identifier"
%token <str_val> CONST_INT "integer"
%token <str_val> CONST_FLOAT "float"
%token <str_val> CONST_STRING "string"

%token CONST_TRUE "True"
%token CONST_FALSE "False"

%token EOL "line break"

%%

program:
      /* empty */
    | program statement
;

statement:
      ID '=' list_expr ';'
      {
          if (!line_error)
              printf("SUCCESS: List declared correctly (line %d)\n", yylineno);
          line_error = 0;
      }
    | error ';'
      {
          line_error = 0;
          yyerrok;
      }
    | ';'
;

list_expr:
      '[' ']'
    | '[' elements ']'
    | '[' error ']'
      {
          yyerror("invalid list content");
          yyerrok;
      }
;

elements:
      value
    | elements ',' value
    | elements error value
      {
          yyerror("missing comma between elements");
          yyerrok;
      }
;

value:
      CONST_INT
    | sign CONST_INT
    | CONST_FLOAT
    | sign CONST_FLOAT
    | CONST_STRING
    | boolean_val
;

boolean_val:
      CONST_TRUE
    | CONST_FALSE
;

sign:
      '+'
    | '-'
;

%%

void yyerror(const char *s)
{
    if (!line_error)
    {
        printf("Line %d error: %s\n", yylineno, s);
        line_error = 1;
    }
}

int main(int argc, char **argv)
{
    SetConsoleCP(65001);
    SetConsoleOutputCP(65001);

    if (argc > 1)
    {
        yyin = fopen(argv[1], "r");
        if (!yyin)
        {
            perror("Cannot open file");
            return 1;
        }
    }
    printf("Analyzer started...\n\n");
    yyparse();
    if (yyin)
        fclose(yyin);
    return 0;
}