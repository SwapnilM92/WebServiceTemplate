///<disable>JS2032, JS2074, JS3092, JS3058, JS3057</disable>
// Global object to keep all constants and urls.
var oCommonConstants = {
    sSampleData: "1;ABC;XYZ; | 2;QWE;RTY; | 3;XYZ;MNO; | 4;PQR;LMN",
    sTitle: "Download Excel",
    sForm: "form",
    oData: [],    // OData is a method created to pass the set values.
    serviceOrigin: window.location.origin, /// Using window.location since service is not hosted on any other platform.
    sPost: "POST",
    sGet: "GET",
};

// Service end points
var oCommonServiceEndPoints = {
    sCorsEndPoint: "/api/Cors",
    sTestEndPoint: "/api/Test/Demo",
    sExportToExcelEndPoint: "/api/Export",
    sSwaggerEndPoint: "/swagger",
    sExportExcelUrl: "Pages/ExportExcel.aspx",
    sTextFileUrl: "/ReadFiles/README.txt",
};

var oCommonService = {
    // sWebMethodName: End point Url.
    // oParameters: Request Data pass to the service.
    // onSuccess: Success function.
    // onFailure: Failure function.
    // onBeforeSend: To be executed before making the service call.
    // oParam: Parameters to be passed to the success or failure function other than result data.
    callService: function (sWebMethodName, oParameters, onSuccess, onFailure, onBeforeSend, oParam) {
        "use strict";
        var sWebMethodUrl = oCommonConstants.serviceOrigin + sWebMethodName,
            sData = JSON.stringify(oParameters);
        $.ajax({
            type: oCommonConstants.sPost,
            url: sWebMethodUrl,
            data: sData,
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                if ("function" === typeof (onSuccess)) {
                    if (oParam) {
                        var oFinalResult = {
                            result: result,
                            oParam: oParam
                        };
                        onSuccess(oFinalResult);
                    } else {
                        onSuccess(result);
                    }
                }
            },
            beforeSend: function (result) {
                if ("function" === typeof (onBeforeSend)) {
                    if (oParam) {
                        var oFinalResult = {
                            result: result,
                            oParam: oParam
                        };
                        onBeforeSend(oFinalResult);
                    } else {
                        onBeforeSend(result);
                    }
                }
            },
            error: function (result) {
                if ("function" === typeof (onFailure)) {
                    if (oParam) {
                        var oFinalResult = {
                            result: result,
                            oParam: oParam
                        };
                        onFailure(oFinalResult);
                    } else {
                        onFailure(result);
                    }
                }
            }
        });
    }
};

