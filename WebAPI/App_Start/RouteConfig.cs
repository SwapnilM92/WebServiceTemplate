#region PageSummary
// *****************************************************************
// Project:        MAQWebService
// Solution:       WebApi
//
// Author:  MAQ Software
// Date:    November 17, 2016
// Description: This class used to register the desired routes for MVC
//
// Change History:
// Name                         Date                    Version        Description
// -------------------------------------------------------------------------------
// Developer               November 17, 2016          1.0.0.0       Register the routes to be used in MVC
// -------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// -------------------------------------------------------------------------------
#endregion
namespace MAQ.WebService.Template
{
    #region
    using System.Web.Mvc;
    using System.Web.Routing;
    #endregion
    /// <summary>
    ///  Default Route configured by MVC.
    /// </summary>
    public sealed class RouteConfig
    {
        private RouteConfig() { }
        /// <summary>
        /// Class used to register the routes for MVC
        /// </summary>
        /// <param name= "routes">Route to be used for routing</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Route to ignore
            routes.IgnoreRoute(Constants.INVALID_ROUTE);
            // name: Route name, URL: URL Pattern, Defaults: defaults for route
            routes.MapRoute(
                name: Constants.DEFAULT_MAP_ROUTE,
                url: Constants.VALID_ROUTE,
                defaults: new { controller = Constants.DEFAULT_CONTROLLER_NAME, action = Constants.DEFAULT_CONTROLLER_INDEX, id = UrlParameter.Optional }
            );
        }
    }
}
