#region PageSummary
// *****************************************************************
// Project:        MAQWebService
// Solution:       WebApi
//
// Author:  MAQ Software
// Date:    November 17, 2016
// Description: A Controller class used to test CORS Policy implemented.
//
// Change History:
// Name                         Date                    Version        Description
// -------------------------------------------------------------------------------
// Developer               November 17, 2016          1.0.0.0       Test controller for CORS policy.
// -------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// -------------------------------------------------------------------------------
#endregion
namespace MAQ.WebService.Template
{
    #region using
    using System.Net.Http;
    using System.Web.Http;
    #endregion
    /// <summary>
    /// Controller used to Test CORS Policy.
    /// </summary>
    [AllowCorsAttribute]
    public class CorsController : ApiController
    {
        HttpResponseMessage httpMessage = new HttpResponseMessage();
        /// <summary>
        /// A method used to test Get Message
        /// </summary>
        /// <returns>String value as HTTP Response</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            // Event Logger is used here only for testing purpose. For every time Get message is hit, there is an event logged in event viewer.
            httpMessage.Content = new StringContent(Constants.ERROR_GET);
            return httpMessage;
        }
        /// <summary>
        /// A method used to test Post Message
        /// </summary>
        /// <returns>String value as HTTP Response</returns>
        [HttpPost]
        public HttpResponseMessage Post()
        {
            httpMessage.Content = new StringContent(Constants.ERROR_POST);
            return httpMessage;
        }
    }
}
