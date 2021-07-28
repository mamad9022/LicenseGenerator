using System;
using LicenseGenerator.Application.Dtos.Customer;
using LicenseGenerator.Application.Dtos.Product;

namespace LicenseGenerator.Application.Dtos.LicenseLog
{
    public class LicenseLogDto
    {
        /// <summary>
        /// شناسه
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// ای پی
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// لایسنس
        /// </summary>
        public string License { get; set; }

        /// <summary>
        /// تاریخ ایجاد
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// تاریخ انقضا
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// شناسه مشتری
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// مشتری
        /// </summary>
        public CustomerDto Customer { get; set; }

        /// <summary>
        /// شناسه محصول
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// محصول
        /// </summary>
        public  ProductDto Products { get; set; }
    }
}
