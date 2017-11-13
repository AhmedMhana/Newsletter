using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ISubscriberService
    {
        Subscriber GetById(Guid subscriberId);
        IEnumerable<Subscriber> GetAll();
        Subscriber Create(Subscriber subscriber);
        Subscriber Update(Subscriber subscriber);
        bool Delete(Guid subscriberId);
        bool IsExist(string email);
    }
}
