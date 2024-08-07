using EmployeeAPI.Data.ContextData;
using EmployeeAPI.Data.Models;
using EmployeeAPI.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Services.Services.Repositories
{
    public class CascadingLogic(EmployeeContext employee) : ICascadingLogic, IDisposable
    {
        private bool disposedValue;

        public async Task<List<Country>> BindCountry()
        {
            try 
            {
                 
                var country = await employee.Countries.ToListAsync();
                return country;
            }

            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<State>> BindState(int countryId)
        {
            try
            {

                var states = await employee.States.Where(s=>s.CountryId==countryId).ToListAsync();
                return states;
            }

            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<City>> BindCity(int stateId)
        {
            try
            {

                var cities = await employee.Cities.Where(s => s.StateId == stateId).ToListAsync();
                return cities;
            }

            catch
            {
                throw new NotImplementedException();
            }
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
