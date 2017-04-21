#region PageSummary
// *****************************************************************
// Project:        MAQWebService
// Solution:       WebApi
//
// Author:  MAQ Software
// Date:    November 17, 2016
// Description: Class containing constant values for variables throughout the project 
// Change History:
// Name                         Date                    Version        Description
// -------------------------------------------------------------------------------
// Developer               November 17, 2016           1.0.0.0       Class containing constant values for variables throughout the project 
// -------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// -------------------------------------------------------------------------------
#endregion
namespace MAQ.WebService.Template
{
    #region using
    using System;
    using System.Configuration;
    using System.Globalization;
    #endregion
    /// <summary>
    /// A Constants class used to define the literal to be used throughout the API.
    /// </summary>
    internal static class Constants
    {
        #region Web.CONFIG Keys
        /// <summary>
        /// CORSOrigins is a constant value retrieved from Web config attribute "CORSOrigins". 
        /// This attribute contains value required for a server to explicitly allow cross-origin requests while rejecting others
        /// </summary>

        internal static readonly string CORS_ORIGINS = ConfigurationManager.AppSettings["CORSOrigins"];
        /// <summary>
        /// Defines the Media type used to describe the format of the message body
        /// </summary>

        internal static readonly string SUPPORTED_MEDIA_TYPE = ConfigurationManager.AppSettings["SupportedMediaType"];
        #endregion

        #region Constants
        /// <summary>
        /// String literal closing bracket
        /// </summary>
        internal static string CLOSING_BRACKET = "}";

        /// <summary>
        /// PreflightMaxAge stores the number of seconds the results of a preflight request can be cached
        /// </summary>
        internal static readonly string PRE_FLIGHT = ConfigurationManager.AppSettings["PreflightMaxAge"];

        /// <summary>
        /// Defines servers for which CORS Origins are allowed
        /// </summary>
        internal static readonly string ALLOWED_ORIGINS = ConfigurationManager.AppSettings["AllowedOrigins"];

        /// <summary>
        /// String semicolon
        /// </summary>
        internal static string SEMI_COLON = ";";

        /// <summary>
        ///  Defines the name of route map used by HTTPRouteCollection
        /// </summary>
        internal static string HTTP_ROUTE_NAME = "DefaultApi";

        /// <summary>
        ///  Defines the Route Template used by HTTPRouteCollection
        /// </summary>
        internal static string HTTP_ROUTE_TEMPLATE = "api/{controller}/{id}";

        /// <summary>
        ///  String literal Register
        /// </summary>
        public const string REGISTER = "Register";

        /// <summary>
        ///  String literal Path
        /// </summary>
        internal static string PATH = @"bin\OutputXML.xml";

        /// <summary>
        /// Path that needs to be ignored by Route configuration.
        /// </summary>
        internal static string INVALID_ROUTE = "{resource}.axd/{*pathInfo}";

        /// <summary>
        /// Path that needs to be accepted by Route configuration.
        /// </summary>
        internal static string VALID_ROUTE = "{controller}/{action}/{id}";

        /// <summary>
        /// String literal Default name for map route
        /// </summary>
        internal static string DEFAULT_MAP_ROUTE = "Default";

        /// <summary>
        /// String literal Default value for controller
        /// </summary>
        internal static string DEFAULT_CONTROLLER_NAME = "Home";

        /// <summary>
        /// String literal Default value for controller
        /// </summary>
        internal static string DEFAULT_CONTROLLER_INDEX = "Index";

        /// <summary>
        /// Error Message for Get
        /// </summary>
        internal static string ERROR_GET = "GET: Test message";

        /// <summary>
        /// Error Message for Post
        /// </summary>
        internal static string ERROR_POST = "POST: Test message";

        /// <summary>
        /// Swagger Error Message for Get
        /// </summary>
        internal static string ERROR_GET_SWAGGER = "GET: SWAGGER Test message";

        /// <summary>
        /// Swagger Error Message for POST
        /// </summary>
        internal static string ERROR_POST_SWAGGER = "POST: SWAGGER Test message";

        /// <summary>
        /// Success message for Swagger
        /// </summary>
        internal static string SWAGGER_MESSAGE = "Test Data Updated";

        /// <summary>
        /// Swagger Version
        /// </summary>
        internal static string SWAGGER_VERSION = "v2";

        /// <summary>
        /// Swagger Title
        /// </summary>
        internal static string SWAGGER_TITLE = "Web API";

        /// <summary>
        /// Swagger Version
        /// </summary>
        internal static string DEMO_STRING = "This is a Demo string for Test Controller!!";
        #endregion

        #region Export to Excel 
        /// <summary>
        /// Set Headers for Excel file
        /// </summary>
        internal static string EXCEL_HEADERS = "Id;First Name;Last Name";

        /// <summary>
        /// Content type(Excel extension)
        /// </summary>
        internal static string CONTENT_TYPE = "xlsx";

        /// <summary>
        /// Char data-type semicolon
        /// </summary>
        internal static char CHAR_SEMICOLON = ';';

        /// <summary>
        /// Char data-type new line
        /// </summary>
        internal static char CHAR_NEWLINE = '\n';

        /// <summary>
        /// Excel sheet name
        /// </summary>
        internal static string SHEET_NAME = "Sheet1";

        /// <summary>
        /// Contains value for HTTP Content
        /// </summary>
        internal static string HTTP_CONTENT = "content";

        /// <summary>
        /// Excel file name
        /// </summary>
        internal static string EXCEL_FILENAME = "ExportExcel";

        /// <summary>
        /// Excel header name
        /// </summary>
        internal static string EXCEL_HEADER_NAME = "content-disposition";

        /// <summary>
        /// Excel header value 
        /// </summary>
        internal static string EXCEL_HEADER_VALUE = "attachment;filename={0}_{1}.xlsx";

        /// <summary>
        /// Date format for file name
        /// </summary>
        internal static string EXPORT_TO_EXCEL_FILENAME_DATEFORMAT = "yyyyMMdd_HHmmss";

        /// <summary>
        /// Date format for file name
        /// </summary>
        internal static string ZERO_PLACEHOLDER = "{0:";

        /// <summary>
        /// String literal Pipe Separator
        /// </summary>
        internal static string PIPE_SEPARATOR = "|";

        /// <summary>
        /// Char data-type new line
        /// </summary>
        internal static string NEWLINE = "\n";
        #endregion

        #region Export to Excel Service
        /// <summary>
        /// Folder name to read Excel file
        /// </summary>
        internal static string EXCEL_FOLDERNAME = "ReadFiles";

        /// <summary>
        /// File name to read Excel 
        /// </summary>
        internal static string EXCEL_FILE = "ExportToExcel.xlsx";

        /// <summary>
        /// Set Excel Media types to Office document.
        /// </summary>
        internal static string EXCEL_MEDIA_TYPE = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        /// <summary>
        /// Set Excel Media types to Office document.
        /// </summary>
        internal static string EXCEL_DISPOSITIONTYPE = "attachment";

        #endregion

    }
}