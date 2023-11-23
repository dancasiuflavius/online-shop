using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Common;
using online_shop.Models;

namespace online_shop.Services
{
    public class ServiceProducts
    {
        private List<Product> _productsList;

        private String _filePath;

        public ServiceProducts()
        {
            _productsList = new List<Product>();
            _filePath = GetDirectory();

            this.ReadProduct();
        }
        public ServiceProducts(List<Product> products)
        {
            _productsList = products;

        }
        public string GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string dataFolderPath = Path.Combine(currentDirectory, "Data");

            string filePath = Path.Combine(dataFolderPath, "products.txt");

            return filePath;
        }
        public void ReadProduct()
        {
            try
            {

                string filePath = GetDirectory();

                // Create a StreamReader to read from the file
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Read and process the file line by line
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        _productsList.Add(new Product(line));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
        }
        public void ShowProducts()
        {
            for (int i = 0; i < _productsList.Count; i++)
                Console.WriteLine(_productsList[i].GetProductDescription());
        }
        public void ShowProducts(List<Product> products )
        {
            for (int i = 0; i < products.Count; i++)
                Console.WriteLine(products[i].GetProductDescription());
        }
        public List<Product> GetProduct()
        {
            List<Product> aux = new List<Product>();
            for (int i = 0; i < _productsList.Count; i++)
                    aux.Add(_productsList[i]);
            return aux;

        }
        public bool FindProductByID(Product product)
        {
            for (int i = 0; i < _productsList.Count(); i++)
            {
                if (product.GetProductID().Equals(_productsList[i].GetProductID()))
                    return true;
            }

            return false;
        }
        public bool AddProduct(Product product)
        {
            if (FindProductByID(product) == true)
                return false;
            else
                _productsList.Add(product);
            return true;
        }
        public bool RemoveProduct(String id)
        {
            for (int i = 0; i < _productsList.Count; i++)
            {
                if (_productsList[i].GetProductID().Equals(id))
                {
                    _productsList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public bool UpdateProduct(String id, String name, int price, String description, DateTime createDate, int stock, String newId)
        {
            for (int i = 0; i < _productsList.Count; i++)
            {
                if (_productsList[i].GetProductID().Equals(id))
                {
                    _productsList[i].SetProductName(name);
                    _productsList[i].SetPrice(price);
                    _productsList[i].SetDescription(description);
                    _productsList[i].SetCreationDate(createDate);
                    _productsList[i].SetStock(stock);
                    _productsList[i].SetProductID(newId);
                    return true;
                }
            }
            return false;
        }
        public List<Product> AscendingSortByPrice()
        {
            Product aux = new Product();
           
            for (int i = 0; i < _productsList.Count; i++)
            {
                for (int j = 0; j < _productsList.Count; j++)
                    if (_productsList[i].GetPrice() < _productsList[j].GetPrice())
                    {
                        aux=_productsList[i];
                        _productsList[i]=_productsList[j];
                        _productsList[j]=aux;                     
                    }
            }
            return _productsList;
           

        }
        public List<Product> DescendingSortByPrice()
        {
            Product aux = new Product();

            for (int i = 0; i < _productsList.Count; i++)
            {
                for (int j = 0; j < _productsList.Count; j++)
                    if (_productsList[i].GetPrice() > _productsList[j].GetPrice())
                    {
                        aux = _productsList[i];
                        _productsList[i] = _productsList[j];
                        _productsList[j] = aux;
                    }
            }
            return _productsList;
        }
        public List<Product> SortDate()
        {
            Product a = new Product();
            Product b = new Product();
            _productsList.Sort((a, b) => a.GetCreationDate().CompareTo(b.GetCreationDate()));
            return _productsList;
        }
        public Product GetProductDetailsByName(String name)
        {
            for (int i = 0; i < _productsList.Count; i++)
                if (_productsList[i].GetProductName().Equals(name))
                    return _productsList[i];
                
           return null;
        }
        public Product BuyProduct(String productName, int qty)
        {
            Product product = new Product();
            Product aux = new Product();
            Cos cos = new Cos();
            if (GetProductDetailsByName(productName) != null)
            
                product = GetProductDetailsByName(productName);
                if (product.GetStock() > qty)
                    return product;
            
            else
                return null;
            
                
        }



    }
}
