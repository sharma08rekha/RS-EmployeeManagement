Please flow below steps to set up the Employee management API project.
Assumption is the system contails VS 2019 latest version with .NetCore 3.1.409 SDK and SQL server 2019.

1) Ensure the target frame work is set to NetCoreAPP3.1 WebAPI project file.
2) Change the connection string in appsettings.json , to point to the correct database server
2) Build the solution.

Execute the below commands in Package Manager Console for creating database and repective table. 
1) Add-Migration
2) Update-Database

ReBuild the project and press F5 to start the local server(IIS).
Set the frontend UI project as per provided README.
Once the project is started sucessfully below API will be available

POST: https://localhost:44320/api/employee
GET:  https://localhost:44320/api/employee
DELETE: https://localhost:44320/api/employee/{id}

