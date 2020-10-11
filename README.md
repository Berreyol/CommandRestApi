CommanderRestApi

This is just a tutorial in c#

To run the Rest api you will need to execute database migrations

Run:
dotnet ef migrations add InitialMigration
dotnet ef database update

Then just execute 
dotnet run
inside the project dir and that's it.
