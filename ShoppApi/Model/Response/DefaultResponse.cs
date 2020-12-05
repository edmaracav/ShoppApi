using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Model.Response
{
    public abstract class DefaultResponse
    {
        public String ErrorMessage { get; set; }

        public int StatusCode { get; set; }
    }
}
