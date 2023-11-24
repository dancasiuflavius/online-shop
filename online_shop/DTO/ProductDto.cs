using online_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.DTO
{
    public class ProductDto
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }

        public int TotalPrice { get; set; }


        public ProductDto(Product product,int qty)
        {


            this.ID = product.GetProductID();

            this.Name=product.GetProductName();

            this.Qty = qty;

            this.TotalPrice = qty*product.GetPrice();
       }




        public override string ToString()
        {
            return "Produs: " + Name + "  " + "QTY:" + Qty + "  " + "Total Price:" + TotalPrice;
        }
    }
}
