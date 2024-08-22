# Entities

Here should be stored all entities with configuration.

Sample structure
* `Examples` - note that it should be plural
  * `ExampleEntity.cs` - should have `Entity` suffix to avoid name conflicts
  * `ExampleEntityConfiguration.cs` - should contain all configuration for given entity i.e. key, relations

Notes:
* Use `ICollection<T>` for navigation properties (EF Core can then use HashSet for then)