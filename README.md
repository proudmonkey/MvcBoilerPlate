# MvcBoilerPlate.AspNetCore

A simple project template designed for small standalone projects or PoC's. The goal is to help you get up to speed when setting up the core structure of your ASP.NET Core MVC app and its dependencies. This enables you to focus on implementing business specific code requirements without you having to copy and paste the core structure of your project, and installing its dependencies all over again. 

## Tools and Frameworks Used

* [.NET Core 3.0](https://dotnet.microsoft.com/download/dotnet-core)
* [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.0) - For generating Web UIs
* [Dapper](https://dapper-tutorial.net/dapper) - For data access.
* [AutoMapper](https://github.com/AutoMapper/AutoMapper) - For mapping entity models to DTOs.
* [FluentValidation.AspNetCore](https://fluentvalidation.net/aspnet) - For Model validations
* [Serilog.AspNetCore](https://github.com/serilog/serilog-aspnetcore) - For logging capabilities

Keep in mind that you can always replace and choose whatever framework you want to use for your project. After all, the template is just a skeleton for your project structure with default preconfigured middlewares. For example, you can always replace `Dapper` with `Entity Framework Core`, `PetaPoco`, etc. and configure them yourself. You can also replace `Serilog` with whatever logging frameworks and providers you want that works with `ASP.NET Core` - the choice is yours.


## Steps to run the template

**STEP 1:** [Fork](https://help.github.com/en/github/getting-started-with-github/fork-a-repo##targetText=When%20you%20fork%20a%20project,octocat%2FSpoon%2DKnife%20repository.) the repo.

**STEP 2:** Create a Test local Database:

1. Open Visual Studio 2019
2. Go to `View` > `SQL Server Object Explorer`
3. Drilldown to `SQL Server` > `(localdb)\MSSQLLocalDB`
4. Right-click "`Database`" Folder
5. Click "`Add New Database`"
6. Name it as "`TestDB`" and click OK
7. Right-click on the "`TestDB`" database and then select "`New Query`"
8. Run the script below to generate the "`Person`" table.

```sql
CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    	[FirstName] NVARCHAR(20) NOT NULL, 
    	[LastName] NVARCHAR(20) NOT NULL, 
    	[DateOfBirth] DATETIME NOT NULL
)
```

**STEP 3:** Update Database ConnectionString (Optional)

If you follow step 2, then you can skip this step and run the application right away.

If you have a different `database` and `table` name then you need to change the `connectionString` in `appsettings.json` that is pointing to the newly created database. You can get the `connectionString` values in the `properties` window of the "TestDB" database in Visual Studio.

# ASP.NET Core API Template
If you need an API template to separate your APIs from your UI, then you can take a look at `ApiBoilerPlate` here: [https://github.com/proudmonkey/ApiBoilerPlate](https://github.com/proudmonkey/ApiBoilerPlate)


