﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Model.Response
{
    public abstract class DefaultCartResponse : DefaultResponse
    {
        public Cart Cart { get; set; }
    }
}
