using System;
using System.IO;

namespace GroceryCoKiosk
{

    public class FileHandler
    {
        static public String[] ReadFileGiven(String FileName)
        {           
            // Returns all lines in the given text file as a string array
            try
            {
                return File.ReadAllLines(FileName);
            }
            catch (FileNotFoundException)
            {
                ErrorHandling.DisplyError("File Not Found");
            }
            return null;
        }
    }

    public class ErrorHandling
    {
        static public void DisplyError(String Message)
        {
            // Displays the message to the console in red text
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Message);
            Console.ResetColor();
        }
    }
}
