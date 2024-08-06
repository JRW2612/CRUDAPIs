using EmployeeAPI.Data.Models;
using EmployeeAPI.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services.Services.Repositories
{
    public class CascadingLogic : ICascadingLogic, IDisposable
    {
        private bool disposedValue;

        public Task<List<Country>> BindCountry()
        {

            throw new NotImplementedException();
        }

        public Task<List<State>> BindState(int countryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<City>> BindCity(int stateId)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                disposedValue = true;
            }
        }

       
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
