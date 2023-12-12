using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Models;
using online_shop.Services;

namespace Tests
{
    public class TestServiceProduct
   
    {
        [Fact]
        public void testFindProductByIdTrue()
        {
            List<Product> _productList = new List<Product>();

            Product product1 = new Product("P1", "Apple Watch", 500, "Apple Watch 8 series", "2023-11-01", 100);

            _productList.Add(product1);

            ServiceProducts _serviceProducts = new ServiceProducts(_productList);

            Assert.True(_serviceProducts.FindProductByID(product1));
        }
        [Fact]
        public void testFindProductByIdFalse()
        {
            List<Product> _productList = new List<Product>();

            Product product1 = new Product("P1", "Apple Watch", 500, "Apple Watch 8 series", "2023-11-01", 100);
            Product product2 = new Product("P2", "Iphone 15", 2000, "Iphone 15 Plus Space Gray", "2023-10-01", 50);

            _productList.Add(product1);

            ServiceProducts _serviceProducts = new ServiceProducts(_productList);

            Assert.False(_serviceProducts.FindProductByID(product2));
        }
        [Fact]
        public void testAddCustomerTrue()
        {
            List<Product> _productList = new List<Product>();

            Product product1 = new Product("P1", "Apple Watch", 500, "Apple Watch 8 series", "2023-11-01", 100);
            Product product2 = new Product("P2", "Iphone 15", 2000, "Iphone 15 Plus Space Gray", "2023-10-01", 50);

            _productList.Add(product1);

            ServiceProducts _serviceProducts = new ServiceProducts(_productList);

            _serviceProducts.AddProduct(product2);

            Assert.True(_serviceProducts.FindProductByID(product2));
        }
        [Fact]
        public void testAddProductFalse()
        {

            List<Product> _productList = new List<Product>();

            Product product1 = new Product("P1", "Apple Watch", 500, "Apple Watch 8 series", "2023-11-01", 100);
            Product product2 = new Product("P2", "Iphone 15", 2000, "Iphone 15 Plus Space Gray", "2023-10-01", 50);

            _productList.Add(product1);

            ServiceProducts _serviceProducts = new ServiceProducts(_productList);

            Assert.False(_serviceProducts.AddProduct(product1));
        }
        [Fact]
        public void testRemoveProductTrue()
        {
            List<Customer> _customerList = new List<Customer>();

            List<Product> _productList = new List<Product>();

            Product product1 = new Product("P1", "Apple Watch", 500, "Apple Watch 8 series", "2023-11-01", 100);
            Product product2 = new Product("P2", "Iphone 15", 2000, "Iphone 15 Plus Space Gray", "2023-10-01", 50);

            _productList.Add(product1);

            ServiceProducts _serviceProducts = new ServiceProducts(_productList);
            _serviceProducts.RemoveProduct("P1");

            Assert.False(_serviceProducts.FindProductByID(product1));
        }
        [Fact]
        public void testRemoveProductFalse() //Verific daca merge remove, false - inseamna ca nu merge, am pus Assert True ca sa stiu ca elementul  mai e in lista
        {
            List<Product> _productList = new List<Product>();

            Product product1 = new Product("P1", "Apple Watch", 500, "Apple Watch 8 series", "2023-11-01", 100);
            Product product2 = new Product("P2", "Iphone 15", 2000, "Iphone 15 Plus Space Gray", "2023-10-01", 50);

            _productList.Add(product1);

            ServiceProducts _serviceProducts = new ServiceProducts(_productList);

            string id = "x";

            Assert.False(_serviceProducts.RemoveProduct(id));
        }
        [Fact]
        public void testUpdateProductTrue()
        {
            List<Product> _productList = new List<Product>();

            Product product1 = new Product("P1", "Apple Watch", 500, "Apple Watch 8 series", "2023-11-01", 100);
            Product product2 = new Product("P2", "Iphone 15", 2000, "Iphone 15 Plus Space Gray", "2023-10-01", 50);

            _productList.Add(product1);

            ServiceProducts _serviceProducts = new ServiceProducts(_productList);

            Assert.True(_serviceProducts.UpdateProduct("P1", "a", 1, "a", "2021-11-02", 1, "aX"));
        }
        [Fact]
        public void testUpdateProductFalse()
        {
            List<Product> _productList = new List<Product>();

            Product product1 = new Product("P1", "Apple Watch", 500, "Apple Watch 8 series", "2023-11-01", 100);
            Product product2 = new Product("P2", "Iphone 15", 2000, "Iphone 15 Plus Space Gray", "2023-10-01", 50);

            _productList.Add(product1);

            ServiceProducts _serviceProducts = new ServiceProducts(_productList);

            Assert.False(_serviceProducts.UpdateProduct("P5", "a", 1, "a", "11/02/2021", 1, "aX"));
        }



    }
}

