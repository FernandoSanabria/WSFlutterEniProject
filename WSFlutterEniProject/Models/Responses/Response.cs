using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSFlutterEniProject.Models.Response
{
    public class Response
    {
        public bool Successful { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }

        public Response()
        {
            this.Successful = false;
        }

    }
}
