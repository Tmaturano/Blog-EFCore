# Blog-EFCore
Reviewing some EF Core fundamentals

* Install global EF Tool in order to run migrations:
  - dotnet tool install --global dotnet-ef

* To create a migration:
  - dotnet ef migrations add MigrationName

* To execute a migration:
  - dotnet ef database update
