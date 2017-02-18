James Robertson

Email: jamesjrobertson42@gmail.com

Coding Exercise v.1.1.2 - GroceryCo

Run Application:
	...\GroceryCoKiosk\GroceryCoKiosk\bin\Release\GroceryCoKiosk.exe

To add items to the price catalog:
	Edit the Catalog.txt file in release folder, has examples
	Format: 
		[Name],[Price],[Promotion]/[Discount]/[Quantity]
		- Name can be anything (Required)
		- Price has to be a number (Required)
		- Promotion can be "onsale", "group", "additional" (Optional)
		- Discount has to be a number. 
			-- onsale is new price
			-- group is the price for the quantity given ex. 3 apples for $2.00
			-- additional is the price for the second item ex. buy one get for for [Discount]
		- Quantity is the amount of same items needed to get the promotion (at this point only group uses it)
	Notes: Duplicates will be ignored and an error will be displayed.
	       Errors will be displayed because of wrong formatting but program will continue with valid entries
	
Using Application:
	Will be prompted to type item names in or submit a file with a list, Basket.txt is an example.
	Once done type "checkout" to print the receipt.
	Will be notified if an item does not exist in the price catalog.
	Capital in-sensitive for product names and options.
	
Design:
	It is designed so only the Promotion.cs file needs to be changed when a new type of promotion is added.
	All items are created from the price catalog file.
	
	
Assumptions:
	1. An item can only have one promotion at a time.
	2. Input file ends in .txt
	3. All prices are in "$", in the Catalog file do not include any currency symbols.
	4. Promotions will be added to the Catalog file when they start and removed when they expire.
	5. The formatting to add items to the price catalog in this readme is accessible to GroceryCo staff.
	6. There can be a negative price, incase they want to add some sort of coupon or rebate item.