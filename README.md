#CommanderRestApi

This is just a tutorial in c# using entity framework

##Configuration
To run the Rest api you will need to apply database migrations

Run:
```.NET
dotnet ef migrations add InitialMigration
dotnet ef database update
```

Then just execute 
```.NET
dotnet run
```
inside the project dir and that's it.
