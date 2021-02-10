using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());
            //carManager.Add(new Car { Id = 5, BrandId = 3, ColorId = 4, DailyPrice = 250, Description = "Tüplü Benzinli", ModelYear = 2021 });
            //Car car1 = new Car() { Id = 6, BrandId = 3, ColorId = 4, DailyPrice = 250, Description = "silinecek", ModelYear = 2021 };
            //carManager.Add(car1);
            //carManager.Update(car1);
            //carManager.Delete(car1);
            //Console.WriteLine(carManager.GetById(1).ModelYear ); 
            

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Description);
            }




        }
    }
}
