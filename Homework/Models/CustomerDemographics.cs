namespace Homework.Models
{
    using System.Collections.Generic;

    public partial class CustomerDemographics
    {
        public CustomerDemographics()
        {
            Customers = new HashSet<Customers>();
        }

        public string CustomerTypeID { get; set; }

        public string CustomerDesc { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
