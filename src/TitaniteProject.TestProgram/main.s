;;;;;; Instructions ;;;;;;
; dcl: declare variable: <type>.<identifier>
; ass: assign value: <identifier>=<value>
; sto: store variable in global context: <identifier>:<alias>
; lod: load variable from global context: <alias>:<identifier>
; cpy: copy variable value to another variable: <identifier>/<identifier>

; fnc: define function: <identifier>:
; cll: call function: <identifier>
; rtn: return to caller

fnc main:
	dcl str.text1
	ass text1="Hello, from the main function!"
	cpy text1/text1
	sto text1:stdout
	cll function
	rtn

fnc function:
	dcl str.text2
	ass text2="Hello again, from a callee function!"
	sto text2:stdout
	rtn
