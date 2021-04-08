using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals

                             join c in context.Cars
                             on r.CarId equals c.CarId

                             join b in context.Brands
                             on r.BrandId equals b.BrandId

                             join cs in context.Customers
                             on r.CustomerId equals cs.CustomerId

                             join u in context.Users
                             on cs.UserId equals u.Id

                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = r.CarId,
                                 CustomerId = cs.CustomerId,
                                 CarName = c.CarName,
                                 UserName = u.FirstName + " " + u.LastName,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
