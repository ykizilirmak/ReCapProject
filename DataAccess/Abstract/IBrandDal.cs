using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBrandDal:IEntityRepository<Brand>
    {
    }
}
//Code refactoring yaptık core taşıdıktan sonra
//kodun iyileştirilmesi referansları ayarla ..