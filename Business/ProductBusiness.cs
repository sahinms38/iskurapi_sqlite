using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IskurNortwindApi.Contexts;
using IskurNortwindApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IskurNortwindApi.Business
{
    public class ProductBusiness : IProductService
    {
        private readonly NortwindContext _dbContext;

        public ProductBusiness(NortwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProducts()
        { 
            return  _dbContext.Set<Product>();
        }

        public Product GetById(int id)
        {
            return _dbContext.Products.AsEnumerable().Where(p => p.Id == id).First();
        }

        public Product Insert(Product product)
        {
            _dbContext.Set<Product>().Add(product);
            _dbContext.SaveChanges();
            return product;
        }
        public Product Update(Product product)
        {
            var foundProduct=_dbContext.Set<Product>().AsQueryable().Where(p => p.Id == product.Id).First();
            foundProduct.CategoryId = product.CategoryId;
            foundProduct.Description = product.Description;
            foundProduct.Name = product.Name;
            foundProduct.QuantityPerUnit = product.QuantityPerUnit;
            foundProduct.UnitPrice = product.UnitPrice;
            foundProduct.UnitsInStock = product.UnitsInStock;

            _dbContext.SaveChanges();
            return foundProduct;
        }

        public Product UpdateProductPrice(int id, decimal unitPrice)
        {
            var foundProduct = _dbContext.Set<Product>().AsQueryable().Where(p => p.Id == id).First();
            foundProduct.UnitPrice = unitPrice;
            _dbContext.SaveChanges();
            return foundProduct;
        }

        public int DeleteProduct(int id)
        {
            var foundProduct = _dbContext.Set<Product>().AsQueryable().Where(p => p.Id == id).First();
            _dbContext.Products.Remove(foundProduct);
            var result =_dbContext.SaveChanges();
            return result;
        }
    }
}
