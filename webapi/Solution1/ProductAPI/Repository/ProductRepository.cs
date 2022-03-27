using ProductAPI.Models;
using ProductAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAPI.Context;

namespace ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool CreateProduct(Product product)
        {
            context.Product.Add(product);
            return Save();
        }

        public bool DeleteProduct(Product product)
        {
            context.Product.Remove(product);
            return Save();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Product.ToList();
        }

        public Product GetProduct(int id)
        {
            return context.Product.FirstOrDefault(x => x.Id.Equals(id));
        }

        public bool ProductExist(string name)
        {
            return context.Product.Any(x => x.Name.ToLower().Trim ().Equals (name.ToLower().Trim()));
        }

        public bool ProductExist(int id)
        {
            return context.Product.Any(x => x.Id.Equals(id));
        }
    

        public bool Save()
        {
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateProduct(Product product)
        {
            context.Product.Update(product);
            return Save();
        }
    }
}
