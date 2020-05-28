using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    partial interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategory(int categoryId);
    }
}
