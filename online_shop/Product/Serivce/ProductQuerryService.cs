using online_shop.OrderDetail;
using online_shop.Products.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Products.Model
{
    public class ProductQuerryService:IProductQuerryService
    {
        private List<Product> _productsList;

        private string _filePath;

        public ProductQuerryService()
        {
            _productsList = new List<Product>();
                     
            _filePath = GetDirectory();

            ReadProduct();
        }
        public ProductQuerryService(List<Product> products)
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
        public Product FindProductByName(string name)
        {
            for (int i = 0; i < _productsList.Count(); i++)
            {
                if (_productsList[i].GetProductName().Equals(name))
                    return _productsList[i];
            }

            return null;
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

        public Product FindProductByID2(string productId)
        {
            for (int i = 0; i < _productsList.Count(); i++)
            {
                if (productId.Equals(_productsList[i].GetProductID()))
                    return _productsList[i];
            }

            return null;
        }
        public void ShowProducts()
        {
            for (int i = 0; i < _productsList.Count; i++)
                Console.WriteLine(_productsList[i].GetProductDescription());

        }
        public void UpdateStock(List<ProductDto> productDtos)
        {


            productDtos.ForEach(x =>
            {


                Product product = FindProductByID2(x.ID);
                product.SetStock(product.GetStock() - x.Qty);

            });
        }
        public void UpdateStock(List<OrderDetails> orderDetails)
        {


            orderDetails.ForEach(x =>
            {

                Product product = FindProductByID2(x.GetProductID());
                if (product != null)
                
                    product.SetStock(product.GetStock() + x.GetQuantity());
                else
                {
                    //todo;
                }
                                
            });

        }
        private bool FindProductByID3(string productId)
        {
            for (int i = 0; i < _productsList.Count(); i++)
            {
                if (productId.Equals(_productsList[i].GetProductID()))
                    return true;
            }

            return false;
        }
        public string NextID()
        {
            Random rand = new Random();
            string id = "P" + rand.Next(1, 999);

            while (FindProductByID3(id) == true)
            {
                id = "P" + rand.Next(1, 999);
            }
            return id;

        }
    }
}
