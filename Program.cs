using System;
using Models.Entity;
using Models.EntityExts;

namespace LearningEfCore
{
    class Program
    {
        static void DisplayProductType(ProductType productType, String label)
        {
            Console.WriteLine(label);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(" Id       : " + productType.ProductTypeId);
            Console.WriteLine(" Name     : " + productType.ProductTypeName);
            Console.WriteLine(" Desc     : " + productType.ProductTypeDesc);
            Console.WriteLine(" HashCode : " + productType.GetHashCode());
        }

        static void TestWithNoTracking()
        {
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
        }

        static void TestWithTracking()
        {
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
        }

        static void Main(string[] args)
        {        
            try
            {
                if (args.Length == 0) {
                    Console.WriteLine(String.Format("Missing option. Kindly use either --with-tracking or --with-no-tracking."));
                    return;
                }
                switch(args[0])
                {
                    case "--with-tracking":
                        TestWithTracking();
                        break;
                    case "--with-no-tracking":
                        TestWithNoTracking();
                        break;
                    default:
                        Console.WriteLine(String.Format("Invalid option: '{0}'", args[0]));
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: \n" + ex.Message + "\n\t" + ex.StackTrace);
            }
        }
    }
}
