using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.DBContexts;
using ProductMicroservice.Models;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        //DI
        private readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbConetxt)
        {
            _dbContext = dbConetxt;
        }


        public void DeleteProduct(int ProductId)
        {
            var Product = _dbContext.Products.Single(p => p.Id == ProductId);
            _dbContext.Remove(Product);
            Save();
        }

        public Product GetProductById(int ProductId)=> _dbContext.Products.Single(p => p.Id == ProductId);


        public IEnumerable<Product> GetProducts() => _dbContext.Products.ToList();
       

        public void InsertProduct(Product Product)
        {
            _dbContext.Products.Add(Product);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            Save();

        }
    }
}
