using System;

namespace LicenseGenerator.Model.Models
{
   public class ProductDetails
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

        //================ Relation ========================== 

        /// <summary>
        /// شناسه محصول
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// محصول
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
