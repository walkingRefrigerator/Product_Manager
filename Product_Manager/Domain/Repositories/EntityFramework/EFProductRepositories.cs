using Microsoft.EntityFrameworkCore;
using Product_Manager.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Manager.Domain.Repositories.EntityFramework
{
    public class EFProductRepositories : IProductRepositories
    {
        private readonly TestDbContext _testDbContext;

        public EFProductRepositories(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }

        public void DeleteProduct(Guid id)
        {
            _testDbContext.Products.Remove(new Product { Id = id });
            _testDbContext.SaveChanges();
        }

        public IList<Product> GetAll()
        {
            return _testDbContext.Products.ToList();
        }

        public IList<Product> GetFilterName(string name)
        {
            return _testDbContext.Products.Where(x => x.Name == name).ToList();
        }

        public Product GetProduct(Guid id)
        {
            return _testDbContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void PostOrPutProduct(Product product)
        {
            if (product.Id == default)
            {
                product.Id = Guid.NewGuid();
                _testDbContext.Entry(product).State = EntityState.Added;
            }
            else
            {
                _testDbContext.Entry(product).State = EntityState.Modified;
            }

            _testDbContext.SaveChanges();
        }
    }
}

