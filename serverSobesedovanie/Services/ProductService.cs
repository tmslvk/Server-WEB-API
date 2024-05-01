using Microsoft.EntityFrameworkCore;
using serverSobesedovanie.DTO;
using serverSobesedovanie.Models;
using System.Linq;
using System.Threading.Tasks;

namespace serverSobesedovanie.Services
{
    public class ProductService
    {
        ApplicationContext db;

        public ProductService(ApplicationContext context)
        {
            this.db = context;
        }

        public async Task<Product> Add(ProductDTO productsDTO)
        {
            Product products = new Product()
            {
                DefaultQuantity = productsDTO.DefaultQuantity,
                Name = productsDTO.Name,
            };

            await db.Products.AddAsync(products);
            await db.SaveChangesAsync();

            return products;
        }

        public async Task<Product> Get(int id)
        {
            return await db.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Delete(int id)
        {
            var product = await Get(id);

            db.Products.Remove(product);
            await db.SaveChangesAsync();
        }

        public async Task<Product> Update(int id, ProductDTO fridgeDTO)
        {
            var product = await Get(id);

            if (product.Name != null)
            {
                product.Name = fridgeDTO.Name;
            }
            if (product.DefaultQuantity != null)
            {
                product.DefaultQuantity = fridgeDTO.DefaultQuantity;
            }
            return product;
        }

        public async Task SetProductsDefaultQuantities()
        {
            var productsQuery = db.FridgeProducts.FromSqlRaw("SelectFridgeProducts");
            var list = productsQuery.AsAsyncEnumerable();
            await foreach (var fridgeProduct in list)
            {
                var product = await Get(fridgeProduct.ProductId);
                fridgeProduct.Quantity = product.DefaultQuantity.Value;
            }
            db.SaveChanges();
        }
    }
}
