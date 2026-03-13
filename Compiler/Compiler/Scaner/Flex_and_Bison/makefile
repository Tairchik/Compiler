all: lexer.l parser.y
	bison -d parser.y
	flex lexer.l


comp:
	gcc lex.yy.c parser.tab.c -o calculator

clean:
	rm -f calculator.exe lex.yy.c parser.tab.*