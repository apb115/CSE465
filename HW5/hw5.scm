; Use = to compare numbers
; use equal? to compare anything else (e.g., strings, lists)

; Use scheme48 on the ceclnx01 server for this assignment

,open big-util

; Helper function - do not change
(define (mydisplay value)
	(display value)
	(newline)
	#t
)

; Returns a list containing the original list's values modulo c.
; *** You are required to use the built-in function map in your solution! ***
; lst is a flat list of integers and c is an integer
(define (modIt lst c)
	(cond
			((null? lst) '())
			(list (map (lambda (x) (modulo x c)) lst) )
	)
)

; Returns a list containing only the elements divisible by 10 from the 
; input list lst
; *** You are required to use the built-in function filter in your solution! ***
; lst is a flat list of integers
(define (divisibleBy10 lst)
	(cond
			((null? lst) '())
			(else (filter (lambda (x) (= (modulo x 10) 0)) lst) ) 
	)
)

; Returns the union of two sets. The inputs are flat lists
; of atoms. The result is a flat list containing all the elements
; that appear in at least one of the two lists. No duplicates 
; should be present in the result. Order is not important.
; ***You can use the built-in functions memq? and/or remove-duplicates
; (see here: https://s48.org/1.1/manual/s48manual_36.html)
; 	(memq? value list) -> boolean 
;   	Returns true if value is in list, false otherwise.
; 	(remove-duplicates list) -> list 
; 		Returns its argument with all duplicate elements removed. 
;		The first instance of each element is preserved.
; (union '(1 2 3) '(1 3 2)) -> (1 2 3) ; order does not matter
; (union '(1 2 3) '(1 2 3 4)) -> (1 2 3 4)
; (union '(1 2) '(3 4)) -> (1 2 3 4)
(define (union lst1 lst2)
	(remove-duplicates (append lst1 lst2)) 
)

; Transform the function below in its tail recursive version
; (define (numZeros lst)
;	(if (null? lst) 
;		0 
; 		(+ (if (= 0 (car lst)) 1 0) (numZeros (cdr lst)))
;	)
;)
; The function calculates the number of 0 elements appearing in lst
; Recall that the tail recursive version will need a helper function
(define (numZerosHelper lst partial)
	(if (null? lst) 
		partial
		(if (= 0 (car lst)) 
			(numZerosHelper (cdr lst) (+ 1 partial)) 
			(numZerosHelper (cdr lst) partial) 
		)
	)
)

(define (numZeros lst)
	(numZerosHelper lst 0)
)


; sales.scm contains all the company's sales.
; You should not modify that file. 
(load "sales.scm")


; Returns the set (i.e., list with no duplicates) of order numbers
; that were shipped on a given date.
(define (getOrdersShippedOn date sales)
	(cond
		((null? sales) '())
		( (equal? (car (cdr (car (cdr (car sales))))) date) (remove-duplicates (cons (car (car sales)) (getOrdersShippedOn date (cdr sales)))))
		(else (getOrdersShippedOn date (cdr sales)))
	)
)

; Returns the total profit for a given province prov. 
; Returned orders (whose order numbers are listed in the returns list)
; should not be included in this calculation!
(define (totalProfitProv prov sales returns)	
	(cond
		((null? sales) 0)
		((and (equal? (car (cdr (car (cdr (cdr (cdr (car sales))))))) prov) (not (memq? (caar sales) returns))) (+ (car (cdr (cdr (car (cdr (cdr (car sales))))))) (totalProfitProv prov (cdr sales) returns)))
		(else (totalProfitProv prov (cdr sales) returns))
	)	
)

; Do not modify the following line
(load "hw5tests.scm")

,exit
