#region PageSummary
// *****************************************************************
// Project:        MAQWebService
// Solution:       WebApi
//
// Author:  MAQ Software
// Date:    November 17, 2016
// Description: Class to allow a custom cors policy from web.comfig. 
// Change History:
// Name                         Date                    Version        Description
// -------------------------------------------------------------------------------
// Developer               November 17, 2016           1.0.0.0       Custom CORS policy to allow configurable CORS origins from web.config
// -------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// -------------------------------------------------------------------------------
#endregion
namespace MAQ.WebService.Template
{
    #region Using
    using System;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Cors;
    using System.Web.Http.Cors;
    #endregion

    /// <summary>
    /// CORS policy file, to make a service independent and remove the need for rebuilding the solution after changing CORS attributes. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
    public sealed class AllowCorsAttribute : Attribute, ICorsPolicyProvider
    {
        private CorsPolicy policy;
        /// <summary>
        /// Public Constructor to allow CORS policy.
        /// </summary>
        public AllowCorsAttribute()
        {
            // Create a CORS policy.
            policy = new CorsPolicy
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true,
                PreflightMaxAge = Convert.ToInt64(Constants.PRE_FLIGHT, CultureInfo.InvariantCulture)
            };
            string allowedOrigins = Constants.CORS_ORIGINS;
            if (!string.IsNullOrWhiteSpace(allowedOrigins))
            {
                if (Constants.ALLOWED_ORIGINS == allowedOrigins.Trim())
                {
                    policy.AllowAnyOrigin = true;
                }
                string[] origins = allowedOrigins.Split(new[] { Constants.SEMI_COLON }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string origin in origins)
                {
                    string allowedOrigin = origin.Trim();
                    policy.Origins.Add(allowedOrigin);
                }
            }
        }

        /// <summary>
        /// Gets the policy for Cross-Origin requests based on the CORS specifications.
        /// </summary>
        /// <param name="request">Represents a HTTP request message.</param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns></returns>
        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(policy);
        }
    }
}