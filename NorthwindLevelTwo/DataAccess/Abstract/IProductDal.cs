﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        // Repository pattern
        // Listing
        // Adding
        // Deleting
        // Updating
    }
}
