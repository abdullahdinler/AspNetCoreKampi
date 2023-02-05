using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MessageTwo
    {
        [Key]
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime MessageDateTime { get; set; }
        public bool Status { get; set; }



        //[ForeignKey("SenderUser")]
        public Author SenderUser { get; set; }

        //[ForeignKey("ReceiverUser")]
        public Author ReceiverUser { get; set; }
    }
}
