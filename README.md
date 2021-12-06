# Blog-EFCore
Reviewing some EF Core fundamentals

* Install global EF Tool in order to run migrations:
  - dotnet tool install --global dotnet-ef

* To create a migration:
  - dotnet ef migrations add MigrationName

* To execute a migration:
  - dotnet ef database update

* If you don't want to use migrations, you can delete the Migrations folder and the __EFMigrationsHistory table that is generated

* There is a way also, to generate a SQL script through migrations:
  - dotnet ef migrations script -o ./script.sql
