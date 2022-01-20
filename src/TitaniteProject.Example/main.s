
;								   ;
; "Greetings", v2.0.0.0 | austanss ;
;                                  ;

; This file is released to the public domain. ;

fnc main:
	dcl text1
	asv text1="main: Hello, world!"
	sto text1:stdout
	cll function
	rtn

fnc function:
	dcl text2
	asv text2="function: Hello, world!"
	sto text2:stdout
	rtn
