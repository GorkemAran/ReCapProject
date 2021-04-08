using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetailByColor(int colorId);
        List<CarDetailDto> GetCarDetailByBrand(int brandId);
        List<CarDetailDto> GetCarDetailById(int carId);
        //List<CarDetailDto> GetCarDetailsById(Expression<Func<Car, bool>> filter = null);

    }
}
