# Controllers

## Rules

1. All routes have to have plural names i.e. Products, Shops
2. All operations have to have names in CRUD
    * `Create` for all `POST` operations
    * `GetAll` and `GetById` for all `GET` operations
    * `Update` for all `PUT` operation
    * `Delete` for all `DELETE` operations
3. Use type specifiers in the route params i.e.
   ```csharp
   [HttpPut("{id:guid}")]
   ```
4. Specify what codes and data an endpoint can return using `ProducesResponseType` attribute
5. Pass `cancellationToken` all the way down
6. Do not send more than one request using mediator in an endpoint
7. Assign values from routes to request if needed. I.e. Id from route

## Validation

All requests are validated using automatic FluentValidation.
See [validator class](../../Template.Application/Requests/Products/Commands/CreateProduct/CreateProductCommandValidator.cs)
for example validator class.

> ⚠ Note: When using automatic FluentValidation you cannot use any async functions. 
