using Newtonsoft.Json;
using Rest_Api_Task___RestSharp.Entities;
using Rest_Api_Task___RestSharp.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rest_Api_Task___RestSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new Products();
            var getProducts = products.GetAllProducts();

            var productsDomestic = getProducts.Where(x => x.domestic == true).ToList();
            var productsImported = getProducts.Where(x => x.domestic == false).ToList();

            products.printDomesticProducts(productsDomestic);
            products.printImportedProducts(productsImported);

            var domesticCost = products.getDomesticCost(productsDomestic);
            Console.WriteLine($"Domestic cost: ${domesticCost}");

            var importedCost = products.getImportedCost(productsImported);
            Console.WriteLine($"Imported cost: ${importedCost}");

            var domesticCount = products.getDomesticCount();
            Console.WriteLine($"Domestic count: {domesticCount}");

            var importedCount = products.getImportedCount();
            Console.WriteLine($"Imported count: {importedCount}");

            Console.ReadLine();
        }
    }
}
