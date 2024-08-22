# Generators

Here should be placed generators for entities.

## How to create a new generator

1. Create new class called `EntityNameGenerator`
> It should inherit from `Faker<EntityName>`
2. Add `RuleFor` methods for each property. Try to use a proper random generator method.

Example:
```cs
RuleFor(x => x.Id, Guid.NewGuid);
RuleFor(x => x.Name, f => f.Commerce.ProductName());
RuleFor(x => x.Description, f => f.Commerce.ProductDescription());
RuleFor(x => x.Email, f => f.Internet.Email());
```