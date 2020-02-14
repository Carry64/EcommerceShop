using EcommerceShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                this.products = new List<Product>();
            }
        }

        public void Commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product p)
        {
            products.Add(p);
        }

        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.Id == product.Id);

            if (productToUpdate == null)
            {
                throw new Exception("Product not found!");
            }
            else
            {
                productToUpdate = product;
            }
        }

        public Product Find(string Id)
        {
            Product productToFind = products.Find(p => p.Id == Id);

            if (productToFind == null)
            {
                throw new Exception("Product doesn't exist");
            }
            else
            {
                return productToFind;
            }
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string Id)
        {
            Product productToDelete = products.Find(p => p.Id == Id);

            if (productToDelete == null)
            {
                throw new Exception("This product doesn't exist");
            }
            else
            {
                products.Remove(productToDelete);
            }
        }

    }
}
