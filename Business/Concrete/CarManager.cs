using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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
            if (car.DailyPrice > 0 && car.)
            {
                _carDal.Add(car);
                Console.WriteLine("Arac Sisteme basariyla eklendi.");
            }
            else
            {
                Console.WriteLine("Lutfen aracin gunluk kirasini sifirdan buyuk bir deger giriniz.");
            }
           
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int Id)
        {
           return _carDal.Get(p => p.Id == Id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p=>p.BrandId==id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
