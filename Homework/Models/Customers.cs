namespace Homework.Models
{
    using System.Collections.Generic;

    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
            CustomerDemographics = new HashSet<CustomerDemographics>();
        }

        public string CustomerID { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

        public virtual ICollection<CustomerDemographics> CustomerDemographics { get; set; }
    }
}
