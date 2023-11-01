using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public bool FindPrdouctByID(Product product)
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
            if (FindPrdouctByID(product) == true)
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
    }
}
