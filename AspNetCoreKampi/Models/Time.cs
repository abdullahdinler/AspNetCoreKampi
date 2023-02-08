using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreKampi.Models
{
    public static class Time
    {
        public static string Zaman(this DateTime date)
        {
            // Zaman farkı alındı.
            var timeSpan = DateTime.Now - date;

            // 60 saniyeden küçük ise
            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                return $"{timeSpan.Seconds} saniye önce";
            }

            // 60 dakikadan küçük ise
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                return timeSpan.Minutes > 1
                    ? $"{timeSpan.Minutes} dakika önce"
                    : "Yaklaşik bir dk önce";
            }
            // 24 saat'ten kücük ise
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                return timeSpan.Hours > 1 ? $"{timeSpan.Hours} saat önce" : "Yaklaşık bir saat önce";
            }

            // 30 gün'den kücük ise
            else if (timeSpan <= TimeSpan.FromDays(30))
            {

                return timeSpan.Days > 1 ? $"{timeSpan.Days} gün önce" : "Yaklaşık bir gün önce";
            }

            // 365 gün'den kücük ise
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                return timeSpan.Days > 1 ? $"{timeSpan.Days / 30} ay önce" : "Yaklaşık bir ay önce";
            }
            return timeSpan.Days > 365 ? $"{timeSpan.Days / 365} yil önce" : "Yaklaşık bir yıl önce";
        }
    }
}
