using System;

namespace LicenseGeneratorApplication.Dtos.Customer
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
    }
}
