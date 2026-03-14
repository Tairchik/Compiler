all: lexer.l parser.y
	bison -d parser.y
	flex lexer.l

comp:
	gcc lex.yy.c parser.tab.c -o calculator

dll: 
	gcc -shared -o parser.dll lex.yy.c parser.tab.c wrapper.c -DYY_NO_UNISTD_H

clean:
	rm -f calculator.exe lex.yy.c parser.tab.*