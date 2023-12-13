using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using online_shop.DTO;
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
        public void ShowProducts(List<Product> products)
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

        public Product FindProductByID(String productId)
        {
            for (int i = 0; i < _productsList.Count(); i++)
            {
                if (productId.Equals(_productsList[i].GetProductID()))
                    return _productsList[i];
            }

            return null;
        }
        public bool FindProductByID2(String productId)
        {
            for (int i = 0; i < _productsList.Count(); i++)
            {
                if (productId.Equals(_productsList[i].GetProductID()))
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

        public Product FindProductByName(String name)
        {
            for (int i = 0; i < _productsList.Count(); i++)
            {
                if (_productsList[i].GetProductName().Equals(name))
                    return _productsList[i];
            }

            return null;
        }


        public void UpdateStock(List<ProductDto> productDtos)
        {


            productDtos.ForEach(x =>
            {


                Product product = FindProductByID(x.ID);
                product.SetStock(product.GetStock() - x.Qty);

            });
        }
        public void UpdateStock(List<OrderDetails> orderDetails)
        {


            orderDetails.ForEach(x =>
            {

                Product product = FindProductByID(x.GetProductID());
                product.SetStock(product.GetStock() + x.GetQuantity());

            });
        }

        public string ConvertProductIDIntoName(string productID)
        {
            string name = "";
            for (int i = 0; i < _productsList.Count(); i++)
                if (_productsList[i].GetProductID().Equals(productID))
                    name = _productsList[i].GetProductName();
            return name;

        }
        public String toSave()
        {

            String text = "";
            int i = 0;
            for (i = 0; i < _productsList.Count - 1; i++)
            {

                text += _productsList[i].ToSave() + "\n";
            }

            text += _productsList[i].ToSave();

            return text;
        }

        public void SaveProduct()
        {
            try
            {

                string filePath = GetDirectory();

                // Create a StreamReader to read from the file
                using (StreamWriter reader = new StreamWriter(filePath))
                {
                    // Read and process the file line by line

                    reader.Write(toSave());

                    reader.Close();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
        }

        public string NextID()
        {
            Random rand = new Random();
            String id = "P" + rand.Next(1, 999);

            while (FindProductByID2(id) == true)
            {
                id = "P" + rand.Next(1, 999);
            }
            return id;

        }

    }
}
