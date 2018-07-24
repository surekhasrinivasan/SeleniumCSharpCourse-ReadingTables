﻿using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTables
{
    public class Utilities
    {
       static List<TableDatacollection> _tableDatacollections = new List<TableDatacollection>();

        public static void ReadTable(IWebElement table)
        {
            //Get all the columns from the table 
            var columns = table.FindElements(By.TagName("th"));

            //Get all the rows 
            var rows = table.FindElements(By.TagName("tr"));

            //Create row Index
            int rowIndex = 0;

            foreach (var row in rows)
            {
                int colIndex = 0;

                var colDatas = row.FindElements(By.TagName("td"));

                foreach (var colValue in colDatas)
                {
                    _tableDatacollections.Add(new TableDatacollection
                    {
                        RowNumber = rowIndex,
                        ColumnName = columns[colIndex].Text != "" ?
                                     columns[colIndex].Text : colIndex.ToString(),
                        ColumnValue = colValue.Text,
                        ColumnSpecialValues = colValue.Text != "" ? null :
                                              colValue.FindElements(By.TagName("input"))
                    });

                    //Move to next column
                    colIndex++;
                }
                rowIndex++;
            }
        }

        public static string ReadCell(string columnName, int rowNumber)
        {
            var data = (from e in _tableDatacollections
                        where e.ColumnName == columnName && e.RowNumber == rowNumber
                        select e.ColumnValue).SingleOrDefault();
            return data;
        }

        public static void PerformActionOnCell(string columnIndex, string refColumnName, string refColumnValue, 
            string controlToOperate = null)
        {
            foreach (int rowNumber in GetDynamicRowNumber(refColumnName, refColumnValue))
            {
                var cell = (from e in _tableDatacollections
                            where e.ColumnName == columnIndex && e.RowNumber == rowNumber
                            select e.ColumnSpecialValues).SingleOrDefault();

                //Need to operate on those controls 
                if (controlToOperate != null && cell != null)
                {
                    var returnedControl = (from c in cell
                                          where c.GetAttribute("value") == controlToOperate
                                          select c).SingleOrDefault();

                    returnedControl?.Click();
                }
                else
                {
                    //if (cell != null) cell.First().Click();
                    //using interpolition
                    cell?.First().Click();
                }
            }
        }

        private static IEnumerable GetDynamicRowNumber(string columnName, string columnValue)
        {
            foreach (var table in _tableDatacollections)
            {
                //dynamic row
                if (table.ColumnName == columnName && table.ColumnValue == columnValue)
                    yield return table.RowNumber;
            }
        }
        
    }

    public class TableDatacollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }

        //create a list of IWebElements as we have 2 buttons
        public IEnumerable<IWebElement> ColumnSpecialValues { get; set; }
    }
}
