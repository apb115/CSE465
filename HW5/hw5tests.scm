(mydisplay "1. MODIT --------------------------------------")
(mydisplay (modIt '(1 2 3 4 5 6) 3))
(mydisplay (modIt '(1 2 3 4 5 6) 2))
(mydisplay (modIt '() 3))

(mydisplay "2. DIVISIBLEBY10 --------------------------------------")
(mydisplay (divisibleBy10 '(2 10 3 700 8000 5)))
(mydisplay (divisibleBy10 '(3 7 20 8)))
(mydisplay (divisibleBy10 '()))

(mydisplay "3. UNION --------------------------------------")
(mydisplay (union '(1 2 3) '(1 3 2)))
(mydisplay (union '(1 2 3) '(1 2 3 4)))
(mydisplay (union '(1 2) '(3 4)))
(mydisplay (union '() '(3 4)))

(mydisplay "4. NUMZEROS --------------------------------------")
(mydisplay (numZeros '(-9 2 3 0 -2 -8 0)))
(mydisplay (numZeros '(-1 1 2 3 4 -4 5)))
(mydisplay (numZeros '(-1 0 0)))
(mydisplay (numZeros '()))

(mydisplay "5. GETORDERSSHIPPEDON --------------------------------------")
(mydisplay (getOrdersShippedOn "3/14/2012" SALES))
(mydisplay (getOrdersShippedOn "2/29/2012" SALES))
(mydisplay (getOrdersShippedOn "1/25/2012" SALES))

;(mydisplay "6. FINDPROV --------------------------------------")
;(findProv SALES "Nunavut")

;(mydisplay "7. NONRETURNS --------------------------------------")
;(nonReturns SALES RETURNS)

;(mydisplay "8. FINALLST --------------------------------------")
;(mydisplay (finalLst (findProv SALES "Nunavut") (nonReturns SALES RETURNS)))
;
(mydisplay "9. TOTALPROFITPROV --------------------------------------")
(mydisplay (totalProfitProv "Nunavut" SALES RETURNS))
(mydisplay (totalProfitProv "Ontario" SALES RETURNS))

