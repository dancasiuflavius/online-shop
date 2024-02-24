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
            return _productsList.Any(p => p.GetProductID() == product.GetProductID());
        }

        public void AddProduct(Product product)
        {
            if (FindProductByID(product))
            {
                throw new ProductNotFoundExceptions(Constants.ProductNotFoundMessage);
            }
            else
            {
                _productsList.Add(product);
            }
        }

        public void RemoveProduct(string id)
        {
            var productToRemove = _productsList.FirstOrDefault(p => p.GetProductID() == id);

            if (productToRemove != null)
            {
                _productsList.Remove(productToRemove);
            }
            else
            {
                throw new ProductNotFoundExceptions(Constants.ProductNotFoundMessage);
            }
        }


        public void UpdateProduct(string id, string name, int price, string description, DateTime createDate, int stock, string newId)
        {
            var productToUpdate = _productsList.FirstOrDefault(p => p.GetProductID() == id);

            if (productToUpdate != null)
            {
                productToUpdate.SetProductName(name);
                productToUpdate.SetPrice(price);
                productToUpdate.SetDescription(description);
                productToUpdate.SetCreationDate(createDate);
                productToUpdate.SetStock(stock);
                productToUpdate.SetProductID(newId);
                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                throw new ProductNotFoundExceptions(Constants.ProductNotFoundMessage);
            }
        }



    }
}

