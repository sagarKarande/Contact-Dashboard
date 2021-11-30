# ContactDashboard

Contact dashboard is a MVC web project which perform basic CRUD operation and fetch and store contact information to Database

## Installation/Publish

There are two projects under ContactDashboard solution, to publish/deploy this web site need to follow below steps.

1. First deploy ContactsAPI project to IIS server (This is Web API project which access contact data from database and return to MVC application):
•	Publish ContactsAPI project to local server hard drive path using Visual studio editor.
•	Add new web site under IIS manager with basic settings like give hostname, port number etc. and set website physical path option to above publish folder local path under web site advanced setting option.
•	Create/Select App pool for created web site.
•	Browse deployed website and see weather deployed web site correctly or not.

2. Second step deploy ContactDashboard MVC project to IIS. (This is actual web project which provides end user interface to display, insert, update, delete contact record. To perform these actions on database and contact database MVC application internally calling ContactAPI endpoints internally.
•	In Contact Dashboard MVC web config file find "APIBaseURL" key and replace its value with your local ContactAPI base address eg. suppose ContactAPI deployed to https://localhost then need to add this base address to "APIBaseURL" key, So ContactDashboard will point your local API endpoints for further communication.
•	Publish ContactDashboard project to local server hard drive path under “WWW” root folder using Visual studio editor.
•	Add new web site under IIS manager with basic settings like give hostname, port number etc and set website physical path option to above publish folder local path under web site advanced setting option.
•	Create/Select App pool for created web site.
•	Browse deployed website and see weather deployed web site correctly or not.
 
## Folder Structure:
Both ContactAPI and ContactDashboard implemented using Asp.net MVC architecture. So both are having slightly same folder structure under project tree.
Folder structure:
1.	App_Data: This consist local database .mdf file whicn consist our all database table and record's.
2.	App_start: This consist all necessary startup class file to run and configure our projects like Routeconfig.cs ,Webapiconfig.cs,FiltterConfig.cs etc.
3.	Controller: This folder consist all controller class which handle user inputs and return appropriate view with its model.
4.	Content: This folder contains all static files, css files, Theme file etc.
5.	Models: This folder contains all models classes which consist business logic and model properties.
6.	Scripts: This folder Contains all JavaScript and Jquery files which are necessary to run browser scripting code logic.
7.	View: This folder contains all UI pages called as views in structured format. Views are stored inside appropriate folder name which is exact similar to controller name.

## S/W Requirements
1.	IIS 
2.	.Net Framework 4.5 and grater version.

