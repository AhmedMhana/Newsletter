using Models;
using System;
using System.Collections.Generic;

namespace Interfaces
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
