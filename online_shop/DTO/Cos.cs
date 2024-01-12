using online_shop.Models;
using online_shop.Products.Serivce;
using online_shop.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.DTO
{
    public class Cos
    {
        public List<ProductDto> _products;


  

         
        private Cos(List<ProductDto> products)
        {
            _products = products;
        }

        public Cos()
        {
            _products = new List<ProductDto>();
        }

        public bool FindProduct(ProductDto product)
        {
            for (int i = 0; i < _products.Count; i++)
                if (product.ID.Equals(_products[i].ID))
                    return true;
            return false;

        }
        public void AddProduct(ProductDto product)
        {

            if (FindProduct(product) == true)
            {
                product.Qty += 1;
               
            }
            else
                _products.Add(product);
        }
        public void RemoveProduct(String id)
        {
            for (int i = 0; i < _products.Count; i++)
                if (_products[i].ID.Equals(id))
                    _products.Remove(_products[i]);
        }
        public void RemoveProductByName(String name)
        {
            for (int i = 0; i < _products.Count; i++)
                if (_products[i].Name.Equals(name))
                    _products.Remove(_products[i]);
        }
        public void UpdateBasket(ProductDto product, int qty)
        {
            int pos = 0;
            pos = FindPos(product);
            
            if (FindProduct(product) == true)
            {
                _products[pos].Qty += qty;
            }
            else
                _products.Add(product);
        }
        public int FindPos(ProductDto product)
        {
            int pos = 0;
            for (int i = 0; i < _products.Count; i++)
                if (_products[i].Equals(product))
                    pos = i;
            return pos;
        }


        public CreateOrderRequest createOrder(ServiceOrders order,ServiceOrderDetails serviceOrderDetails, ServiceProducts serviceProd,Customer customer)
        {
            CreateOrderRequest request = new CreateOrderRequest();
            request.Details = new List<OrderDetails>();
            int total=0;
            this._products.ForEach(x => {
                total += x.TotalPrice;


            });
            request.order = new Order(order.NextID(), customer.GetID(), total, "created");
            this._products.ForEach(x => {
                request.Details.Add(new OrderDetails(serviceOrderDetails.NextID(),request.order.GetOrderID(),x.ID,x.TotalPrice,x.Qty));
            });
            serviceProd.UpdateStock(_products);
            return request;

        }


        public override string ToString()
        {


            String text = "";

            foreach (ProductDto product in _products)
            {
                text += product;
            }

            return text;
        }
    }
}
