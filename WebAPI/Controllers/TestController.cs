#region PageSummary
// *****************************************************************
// Project:        MAQWebService
// Solution:       WebApi
//
// Author:  MAQ Software
// Date:    November 17, 2016
// Description: A Demo Controller class implemented.
//
// Change History:
// Name                         Date                    Version        Description
// -------------------------------------------------------------------------------
// Developer               November 17, 2016          1.0.0.0       Test demo controller.
// -------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// -------------------------------------------------------------------------------
#endregion

namespace MAQ.WebService.Template
{
    #region Using
    using System.Net.Http;
    using System.Web.Http;
    #endregion
    /// <summary>
    /// This class is a test controller.
    /// </summary>
    public class TestController : ApiController
    {
        HttpResponseMessage httpMessage = new HttpResponseMessage();
        /// <summary>
        /// This method is used to test the demo controller.
        /// </summary>
        /// <returns>HTTP message from demo string</returns>
        [HttpPost]
        public HttpResponseMessage Demo()
        {
            httpMessage.Content = new StringContent(Constants.DEMO_STRING);
            return httpMessage;
        }
    }
}
