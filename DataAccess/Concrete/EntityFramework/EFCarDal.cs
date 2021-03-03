using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId = b.Id,
                                 BrandName = b.Name

                             };
                return result.ToList();

            }
        }

        public List<CarMoreDetailDto> GetCarMoreDetails()
        {
            using (ReCapContext reCapContext=new ReCapContext())
            {
                var result = from c in reCapContext.Cars
                             join b in reCapContext.Brands
                             on c.BrandId equals b.Id
                             join co in reCapContext.Colors
                             on c.ColorId equals co.Id
                             select new CarMoreDetailDto
                             {
                                 CarId=c.Id, BrandName=b.Name,ColorName=co.Name, DailyPrice=c.DailyPrice
                             };
                return result.ToList();
                            

            }
        }
    }
}
