using System;

namespace GroceryCoKiosk
{
    public class Item
    {
        public String _Name { get; set; }
        public double _Price { get; set; }
        public Promotion _Promo { get; set; }
        
        public Item(String Name, double Price)
        {
            _Name = Name.ToLower();
            _Price = Price;
        }

        public Item(String Name, double Price, Promotion Promo)
        {
            _Name = Name.ToLower();
            _Price = Price;
            _Promo = Promo;
        }

        public bool HasPromo()
        {
            // returns true if there is a promotion for the item 
            if (_Promo == null)
            {
                return false;
            }
            return true;
        }

        static public Item CreateItem(String Parameters)
        {
            // Parameters should be one line from the catalog file unsplit and not error checked
            String[] seperator = { "," };
            String[] elements = Parameters.Split(seperator, StringSplitOptions.RemoveEmptyEntries);


            // Not enough parameters to create an item
            if (elements.Length < 2)
            {
                return null;
            }

            // Item already exists duplicates not allowed
            if (null != PriceCatalog.getItemFromName(elements[0].ToLower()))
            {
                ErrorHandling.DisplyError("Item already exists: " + elements[0]);
                return null;
            }

            // Extract the price from the string parameters
            double d;
            if (!double.TryParse(elements[1], out d))
            {
               ErrorHandling.DisplyError("Failed to parse price (double) from: " + Parameters);
                return null;
            }

            // If the item has no promotions create it without
            if (elements.Length < 3)
            {
                return new Item(elements[0], d);
            }
            // If the item has a promotion create it with one
            else if(elements.Length >= 3)
            {
                return new Item(elements[0], d, Factory.PromotionFactory(elements[2]));
            }

            // Criteria not met to create item
            return null;
        }           
           
    }
}
