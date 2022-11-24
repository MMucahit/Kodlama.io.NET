﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // İnterface methodları default publicdir.
    // İnterface in kendisi değildir.
    public interface IProductDal:IEntityRepository<Product>
    {
        
    }
}
