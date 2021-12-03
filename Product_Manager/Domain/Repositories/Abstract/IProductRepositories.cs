using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Manager.Domain.Repositories.Abstract
{
    public interface IProductRepositories
    {
        IList<Product> GetAll();
        IList<Product> GetFilterName(string name);
        Product GetProduct(Guid id);
        void PostOrPutProduct(Product product);
        void DeleteProduct(Guid id);
    }
}
