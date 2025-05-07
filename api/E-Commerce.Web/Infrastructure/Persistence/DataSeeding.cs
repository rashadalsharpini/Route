using System.Text.Json;
using Domain.Contracts;
using Domain.Models;
using Domain.Models.productModule;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence;

public class DataSeeding(StoreDbContext db) : IDataSeeding
{
    public async Task DataSeedAsync()
    {
        try
        {

            var pendingMigrations = await db.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
                await db.Database.MigrateAsync();
            if (!db.ProductBrands.Any())
            {
                // var productBrandsData = await File.ReadAllTextAsync(@"../Infrastructure/Persistence/Data/DataSeed/brands.json");
                var productBrandsData = File.OpenRead(@"../Infrastructure/Persistence/Data/DataSeed/brands.json");
                var productBrands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(productBrandsData);
                if (productBrands is not null && productBrands.Any())
                    await db.ProductBrands.AddRangeAsync(productBrands);
            }

            if (!db.ProductTypes.Any())
            {
                var productTypesData = File.OpenRead(@"../Infrastructure/Persistence/Data/DataSeed/types.json");
                var productTypes = await JsonSerializer.DeserializeAsync<List<ProductType>>(productTypesData);
                if (productTypes is not null && productTypes.Any())
                    await db.ProductTypes.AddRangeAsync(productTypes);
            }

            if (!db.Products.Any())
            {
                var productSData = File.OpenRead(@"../Infrastructure/Persistence/Data/DataSeed/products.json");
                var products = await JsonSerializer.DeserializeAsync<List<Product>>(productSData);
                if (products is not null && products.Any())
                    await db.Products.AddRangeAsync(products);
            }

            await db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // TODO  
        }

    }
}