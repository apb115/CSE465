; Use = to compare numbers

; Andrew Boothe
; CSE 465
; 2/25/2023

; Helper function - do not change
(define (mydisplay value)
	(display value)
	(newline)
	#t
)


(define pi 3.14159)

;;; Complete the code for the functions below.
;;; You are allowed to add your own helper functions.

; Calculates the area of a circle with radius r
; The formula for area is pi * r^2
(define (circleArea r)
	(* pi r r)
)

(mydisplay "1. CIRCLEAREA --------------------------------------")
(mydisplay (circleArea 3))
(mydisplay (circleArea 10))
(mydisplay (circleArea 2))
(mydisplay (circleArea 5))


; Returns true if l and w are equal, and they are both greater than 0; false otherwise
(define (isSquare l w)
	(if (and (= l w) (> l 0) (> w 0)) #t #f) 
)

(mydisplay "2. ISSQUARE --------------------------------------")
(mydisplay (isSquare 3 2))
(mydisplay (isSquare 10 10))
(mydisplay (isSquare 2 7))
(mydisplay (isSquare -5 -5))


; Calculates x raised to the power y
; Assume that y is a non-negative number (i.e., y >= 0)
(define (power x y)
	(if (< y 0) #null)
	(expt x y)
)


; Tests
(mydisplay "3. POWER --------------------------------------")
(mydisplay (power 3 0))
(mydisplay (power 3 1))
(mydisplay (power 3 2))
(mydisplay (power 3 3))


; Returns the average of the values in the list 
; and #f if the list is empty
; You may want to create a helper function for sum

(define (lstSum lst)
	(if (= (length lst) 1)
		(car lst)
		(+ (car lst) (lstSum (cdr lst)))
	)
)

(define (avg lst)
	(cond
		((= (length lst) 1) (car lst))
		((= (length lst) 0) #f)
		(else (/ (lstSum lst) (length lst) ))
	)
)

; Tests
(mydisplay "4. AVG --------------------------------------")
(mydisplay (avg '(1 2 3)))
(mydisplay (avg '(1 2 1 1 14 1 5 6)))
(mydisplay (avg '()))
(mydisplay (avg '(1)))



; Calculate taxes paid based on income
; We'll use the following tax brackets for individual income
; income below $10,275 - 10%
; income from $10,276 to 41,775 - 12%
; income from 41,776 to 89,075 - 22%
; income from 89,076 to 170,050 - 24%
; income from 170,051 to 215,950 - 32%
; income from 215,951 to 539,900 - 35%
; income of 539,901 or more - 37%
(define (tax income)
	(cond
		((< income 10275) (* income .1))
		((and (> income 10275) (< income 41776)) (* income .12))
		((and (> income 41775) (< income 89076)) (* income .22))
		((and (> income 89075) (< income 170051)) (* income .24))
		((and (> income 170050) (< income 215951)) (* income .32))
		((and (> income 215950) (< income 539901)) (* income .35))
		(else (* income .37))
	)
)

; Tests
(mydisplay "5. TAX --------------------------------------")
(mydisplay (tax 7000))
(mydisplay (tax 30000))
(mydisplay (tax 600000))
(mydisplay (tax 175000))


; Returns a list containing only those items in lst that have exactly 3 digits
; Assume that all numbers in lst are positive
; For example (threeDigitsOnly '(123 4 65 785 2 900)) should return
; (123 785 900)

(define (counter val)
	(if (< val 10) 
		1
		(+ (counter (/ val 10)) 1))
)

(define (threeDigitsOnly lst)
	(cond
			((null? lst) '())
			((= (counter (car lst)) 3) (cons (car lst) (threeDigitsOnly (cdr lst))))
			(else (threeDigitsOnly (cdr lst)))
	)
)

; Tests
(mydisplay "6. THREEDIGITSONLY --------------------------------------")
(mydisplay (threeDigitsOnly '(123 4 65 785 2 900)))
(mydisplay (threeDigitsOnly '(1 41 62 0)))
(mydisplay (threeDigitsOnly '(111 222 3333 44 57685)))
(mydisplay (threeDigitsOnly '()))



; The following exercises will use the following format for individual sales
;(orderNum (orderDate shipDate) (grossSale discount profit unitPrice) (deliveryMethod province) product)

; Returns the unit price information out of a given record for a sale.
; (getUnitPrice '(3 ("10/13/2010" "10/20/2010") (261.54 0.04 -213.25 38.94) ("Regular Air" "Nunavut") "Eldon Base for stackable storage shelf, platinum")) -> 38.94
(define (getUnitPrice sale)
	(cdr (cdr (cdr (caddr sale))))
)

; Tests
(mydisplay "7. GETUNITPRICE --------------------------------------")
(mydisplay (getUnitPrice '(3 ("10/13/2010" "10/20/2010") (261.54 0.04 -213.25 38.94) ("Regular Air" "Nunavut") "Eldon Base for stackable storage shelf, platinum")))
(mydisplay (getUnitPrice '(293 ("10/1/2012" "10/2/2012") (10123.02 0.07 457.81 208.16) ("Delivery Truck" "Northwest Territories") "1.7 Cubic Foot Compact Cube Office Refrigerators")))


; Returns the province information out of a given record for a sale.
; (getProv '(3 ("10/13/2010" "10/20/2010") (261.54 0.04 -213.25 38.94) ("Regular Air" "Nunavut") "Eldon Base for stackable storage shelf, platinum")) -> Nunavut
(define (getProv sale)
	(cdr (cadddr sale))
)

; Tests
(mydisplay "8. GETPROV --------------------------------------")
(mydisplay (getProv '(3 ("10/13/2010" "10/20/2010") (261.54 0.04 -213.25 38.94) ("Regular Air" "Nunavut") "Eldon Base for stackable storage shelf, platinum")))
(mydisplay (getProv '(293 ("10/1/2012" "10/2/2012") (10123.02 0.07 457.81 208.16) ("Delivery Truck" "Northwest Territories") "1.7 Cubic Foot Compact Cube Office Refrigerators")))


; Returns true if the profit of a given sale record is a positive number, false otherwise
; (isProfitPos '(3 ("10/13/2010" "10/20/2010") (261.54 0.04 -213.25 38.94) ("Regular Air" "Nunavut") "Eldon Base for stackable storage shelf, platinum")) -> #f
(define (isProfitPos sale)
	(> (car (cdr (cdr (caddr sale)))) 0)
)

; Tests
(mydisplay "9. ISPROFITPOS --------------------------------------")
(mydisplay (isProfitPos '(3 ("10/13/2010" "10/20/2010") (261.54 0.04 -213.25 38.94) ("Regular Air" "Nunavut") "Eldon Base for stackable storage shelf, platinum")))
(mydisplay (isProfitPos '(293 ("10/1/2012" "10/2/2012") (10123.02 0.07 457.81 208.16) ("Delivery Truck" "Northwest Territories") "1.7 Cubic Foot Compact Cube Office Refrigerators")))


; Returns a triple consisting of the orderNum, profit, and product information out of a given record for a sale.
; (getProv '(3 ("10/13/2010" "10/20/2010") (261.54 0.04 -213.25 38.94) ("Regular Air" "Nunavut") "Eldon Base for stackable storage shelf, platinum")) -> (3 -213.25 "Eldon Base for stackable storage shelf, platinum")

(define (getUnit sale)
	(cdr (cdr (cdr (cdr sale))))
)
(mydisplay (getUnit '(3 ("10/13/2010" "10/20/2010") (261.54 0.04 -213.25 38.94) ("Regular Air" "Nunavut") "Eldon Base for stackable storage shelf, platinum")))


(define (getSummary sale)
	(list (car sale) (car (cdr (cdr (caddr sale)))) (car (getUnit sale)))
)

; Tests
(mydisplay "10. GETSUMMARY --------------------------------------")
(mydisplay (getSummary '(3 ("10/13/2010" "10/20/2010") (261.54 0.04 -213.25 38.94) ("Regular Air" "Nunavut") "Eldon Base for stackable storage shelf, platinum")))
(mydisplay (getSummary '(293 ("10/1/2012" "10/2/2012") (10123.02 0.07 457.81 208.16) ("Delivery Truck" "Northwest Territories") "1.7 Cubic Foot Compact Cube Office Refrigerators")))



; Returns a triple consisting of the orderNum, orderDate, and shipDate information out of a given record for a sale.
; (getProv '(3 ("10/13/2010" "10/20/2010") (261.54 0.04 -213.25 38.94) ("Regular Air" "Nunavut") "Eldon Base for stackable storage shelf, platinum")) -> (3 "10/13/2010" "10/20/2010")
(define (getDatesSummary sale)
	(list (car sale) (car (cadr sale)) (car (cadr sale)))
)

; Tests
(mydisplay "11. GETDATESSUMMARY --------------------------------------")
(mydisplay (getDatesSummary '(3 ("10/13/2010" "10/20/2010") (261.54 0.04 -213.25 38.94) ("Regular Air" "Nunavut") "Eldon Base for stackable storage shelf, platinum")))
(mydisplay (getDatesSummary '(293 ("10/1/2012" "10/2/2012") (10123.02 0.07 457.81 208.16) ("Delivery Truck" "Northwest Territories") "1.7 Cubic Foot Compact Cube Office Refrigerators")))


; Uncomment the line below if you are using scheme on ceclnx01
; ,exit
