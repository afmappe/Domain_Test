using System;

namespace Cars.Library.Infrastructure.Common
{
    public abstract class Disposable : IDisposable
    {
        // Flag: Has Dispose already been called?
        private bool disposed = false;

        protected Disposable()
        {
        }

        ~Disposable()
        {
            Dispose(false);
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    InternalDispose();
                }

                // Free any unmanaged objects here.
                disposed = true;
            }
        }

        protected abstract void InternalDispose();
    }
}