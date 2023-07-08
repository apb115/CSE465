; From community.tableau.com

; These are order numbers that were returned. Revenue and profit do not count toward totals.
(define RETURNS '(998 1412))

; Format of indiviudal sales
;(orderNum (orderDate shipDate) (grossSale discount profit unitPrice) (deliveryMethod province) product)
(define SALES '(
 (3 ("10/13/2010" "10/20/2010") (261.54 0.04 -213.25 38.94) ("Regular Air" "Nunavut") "Eldon Base for stackable storage shelf, platinum")
 (293 ("10/1/2012" "10/2/2012") (10123.02 0.07 457.81 208.16) ("Delivery Truck" "Northwest Territories") "1.7 Cubic Foot Compact Cube Office Refrigerators")
 (995 ("5/30/2011" "5/31/2011") (1815.49 0.03 782.91 39.89) ("Regular Air" "Nunavut") "Ultra Commercial Grade Dual Valve Door Closer")
 (998 ("11/25/2009" "11/26/2009") (248.26 0.07 93.80 15.74) ("Regular Air" "Nunavut") "#10-4 1/8 x 9 1/2 Premium Diagonal Seam Envelopes")
 (1154 ("2/14/2012" "2/16/2012") (4462.23 0.04 440.72 100.98) ("Delivery Truck" "Nunavut") "Hon 4-Shelf Metal Bookcases")
 (1154 ("2/14/2012" "2/16/2012") (663.784 0.25 -481.04 71.37) ("Regular Air" "Nunavut") "Lesro Sheffield Collection Coffee Table, End Table, Center Table, Corner Table")
 (1412 ("3/12/2010" "3/14/2010") (59.03 0.1 26.92 3.69) ("Express Air" "Nunavut") "Avery 52")
 (1412 ("3/12/2010" "3/14/2010") (97.48 0.05 -5.77 4.71) ("Regular Air" "Nunavut") "Plymouth Boxed Rubber Bands by Plymouth")
 (23584 ("3/12/2012" "3/14/2012") (2671.21 0.06 636.18 200.97) ("Delivery Truck" "Northwest Territories") "Hewlett-Packard Deskjet 6122 Color Inkjet Printer")
 (31270 ("11/23/2012" "11/24/2012") (6806.66 0 801.72 299.05) ("Delivery Truck" "Northwest Territories") "Global Comet� Stacking Armless Chair")
 (31270 ("11/23/2012" "11/25/2012") (891.61 0.1 -328.36 291.73) ("Delivery Truck" "Northwest Territories") "Hon 4070 Series Pagoda� Armless Upholstered Stacking Chairs")
 (31270 ("11/23/2012" "11/25/2012") (165.04 0.03 -112.44 30.42) ("Regular Air" "Northwest Territories") "Fellowes Internet Keyboard, Platinum")
 (44099 ("3/12/2012" "3/14/2012") (11823.52 0.1 4592.74 367.99) ("Regular Air" "British Columbia") "Ibico Ibimaster 300 Manual Binding System")
 (44099 ("3/12/2012" "3/14/2012") (80.81 0.1 -67.46 4.24) ("Regular Air" "British Columbia") "Storex DuraTech Recycled Plastic Frosted Binders")
 (56001 ("4/12/2010" "4/16/2010") (118.36 0.08 -60.65 6.48) ("Express Air" "British Columbia") "Xerox 210")
 (26756 ("5/10/2012" "5/10/2012") (767.26 0.07 -29.56 30.97) ("Regular Air" "British Columbia") "Microsoft Multimedia Keyboard")
 (26756 ("5/10/2012" "5/12/2012") (253.89 0.09 -103.77 6.48) ("Regular Air" "British Columbia") "Xerox 1894")
 (26756 ("5/10/2012" "5/12/2012") (127.9 0.07 -80.41 6.48) ("Regular Air" "British Columbia") "Xerox 210")
 (54177 ("1/25/2012" "1/25/2012") (480.73 0.1 148.20 42.8) ("Regular Air" "Ontario") "Wilson Jones Elliptical Ring 3 1/2 Capacity Binders, 800 sheets")
 (54177 ("1/25/2012" "1/27/2012") (159 0.1 -98.15 6.48) ("Regular Air" "Ontario") "Xerox 210")
 (55107 ("5/8/2010" "5/13/2010") (171.52 0.1 46.61 5.68) ("Regular Air" "Ontario") "Staples Standard Envelopes")
 )
)
