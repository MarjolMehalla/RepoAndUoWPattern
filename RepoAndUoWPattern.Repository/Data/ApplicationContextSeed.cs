using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RepoAndUoWPattern.Data.Entities;

namespace RepoAndUoWPattern.Repository.Data
{
    public static class ApplicationContextSeed
    {

        public static async Task SeedAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {

                if (!context.Products.Any())
                {
                    var productsData = await File.ReadAllTextAsync("../RepoAndUoWPattern.Repository/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    if (products != null)
                        foreach (var item in products)
                        {
                            await context.Products.AddAsync(item);
                        }

                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger(typeof(ApplicationContextSeed));
                logger.LogError(ex.Message);

            }
        }
    }
}
