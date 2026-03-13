%{
#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

extern int yylex();
extern int yylineno;

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
    | program line
;

line:
      statement EOL
      {
          if (!line_error)
              printf("SUCCESS: List declared correctly (line %d)\n", yylineno);

          line_error = 0;
      }

    | error EOL
      {
          line_error = 0;
          yyerrok;
      }
    | EOL
;

statement:
      ID '=' list_expr ';'
;

list_expr:
      '[' ']'
    | '[' elements ']'
;

elements:
      value
    | elements ',' value
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

int main()
{
    SetConsoleCP(65001);
    SetConsoleOutputCP(65001);

    printf("Analyzer started. Waiting for input...\n\n");

    yyparse();

    return 0;
}