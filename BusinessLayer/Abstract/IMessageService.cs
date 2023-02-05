using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IMessageService: IGenericService<MessageTwo>
    {
        List<MessageTwo> GetByAuthorMessage(int id);
    }
}
