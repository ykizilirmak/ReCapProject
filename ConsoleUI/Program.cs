﻿using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManagerTest();
            //CarDtoTest();
            //BrandManagerTest();
            //ColorMnagerTest();
            //CarDto2Test();
             CustomerAddingTest();



            RentalAddingAndListingTest();

        }

        private static void RentalAddingAndListingTest()
        {
            RentalManager rentalManager = new RentalManager(new EFRentalDal());

            rentalManager.Add(new Rental { CarId = 3, CustomerId = 4, RentDate = DateTime.Now, ReturnDate = DateTime.Today });
            foreach (var rentaldetail in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine(rentaldetail.RentalId + "/" + rentaldetail.CarName + "/" + rentaldetail.BrandName + "/" + rentaldetail.ColorName + "/" +
                rentaldetail.CustomerName + "/" + rentaldetail.CustomerLastName + "/" + rentaldetail.RentDate + "/" + rentaldetail.ReturnDate + "/" + rentaldetail.CompanyName);
            }
        }

        private static void CustomerAddingTest()
        {
            UserManager userManager = new UserManager(new EFUserDal());
            User user1 = new User() { FirstName = "Ali", LastName = "Kınalı", Email = "Is", Password = "123" };
            userManager.Add(user1);

            CustomerManager customerManager = new CustomerManager(new EFCustomerDal());
            Customer customer1 = new Customer() { UserId = user1.Id, CompanyName = " Microsoft" };//foreign kısıtlamasıyla birlikte olmayan user id kabul etmiyor ve userı silerken de kontrol mekanizması giriyor.
            customerManager.Add(customer1);


            Console.WriteLine("Müşteri eklendikten  sonra database durumu");
            foreach (var customerdetail in customerManager.GetCustomerDetails().Data)
            {
                Console.WriteLine(customerdetail.CustomerId + "/" + customerdetail.FirstName + "/" + customerdetail.LastName + "/" + customerdetail.Email + "/" + customerdetail.CompanyName);
            }
        }

        private static void CarDto2Test()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var car in carManager.GetCarMoreDetails().Data)
            {
                Console.WriteLine(car.CarId + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }
        }

        private static void ColorMnagerTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Id + "/" + color.Name);
            }
            Console.WriteLine("1 nolu Id'li rengin adı: " + colorManager.GetById(1).Data.Name);

            Color color1 = new Color() { Name = " Pembe" };
            colorManager.Add(color1);
            Console.WriteLine("Pembe rengini ekledikten sonra database durumu");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Id + "/" + color.Name);
            }

            colorManager.Update(color1);
            colorManager.Delete(color1);
            Console.WriteLine("pembe rengini güncelleme ve silinmesinden sonra database durumu");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Id + "/" + color.Name);
            }
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Id + "/" + brand.Name);
            }
            Console.WriteLine("1 nolu Id'li markanın adı: " + brandManager.GetById(1).Data.Name);

            Brand brand1 = new Brand() { Name = " Ford" };
            brandManager.Add(brand1);
            Console.WriteLine("Ford markasını ekledikten sonra database durumu");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Id + "/" + brand.Name);
            }

            brandManager.Update(brand1);
            brandManager.Delete(brand1);
            Console.WriteLine("Ford markasının güncelleme ve silinmesinden sonra database durumu");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Id + "/" + brand.Name);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            var result = carManager.GetAll(); // Genel kullanım bu şekilde olacak fakat bununiçinde iki farklı return oldugu için zaten newlememiz lazım diğerleri tek return .
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id + "/" + car.BrandId + "/" + car.ColorId + "/" + car.DailyPrice + "/" + car.Description + "/" + car.ModelYear);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(car.Description);
            }

            Car car1 = new Car() { BrandId = 3, ColorId = 4, DailyPrice = 250, Description = "silinecek", ModelYear = 2021 };
            carManager.Add(car1);

            carManager.Add(new Car { BrandId = 3, ColorId = 12, DailyPrice = 250, Description = "Tüplü Benzinli", ModelYear = 2021 });
            Console.WriteLine("iki araç eklendikten sonra database durumu");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Id + "/" + car.BrandId + "/" + car.ColorId + "/" + car.DailyPrice + "/" + car.Description + "/" + car.ModelYear);
            }
            carManager.Update(car1);
            carManager.Delete(car1);
            Console.WriteLine("son car nesnesi güncellendikten ve silindikten  sonraki database durumu");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Id + "/" + car.BrandId + "/" + car.ColorId + "/" + car.DailyPrice + "/" + car.Description + "/" + car.ModelYear);
            }
            Console.WriteLine("1 nolu Id'li aracın model yılı: " + carManager.GetById(1).Data.ModelYear);
        }

        private static void CarDtoTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarId + "/" + car.BrandName);
            }
        }



    }
}
