using System;
using System.Collections.Generic;

namespace LicenseGeneratorApplication.Command.License
{
    public class LicenseCreateCommand
    {
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime ExpireDate { get; set; }
        public string SystemId { get; set; }
        public List<FeatureLicense> Features { get; set; }
        public class FeatureLicense
        {
            public string Ename { get; set; }
            public string Value { get; set; }
        }
    }


}
