using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddCar();
            //AddBrand();
            //AddColor();
            
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }




            //ReCapContext reCapContext = new ReCapContext();

            //foreach (var car in reCapContext.Cars)
            //{
            //    Console.WriteLine(car.CarName);
            //}
        }

        private static void AddColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = 10, ColorName = "Sarı" });
            colorManager.Add(new Color { ColorId = 30, ColorName = "Siayh" });
            colorManager.Add(new Color { ColorId = 50, ColorName = "Beyaz" });
        }

        private static void AddBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 1, BrandName = "Ford" });
            brandManager.Add(new Brand { BrandId = 2, BrandName = "BMW" });
            brandManager.Add(new Brand { BrandId = 3, BrandName = "Mercedes" });
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 2, CarName = "BMW 320", ColorId = 30, DailyPrice = 375, ModelYear = "2011", Description = "4 kapı" });
            carManager.Add(new Car { BrandId = 1, CarName = "Ford Focus", ColorId = 10, DailyPrice = 300, ModelYear = "2009", Description = "4 kapı" });
            carManager.Add(new Car { BrandId = 2, CarName = "BMW 350", ColorId = 10, DailyPrice = 450, ModelYear = "2007", Description = "4 kapı" });
            carManager.Add(new Car { BrandId = 3, CarName = "Mercedes E250", ColorId = 50, DailyPrice = 220, ModelYear = "2010", Description = "2 kapı" });
        }
    }
}
