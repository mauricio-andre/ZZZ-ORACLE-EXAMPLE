# ZZZ-ORACLE-EXAMPLE
This branch was created to exemplify an error in zzzproject in the InsertFromQuery function.


## Description

When We try to call the function InsertFromQuery to operate a insert function in the oracle database, We get an ArgumentOutOfRangeException, this error does not occur when the function is executed on Sql Server Database. This repository can be used to simulation de problem.


## Exceptions stacktrace

Exception has occurred: CLR/System.ArgumentOutOfRangeException
An unhandled exception of type 'System.ArgumentOutOfRangeException' occurred in System.Private.CoreLib.dll: 'Length cannot be less than zero.'
   at System.String.ThrowSubstringArgumentOutOfRange(Int32 startIndex, Int32 length)
   at System.String.Substring(Int32 startIndex, Int32 length)
   at `1.()
   at `1.(IQueryable`1 , Action`1 )
   at `1.Execute(IQueryable`1 query, Action`1 batchInsertBuilder)
   at DbContextExtensions.[](IQueryable`1 , Action`1 )
   at DbContextExtensions.[](IQueryable`1 , String , String , String , Type , Expression`1 )
   at DbContextExtensions.InsertFromQuery[TEntity](IQueryable`1 query, Expression`1 selectExpression)
   at ZZZOracleExample.Core.Handlers.CreateExampleCmdHandler.<Handle>d__5.MoveNext() in C:\Users\mauricio.andre\repos\private\ZZZ-ORACLE-EXAMPLE\src\ZZZOracleExample.Core\Examples\Handlers\CreateExampleCmdHandler.cs:line 41
   at Program.<<Main>$>g__ExemplifyServiceLifetime|0_1(IServiceProvider hostProvider) in C:\Users\mauricio.andre\repos\private\ZZZ-ORACLE-EXAMPLE\src\ZZZOracleExample.App.SomeEventHandlerWorker\Program.cs:line 29
   at Program.<Main>$(String[] args) in C:\Users\mauricio.andre\repos\private\ZZZ-ORACLE-EXAMPLE\src\ZZZOracleExample.App.SomeEventHandlerWorker\Program.cs:line 22


## Simulation
Open the appsettings.json file located in the ZZZOracleExample.App.SomeEventHandlerWorker folder and change the following environments variables
- ConnectionStrings__CoreDbContext: Database address
- Z.EntityFramework.Extensions: License of zzzproject

In terminal, execute de following command ``dotnet ef database update --project .\src\ZZZOracleExample.App.SomeEventHandlerWorker``, this will create an Example table used em this project.

Then execute the ZZZOracleExample.App.SomeEventHandlerWorker project with ``dotnet run --project .\src\ZZZOracleExample.App.SomeEventHandlerWorker`` to get the error. In the source code you will find a TODO item marking the point where the error occurrent.


## Further technical details
- Microsoft.EntityFrameworkCore: 7.0.7
- Z.EntityFramework.Extensions.EFCore: 7.22.3
- Oracle.EntityFrameworkCore: 7.21.9
- Database: Oracle 19.11.0.0.0
