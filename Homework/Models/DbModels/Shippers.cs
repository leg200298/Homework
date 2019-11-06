namespace Homework.Models
{
    using System.Collections.Generic;
    public partial class Shippers
    {
        public Shippers()
        {
            Orders = new HashSet<Orders>();
        }

        public int ShipperID { get; set; }

        public string CompanyName { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
