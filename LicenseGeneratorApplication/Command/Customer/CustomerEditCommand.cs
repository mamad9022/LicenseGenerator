using System;

namespace LicenseGeneratorApplication.Command.Customer
{
    public class CustomerEditCommand
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
    }
}
