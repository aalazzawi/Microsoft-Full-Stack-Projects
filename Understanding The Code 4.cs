// Declaring the Resources usage for this program
using System;
using System.IO;
using System.Text;

// Creating and naming the main container for this program
namespace _9_4HTML
{
    // Creating Class for the file header that contain variaqbles holds the opening and closing codes for the header paragraph 
    /* And a method for adding a text to the opening and closing codes and store it in avariable with the return built in function
       to send the contains to the code that called the method*/
    class Header
    {
        public const string open = "<h1>";
        public const string close = "</h1>";

        public string CreateHeader(string text)
        {
            string header = String.Concat(open, text, close, "\n");
            return header;
        }
    }

    // Creating Class for the file unordered list contain variaqbles holds the opening and closing codes for the list  
    /* And a method for adding a text to the opening and closing codes and store it in avariable with the return built in function
       to send the contains to the code that called the method*/
    class UnorderedList
    {
        public const string open = "<ul>";
        public const string close = "</ul>";

        public string CreateListItem(string text)
        {
            string open = "<li>\n";
            string close = "</li>\n";

            string listItem = String.Concat(open, text, close, "\n");
            return listItem;
        }

        /* Creating a new object of type stringbuilder to hold the list includes the following:
           Create a new variable of string builder type using the string builders function
           Open the sb append function that will call and cycle the comtains of listItem using the foreach function
           store the contains of listItem in the local item variable and append it's value each cycle to the sb variable
           close the procedure after the last cycle and return the sb variablr contains to the calling code in the program class */
        public StringBuilder CreateList(string[] listItems)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(open);
            foreach (string item in listItems)
            {
                sb.Append(item);
            }
            sb.Append(close);

            return sb;
        }

    }



    // Creating the program Class that will run the program using the other Classes
    class Program
    {

        // Indicating that the Class has a parameter which is a reference to an array of String type
        static void Main(string[] args)
        {
            // Creating a custom file distination and store it in a variable
            string filename = "C://weblogs//9_4Lab.html";

            // Creating 2 new objects of header and unorderedlist 
            Header header = new Header();
            UnorderedList list = new UnorderedList();
           
            // Creating a new instance of the StringBuilder Class
            StringBuilder sb = new StringBuilder();

            // Console write text require input from the user
            Console.WriteLine("Enter text for HTML header.");

            // Console red the user input and use it as a parameter for the CreateHeader method of the header class
            // And store the value to a nea headerElement variable
            string headerElement = header.CreateHeader(Console.ReadLine());

            // Creating listItems as a new array list of 3 items type string
            string[] listItems = new string[3];

            // For loop using the new array list to cycle through, storing the value in the local variable each time
            for (int i = 0; i < listItems.Length; i++)
            {
                // In each cycle the console write asking the user for more input
                // And red the input and uset as a parameter for the Creatlist method of Class list (instance of class unorderedList)
                // Then store the value in the listItem of that cycle
                Console.WriteLine("Add another item to the list.");
                listItems[i] = list.CreateListItem(Console.ReadLine());
            }

            // Using the accumulated value of array listItems as a parameter for CreateList method of the list class
            // And store it in listElemen variable
            StringBuilder listElement = list.CreateList(listItems);

            // Append the contais of headerElement and listElement to the sb class after turning the listElement value to string
            sb.Append(headerElement);
            sb.Append(listElement.ToString());


            // using the Fill.AppendAllText method to append all to the HTML file
            File.AppendAllText(filename, sb.ToString());

        }
    }
}