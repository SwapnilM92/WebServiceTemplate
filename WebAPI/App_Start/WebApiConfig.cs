#region Page Summary
// *****************************************************************
// Project:        MAQWebService
// Solution:       WebApi
//
// Date:    October 19, 2016
// Description: Registering the WebApi configuration
//
// Change History:
// Name                             Date                Version        Description
// -------------------------------------------------------------------------------
// Developer               November 17, 2016           1.0.0.0           Registering the WebApi configuration
// -------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// -------------------------------------------------------------------------------
#endregion

namespace MAQ.WebService.Template
{
    #region Using
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    #endregion
    /// <summary>
    /// Web API startup CONFIG File
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register the configurations for HTTP
        /// </summary>
        /// <param name="config">Contains the configuration of HTTP server responses</param>
        public static void Register(HttpConfiguration config)
        {
            if (null != config)
            {
                config.MapHttpAttributeRoutes();
                config.EnableCors();
                // Convention-based routing.
                config.Routes.MapHttpRoute(
                    name: Constants.HTTP_ROUTE_NAME,
                    routeTemplate: Constants.HTTP_ROUTE_TEMPLATE,
                    defaults: new { id = RouteParameter.Optional }
                );
                //Returns JSON format data
                config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue(Constants.SUPPORTED_MEDIA_TYPE));
            }
        }
    }
    ///// <summary>
    ///// Delegate handler to intercept incoming requests
    ///// </summary>
    //public class DefaultContentTypeMessageHandler : DelegatingHandler
    //{
    //    /// <summary>
    //    /// Class used to handle the null request for content type header.
    //    /// </summary>
    //    /// <param name="request">Represents the HTTP Request Message</param>
    //    /// <param name="cancellationToken">Propagates notification that operations should be canceled</param>
    //    /// <returns>HttpResponseMessage</returns>
    //    protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    //    {
    //        if (null == request.Content.Headers.ContentType)
    //        {
    //            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(Constants.NULL_SUPPORTED_MEDIA_TYPE);
    //        }
    //        var response = await base.SendAsync(request, cancellationToken);
    //        return response;
    //    }
    //}
}