using online_shop.Products.Model;
using online_shop.Products.Serivce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Products.Serivce
{
    public class Sorting : ISorting
    {
        public List<Product> AscendingSortByPrice(List<Product> _productList)
        {
            Product aux = new Product();

            for (int i = 0; i < _productList.Count; i++)
            {
                for (int j = 0; j < _productList.Count; j++)
                    if (_productList[i].GetPrice() < _productList[j].GetPrice())
                    {
                        aux = _productList[i];
                        _productList[i] = _productList[j];
                        _productList[j] = aux;
                    }
            }
            return _productList;


        }
        public List<Product> DescendingSortByPrice(List<Product> _productList)
        {
            Product aux = new Product();

            for (int i = 0; i < _productList.Count; i++)
            {
                for (int j = 0; j < _productList.Count; j++)
                    if (_productList[i].GetPrice() > _productList[j].GetPrice())
                    {
                        aux = _productList[i];
                        _productList[i] = _productList[j];
                        _productList[j] = aux;
                    }
            }
            return _productList;
        }
        public List<Product> SortDate(List<Product> list)
        {
            Product a = new Product();
            Product b = new Product();
            list.Sort((a, b) => a.GetCreationDate().CompareTo(b.GetCreationDate()));
            return list;
        }
    }
}
