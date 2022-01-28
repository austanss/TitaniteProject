
;								   ;
; "Greetings", v3.0.0.0 | austanss ;
;                                  ;

; This file is released to the public domain. ;

:main
	def text1
	set text1, "main: Hello, world!"
	wrr stdout, text1
	jmp math
	nop
	jmp func
	ret

:func
	def text2
	set text2, "function: Hello, world!"
	wrr stdout, text2
	ret

:math
	def number
	set number, 2
	mul number, 4
	div number, 2
	add number, 5
	sub number, 3
	ret
