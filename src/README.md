# ASP.Net REST API Template

## How to use

1. Install it using `dotnet new`
   ```bash
   dotnet new install .\aspnet-restapi-template\src\ --force
   ```
   > You need to clone repository or have a source code
2. Create new from template:
   * terminal
   ```bash
   dotnet new herodotapi --name MyNewApi
   ```
   
## Description

A clean, optioned ASP.Net REST API template.

> Template is using ASP.Net 7

Features:
* CQRS with MediatR
* Clean project structure
* Swagger configuration
* Health checks
* API Versioning
* Ready to go unit tests
* Integration tests with real database in docker and `WebApplicationFactory`
* Dependencies in docker (i.e. database)
* Configured docker file
* IoC scope services validation

> You can find more docs in specific README files.

# How to setup

1. Install `Docker`
   * for `Windows` - Install `DockerDesktop`

# How to run

1. Open terminal
1. Go to your `.sln` directory (directory with `docker-compose.yaml` file)
1. Run `docker-compose`
   ```bash
   docker compose up -d
   ```
1. Run your application using your favorite IDE or terminal `cd YourName.Api && dotnet run`
1. Go to `http://localhost:5024/swagger/index.html`
1. Check if it looks good

> No request will work because the migration is not created and applied. This is intentional in order not to pollute the project and the database.

## Where to start?

### Get familiar

1. Go to `ProductController` and see how the flow looks.
2. Go to `Application/Requests/Products/Commands/UpdateProductCommandHandler.cs` and see how update is performed and how to communicate using exceptions.
3. Go to `Peristence` and see how context is configured with see `ProductEntity` and `ProductEntityConfiguration`
4. Go to `Application/Services/Email` and later go to `Infrastructure/Services/Email` and see how ports and adapter pattern is implemented here.
5. Go to `Tests/UnitTests` to check how handlers can be tests
6. Go to `Tests/Intergration` to see how API can be tested in almost live environment 

### Cleanup

Remove all unnecessary files and start coding :)

## Credits

Created by Morasiu (morasiu2@gmail.com). Feel free to ask me any questions about it. 
