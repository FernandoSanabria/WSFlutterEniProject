using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WSFlutterEniProject.Models
{
    public partial class Product
    {
        public Product()
        {
            ImagesProduct = new HashSet<ImagesProduct>();
        }

        public uint Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Composition { get; set; }
        public string Tissue { get; set; }
        public string Use { get; set; }
        public string WaterRepelence { get; set; }
        public decimal BasePrice { get; set; }
        public uint IdCategory { get; set; }
        public string Name { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual ICollection<ImagesProduct> ImagesProduct { get; set; }
    }
}
