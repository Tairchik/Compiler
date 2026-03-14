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

%error-verbose

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

      }
;

elements:
      value
    | elements ',' value
    | elements error value
      {

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