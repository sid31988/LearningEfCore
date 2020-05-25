# A Readonly Situation

## A. Introduction
This is a pretty simple scenario wherein, we only require to perform simple readonly or select queries from the database. For instance, dealing with master data or configuration data stored in database are a good example.

## B. The scenario
We are reading from a table named Product and ProductType, where ProductType is a master table, consisting of "Mobile", "Tablet" and "Laptop" as predefined product types. We will create a dotnet core console application, which will fetch us the list of products along with their respective product types.
  ### 1. The entities:
  ![Entity Diagram](https://github.com/sid31988/LearningEfCore/blob/scenario/001-Readonly-Situation/A-Readonly-Scenario-ERD.png)
  ### 2. Solutions:
  There are two approaches for such a kind of scenario,
  a. complete readonly
      Here we can directly set the query tracking behavior for all the queries.
      ```
      context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
      var productTypes = context.ProductTypes.ToList();
      ```
  b. partial readonly
      Here we can optionally set the query tracking behavior for a desired query.
      ```
      var poductTypes = context.ProductTypes.AsNoTacking().ToList();
      ```

# A. About Tracing

The method below serves the purpose:
- DbExtensions.AsNoTracking(this IQueryable query)
  - The method disables change tracking for the queried entity.
  - Performs better in comparison to tracking, since there is no change tracking involved.

The extension method is targetted for disabling tracing for IQueryable objects and disables change tracking for the desired entity.
