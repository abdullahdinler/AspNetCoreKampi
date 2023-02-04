using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Notification
    {
        public int Id { get; set; }
        public string NotificationType { get; set; }
        public string NotificationTypeSymbol { get; set; }
        public string NotificationTypeSymbolColor { get; set; }
        public string NotificationDetail { get; set; }
        public DateTime NotificationDateTime { get; set; }
        public bool NotificationStatus { get; set; }
    }
}
