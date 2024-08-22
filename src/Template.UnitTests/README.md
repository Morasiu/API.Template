# Unit tests

This project contains a set of unit tests for the `Template` project.

## What should be tested
* All `Requests`
* Any class containing any business logic

## What should not be tested
* Difficult or impossible to test service classes for example `ServiceBus`
* Any class that need external dependencies like. Email, SMS, etc.

## How to write a request test
1. Create a new test class in a specific directory. Match the hierarchy of the `Requests` directory in `Application project`.
    > Example: for `GetAllProductsQueryHandler` create `Requests/Products/Queries/GetAllProducts/GetAllProductsQueryHandlerTests.cs`
2. Inherit from `BaseRequestTest` class.
3. Test all code paths of the request.

## Notes
* Use `NSubstitute` for mocking dependencies.
* It's okay to use `InMemoryDatabase` for unit testing, integration tests should use a real database.
* Use `Generators` from `Shared` project to generate random data.
* Use Arrange, Act, Assert pattern in your tests.

