﻿using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories
{
    public class ProductOrderRepo : BaseRepo<ProductOrder>, IProductOrderRepo
    {
        public ProductOrderRepo(AppDbContext context) : base(context)
        {
        }
    }
}
