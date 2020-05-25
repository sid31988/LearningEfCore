using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models.Entity;
using System.Linq;

namespace Models.EntityExts
{
    public static class ProductsExtensions
    {
        public static List<Product> List(this DbSet<Product> productSet, bool noTracking = false, bool includeProductType = true)
        {
            IQueryable<Product> productQuery = null;
            if (noTracking)
                productQuery = productSet.AsNoTracking();
            else
                productQuery = productSet.AsTracking();
            if (includeProductType)
                productQuery = productQuery.Include(x => x.ProductType);
            return productQuery.ToList();
        }
    }
}