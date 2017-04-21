#region PageSummary
// *****************************************************************
// Project:        MAQWebService
// Solution:       WebApi
//
// Author:  MAQ Software
// Date:    November 25, 2016
// Description: To download or export the excel file, we use this class.
//
// Change History:
// Name                         Date                    Version        Description
// -------------------------------------------------------------------------------
// Developer               November 25, 2016          1.0.0.0       Webpage to download the excel file.
// -------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// -------------------------------------------------------------------------------
#endregion
namespace MAQ.WebService.Template
{
    #region
    using ClosedXML.Excel;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    #endregion
    /// <summary>
    /// ExportExcel is a code behind class to generate and export the excel file
    /// </summary>
    public partial class ExportExcel : System.Web.UI.Page
    {
        /// <summary>
        /// Default values and controls are loaded on page.
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.</param>
        /// <param name="e">EventArgs is a parameter called e that contains the event data</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rowJsonText = Server.UrlDecode(Request.Form[Constants.HTTP_CONTENT]);
                string jsonText = rowJsonText.Replace(Constants.PIPE_SEPARATOR, Constants.NEWLINE);
                if (!string.IsNullOrWhiteSpace(jsonText))
                {
                    using (XLWorkbook workBook = new XLWorkbook())
                    {
                        IXLWorksheets workSheets = workBook.Worksheets;
                        IXLWorksheet workSheet = workSheets.Add(Constants.SHEET_NAME);
                        string[] excelHeaders = Constants.EXCEL_HEADERS.Split(Constants.CHAR_SEMICOLON);
                        AddColumnHeaders(workSheet, excelHeaders);
                        AddDataToExcel(jsonText, workSheet);
                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = string.Empty;
                        Response.ContentType = Constants.CONTENT_TYPE;
                        Response.AddHeader(Constants.EXCEL_HEADER_NAME, string.Format(CultureInfo.InvariantCulture, Constants.EXCEL_HEADER_VALUE, Constants.EXCEL_FILENAME, string.Format(CultureInfo.InvariantCulture, string.Concat(Constants.ZERO_PLACEHOLDER, Constants.EXPORT_TO_EXCEL_FILENAME_DATEFORMAT, Constants.CLOSING_BRACKET), Convert.ToDateTime(DateTime.Now, CultureInfo.InvariantCulture))));
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            workBook.SaveAs(memoryStream);
                            memoryStream.WriteTo(Response.OutputStream);
                        }
                    }
                }
                else
                {
                    // Do logging
                }
            }
            catch (Exception)
            {
                // Do logging
            }
            finally
            {
                Response.Flush();
                Response.End();
            }
        }
        /// <summary>
        /// Adds headers to excel.
        /// </summary>
        /// <param name="workSheet">Worksheet for which header needs to be added</param>
        /// <param name="excelColumns">array list of headers which includes the headers for the excel</param>
        private static void AddColumnHeaders(IXLWorksheet workSheet, string[] excelColumns)
        {
            // Add column Titles
            for (int index = 0; index < excelColumns.Length; index++)
            {
                workSheet.Cell(1, index + 1).Value = excelColumns[index];
            }
            // use below line to set auto filter on
            //workSheet.RangeUsed().SetAutoFilter();
            IXLRange headers = workSheet.RangeUsed();
            headers.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            headers.Style.Font.Bold = true;
            headers.Style.Font.FontColor = XLColor.White;
            headers.Style.Fill.BackgroundColor = XLColor.AirForceBlue;
        }
        /// <summary>
        /// Method used to add values to excel file
        /// </summary>
        /// <param name="jsonText">Is a json value for which excel needs to be created.</param>
        /// <param name="workSheet">Worksheet for which header needs to be added</param>
        private static void AddDataToExcel(string jsonText, IXLWorksheet workSheet)
        {
            //Add data rows
            int rowCount = 2;
            //make a new string list
            List<string> jsonList = jsonText.Split(Constants.CHAR_NEWLINE).ToList();
            foreach (string jsonListItem in jsonList)
            {
                List<string> rowValue = new List<string>(); //make a new string list    
                rowValue.AddRange(jsonListItem.Split(Constants.CHAR_SEMICOLON));
                for (int iCount = 0; iCount < rowValue.Count; iCount++)
                {
                    if (0 > rowValue[iCount].Trim().Length)
                    {
                        workSheet.Cell(rowCount, iCount + 1).Value = string.Empty;
                    }
                    else
                    {
                        workSheet.Cell(rowCount, iCount + 1).Value = (string.IsNullOrWhiteSpace(Convert.ToString(rowValue[iCount], CultureInfo.InvariantCulture))) ? string.Empty : rowValue[iCount];
                    }
                }
                rowCount++;
                workSheet.Columns().AdjustToContents();
            }
        }
    }
}