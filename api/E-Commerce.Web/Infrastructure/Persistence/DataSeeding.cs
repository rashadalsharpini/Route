using System.Text.Json;
using Domain.Contracts;
using Domain.Models.IdentityModel;
using Domain.Models.productModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Persistence.Data;
using Persistence.Identity;

namespace Persistence;

public class DataSeeding(
    StoreDbContext db,
    UserManager<AppUser> userManager,
    RoleManager<IdentityRole> roleManager, 
    StoreIdentityDbContext identityDb,
    ILogger<DataSeeding> logger)
    : IDataSeeding
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
            logger.LogError(ex.Message);
        }
    }

    public async Task IdentityDataSeedAsync()
    {
        try
        {

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }

            if (!userManager.Users.Any())
            {
                var user01 = new AppUser()
                {
                    Email = "mohamed@gmail.com",
                    DisplayName = "mohamed",
                    PhoneNumber = "0123456789",
                    UserName = "mohamed",
                };
            
                var user02 = new AppUser()
                {
                    Email = "salma@gmail.com",
                    DisplayName = "salma",
                    PhoneNumber = "0123456789",
                    UserName = "salma",
                };
                await userManager.CreateAsync(user01, "P@ssw0rd");
                await userManager.CreateAsync(user02, "P@ssw0rd");
                await userManager.AddToRoleAsync(user01, "Admin");
                await userManager.AddToRoleAsync(user02, "SuperAdmin");
            }
            await identityDb.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}