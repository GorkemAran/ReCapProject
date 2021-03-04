using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, ReCapContext>, IBrandDal
    {
        Brand IEntityRepository<Brand>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
