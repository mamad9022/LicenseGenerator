using System;
using System.Collections.Generic;
using LicenseGenerator.Application.Dtos.ProductDetail;

namespace LicenseGenerator.Application.Dtos.Product
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
