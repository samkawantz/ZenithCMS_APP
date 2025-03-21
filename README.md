# ZenithCMS_APP
This repo contains a web app for managing a static web site.

# Running an ASP.NET MVC Application

This document outlines the steps required to run an ASP.NET MVC application cloned from a repository.

## Prerequisites

Before you begin, ensure you have the following software installed:

1.  **.NET SDK:**
    * Download and install the latest .NET SDK from the official Microsoft website: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).
    * Verify the installation by opening a command prompt or terminal and running: `dotnet --version`.

2.  **Integrated Development Environment (IDE):**
    * **Visual Studio (Recommended):**
        * Download and install Visual Studio Community, Professional, or Enterprise from: [https://visualstudio.microsoft.com/](https://visualstudio.microsoft.com/).
        * Ensure you select the ".NET web development" workload during installation.
    * **Visual Studio Code (Alternative):**
        * Download and install Visual Studio Code from: [https://code.visualstudio.com/](https://code.visualstudio.com/).
        * Install the C# extension from the VS Code marketplace.

3.  **SQL Server (If using a database):**
    * If your application uses a SQL Server database, install SQL Server Express, Developer, or Standard edition.
    * SQL Server Express: [https://www.microsoft.com/en-us/sql-server/sql-server-downloads](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
    * SQL Server Management Studio (SSMS) is also recomended for database management.

## Steps to Run the Application

1.  **Clone the Repository:**
    * Use Git or your preferred method to clone the repository to your local machine.
    * Example using command line: `git clone <repository_url>`.

2.  **Open the Solution:**
    * **Visual Studio:** Open the `.sln` file located in the root directory of the cloned repository.
    * **Visual Studio Code:** Open the folder containing the repository in VS Code.

3.  **Restore NuGet Packages:**
    * **Visual Studio:** Visual Studio should automatically restore NuGet packages. If not, right-click on the solution in the Solution Explorer and select "Restore NuGet Packages."
    * **Visual Studio Code:** Open the terminal in VS Code and run `dotnet restore` in the directory containing the `.sln` file.

4.  **Database Configuration (If applicable):**
    * If the application uses a database, you'll need to configure the connection string.
    * Locate the `appsettings.json` file in the project.
    * Modify the connection string in the `ConnectionStrings` section to match your SQL Server instance.
        * Example:
            ```json
            "ConnectionStrings": {
              "DefaultConnection": "Server=.\\SQLExpress;Database=YourDatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true"
            }
            ```
    * If the database does not exist, you may need to use Entity Framework Core Migrations to create it.
        * Open the Package Manager Console (in Visual Studio) or the terminal (in VS Code).
        * Run the following commands:
            * `Add-Migration InitialCreate` (Creates the initial migration)
            * `Update-Database` (Applies the migrations to create the database)
        * Or using the dotnet CLI:
            * `dotnet ef migrations add InitialCreate`
            * `dotnet ef database update`

5.  **Build the Application:**
    * **Visual Studio:** Press `Ctrl + Shift + B` or select "Build" -> "Build Solution" from the menu.
    * **Visual Studio Code:** Open the terminal and run `dotnet build` in the project directory.

6.  **Run the Application:**
    * **Visual Studio:** Press `F5` or click the "Run" button to start debugging.
    * **Visual Studio Code:** Open the terminal and run `dotnet run` in the project directory.
    * The application will launch in your default web browser.

7.  **Configuration Notes:**
    * **appsettings.json:** Review the `appsettings.json` file for any other application-specific configurations, such as API keys, logging settings, or other environment variables.
    * **Environment Variables:** If the application uses environment variables, ensure they are set correctly on your local machine.
    * **IIS Express/Kestrel:** Visual Studio typically uses IIS Express for debugging, while `dotnet run` uses Kestrel. You can configure these in the project's properties or `launchSettings.json`.
    * **Dependencies:** Check for any specific dependencies that might need to be installed, such as external libraries or services.

## Troubleshooting

* **NuGet Package Restore Errors:** Ensure you have a stable internet connection. Try cleaning and rebuilding the solution.
* **Database Connection Errors:** Double-check the connection string and ensure your SQL Server instance is running.
* **Build Errors:** Review the error messages in the output window for clues. Ensure all dependencies are correctly installed.
* **Routing Errors:** If you encounter 404 errors, check the routing configurations in `Startup.cs` or `Program.cs` and your controllers.

This guide should help you get the ASP.NET MVC application running on your local machine. If you encounter any issues, please refer to the application's documentation or contact the repository owner.
