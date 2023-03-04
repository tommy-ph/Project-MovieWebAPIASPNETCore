# Project-MovieWebAPIASPNETCore

This WEB RESTful API app is created with Entity Framework Code First workflow and an ASP.NET Core (.NET 6) in C#.

Running this app creates a datastore and interface to store and manipulate a movies characters. The database will store information about characters, movies they appear in, and the franchises these movies belong to and also it can be expanded on.

Created by Maryam Almashhadi and Tommy Pham.

Download and install:
1. Install .NET 6 or later. 
2. SSMS (SQL Server Management studio)

Please remember to change the "Datasource" to your own servername, you will need to replace it in appsettings.json

3. Apply migrations using: "dotnet ef database update" in the Package Manager Console. This will create a database with tables and initial data. 

Usage:
Running the application should start the server and open browser with Swagger documentation. 
Pick an action and press "Execute".
