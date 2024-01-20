using online_shop.Services;
using online_shop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Products.Model;

namespace Tests
{
    public class TestCos
    {
        [Fact]
        public void testProductTrue()
        {
            List<ProductDto> _productsDTO = new List<ProductDto>();

            Product prod = new Product("1", "iphone", 100, "telefon", "12/12/2023", 20);
            Product prod1 = new Product("2", "airpods", 100, "airpods", "12/10/2023", 10);

            ProductDto pdto = new ProductDto(prod, 20);
            ProductDto pdto1 = new ProductDto(prod1, 10);

            _productsDTO.Add(pdto);
            _productsDTO.Add(pdto1);

            Cos _cos = new Cos(_productsDTO);

            Assert.True(_cos.FindProduct(pdto));
        }
        [Fact]
        public void testProductFalse()
        {
            List<ProductDto> _productsDTO = new List<ProductDto>();

            Product prod = new Product("1", "iphone", 100, "telefon", "12/12/2023", 20);
            Product prod1 = new Product("2", "airpods", 100, "airpods", "12/10/2023", 10);

            ProductDto pdto = new ProductDto(prod, 20);
            ProductDto pdto1 = new ProductDto(prod1, 10);

            _productsDTO.Add(pdto);
            

            Cos _cos = new Cos(_productsDTO);

            Assert.False(_cos.FindProduct(pdto1));
        }
        [Fact]
        public void testAddProductTrue()
        {
            List<ProductDto> _productsDTO = new List<ProductDto>();

            Product prod = new Product("1", "iphone", 100, "telefon", "12/12/2023", 20);
            Product prod1 = new Product("2", "airpods", 100, "airpods", "12/10/2023", 10);

            ProductDto pdto = new ProductDto(prod, 20);
            ProductDto pdto1 = new ProductDto(prod1, 10);

            _productsDTO.Add(pdto);
            


            Cos _cos = new Cos(_productsDTO);
            _cos.AddProduct(pdto1);

            Assert.True(_cos.FindProduct(pdto1));
        }
        [Fact]
        public void testRemoveProduct()
        {
            List<ProductDto> _productsDTO = new List<ProductDto>();

            Product prod = new Product("1", "iphone", 100, "telefon", "12/12/2023", 20);
            Product prod1 = new Product("2", "airpods", 100, "airpods", "12/10/2023", 10);

            ProductDto pdto = new ProductDto(prod, 20);
            ProductDto pdto1 = new ProductDto(prod1, 10);

            _productsDTO.Add(pdto);
            _productsDTO.Add(pdto1);

            String id = pdto.ID;

            Cos _cos = new Cos(_productsDTO);
            _cos.RemoveProduct(id);

            Assert.False(_cos.FindProduct(pdto));
        }
        [Fact]
        public void testRemoveProductByName()
        {
            List<ProductDto> _productsDTO = new List<ProductDto>();

            Product prod = new Product("1", "iphone", 100, "telefon", "12/12/2023", 20);
            Product prod1 = new Product("2", "airpods", 100, "airpods", "12/10/2023", 10);

            ProductDto pdto = new ProductDto(prod, 20);
            ProductDto pdto1 = new ProductDto(prod1, 10);

            _productsDTO.Add(pdto);
            _productsDTO.Add(pdto1);

            String id = pdto.Name;

            Cos _cos = new Cos(_productsDTO);
            _cos.RemoveProductByName(id);

            Assert.False(_cos.FindProduct(pdto));
        }
        [Fact]
        public void testUpdateBasket()
        {
            List<ProductDto> _productsDTO = new List<ProductDto>();

            Product prod = new Product("1", "iphone", 100, "telefon", "12/12/2023", 20);
            Product prod1 = new Product("2", "airpods", 100, "airpods", "12/10/2023", 10);

            ProductDto pdto = new ProductDto(prod, 20);
            ProductDto pdto1 = new ProductDto(prod1, 10);

            _productsDTO.Add(pdto);
            _productsDTO.Add(pdto1);

            Cos _cos = new Cos(_productsDTO);

            _cos.UpdateBasket(pdto, 2);

            Assert.Equal(22, pdto.Qty);
        }
        [Fact]
        public void testFindPos()
        {
            List<ProductDto> _productsDTO = new List<ProductDto>();

            Product prod = new Product("1", "iphone", 100, "telefon", "12/12/2023", 20);
            Product prod1 = new Product("2", "airpods", 100, "airpods", "12/10/2023", 10);

            ProductDto pdto = new ProductDto(prod, 20);
            ProductDto pdto1 = new ProductDto(prod1, 10);

            _productsDTO.Add(pdto);
            _productsDTO.Add(pdto1);

            Cos _cos = new Cos(_productsDTO);

            int pos = 0;
            pos = _cos.FindPos(pdto);

            Assert.Equal(0, pos);
        }

    }
}
