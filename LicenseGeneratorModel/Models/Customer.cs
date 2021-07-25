using System;

namespace LicenseGenerator.Model.Models
{
    public class Customer
    {
        /// <summary>
        /// شناسه
        /// </summary>
        public Guid Id { get; set; }
        public int Code { get; set; }


        /// <summary>
        /// نام
        /// </summary>
        public string Name { get; set; }
    }
}
