
;								   ;
; "Greetings", v2.0.0.0 | austanss ;
;                                  ;

; This file is released to the public domain. ;

fnc main:
	dcl text1
	asv text1="main: Hello, world!"
	sto text1:stdout
	cll math
	cll function
	rtn

fnc function:
	dcl text2
	asv text2="function: Hello, world!"
	sto text2:stdout
	rtn

fnc math:
	dcl number
	aiv number=2
	mul number*4
	div number/2
	add number+5
	sub number-3
	rtn
