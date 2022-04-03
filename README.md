# MVC Crash Course - ASP.NET Core 6

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

## Doc References

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
