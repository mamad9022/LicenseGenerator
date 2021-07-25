using System;

namespace LicenseGenerator.Model.Models
{
    public class LicenseLog
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
        /// تاریخ ایجاد
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// لایسنس
        /// </summary>
        public string License { get; set; }

        //================ Relation ========================== 
        /// <summary>
        /// شناسه مشتری
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// مشتری
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// شناسه محصول
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// محصول
        /// </summary>
        public virtual Product Products { get; set; }
    }
}
