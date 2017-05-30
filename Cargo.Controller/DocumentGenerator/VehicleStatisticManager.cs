using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.DB;
using Cargo.Domain.Entities;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop;
using Microsoft.Office.Core;
using Cargo.Controller;
using Cargo.Controller.Models;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace Cargo.Controller.DocumentGenerator
{
    public class VehicleStatisticManager
    {
        private const string templateFilePath = @"D:\Projects\University\Cargo\Cargo.Controller\DocumentTemplates\DriverSallary_Template.doc";
        private const string outputDir = @"D:\Projects\University\Cargo\Reports\DriverSallary";


        public void generate(VehicleModel vm, List<KeyValuePair<string, int>> vals)
        {
            using (var db = new CargoDbContext())
            {
                Vehicle veh = db.Vehicles.Where(e => e.VehicleId == vm.ID).First();
                List<RouteReport> reports = veh.RouteReports.ToList();
                foreach (var report in reports)
                {
                    Cargo.Domain.Entities.Application app = report.Applications.First();
                    vals.Add(new KeyValuePair<string, int>(report.StartDate.ToString("dd.MM.yyyy"), (int)app.Compensation));
                }
            }
        }

        public void generate()
        {
            object oMissing = System.Reflection.Missing.Value;

            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            _Application oWord;
            _Document oDoc;
            oWord = new Microsoft.Office.Interop.Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);

            //Insert a chart.
            InlineShape oShape;
            object oClassType = "MSGraph.Chart.8";
            Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oShape = wrdRng.InlineShapes.AddOLEObject(ref oClassType, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing);

            //Demonstrate use of late bound oChart and oChartApp objects to
            //manipulate the chart object with MSGraph.
            object oChart;
            object oChartApp;
            oChart = oShape.OLEFormat.Object;
            oChartApp = oChart.GetType().InvokeMember("Application",
             BindingFlags.GetProperty, null, oChart, null);

            //Change the chart type to Line.
            object[] Parameters = new Object[1];
            Parameters[0] = 4; //xlLine = 4
            oChart.GetType().InvokeMember("ChartType", BindingFlags.SetProperty,
            null, oChart, Parameters);

            //Update the chart image and quit MSGraph.
            oChartApp.GetType().InvokeMember("Update",
            BindingFlags.InvokeMethod, null, oChartApp, null);
            oChartApp.GetType().InvokeMember("Quit",
            BindingFlags.InvokeMethod, null, oChartApp, null);
            //... If desired, you can proceed from here using the Microsoft Graph 
            //Object model on the oChart and oChartApp objects to make additional
            //changes to the chart.

            //Set the width of the chart.
            oShape.Width = oWord.InchesToPoints(6.25f);
            oShape.Height = oWord.InchesToPoints(3.57f);

            //string filename = Guid.NewGuid().ToString() + ".doc";
            //string outFilePath = Path.Combine(outputDir, filename);
            //oDoc.SaveAs(outFilePath);
            //oDoc.Close();
            //// TODO: use singleton
            //oWord.Quit();
    //        Process.Start("WINWORD.EXE", outFilePath);

        }
    }
}
