namespace Homework.Models
{
    using System.Collections.Generic;

    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
