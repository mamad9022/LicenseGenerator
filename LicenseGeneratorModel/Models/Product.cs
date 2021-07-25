using System;
using System.Collections.Generic;

namespace LicenseGenerator.Model.Models
{
    public class Product
    {
        /// <summary>
        /// شناسه
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        public string Name { get; set; }

        ////================ Relation ========================== 

        /// <summary>
        /// جزئیات محصول
        /// </summary>
        public virtual ICollection<ProductDetails> ProductDetails { get; set; }

    }
}
