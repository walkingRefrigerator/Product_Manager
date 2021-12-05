using Microsoft.EntityFrameworkCore;
using Product_Manager.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Manager.Domain.Repositories.EntityFramework
{
    public class EFProductRepositories : IProductRepositories
    {
        private readonly TestDbContext _testDbContext;

        public EFProductRepositories(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }
        //Удаление продукта по id
        public void DeleteProduct(Guid id)
        {
            _testDbContext.Products.Remove(new Product { Id = id });
            _testDbContext.SaveChanges();
        }
        //Вывод всех объектов из бд
        public IList<Product> GetAll()
        {
            return _testDbContext.Products.ToList();
        }
        //Вывод списка по фильтру
        public IList<Product> GetFilterName(string name)
        {
            //Поиск объектов с совпадающими первыми буквами
            return _testDbContext.Products.Where(x => x.Name.StartsWith(name)).ToList();
        }
        //Вывод объета по id
        public Product GetProduct(Guid id)
        {
            return _testDbContext.Products.FirstOrDefault(x => x.Id == id);
        }
        //Добавление\редактирование объекта
        public void PostProduct(Product product)
        {
            //Проверка по id, был ли ранее создан объект или нет
            if (product.Id == default)
            {
                //Добавление объекта в бд с присвоением ему id
                product.Id = Guid.NewGuid();
                _testDbContext.Entry(product).State = EntityState.Added;
            }
            else
            {
                //Изменение объекта в бд
                _testDbContext.Entry(product).State = EntityState.Modified;
            }

            _testDbContext.SaveChanges();
        }
    }
}

