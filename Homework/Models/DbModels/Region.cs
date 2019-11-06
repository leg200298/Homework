namespace Homework.Models
{
    using System.Collections.Generic;

    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territories>();
        }

        public int RegionID { get; set; }

        public string RegionDescription { get; set; }

        public virtual ICollection<Territories> Territories { get; set; }
    }
}
