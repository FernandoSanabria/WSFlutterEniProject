using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WSFlutterEniProject.Models
{
    public partial class ImagesProduct
    {
        public uint Id { get; set; }
        public uint IdProduct { get; set; }
        public string UrlImage { get; set; }

        public virtual Product IdProductNavigation { get; set; }
    }
}
