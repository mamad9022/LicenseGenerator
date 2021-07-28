using System;

namespace LicenseGenerator.Application.Dtos.ProductDetail
{
    public class ProductDetailDto
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
        /// نام لاتین
        /// </summary>
        public string EnName { get; set; }

        /// <summary>
        /// شناسه محصول
        /// </summary>
        public Guid ProductId { get; set; }
    }
}
