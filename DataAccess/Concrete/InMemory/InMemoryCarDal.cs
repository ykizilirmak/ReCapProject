using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            {
                new Car{Id=1, BrandId=1, ColorId=10, DailyPrice=100, ModelYear=2005, Description="Tüplü" },
                new Car{Id=2, BrandId=2, ColorId=11, DailyPrice=150, ModelYear=2010, Description="Dizel " },
                new Car{Id=3, BrandId=2, ColorId=12, DailyPrice=200, ModelYear=2020, Description="Benzinli" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.Where(p => p.Id == car.Id).FirstOrDefault();
            _cars.Remove(carToDelete);
            
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).FirstOrDefault();
        }

        public void Update(Car car)
        {
            Car cartoupdate = _cars.Where(p => p.Id == car.Id).FirstOrDefault();
            cartoupdate.BrandId = car.BrandId;
            cartoupdate.ColorId = car.ColorId;
            cartoupdate.DailyPrice = car.DailyPrice;
            cartoupdate.Description = car.Description;
            cartoupdate.ModelYear = car.ModelYear;
        }
    }
}
