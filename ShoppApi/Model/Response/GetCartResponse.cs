using ShoppApi.Common;
using ShoppApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Model.Response
{
    public class GetCartResponse
    {

        public Cart Cart { get; set; }

        public String ErrorMessage { get; set; }

        public int StatusCode { get; set; }

    }
}
