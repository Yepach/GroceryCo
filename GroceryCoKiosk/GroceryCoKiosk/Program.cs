namespace GroceryCoKiosk
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Read in the item catalog for all items and associated promotions in the given file "Catalog.txt"
                PriceCatalog.ReadPriceCatalog();

                // Start the interaction with the user
                UserInteraction.Start();
               
                // Print the recipt, calculate cost, clear data
                Checkout.Finish();    
                
                // Repeat            
            }
        }
    }
}
