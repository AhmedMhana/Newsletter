using DatabaseLayer;
using Models;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class SubscriberService : BaseService, ISubscriberService
    {

        #region Private Properites
        private GenericRepository<Subscriber> _repository;
        #endregion

        #region Contractor
        public SubscriberService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = base._unitOfWork.Repository<Subscriber>();
        }

        public SubscriberService(IUnitOfWork unitOfWork,GenericRepository<Subscriber> repository) : base(unitOfWork)
        {
            _repository = repository;
        }
        #endregion

        #region Implement ISubscriberService
        public IEnumerable<Subscriber> GetAll()
        {
            return _repository.GetAll();
        }

        public Subscriber GetById(Guid subscriberId)
        {
            return _repository.GetByID(subscriberId);
        }

        public Subscriber Create(Subscriber subscriber)
        {
            if (subscriber != null)
            {
                _repository.Insert(subscriber);
                _unitOfWork.Save();
            }
            return subscriber;
        }

        public Subscriber Update(Subscriber subscriber)
        {
            if (subscriber != null)
            {
                var entityInDB = _repository.GetByID(subscriber.Id);
                if (entityInDB != null)
                {
                    _repository.Update(subscriber);
                    _unitOfWork.Save();
                }
            }
            return subscriber;
        }

        public bool Delete(Guid subscriberId)
        {
            var success = false;
            if (subscriberId != Guid.Empty)
            {
                var entityInDB = _repository.GetByID(subscriberId);
                if (entityInDB != null)
                {
                    _repository.Delete(entityInDB);
                    _unitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }

        public bool IsExist(string email)
        {
            return _repository.GetAll().Any(s => s.Email.ToLower() == email.ToLower());
        }
        #endregion
    }
}
