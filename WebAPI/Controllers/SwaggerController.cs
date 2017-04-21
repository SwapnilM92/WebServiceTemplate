#region PageSummary
// *****************************************************************
// Project:        MAQWebService
// Solution:       WebApi
//
// Author:  MAQ Software
// Date:    November 17, 2016
// Description: Controller class used to test the Swagger api
// Change History:
// Name                         Date                    Version        Description
// -------------------------------------------------------------------------------
// Developer               November 17, 2016           1.0.0.0       Controller class used to test the Swagger api
// -------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// -------------------------------------------------------------------------------
#endregion

namespace MAQ.WebService.Template
{
    #region using
    using System.Web.Http;
    #endregion
    /// <summary>
    /// Controller to test the Swagger api.
    /// </summary>
    public class SwaggerController : ApiController
    {
        string message = string.Empty;
        /// <summary>  
        /// get simple string   
        /// </summary>  
        [HttpGet]
        public string ResultGet()
        {
            message = Constants.ERROR_GET_SWAGGER;
            return message;
        }
        /// <summary>  
        /// Post simple string   
        /// </summary>  
        [HttpPost]
        public string ResultPost()
        {
            message = Constants.ERROR_POST_SWAGGER;
            return message;
        }
        /// <summary>  
        /// Put simple string
        /// </summary>  
        [HttpPut]
        public string UpdateEmployee()
        {

            message = Constants.SWAGGER_MESSAGE;
            return message;
        }
    }
}
