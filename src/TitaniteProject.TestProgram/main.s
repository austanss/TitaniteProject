;;;;;; Instructions ;;;;;;
; dcl: declare variable: <type>.<identifier>
; ass: assign value: <identifier>=<value>
; sto: store variable in global context: <identifier>:<alias>
; lod: load variable from global context: <alias>:<identifier>
; cpy: copy variable value to another variable: <identifier>/<identifier>
; cll: call function: <identifier>
; fnc: define function: <identifier>:
; rtn: return to caller

;;;;;; Built-in Functions ;;;;;;
; puts: conout: prints <conout> to stdout, then linefeeds

fnc main:
	dcl str.text1
	ass text1="Hello, from the main function!"
	cpy text1/text1
	sto text1:conout
	lod conout:text1
	cll puts
	cll function
	rtn

fnc function:
	dcl str.text2
	ass text2="Hello again, from a callee function!"
	sto text2:conout
	cll puts
	rtn
