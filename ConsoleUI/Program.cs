using Business.Concrete;
using Core.Entities.Concrete;
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
            //AddCustomer();
            //CarDetailsList();
            //AddUser();
            //AddCustomer();
            AddRental();



            //ReCapContext context = new ReCapContext();

            //foreach (var user in context.Users)
            //{
            //    Console.WriteLine(user.FirstName);
            //}

            //ReCapContext context = new ReCapContext();

            //foreach (var car in context.Cars)
            //{
            //    Console.WriteLine(car.CarName);
            //}

            //ReCapContext context = new ReCapContext();

            //foreach (var customer in context.Customers)
            //{
            //    Console.WriteLine(customer.FirstName);
            //}
        }

        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental { CarId = 1, CustomerId = 2, BrandId = 2, RentDate = DateTime.Now });
            rentalManager.Add(new Rental { CarId = 2, CustomerId = 3, BrandId = 1, RentDate = DateTime.Now });
        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User { FirstName = "Görkem", LastName = "Aran", Email = "gorkemaran@gmail.com" });
            //userManager.Add(new User { FirstName = "Ayşe", LastName = "Gül", Email = "aysegul@gmail.com" });
            userManager.Add(new User { FirstName = "asd", LastName = "qwe", Email = "afqwr@gmail.com" });
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { CompanyName = "Aran Otel" });
            customerManager.Add(new Customer { CompanyName = "Ece Lojistik" });
            customerManager.Add(new Customer { CompanyName = "Gül Otel" });
            customerManager.Add(new Customer { CompanyName = "Zıt Otel" });
        }

        private static void CarDetailsList()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = 10, ColorName = "Sarı" });
            colorManager.Add(new Color { ColorId = 30, ColorName = "Siyah" });
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
