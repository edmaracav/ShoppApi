﻿using ShoppApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Repositories.Contracts
{
    public interface ISkuRepository
    {
        Sku FindSku(Guid oid);
    }
}
