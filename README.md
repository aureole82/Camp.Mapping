This is an ASP.NET Core web application created by the latest Visual Studio template including authentication by "storing user accounts in-app" (Visual Studio 2019, .NET Core 2.2).

Some changes have been applied to meet real world requirements:
* The data models and `DbContext` classes are extracted into a separate class library.
* A custom user and role class has been provided to allow an `int` primary key and enhance them with some more properties.
* Add common versioning (set `<GenerateAssemblyInfo>false</GenerateAssemblyInfo>` to `*.csproj`).

(For more informations about setup read [these steps](Camp.Mapping.Data/README.md).)

---

