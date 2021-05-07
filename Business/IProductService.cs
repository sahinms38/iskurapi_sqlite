using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IskurNortwindApi.Models;

namespace IskurNortwindApi.Business
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetById(int id);
        Product Insert(Product product);
        Product Update(Product product);
        int DeleteProduct(int id);
        Product UpdateProductPrice(int id, decimal unitPrice);
    }
}
