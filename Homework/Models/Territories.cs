namespace Homework.Models
{
    using System.Collections.Generic;

    public partial class Territories
    {
        public Territories()
        {
            Employees = new HashSet<Employees>();
        }

        public string TerritoryID { get; set; }

        public string TerritoryDescription { get; set; }

        public int RegionID { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
