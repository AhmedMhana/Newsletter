using DatabaseLayer;
using System;

namespace Services.Services
{
    public class BaseService : IDisposable
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Properties and Attributes

        private bool _disposed = false;

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;
        }

        #endregion
    }
}
