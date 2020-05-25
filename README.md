# A Readonly Situation

## A. Introduction
This is a pretty simple scenario wherein, we only require to perform simple readonly or select queries from the database. For instance, dealing with master data or enum types are a good example.

## B. The scenario
We are reading from a table named Product and ProductType, where ProductType is a master table, consisting of "Mobile", "Tablet" and "Laptop" as predefined product types. We will create a dotnet core console application, which will fetch us the list of products along with their respective product types.
  ### 1. The entities:
  Below is the entity diagram for the above described scenario:
  x-special/nautilus-clipboard
copy
file:///home/siddharth/Downloads/A-Readonly-Scenario-ERD.png


# A. About Tracing

The method below serves the purpose:
- DbExtensions.AsNoTracking(this IQueryable query)
  - The method disables change tracking for the queried entity.
  - Performs better in comparison to tracking, since there is no change tracking involved.

The extension method is targetted for disabling tracing for IQueryable objects and disables change tracking for the desired entity.
