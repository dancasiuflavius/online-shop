using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.DTO
{
    internal class Cos
    {
        private List<ProductDto> _products;

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
