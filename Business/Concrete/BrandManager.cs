using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            using (ReCapContext context = new ReCapContext())
            {
                context.Brands.Add(brand);
                context.SaveChanges();
            }
        }

        public void Delete(Brand brand)
        {
            using (ReCapContext context = new ReCapContext())
            {
                context.Brands.Remove(context.Brands.SingleOrDefault(b => b.BrandId == brand.BrandId));
                context.SaveChanges();
            }
        }

        public List<Brand> GetAll()
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Brands.ToList();
            }
        }

        public void Update(Brand brand)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var brandToUpdate = context.Brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
                brandToUpdate.BrandId = brand.BrandId;
                brandToUpdate.BrandName = brand.BrandName;
                context.SaveChanges();
            }
        }

        public Brand GetById(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Brands.SingleOrDefault(b => b.BrandId == id);
            }
        }
    }
}
