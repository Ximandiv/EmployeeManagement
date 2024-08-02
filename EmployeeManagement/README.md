# Welcome to Employee Management

This README will guide you to understand the general architecture of the project.
First off, we're using C# .NET Framework 4.8 and this is an MVC Project that uses
JQuery for Frontend processing

## Requirements
- Any kind of editor
- SQL Server as DBMS
- SQL
- .NET Framework 4.8 SDK/RunTime
- At least 2GB RAM
- At least 500MB of space
- Any OS

## Setup
Before anything, you must locate the Web.config file. Do not be confused by the one inside 
Views folder, that one is a completely different config.

Once inside, look for the connection string tag and attribute inside the add. Here you will see
the connection string. Change it according to your DBMS access.

Following this, you can now startup the project. If you are in any Code Editor that allows you to just press
the start button like Visual Studio Community, go ahead, it'll work just fine.

Restore the packages by using 'nuget restore' command

Any other editor using their run feature works on this project, be it with or without debugger as long as you're
using IISExpress or any external web server

## General Architecture
This project has everything in the same assembly or project. It was an idea to
use different assemblies to separate responsibilities but due to time constraints
it wasn't possible.

- **App_Start:** Bundle, Filter, Routes any kind of configuration needed upon startup will be found here
- **Web.config:** This file has the configuration where the connection string or any important config value will be located at

You will always see folders with names tied to their purpose.

### Backend Architecture
- **Data:** Contains the Database context and Migrations (currently not implemented)
- **Controllers:** Contains the endpoints that will redirect you to an URL or process information
- **Models:** Contains the entity models being used by the backend

### Frontend Architecture
- **Scripts:** All Javascript files and bundles can be seen here
	- Employee: Where all the Frontend logic resides. **Requests** to endpoints and **validations** happen here.
- **Views:** Folder that contains all the views in the project
	- Employee: Here all the views and partial views can be seen related to the employee model
	- Home: Where the Index and About reside
	- Shared: All those views or partial views shared by all the frontend project
- **Content:** All the CSS files and bundles will be here