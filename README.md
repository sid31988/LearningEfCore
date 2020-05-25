# A Readonly Situation
### A. Introduction
This is a pretty simple scenario wherein, we only require to perform simple readonly or select queries from the database. For instance, dealing with master data or configuration data stored in database are a good example.

### B. The scenario
We are reading from a table named Product and ProductType, where ProductType is a master table, consisting of "Mobile", "Tablet" and "Laptop" as predefined product types. We will create a dotnet core console application, which will fetch us the list of products along with their respective product types.
  ### 1. The entities:
  ![Entity Diagram](https://github.com/sid31988/LearningEfCore/blob/scenario/001-Readonly-Situation/A-Readonly-Scenario-ERD.png)
  ### 2. Solutions:
  There are two approaches for such a kind of scenario,  
  #### 2.1. Context instance readonly:
  Here we can directly set the query tracking behavior for all the queries, at context instance level.
  ```
    context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    var productTypes = context.ProductTypes.ToList();
  ```
  #### 2.2. Query readonly:
  Here we can optionally set the query tracking behavior for a desired query.
  ```
    var poductTypes = context.ProductTypes.AsNoTacking().ToList();
  ```
### C. About Tracing
- Entity Framework by default enables change tracking on all the entities, so that their state is referred when context.SaveChanges is invoked.
- Non tracking query is hence faster in comparison to a tracking enabled query, since there is no inclusion of change tracking mechanism.
- However, Non tracking queries can not be used in cases of inclusion, because for non tracking queries identity resolution is also disabled.
- Inclusion allows fetching an entity we also include the dependent entities, by means of DbExtensions.Include(this IQueryable query) extension method.
- Identity resolution is a mechanism where the id fields are traced, and if a reference to the same id is made, the earlier instance is fetched using change tracking, which does not works in case of non-tracking queries, since change tracking is disabled, hence for them every time a new instance is created even for duplicate references to the same id value.
- Let us understand change tracking with an example. Suppose while fetching data for Products, we also include the data from ProductType. Now assume, for product type "mobile", there are two products "Samsung" and "Nokia", below lines of code demonstrate the change of behavior with tracking enabled and disabled:
  1. Tracking enabled
    ```
    using (var db = new AppDbContext())
    {
        var nonTrackedProducts = db.Products.List(false);
        var mobilePhones = nonTrackedProducts.FindAll(x => x.ProductType.ProductTypeId == 1);
        DisplayProductType(mobilePhones[0].ProductType, "mobilePhones[0].ProductType");
        Console.WriteLine();
        DisplayProductType(mobilePhones[1].ProductType, "mobilePhones[1].ProductType");
        Console.WriteLine();
        if (mobilePhones[0].ProductType == mobilePhones[1].ProductType)
            Console.WriteLine("\"Id Resolution\" found i.e. both the product type instances are same, since tracking is enabled");
    }
    ```
  2. Tracking disabled
    ```
    using (var db = new AppDbContext())
    {
        var nonTrackedProducts = db.Products.List(true);
        var mobilePhones = nonTrackedProducts.FindAll(x => x.ProductType.ProductTypeId == 1);
        DisplayProductType(mobilePhones[0].ProductType, "mobilePhones[0].ProductType");
        Console.WriteLine();
        DisplayProductType(mobilePhones[1].ProductType, "mobilePhones[1].ProductType");
        if (mobilePhones[0].ProductType != mobilePhones[1].ProductType)
            Console.WriteLine("No \"Id Resolution\" i.e. both the product type instances are different, since tracking is disabled.");
    }
    ```
