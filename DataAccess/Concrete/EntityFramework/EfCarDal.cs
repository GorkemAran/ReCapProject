using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             //join ci in context.CarImages
                             //on c.CarId equals ci.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandId = c.BrandId,
                                 BrandName = b.BrandName,
                                 ColorId = c.ColorId,
                                 ColorName = cl.ColorName,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 DailyPrice = c.DailyPrice,
                                 //ImagePath= ci.ImagePath
                             };
                return result.ToList();
            }
            //throw new NotImplementedException();

        }

        public List<CarDetailDto> GetCarDetailByBrand(int brandId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands.Where(w => w.BrandId == brandId)
                             on c.BrandId equals b.BrandId
                             join c1 in context.Colors
                             on c.ColorId equals c1.ColorId
                             //join ci in context.CarImages
                             //on c.CarId equals ci.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 ColorId = c1.ColorId,
                                 BrandName = b.BrandName,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ColorName = c1.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 BrandId = b.BrandId,
                                 CarName = c.CarName,
                                 //ImagePath =ci.ImagePath
                                 //ImagePath = context.CarsImages.Where(w => w.CarId == c.CarId).FirstOrDefault().ImagePath,

                             };
                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarDetailByColor(int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join c1 in context.Colors.Where(w => w.ColorId == colorId)
                             on c.ColorId equals c1.ColorId
                             //join ci in context.CarImages
                             //on c.CarId equals ci.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 ColorName = c1.ColorName,
                                 ColorId = c1.ColorId,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 //ImagePath = ci.ImagePath
                                 //ImagePath = context.CarImages.Where(w => w.CarId == c.CarId).FirstOrDefault().ImagePath,
                             };
                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarDetailById(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars.Where(w => w.CarId == carId)
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             //join ci in context.CarImages
                             //on c.CarId equals ci.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 ColorId = cl.ColorId,
                                 ColorName = cl.ColorName,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 //ImagePath = ci.ImagePath
                                 //MinFindexScore = c.MinFindexScore,
                                 //ImagePath = context.CarsImages.Where(w => w.CarId == c.CarId).FirstOrDefault().ImagePath

                             };
                return result.ToList();

            }
        }

        //public List<CarDetailDto> GetCarDetailsById(Expression<Func<Car, bool>> filter = null)
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        var result = from c in context.Cars.Where(w)
        //                     join c.CarId
        //                     join b in context.Brands
        //                     on c.BrandId equals b.BrandId
        //                     join co in context.Colors
        //                     on c.ColorId equals co.ColorId
        //                     select new CarDetailDto
        //                     {
        //                         CarId = c.CarId,
        //                         CarName = b.BrandName,
        //                         ColorName = co.ColorName,
        //                         ColorId = co.ColorId,
        //                         ColorName =,
        //                         BrandName=,
        //                         DailyPrice = c.DailyPrice,
        //                         Description = c.Description,
        //                         ModelYear = c.ModelYear
        //                     };
        //    };
        //    return result.ToList();
        //}
    }
}
