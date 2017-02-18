using System;
using System.Collections.Generic;

namespace GroceryCoKiosk
{
    public class PriceCatalog
    {
        static public String PriceCatalogFileName = @"Catalog.txt";
        static public List<Item> _PriceCatalog = new List<Item>(); 

        static public void ReadPriceCatalog()
        {
            // Clear current PriceCatalog so we can update any changes
            ClearPriceCatalog();

            // Read in the price catalog file
            String[] lines = FileHandler.ReadFileGiven(PriceCatalogFileName);
            if(null != lines) {
                // Null error handled in reading file (means file didnt exist)
                foreach (String line in lines)
                {
                    // Add each item from the file into the catalog
                    AddItemToPriceCatalog(Item.CreateItem(line));
                }
            }

            if (_PriceCatalog.Count == 0)
            {   
                // The file given exists but was empty
                ErrorHandling.DisplyError("Price catalog is empty");
            }        
        }

        static private void AddItemToPriceCatalog(Item AdditionalItem)
        {
            // Add the given item if it was sucessfully created
            if(null != AdditionalItem)
            {
                _PriceCatalog.Add(AdditionalItem);
            }
            else
            {
                ErrorHandling.DisplyError("Price catalog was not able to add an item.");
            }
        }

        static private void ClearPriceCatalog()
        {
            // Reset any items for the price catalog here
            _PriceCatalog.Clear();
        }

        static public Item getItemFromName(String ItemName)
        {
            // Return the item based on the name given
            try
            {
                foreach (Item i in _PriceCatalog)
                {
                    if (i._Name.Equals(ItemName))
                    {
                        return i;
                    }
                }
            }
            catch (NullReferenceException)
            {
                ErrorHandling.DisplyError("Price Catalog is empty.");
            }

            return null;
        }
    }
}
