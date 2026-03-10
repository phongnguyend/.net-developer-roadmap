## [EF Core | Microsoft Docs](https://docs.microsoft.com/en-us/ef/core/)

## What's new in EF Core
- [EF Core 11.0](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-11.0/whatsnew)
- [EF Core 10.0](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-10.0/whatsnew)
- [EF Core 9.0](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-9.0/whatsnew)
- [EF Core 8.0](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew)
- [EF Core 7.0](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-7.0/whatsnew)
- [EF Core 6.0](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-6.0/whatsnew)
- [EF Core 5.0](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-5.0/whatsnew)
- [EF Core 3.1](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-3.x/)
- [EF Core 3.0](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-3.0)
- [EF Core 2.2](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-2.2)
- [EF Core 2.1](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-2.1)
- [EF Core 2.0](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-2.0)
- [EF Core 1.1](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-1.1)
- [EF Core 1.0](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-1.0)

## What's new in EF .Net Framework
- [What's New in EF6](https://docs.microsoft.com/en-us/ef/ef6/what-is-new/)

## Visual Studio Extensions:
- [EF Core Power Tools](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools)

## Nuget Packages:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Relational
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.InMemory
- ...

## Migrations:
- add-migration 
- remove-migration
- update-database
- script-migration

## Mappings:
- One-to-many
- Many-to-many
- One-to-one
- [Shadow Properties](https://docs.microsoft.com/en-us/ef/core/modeling/shadow-properties)
- [Owned Types](https://docs.microsoft.com/en-us/ef/core/modeling/owned-entities)
- User-defined Functions
- Views ([Query Types, Keyless Entity Types](https://docs.microsoft.com/en-us/ef/core/modeling/query-types))
- [Data Seeding (HasData)](https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding)
- [Value Converters](https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions)

## Common SQL Functions:
- EF.Functions.Like

## Querying Data:
- [Query Tags](https://docs.microsoft.com/en-us/ef/core/querying/tags)
- [Views (Query Types)](https://docs.microsoft.com/en-us/ef/core/modeling/query-types)
- [Raw SQL Queries (FromSql)](https://docs.microsoft.com/en-us/ef/core/querying/raw-sql)
- [Loading Related Data](https://docs.microsoft.com/en-us/ef/core/querying/related-data)
  + Eager loading
  + Explicit loading
  + Lazy loading with and without Proxies
- [Global Query Filters](https://docs.microsoft.com/en-us/ef/core/querying/filters)

## Saving Data:
- [Transactions](https://docs.microsoft.com/en-us/ef/core/saving/transactions)
- [MinBatchSize](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.infrastructure.relationaloptionsextension.minbatchsize?view=efcore-2.1)
- [MaxBatchSize](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.infrastructure.relationaloptionsextension.maxbatchsize?view=efcore-2.1)
- [Attach](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.attach?view=efcore-5.0) vs [Update](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.update?view=efcore-5.0)

## Logging & Tracking Events:
- [Logging](https://docs.microsoft.com/en-us/ef/core/miscellaneous/logging)
- [ChangeTracker.StateChanged Event](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.changetracking.changetracker.statechanged?view=efcore-2.1)
- [ChangeTracker.Tracked Event](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.changetracking.changetracker.tracked?view=efcore-2.1)

## Code Analysis:
- Microsoft.EntityFrameworkCore.Analyzers

## Testing
- [Testing code that uses EF Core](https://docs.microsoft.com/en-us/ef/core/testing/)
- [EF Core testing sample](https://docs.microsoft.com/en-us/ef/core/testing/testing-sample)
- [Sharing databases between tests](https://docs.microsoft.com/en-us/ef/core/testing/sharing-databases)
- [Using SQLite to test an EF Core application](https://docs.microsoft.com/en-us/ef/core/testing/sqlite)
- [Testing with the EF In-Memory Database](https://docs.microsoft.com/en-us/ef/core/testing/in-memory)

## Notes:
- GroupBy Issues
