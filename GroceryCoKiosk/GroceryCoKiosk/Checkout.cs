using System;
using System.Collections.Generic;


namespace GroceryCoKiosk
{
    public class Checkout 
    {
        static double TotalPrice { get; set; } = 0.00;
        static List<String> Buying = new List<String>();

        static public void AddFileList(String FileName)
        {
            // Add items from the given file
            String[] Lines = FileHandler.ReadFileGiven(FileName);
            if (null != Lines) {
                foreach (String Line in Lines)
                {
                    AddItemToBuying(Line);
                }
            }        
        }

        static public void AddItemToBuying(String AddingItem)
        {
            // If item exists in catalog add it to the buyers list
            AddingItem = AddingItem.ToLower();
            if (CheckIfItemExists(AddingItem))
            {
                Buying.Add(AddingItem);
                Console.WriteLine("Added Item: " + AddingItem);
            }
        }

        static private bool CheckIfItemExists(String ItemName)
        {
            // If item exists in the catalog return true otherwise false
            if(PriceCatalog.getItemFromName(ItemName) != null)
            {
                return true;
            }
            Console.WriteLine("Item does not exist in price catalog: " + ItemName);
            return false;
        }

        

        static public void Finish()
        {
            Console.WriteLine("\nPrinting Receipt...\n");

            // Iterate through all the items that are being bought
            foreach (String item in Buying)
            {
                Item i = PriceCatalog.getItemFromName(item);
                Console.WriteLine(item);
               
                // Display original price
                Console.WriteLine("Regular price: $" + Math.Round(i._Price, 2));

                double price = i._Price;
                if (i.HasPromo())
                {
                    // If there is a dicounted price add that to total instead
                    price = i._Promo.CalculatedDiscountedPrice(i._Price);
                    if (price != i._Price)
                    {
                        // Display savings
                        Console.WriteLine("Special pricing: $" + Math.Round(price, 2));
                        Console.WriteLine("You saved: $" + Math.Round((i._Price - price),2));
                    }
                }
                
                // Add to total cost
                TotalPrice += price;
            }

            // Display total
            Console.WriteLine("Total: $" + Math.Round(TotalPrice,2));

            // Thank the customer
            Console.WriteLine("Thank you, please come again.\n");
            
            Clear();

        }

        static private void Clear()
        {
            // Reset the data for next transaction
            TotalPrice = 0.00;
            Buying.Clear();
        }
    }
}
