using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.CarName.Length >= 2 && car.DailyPrice >= 0)
            {
                using (ReCapContext context = new ReCapContext())
                {
                    context.Cars.Add(car);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(Car car)
        {
            using (ReCapContext context = new ReCapContext())
            {
                context.Cars.Remove(context.Cars.SingleOrDefault(c => c.CarId == car.CarId));
                context.SaveChanges();
            }
        }

        public List<Car> GetAll()
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Cars.ToList();
            }
        }

        public Car GetById(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Cars.SingleOrDefault(c => c.CarId == id);
            }
            
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Cars.Where(c => c.BrandId == brandId).ToList();
            }
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Cars.Where(c => c.ColorId == colorId).ToList();
            }
        }

        public void Update(Car car)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var carToUpdate = context.Cars.SingleOrDefault(c => c.CarId == car.CarId);
                carToUpdate.CarId = car.CarId;
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.CarName = car.CarName;
                carToUpdate.ColorId = car.ColorId;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description;
                context.SaveChanges();
            }
        }
    }
}
