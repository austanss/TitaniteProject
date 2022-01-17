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
	dcl str.output
	ass output="Hello, world!"
	cpy output/output
	sto output:conout
	lod conout:output
	cll puts
	rtn