# API

This project is responsible for:
* Authorization
* Authentication
* Serialization
* Communication from and to clients i.e. frontend app
* Swagger config
* Health checks
* Api versioning

Notes:
* It shouldn't contain any business logic. All logic should be in `Application` project
* It should not contains ANY environment sensitive data in `appsettings.json` i.e. production database connection string. Use KeyVault or other methods to store it securely
* Default environment should be `LOCAL` 
  * `appsettings.json` should be treated like `appsettings.local.json`

More info:
* [Controllers](./Controllers/README.md) - How to create a new controller
* [Health checks](./Configuration/HealthChecks/README.md) - How to add a new health check