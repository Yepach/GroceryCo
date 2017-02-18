using System;

namespace GroceryCoKiosk
{
    class UserInteraction
    {
        enum UserAction{
            TextFile,
            Done,
            Item
        };

        static public void Start()
        {
            String response;
            bool AddingItems = true;

            // Welcoming message
            Console.WriteLine("Wecome to GroceryCo");
                       
            do
            {
                // Get the users input and display options
                Console.WriteLine("\nPlease input the basket file name or input the item name to scan.\n" +
                    "Type \"checkout\" when finished.");
                response = Console.ReadLine();
               
                // Act on users input
                switch (CheckUserInput(response))
                {
                    // A text file was inputted
                    case UserAction.TextFile:
                        Checkout.AddFileList(response);
                        break;
                    // The user is finished with the transaction
                    case UserAction.Done:
                        AddingItems = false;
                        break;
                    // Attempt to add item inputted
                    case UserAction.Item:
                        Checkout.AddItemToBuying(response);
                        break;
                }
            }
            while (AddingItems);
        }

        static private UserAction CheckUserInput(String Line)
        {
            // Check for a text file otherwise put to lowercase
            if (Line.Contains(".txt"))
                Line = ".txt";          

            // Return value according to users desired action
            switch (Line)
            {
                case ".txt":
                    return UserAction.TextFile;
                case "checkout":
                    return UserAction.Done;
                default:
                    return UserAction.Item;
            }
        }
    }
}
