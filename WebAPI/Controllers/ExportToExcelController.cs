#region PageSummary
// *****************************************************************
// Project:        MAQWebService
// Solution:       WebApi
//
// Author:  MAQ Software
// Date:    November 25, 2016
// Description: To download or export the excel file, we use this service.
//
// Change History:
// Name                         Date                    Version        Description
// -------------------------------------------------------------------------------
// Developer               March 08, 2017          1.0.0.0       Web Service to download the excel file.
// -------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// -------------------------------------------------------------------------------
#endregion

#region MIT License 
/*MIT License

Copyright(c) 2017 MAQ Software

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sub license, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/

#endregion


namespace MAQ.WebService.Template
{
    #region using
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Http;
    #endregion
    /// <summary>
    /// Controller to export data to Excel
    /// </summary>
    public class ExportToExcelController : ApiController
    {
        /// <summary>
        /// Controller to download the Excel file.
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("api/Export")]
        public HttpResponseMessage Export()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constants.EXCEL_FOLDERNAME, Constants.EXCEL_FILE);

            //Get stream object from DB for export to Excel
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                if (1 <= fileStream.Length)
                {
                    response.Content = new StreamContent(fileStream);
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue(Constants.EXCEL_DISPOSITIONTYPE); // ?
                    response.Content.Headers.ContentDisposition.FileName = Constants.EXCEL_FILE;//your file Name- text.xls
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue(Constants.EXCEL_MEDIA_TYPE);
                    response.Content.Headers.ContentLength = fileStream.Length;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                // Do something here
                return null;
            }
        }
    }
}
