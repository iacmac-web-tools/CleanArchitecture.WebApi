 # ASP.NET Core WebApi - Clean Architecture

![.NET Core](https://github.com/iammukeshm/CleanArchitecture.WebApi/workflows/.NET%20Core/badge.svg?branch=master)
![GitHub stars](https://img.shields.io/github/stars/iammukeshm/CleanArchitecture.WebApi)
[![Twitter Follow](https://img.shields.io/twitter/follow/codewithmukesh?style=social&label=follow)](https://twitter.com/codewithmukesh)

<br/>

An Implementation of Clean Architecture with ASP.NET Core 3.1 WebApi. With this Open-Source BoilerPlate Template, you will get access to the world of Loosely-Coupled and Inverted-Dependency Architecture in ASP.NET Core 3.1 WebApi with a lot of best practices.

Check out the [Project Page](https://www.codewithmukesh.com/project/aspnet-core-webapi-clean-architecture/) to learn more about this Open Source Project.

Read the [Changelog file](https://github.com/iammukeshm/CleanArchitecture.WebApi/blob/master/CHANGELOG.md) to see the new changes.

## Releases
v1.1 - Stable Release - [Download the Stable Release](https://github.com/iammukeshm/CleanArchitecture.WebApi/releases/tag/v1.1)

v1.0-preview - [Download the first Preview here](https://github.com/iammukeshm/CleanArchitecture.WebApi/releases/tag/v1.0-preview)

## v1.1

Follow these steps to get started with this Boiler Plate Template.

### Download the Extension
Make sure Visual Studio 2019 is installed on your machine with the latest SDK.
[Download from Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=MukeshMurugan.CleanArchitectureWebApi). Install it on your machine.

Follow these Steps to get started.

![alt text](https://www.codewithmukesh.com/wp-content/uploads/2020/08/cleanArchitecture_VisualStudio.png)

![alt text](https://www.codewithmukesh.com/wp-content/uploads/2020/08/cleanArchitecture_NewProject.png)

You Solution Template is Ready!

![alt text](https://www.codewithmukesh.com/wp-content/uploads/2020/08/cleanArchitecture_FolderStructure.png)

Visit the Project Page to learn more - [Click Here](https://www.codewithmukesh.com/project/aspnet-core-webapi-clean-architecture/)

### Alternatively you can also clone the Repository.

1. Clone this Repository and Extract it to a Folder.
3. Change the Connection Strings for the Application and Identity in the WebApi/appsettings.json - (WebApi Project)
2. Run the following commands on Powershell in the WebApi Projecct's Directory.
- dotnet restore
- dotnet ef database update -Context ApplicationDbContext
- dotnet ef database update -Context IdentityContext
- dotnet run (OR) Run the Solution using Visual Studio 2019

Check out my [blog](https://www.codewithmukesh.com) or say [Hi on Twitter!](https://twitter.com/codewithmukesh)

### How to use MySQL or PostgreSQL as your Data Provider
The Project currently uses MSSQL as the default Data Provider. If you are more comfortable with MySQL or PostgreSQL, here is how to migrate to them easily.


1. delete all existing file inside migrations folder on both project
   - {YourProjectName}.Infrastructure.Identity
   - {YourProjectName}.Infrastructure.Persistence

2. In in `ServiceExtensions.cs` and `ServiceRegistration.cs` change from `options.UseSqlServer` to:
#### For MySql
`options.UseMySql`
#### For PostgreSQL
`options.UseNpgsql`

3. Add NuGet packages to both projects (Infrastructure.Identity and Infrastructure.Persistence):
#### For MySql:
run `dotnet add package Pomelo.EntityFrameworkCore.MySql --version 3.1.2` (remember to do this on both projects)
#### For PostgreSQL:
run
```cli
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL.Design
```
(remember to do this on both projects)

4. on `IdentityContext.cs` comment `builder.HasDefaultSchema("Identity");` because ef doesn't support that on mysql

5. cd to `Infrastructure.Identity` and run
   - `dotnet ef database update --startup-project ../WebApi/WebApi.csproj -c "IdentityContext"`
   - `dotnet ef migrations add Initial --startup-project ../WebApi/WebApi.csproj -c "IdentityContext"`

6. cd to `{YourProjectName}.Infrastructure.Persistence` and run
   - `dotnet ef database update --startup-project ../WebApi/WebApi.csproj -c "ApplicationDbContext"`
   - `dotnet ef migrations add Initial --startup-project ../WebApi/WebApi.csproj -c "ApplicationDbContext"`

The above guide (To use MySQL) was contributed by [geekz-reno](https://github.com/geekz-reno).

### Default Roles & Credentials
As soon you build and run your application, default users and roles get added to the database.

Default Roles are as follows.
- Root
- Admin
- Moderator
- Basic

Here are the credentials for the default users.
- Email - root@example.com  / Password - 123Pa$$word!
- Email - basic@example.com  / Password - 123Pa$$word!

You can use these default credentials to generate valid JWTokens at the ../api/account/authenticate endpoint.
## Features
- [x] Onion Architecture
- [x] CQRS with MediatR Library
- [x] Entity Framework Core - Code First
- [x] Repository Pattern - Generic
- [x] MediatR Pipeline Logging & Validation
- [x] Serilog
- [x] Swagger UI
- [x] Response Wrappers
- [x] Healthchecks
- [x] Pagination
- [ ] In-Memory Caching
- [ ] Redis Caching
- [x] In-Memory Database
- [x] Microsoft Identity with JWT Authentication
- [x] Role based Authorization
- [x] Identity Seeding
- [x] Database Seeding
- [x] Custom Exception Handling Middlewares
- [x] API Versioning
- [x] Fluent Validation
- [x] Automapper
- [x] SMTP / Mailkit / Sendgrid Email Service
- [x] Complete User Management Module (Register / Generate Token / Forgot Password / Confirmation Mail)
- [x] User Auditing

## Brief Overview
![alt text](https://www.codewithmukesh.com/wp-content/uploads/2020/06/Onion-Architecture-In-ASP.NET-Core.png)

## Prerequisites
- Visual Studio 2019 Community and above
- .NET Core 3.1 SDK and above
- Basic Understanding of Architectures and Clean Code Principles
- I Recommend that you read [Onion Architecture In ASP.NET Core With CQRS – Detailed](https://www.codewithmukesh.com/blog/onion-architecture-in-aspnet-core/) article to understand this implementation much better. This project is just an Advanced Version of the mentioned article.

## Getting Started

## Changelog
Every changes / additions / deletions will be recorded in the [Changelog file](https://github.com/iammukeshm/CleanArchitecture.WebApi/blob/master/CHANGELOG.md).

## Questions? Bugs? Suggestions for Improvement?
Having any issues or troubles getting started? [Get in touch with me](https://www.codewithmukesh.com/contact) or [Raise a Bug or Feature Request](https://github.com/iammukeshm/CleanArchitecture.WebApi/issues/new/choose). Always happy to help.

## Support
Has this Project helped you learn something New? or Helped you at work? Do Consider Supporting.

<a href="https://www.buymeacoffee.com/codewithmukesh" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" width="200"  ></a>

## Share it!
I have personally not come across a clean implementation on a WebAPI, which is the reason that I started building this up. There are quite a lot of improvements and fixes along the way from the day I started out. Thanks to the community for the support and suggestions.
Please share this Repository within your developer community, if you think that this would a difference! Thanks.

## About the Author
### Mukesh Murugan
- Blogs at [codewithmukesh.com](https://www.codewithmukesh.com)
- Facebook - [codewithmukesh](https://www.facebook.com/codewithmukesh)
- Twitter - [Mukesh Murugan](https://www.twitter.com/iammukeshm)
- Twitter - [codewithmukesh](https://www.twitter.com/codewithmukesh)
- Linkedin - [Mukesh Murugan](https://www.linkedin.com/in/iammukeshm/)

## Licensing
iammukeshm/CleanArchitecture.WebApi Project is licensed with the [MIT License](https://github.com/iammukeshm/CleanArchitecture.WebApi/blob/master/LICENSE).
