using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{//static yaptık ki sürekli newlemiyim. Tüm projede sabit çünkü
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarDailyPriceInvalid = "Aracın günlük kirası geçersiz";
        public static string CarDeleted="Araç silindi";
        public static string CarUpdated="Araç güncellendi";
        public static string MaintenanceTime="Bakım Saati";
        public static string CarsListed="Araçlar listelendi";

        public static string BrandAdded= "Marka eklendi";
        public static string BrandDeleted= "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
    }
}
