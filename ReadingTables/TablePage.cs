﻿using OpenQA.Selenium;
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
        public TablePage()
        {
            PageFactory.InitElements(Driver, this);                  
        }

        [FindsBy(How =How.XPath, Using ="//table")]
        public IWebElement table { get; set; }
    }
}
