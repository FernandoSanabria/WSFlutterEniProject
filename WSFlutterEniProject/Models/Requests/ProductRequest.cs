using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSFlutterEniProject.Models.Requests
{
    public class ProductRequest
    {
        public uint Id { get; set; }
        public string Code { get; set; }
        public string Composition { get; set; }
        public string Tissue { get; set; }
        public string Use { get; set; }
        public string WaterRepelence { get; set; }
        public decimal BasePrice { get; set; }
        public uint IdCategory { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public List<Image> Images { get; set; }



        public class Image
        {
            public uint IdProduct { get; set; }
            public string UrlImage { get; set; }

        }

    }
}
