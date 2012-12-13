using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace SpeederTracker
{
    class DatabaseManager
    {
        public void submitToDatabase(int cameralocation, double speed)
        {
            //Tracker database filename
            string dbFilename = "TrackerData.xls";

            //Create new Excel Automation object
            Excel.Application excelApp = new Excel.Application();

            //Change default file path from MyDocuments to current directory
            excelApp.DefaultFilePath = Environment.CurrentDirectory;
            excelApp.DisplayAlerts = false;

            Excel.Workbook trackerDB; //workbook to be manipulated

            //Determine if this is first use of Tracker
            if (File.Exists(dbFilename))
            {
                trackerDB = excelApp.Workbooks.Open(dbFilename, 0, false, 5, "", "",
                    false, Excel.XlPlatform.xlWindows, "", true, false, 0,
                    true, false, false);
            }
            else
            {
                //open blank workbook with one sheet
                trackerDB = excelApp.Workbooks.Add();
            }

            //Reference the default worksheet
            Excel.Worksheet defaultSheet = (Excel.Worksheet)trackerDB.Worksheets.get_Item(1);
    		
            //If file didn't exist, it has still not been saved and still doesn't exist
            //if that's the case, set up the db title information
			if (!File.Exists(dbFilename))
			{
			    defaultSheet.Cells[1, 1] = "Camera Location";
				defaultSheet.Cells[1, 2] = "Speed";
			}
            
            //Reference the used range of the sheet
			Excel.Range range = defaultSheet.UsedRange;
            int newRow = range.Rows.Count + 1;

            //Insert new data after the used range
            defaultSheet.Cells[newRow, 1] = cameralocation;
            defaultSheet.Cells[newRow, 2] = speed;

            //Save and close db
            trackerDB.SaveAs(dbFilename, Excel.XlFileFormat.xlWorkbookNormal, Missing.Value, Missing.Value, 
                Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive);
            trackerDB.Close();
            excelApp.Quit();
        }
    }
}
