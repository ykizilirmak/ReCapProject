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
            //CarManagerTest();
            //CarDtoTest();
            //BrandManagerTest();
            //ColorMnagerTest();
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var car in carManager.GetCarMoreDetails())
            {
                Console.WriteLine(car.CarId + "/" + car.BrandName+"/"+car.ColorName+"/"+car.DailyPrice);
            }
        }

        private static void ColorMnagerTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + "/" + color.Name);
            }
            Console.WriteLine("1 nolu Id'li rengin adı: " + colorManager.GetById(1).Name);

            Color color1 = new Color() { Name = " Pembe" };
            colorManager.Add(color1);
            Console.WriteLine("Pembe rengini ekledikten sonra database durumu");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + "/" + color.Name);
            }

            colorManager.Update(color1);
            colorManager.Delete(color1);
            Console.WriteLine("pembe rengini güncelleme ve silinmesinden sonra database durumu");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + "/" + color.Name);
            }
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id + "/" + brand.Name);
            }
            Console.WriteLine("1 nolu Id'li markanın adı: " + brandManager.GetById(1).Name);

            Brand brand1 = new Brand() { Name = " Ford" };
            brandManager.Add(brand1);
            Console.WriteLine("Ford markasını ekledikten sonra database durumu");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id + "/" + brand.Name);
            }

            brandManager.Update(brand1);
            brandManager.Delete(brand1);
            Console.WriteLine("Ford markasının güncelleme ve silinmesinden sonra database durumu");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id + "/" + brand.Name);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "/" + car.BrandId + "/" + car.ColorId + "/" + car.DailyPrice + "/" + car.Description + "/" + car.ModelYear);
            }
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Description);
            }

            Car car1 = new Car() { BrandId = 3, ColorId = 4, DailyPrice = 250, Description = "silinecek", ModelYear = 2021 };
            carManager.Add(car1);

            carManager.Add(new Car { BrandId = 3, ColorId = 12, DailyPrice = 250, Description = "Tüplü Benzinli", ModelYear = 2021 });
            Console.WriteLine("iki araç eklendikten sonra database durumu");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "/" + car.BrandId + "/" + car.ColorId + "/" + car.DailyPrice + "/" + car.Description + "/" + car.ModelYear);
            }
            carManager.Update(car1);
            carManager.Delete(car1);
            Console.WriteLine("son car nesnesi güncellendikten ve silindikten  sonraki database durumu");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "/" + car.BrandId + "/" + car.ColorId + "/" + car.DailyPrice + "/" + car.Description + "/" + car.ModelYear);
            }
            Console.WriteLine("1 nolu Id'li aracın model yılı: " + carManager.GetById(1).ModelYear);
        }

        private static void CarDtoTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId + "/" + car.BrandName);
            }
        }


       
    }
}
