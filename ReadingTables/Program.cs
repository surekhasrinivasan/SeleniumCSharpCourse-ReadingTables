using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTables
{
    class Program : Base
    {
        [Obsolete("The PageFactory implementation in the .NET bindings is deprecated and will be removed in a future release. This portion of the code has been migrated to the DotNetSeleniumExtras repository on GitHub (https://github.com/DotNetSeleniumTools/DotNetSeleniumExtras)")]
        static void Main(string[] args)
        {
            Driver = new ChromeDriver();

            Driver.Navigate().GoToUrl("file:///C:/Users/Sreenath/source/repos/ReadingTables/complexTablePage.html");
            
            TablePage page = new TablePage();

            //Read Table
            Utilities.ReadTable(page.table);

            //Get the cell value from the table 
            //Console.WriteLine(Utilities.ReadCell("Email", 1));

            Console.WriteLine("******************************************************************************");
            Console.WriteLine("The name is {0} with Email {1} and phone {2}",
                Utilities.ReadCell("Name", 1), Utilities.ReadCell("Email", 1), Utilities.ReadCell("Phone", 1));
            Console.WriteLine("The name is {0} with Email {1} and phone {2}",
                Utilities.ReadCell("Name", 2), Utilities.ReadCell("Email", 2), Utilities.ReadCell("Phone", 2));
            Console.WriteLine("The name is {0} with Email {1} and phone {2}",
                Utilities.ReadCell("Name", 3), Utilities.ReadCell("Email", 3), Utilities.ReadCell("Phone", 3));
            Console.WriteLine("*******************************************************************************");

            //Delete Prashanth
            //Utilities.PerformActionOnCell("5", "Name", "Prashanth", "Delete");
            //Utilities.PerformActionOnCell("5", "Name", "Prashanth", "Save");

            Utilities.PerformActionOnCell("Option", "Name", "Prashanth");
            Console.Read();
        }
    }
}
