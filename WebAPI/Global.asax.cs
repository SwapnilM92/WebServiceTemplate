#region PageSummary
// *****************************************************************
// Project:        MAQWebService
// Solution:       WebApi
//
// Author:  MAQ Software
// Date:    November 17, 2016
// Description: Class used to handles all events raised by HTTP Module.
// Change History:
// Name                         Date                    Version        Description
// -------------------------------------------------------------------------------
// Developer               November 17, 2016           1.0.0.0       Class used to handles all events raised by HTTP Module.
// -------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// -------------------------------------------------------------------------------
#endregion

namespace MAQ.WebService.Template
{
    #region
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    #endregion

    /// <summary>
    /// Class for responding to events raised by HttpModules
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Api")]
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Performs the startup task of life cycle.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
