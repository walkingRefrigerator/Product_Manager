using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Manager.Domain.Repositories.Abstract
{
    public interface IProductRepositories
    {
        //Вывод всех объектов из бд
        IList<Product> GetAll();
        //Вывод списка по фильтру
        IList<Product> GetFilterName(string name);
        //Вывод объета по id
        Product GetProduct(Guid id);
        //Добавление\редактирование объекта
        void PostProduct(Product product);
        //Удаление продукта по id
        void DeleteProduct(Guid id);
    }
}
