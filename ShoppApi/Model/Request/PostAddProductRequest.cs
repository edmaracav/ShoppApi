﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Model.Request
{
    public class PostAddProductRequest
    {
        public Guid SkuId { get; set; }

        public int Count { get; set; }
    }
}
