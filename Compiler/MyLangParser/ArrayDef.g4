grammar ArrayDef;

// =======================
// Parser rules
// =======================

program: statement* EOF;

statement
    : id '=' list ';'
    ;

list
    : '[' elements? ']'
    ;

elements
    : element (',' element)*
    ;

element
    : sign? (INT | FLOAT)
    | STRING
    | BOOL
    ;

sign
    : '+' 
    | '-'
    ;

id: ID;

// =======================
// Lexer rules
// =======================

BOOL
    : 'True'
    | 'False'
    ;

ID
    : [a-zA-Z_] [a-zA-Z_0-9]*
    ;

INT
    : '0'
    | [1-9] [0-9]*
    ;

FLOAT
    : INT '.' [0-9]+
    ;

STRING
    : '\'' (~['\r\n])* '\''
    ;

WS
    : [ \t\r\n]+ -> skip
    ;