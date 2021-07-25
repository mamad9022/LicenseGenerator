using LicenseGeneratorApplication.Dtos.ProductDetail;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicenseGeneratorApplication.Dtos.Product
{
   public class ProductDto
    {
        /// <summary>
        /// شناسه
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// جزئیات محصول
        /// </summary>
        public IEnumerable<ProductDetailDto> ProductDetails { get; set; }
    }
}
