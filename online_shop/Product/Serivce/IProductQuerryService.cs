using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.OrderDetail;
using online_shop.Products;
using online_shop.Products.Model;

namespace online_shop.Products.Model
{
    public interface IProductQuerryService
    {
        bool FindProductByID(Product product);
        Product FindProductByID2(string productId);
        Product FindProductByName(string name);
        void ShowProducts();
        void UpdateStock(List<ProductDto> productDtos);
        void UpdateStock(List<OrderDetails> orderDetails);
        void ReadProduct();
        public string NextID();
    }
}
