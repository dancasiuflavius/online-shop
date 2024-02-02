using online_shop.Products.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Products.Exceptions;
using online_shop.Utils;
using online_shop.Orders.Exceptions;

namespace online_shop.Products.Model
{
    public class ProductComandService : IProductComandService
    {
        private List<Product> _productsList;

        private string _filePath;

        public ProductComandService()
        {
            _productsList = new List<Product>();
            _filePath = GetDirectory();

            ReadProduct();
        }
        public ProductComandService(List<Product> products)
        {
            _productsList = products;

        }
        private string GetDirectory()
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
        public string toSave()
        {

            string text = "";
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
        private bool FindProductByID(Product product)
        {
            for (int i = 0; i < _productsList.Count(); i++)
            {
                if (product.GetProductID().Equals(_productsList[i].GetProductID()))
                    return true;
            }

            return false;
        }
        public void AddProduct(Product product)
        {
            if (FindProductByID(product) == true)
                throw new ProductNotFoundExceptions(Constants.ProductNotFoundMessage);
            else
                _productsList.Add(product);
        }

            public void RemoveProduct(string id)
            {
                try
                {
                    for (int i = 0; i < _productsList.Count; i++)
                    {
                        if (_productsList[i].GetProductID().Equals(id))
                        {
                            _productsList.RemoveAt(i);
                            return;
                        }
                    }

                    throw new ProductNotFoundExceptions(Constants.ProductNotFoundMessage);
                }
                catch (ProductNotFoundExceptions ex)
                {

                    Console.WriteLine($"Error removing product: {ex.Message}");
                }
            }

             public void UpdateProduct(string id, string name, int price, string description, DateTime createDate, int stock, string newId)
             {
                try
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
                            return;
                        }
                    }

                    throw new ProductNotFoundExceptions(Constants.ProductNotFoundMessage);
                }
                catch (ProductNotFoundExceptions ex)
                {
                    // Poți trata excepția aici sau să o arunci mai departe, să o înregistrezi, etc.
                    Console.WriteLine($"Error updating product: {ex.Message}");
                }
            }

        }

       
    }

