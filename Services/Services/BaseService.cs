using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BaseService : IDisposable
    {
        protected readonly UnitOfWork _unitOfWork;

        public BaseService()
        {
            _unitOfWork = new UnitOfWork();
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
