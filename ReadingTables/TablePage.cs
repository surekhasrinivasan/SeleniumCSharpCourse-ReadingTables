using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTables
{
    public class TablePage : Base
    {
        [Obsolete("The PageFactory implementation in the .NET bindings is deprecated and will be removed in a future release. This portion of the code has been migrated to the DotNetSeleniumExtras repository on GitHub (https://github.com/DotNetSeleniumTools/DotNetSeleniumExtras)")]
        public TablePage()
        {
            PageFactory.InitElements(Driver, this);                  
        }

        [FindsBy(How =How.XPath, Using ="//table")]
        public IWebElement table { get; set; }
    }
}