/// Common function containing all the other functions except navigation and document.ready.
var WebScript = (function () {
    "use strict";
    // TODO: Replace with the URL of your WebService application.
    var serviceUrl = oCommonConstants.serviceOrigin + oCommonServiceEndPoints.sCorsEndPoint;
    /// "$" is JQuery variable, hence its shown as undeclared in Javascript file.
    /// XMLHttpRequest,showdown are variables that are used and suppressed using above suppression codes.
    /// Below method is used to get the ReadMe file, convert it to HTML and display it as HTML file.
    function readTextFile() {
        "use strict";
        var oFileRequest = new XMLHttpRequest();
        var sAllText = "";
        var sPath = window.location.origin + oCommonServiceEndPoints.sTextFileUrl;
        oFileRequest.open(oCommonConstants.sGet, sPath, false);
        oFileRequest.onreadystatechange = function () {
            if (4 === oFileRequest.readyState) {
                if (200 === oFileRequest.status || 0 === oFileRequest.status) {
                    sAllText = oFileRequest.responseText;
                    var converter = new showdown.Converter(),
                    html = converter.makeHtml(sAllText);
                    $("#Home").html(html);
                }
            }
        };
        oFileRequest.send(null);
    }
    // Anonymous function that handles all the click events. 
    (function () {
        "use strict";
        // OResults is a method used to hold the top value from the results.
        var sResults = "";
        var sClassFile = oCommonServiceEndPoints.sExportExcelUrl;
        // Click event of navigation bar registered.
        $(".nav a").click(function () {
            "use strict";
            oCommonConstants.oData.viewId = $(this).attr("data-id");
            switch (oCommonConstants.oData.viewId) {
                case "1":
                    $("#Swagger,#Excel").hide();
                    $("#Home").show();
                    WebScript.readTextBox();
                    break;
                case "2":
                    $("#Home,#Excel").hide();
                    window.location = oCommonConstants.serviceOrigin + oCommonServiceEndPoints.sSwaggerEndPoint;
                    break;
                case "3":
                    $("#Home,#Swagger").hide();
                    $("#Excel").show();
                    break;
                default:
                    $("#Swagger,#Excel").hide();
                    $("#Home").show();
                    WebScript.readTextBox();
                    break;
            }
        });
        /// Function used to clear the data in container
        $("#clearData").click(function (oEvent) {
            "use strict";
            $("#container").empty();
        });

        /// Function used to maintain export the excel functionality. Calls ExportExcel.aspx page to download the excel
        $("#exportData").click(function (oEvent) {
            "use strict";
            var sInputString = $("#container").val();
            var oJson = {};
            oJson.Data = sInputString.length > 0 ? sInputString : "";
            if (oJson.Data) {
                var sUrl = location.protocol + "//" + location.host + "/" + sClassFile;
                sResults = encodeURIComponent((oJson.Data));
                var sForm = "<form class=\"ExcelForm\" action=\"" + sUrl + "\" method=\"post\">" +
                  "<input type=hidden name=\"content\" id=\"content\" value=\"" + sResults + "\"/>" +
                  "</form>";
                // Open a new window and call ExportExcel cs page
                var oDownloadWindow = window.open("", "oDownloadWindow");
                if (oDownloadWindow !== null) {
                    var oDownloadDocument = oDownloadWindow.document;
                    if (oDownloadDocument !== null) {
                        oDownloadDocument.open("text/html", "replace");
                        oDownloadDocument.write("<HTML><HEAD><TITLE>" + oCommonConstants.sTitle + "</TITLE></HEAD><BODY></BODY></HTML>");
                        $(oDownloadDocument.body).html(sForm);
                        oDownloadWindow.focus();
                        $(oDownloadDocument.body).find("form").submit();
                    }
                }
            }
        });

        /// Function is used to export data in Excel through Service.
        $("#exportDataService").click(function (data) {
            "Use strict";
            var form = document.createElement(oCommonConstants.sForm);
            var sUrl = location.protocol + "//" + location.host + "/" + oCommonServiceEndPoints.sExportToExcelEndPoint;
            form.setAttribute("method", oCommonConstants.sPost);
            form.setAttribute("action", sUrl);
            form._submit_function_ = form.submit;
            for (var key in data) {
                if (data.hasOwnProperty(key)) {
                    var hiddenField = document.createElement("input");
                    hiddenField.setAttribute("type", "hidden");
                    hiddenField.setAttribute("name", key);
                    hiddenField.setAttribute("value", JSON.stringify(data[key]));
                    form.appendChild(hiddenField);
                }
            }
            document.body.appendChild(form);
            form._submit_function_();
        });


        /// Static Values for Export to excel container.
        /// Below entries are only for Test purpose. These are the sample data used during demo.
        $("#sampleData").click(function (oEvent) {
            "use strict";
            oCommonConstants.oData.staticvalues = oCommonConstants.sSampleData;
            $("#container").html(oCommonConstants.oData.staticvalues);
        });
    })();
    /// Below method is used for testing the Test Controller.  
    var sendRequest = function () {
        "Use strict";
        oCommonService.callService(oCommonServiceEndPoints.sTestEndPoint, "", success, failure, "", "");
    };

    // Success message. 
    var success = function (data) {
        "use strict";
        $("#Home").text(data);
    };

    // Failure message. 
    var failure = function (data) {
        "use strict";
        $("#Home").text(JSON.parse(data.responseText).Message);
    };
    return {
        readTextBox: readTextFile
    };
}());

// "$" is JQuery variable, hence its shown as undeclared in Javascript file.
$(document).ready(function () {
    "use strict";
    $("#Swagger,#Excel").hide();
    WebScript.readTextBox();
});
