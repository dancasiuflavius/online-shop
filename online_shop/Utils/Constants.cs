using online_shop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Utils
{
     public static class Constants
    {
        public const string UserNotFoundMessage = "User Not Found... ";
        public const string OrderInvalidMessage = "Order Already Exists...";
        public const string OrderNotFoundMessage = "Order Does Not Exist In The Current Context...";
        public const string ProductNotFoundMessage = "Product Not Found... ";
        public const string OrderDetailNotFoundMessage = "Order Detail is missing from the list... Please check the ID.";
        public const string DuplicateOrderDetailMessage = "Cannot add a duplicate order detail";
    }
}
