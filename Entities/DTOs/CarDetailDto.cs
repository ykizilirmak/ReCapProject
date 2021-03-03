using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {//isimler tabladakiyle aynı olmasına gerek yok
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
