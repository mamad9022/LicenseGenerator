using System.Collections.Generic;

namespace LicenseGenerator.Application.Command.Product
{
    public class ProductAddCommand
    {
        public string Name { get; set; }
        public ICollection<ProductDetails> Details { get; set; }


        public class ProductDetails
        {
            public string Name { get; set; }
            public string EnName { get; set; }
        }
    }
}
