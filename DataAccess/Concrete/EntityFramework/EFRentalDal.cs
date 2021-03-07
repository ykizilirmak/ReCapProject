using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EFRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id

                             join co in context.Colors
                             on c.ColorId equals co.Id

                             join b in context.Brands
                             on c.BrandId equals b.Id
                      
                             join cus in context.Customers
                             on r.CustomerId equals cus.Id

                             join u in context.Users
                             on cus.UserId equals u.Id



                             select new RentalDetailDto
                             {
                                 RentalId=r.Id,
                                 CarName=c.Description,
                                 BrandName=b.Name,
                                 ColorName=co.Name,
                                 CustomerName=u.FirstName,
                                 CustomerLastName=u.LastName,
                                 CompanyName=cus.CompanyName,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate

                             };
                return result.ToList();

            }
        }
    }
}
