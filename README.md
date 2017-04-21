# MAQ Web Service Template

## Introduction
MAQ Web Service is designed to provide a ready platform for Web API with Swagger, CORS and Excel export functionality. Once installed, we can create a new project and start using the services and functionality directly. This can be used as a base code while starting with a new project, thus saving developers time.
User can add and remove the unwanted files as per their requirements

## Feature list
1.	CORS Policy
2.	Swagger API
3.	Export to Excel
4.	Read Markdown file

### CORS Policy:
It’s a mechanism that allows restricted resources (e.g. fonts, videos) on a web page to be requested from another domain (outside the domain from which the resource originated).
As a best practice, keep configurable attributes, but this is not possible out-of-the box for CORS attributes e.g. origins, options, methods since they accept constant values. To make these values configurable we must create a custom CORS policy and use it for our WebAPI. This solution removes the need for rebuilding the solution after changing CORS attributes.

### Swagger:
Swagger UI is a dependency-free collection of HTML, JavaScript, and CSS assets that dynamically generate beautiful documentation from a Swagger-compliant API. With a Swagger-enabled API, you get interactive documentation, client SDK generation and discoverability.

### Export to Excel:
Sometimes, it is required to export your data into the Excel file in web application. ClosedXML makes it easier to create Excel 2010/2016 files. It provides a nice object oriented way to manipulate the files without dealing with the hassles of XML Documents. 

### Markdown File
Markdown is a lightweight markup language with plain text formatting syntax designed so that it can be converted to HTML and many other formats using a tool by the same name

## How to install the template
There are two ways we can use these services.
1. Clone this repository from the top right corner or use the command
```
$ git clone
```
2. Install the Template in Visual Studio following below steps.
	1. Open Visual Studio (above Visual Studio 2012)
	2. Go to Tools > Extension and Updates
	3. Select Online on left pane
	4. Under Visual Studio Gallery, search for ```MAQ Web Service Template```
	5. Install the template.
	6. Upon creating a new project, ```MAQ Web Service Template``` will be a new option available under Visual C#

## How to use the template
To use the template, follow the below steps.
1. Create a new project by selecting Visual C# > MAQ Web Service.
2. A complete project of Web service will be loaded in your solution.
3. We can set the HTML page as a start up page and execute the project.

### CORS
Definition for CORS are maintained under WebConfig.config file of the project.
``` 
<appSettings>
	  <!--CORS Settings-->
    <add key="CORSOrigins" value="*" />
    <add key="AllowedOrigins" value="*" />
    <add key="PreflightMaxAge" value="3600" />
</appSettings>
```
 CORSOrigins and AllowedOrigins values should be changed as per the requirements.

### Swagger
Swagger currently consists of Get and Post methods. Different methods can be created under SwaggerController.cs file.

### Export to Excel
Export to excel has been implemented in two ways.
1. Using Web Service
2. Using aspx page

Data is currently present for 3 columns. Columns are separated based on ";" operator and rows are separated based on "|" operator

##### Using Web Service for Export to Excel:

Changes for web service based approach can be performed under file ExportToExcelController.cs

##### Using aspx for Export to Excel:

Changes for aspx page based approach can be performed under file ExportExcel.aspx and ExportExcel.aspx.cs

### Read Markdown file
Markdown file is read under WebService.js file. readTextFile() method is used to convert markdown file into HTML format.
