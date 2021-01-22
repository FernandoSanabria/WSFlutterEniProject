using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSFlutterEniProject.Models.Requests;
using WSFlutterEniProject.Models.Responses;

namespace WSFlutterEniProject.Interfaces
{
    public interface IProductInterface
    {
        public List<ProductResponse> GetByCategory(int Id);

        public ProductResponse GetById(int Id);

        public void Update(ProductRequest productRequest);

        public void Delete(int Id);


        public void Add(ProductRequest productRequest);

    }
}
