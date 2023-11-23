# MVC Crash Course - ASP.NET Core 6

> [!NOTE]  
> The [`aspnet8` branch](https://github.com/dahlsailrunner/crash-course-aspnet6-mvc/tree/aspnet8) contains updates for this project for use with ASP.NET 8.

## Prerequisites

* Install the [.NET SDK](https://dotnet.microsoft.com/en-us/download)
* Have an IDE installed - the three main options are:
  * [VS Code](https://code.visualstudio.com/) - include the [C# language extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
  * [Visual Studio or Visual Studio for Mac](https://visualstudio.microsoft.com/) - Community Edition is fine
  * [JetBrains Rider](https://www.jetbrains.com/rider/)
* Trust the dotnet dev https certificate: `dotnet dev-certs https -t`

**N O T E:** when this project runs it will create two different Sqlite
databases, stored in the `Environment.SpecialFolder.LocalApplicationData` folder.  (`C:\Users\USERNAME\AppData\Local` on Windows and `/Users/USERNAME/.local/share` on Mac):

* `carvedrock-admin.db` (this is the main application database)
* `carvedrock-admin-users.db` (this is ASP.NET Core Identity)

### VS Code Setup

Any flavor of Visual Studio or Rider will include
the things you need to run ASP.NET projects, but
VS Code requires some additional setup.

The `C#` extension (link above) is required to use this repo.  I have some other settings that you may be curious about
and they are described in my [VS Code gist](https://gist.github.com/dahlsailrunner/1765b807940e29951ea6bdfb36cd85dd).

## App features

The application is the starting point for an "Admin" application
for a fictional company called Carved Rock for its users to maintain
the products that it sells.

* The primary technology is **ASP.NET Core 6 MVC**
* **Entity Framework (EF) Core** is used with Sqlite for the database
* Basic CRUD operations are supported on Products and Cateogories
* Styled with Bootstrap and the [Litera Bootwatch theme](https://bootswatch.com/litera/)
* Repository and Domain Logic classes are used with **dependency injection (DI)** to support testability
* The Category of a product is a related entity with navigation property
* **Validation** is present on both categories and products, and a sample of
    more complex validation is included on Products with **FluentValidation**
* Products and Categories require users to be **authenticated**
* **ASP.NET Identity** (scaffolded) is used for the the authentication (self-registration works fine - no inital users are created)
* The "initial data" is reset each time the app starts, so
  feel free to play around!!

## Doc References

* [.NET CLI (`dotnet` command)](https://docs.microsoft.com/en-us/dotnet/core/tools)
* [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-6.0)
* **User Interface**
  * [Tag Helpers](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/?view=aspnetcore-6.0)
  * [Razor Syntax](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-6.0)
  * [Validation and Data Annotations](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation)
* **Data / Entity Framework (EF) Core**
  * [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core)
  * [Database Providers](https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli)
  * [Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations)
  * [Relationships](https://docs.microsoft.com/en-us/ef/core/modeling/relationships)
* **Fluent Validation**
  * [General Docs](https://docs.fluentvalidation.net/en/latest/)
* **Identity**
  * [General Docs](https://docs.microsoft.com/en-us/aspnet/core/security/?view=aspnetcore-6.0)
  * [Scaffolding Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity)
