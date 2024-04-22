# Blazor-Clean-Architecture
 This application is an example of using Clean Architecture with the Blazor framework, utilizing the CQRS Pattern & MediatR for component communication, a custom notification system for these requests, and identity user authentication and authorization. As well as Entity 
 Framework for command hanling and Dapper for query handling. 

## Project Setup
In order to get the project up and running you will need to do the following:
- In the appsettings.Devlopment.json files in both the Client and the API, you will need to update the ConnectionString setting with the details for your SQL Connection or other database.
- In the HttpClientService file found in the Client/Services folder, you will need to update the base address port to use the port given when first running the API, to find this you will need to select the startup project to be the API and after running, copy the port number from the URL and paste this here.
- Finally, you will need to add a new migration for the configurations and identity tables, to do this you will need to run the following two commands:

  First:
  ```
  dotnet ef migrations add InitialMigration --startup-project ./DEMO.Client/ --project ./DEMO.Persistence/
  ```

  Second:
  ```
  dotnet ef database update --startup-project ./DEMO.Client/ --project ./DEMO.Persistence/
  ```

  For each change that you make to the domain entities, configurations and database contexts, you will need to run these commands with the former having a unique description for the migration.

- With these steps done, you will now select multiple startup projects, being the Client and the API and start the application. From here you can use this as a base to build off for your own systems.
