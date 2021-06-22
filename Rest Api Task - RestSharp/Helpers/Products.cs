using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using StringExtensions.Truncate;
using Rest_Api_Task___RestSharp.Entities;
using RestSharp;

namespace Rest_Api_Task___RestSharp.Helpers
{
    public class Products
    {
        public List<Product> GetAllProducts()
        {
            string url = "https://interview-task-api.mca.dev/qr-scanner-codes/alpha-qr-gFpwhsQ8fkY1";

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            List<Product> convert = JsonConvert.DeserializeObject<IEnumerable<Product>>(response.Content) as List<Product>;
            return convert;
        }

        public void printDomesticProducts(List<Product> domesticProducts)
        {
            var domesticProductsForPrinting = domesticProducts.Where(x => x.domestic == true).ToList();
            var productsAlphabetical = domesticProductsForPrinting.OrderBy(x => x.name).ToList();
            Console.WriteLine(".Domestic");
            foreach (Product product in productsAlphabetical)
            {
                if (product.weight == null)
                {
                    string weight = "N/A";
                    string s = product.description;
                    if (s.Length > 30)
                    {
                        Console.WriteLine($"...{product.name} \n Price: ${product.price} \n {s.Truncate(12, "...")} \n Weight: {weight}");
                    }
                    if (s.Length <= 30)
                    {
                        Console.WriteLine($"...{product.name} \n Price: ${product.price} \n {product.description} \n Weight: {weight}");
                    }
                }
                if (product.weight != null)
                {

                    string s = product.description;
                    if (s.Length > 30)
                    {
                        {
                            Console.WriteLine($"...{product.name} \n Price: ${product.price} \n {s.Truncate(12, "...")} \n Weight: {product.weight}g");
                        }
                    }
                    if (s.Length <= 30)
                    {
                        Console.WriteLine($"...{product.name} \n Price: ${product.price} \n {s} \n Weight: {product.weight}g");
                    }
                }
            }
        }

        public void printImportedProducts(List<Product> importedProducts)
        {
            var importedProductsForPrinting = importedProducts.Where(x => x.domestic == false).ToList();
            var importedProductsAlphabetical = importedProductsForPrinting.OrderBy(x => x.name).ToList();
            Console.WriteLine(".Imported");

            foreach (Product product in importedProductsAlphabetical)
            {
                if (product.weight == null)
                {
                    string weight = "N/A";
                    string s = product.description;
                    if (s.Length > 30)
                    {
                        Console.WriteLine($"...{product.name} \n Price: {product.price}$ \n {s.Truncate(12, "...")} \n Weight: {weight}");
                    }
                    if (s.Length <= 30)
                    {
                        Console.WriteLine($"...{product.name} \n Price: {product.price}$ \n {product.description} \n Weight: {product.weight}");
                    }
                }
                if (product.weight != null)
                {

                    string s = product.description;
                    if (s.Length > 30)
                    {
                        {
                            Console.WriteLine($"...{product.name} \n Price: {product.price}$ \n {s.Truncate(12, "...")} \n Weight: {product.weight}g");
                        }
                    }
                    if (s.Length <= 30)
                    {
                        Console.WriteLine($"...{product.name} \n Price: {product.price}$ \n {s} \n Weight: {product.weight}g");
                    }
                }
            }
        }

        public double getDomesticCost(List<Product> productList)
        {
            var domesticSum = productList.Where(x => x.domestic == true).Sum(x => (double)(x.price));
            return domesticSum;
        }

        public double getImportedCost(List<Product> productList)
        {
            var importedSum = productList.Where(x => x.domestic == false).Sum(x => (double)(x.price));
            return importedSum;
        }

        public int getDomesticCount()
        {
            var domesticProducts = new Products();
            var domProducts = domesticProducts.GetAllProducts().Where(x => x.domestic == true);
            return domProducts.Count();
        }

        public int getImportedCount()
        {
            var importedProducts = new Products();
            var impProducts = importedProducts.GetAllProducts().Where(x => x.domestic == false);
            return impProducts.Count();
        }
    }
    
}
