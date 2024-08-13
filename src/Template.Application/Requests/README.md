# Requests

Here you can find all requests for mediator pipeline.

## CQRS

CQRS is a simple pattern for structuring project.

Basic rules:
* All request that **retrieve data** should be called `Queries`
* All request that **modify data** (creating, updating, deleting) should be called `Commands`

## Directory structure

Directories here should be a vertical feature slice meaning all the features should have separate directories i.e. products, stores etc.

Every slice should have structure like this:

* Example - feature name i.e. `products`, `stores` in plural form
  * Commands
    * CreateExample
      * CreateExampleCommand.cs 
      * CreateExampleCommandHandler.cs
      * CreateExampleCommandValidator.cs
    * UpdateExample
        * UpdateExampleCommand.cs
        * UpdateExampleCommandHandler.cs
        * UpdateExampleCommandValidator.cs
    * DeleteExample
        * DeleteExampleCommand.cs
        * DeleteExampleCommandHandler.cs
  * Mappings
    * ExampleDtoMapping.cs
  * Queries
    * GetAllExamples
      * GetAllExamplesQuery.cs
      * GetAllExamplesQueryHandler.cs
      * GetAllExamplesQueryValidator.cs
    * GetExampleById
      * GetAllExamplesQuery.cs
      * GetAllExamplesQueryHandler.cs
  * ExampleDto.cs
  * ExampleDetailsDto.cs


Notes:
* Add `[JsonIgnore]` to commands and queries for route parameters i.e. Id to hide it in swagger
* DO NOT USE ANY ASYNC actions in validators (it would not work with auto validation)
* DO NOT USE database in validator. Verify things in handler and throw proper exception
* Try to keep DTOs consistent i.e `Create` and `Update` should return the same DTO