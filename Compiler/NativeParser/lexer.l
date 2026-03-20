ввыф%{
#include "parser.tab.h" 
#include <io.h>
#define isatty _isatty
%}

%option nounistd 
%option yylineno 
%option noyywrap 

DIGIT           [0-9] 
DIGIT0          [1-9] 
LETTER          [a-zA-Z_] 
ID              {LETTER}({LETTER}|{DIGIT})* 
INT             ({DIGIT0}{DIGIT}*|0) 
FLOAT           ({DIGIT0}{DIGIT}*|0)\.{DIGIT}+ 
STRING          \'[^'\n]*\'

%%

"True"          { return CONST_TRUE; } 
"False"         { return CONST_FALSE; } 
{FLOAT}         { yylval.str_val = strdup(yytext); return CONST_FLOAT; } 
{INT}           { yylval.str_val = strdup(yytext); return CONST_INT; } 
{STRING}        { yylval.str_val = strdup(yytext); return CONST_STRING; } 
{ID}            { yylval.str_val = strdup(yytext); return ID; } 

"["             { return '['; } 
"]"             { return ']'; } 
"="             { return '='; } 
","             { return ','; } 
";"             { return ';'; } 
"+"             { return '+'; } 
"-"             { return '-'; } 

[ \t\r\n]+      { } 
.               { return yytext[0]; } 

%%