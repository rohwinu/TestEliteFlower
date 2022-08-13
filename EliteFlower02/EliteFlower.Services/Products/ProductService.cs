using EliteFlower.Core;
using EliteFlower.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteFlower.Services.Products
{
    public partial class ProductService : IProductService
    {
        private readonly eliteflowerContext _eliteflowerContext;

        public ProductService(eliteflowerContext eliteflowerContext)
        {
            _eliteflowerContext = eliteflowerContext;
        }

        public async Task<bool> Delete(int id)
        {
            Product product = _eliteflowerContext.Products.First(x => x.Id == id);
            _eliteflowerContext.Remove(product);
            await _eliteflowerContext.SaveChangesAsync();

            return true;
        }

        public List<Product> GetAll()
        {
            return _eliteflowerContext.Products.ToList();
        }

        public async Task<Product> GetById(int id)
        {
            return await _eliteflowerContext.Products.FindAsync(id);
        }

        public async Task<bool> Insert(Product product)
        {
            _eliteflowerContext.Add(product);
            await _eliteflowerContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Product product)
        {
            _eliteflowerContext.Products.Update(product);
            await _eliteflowerContext.SaveChangesAsync();
            return true;
        }
    }
}
