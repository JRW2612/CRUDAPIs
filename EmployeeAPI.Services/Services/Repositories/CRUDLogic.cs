using EmployeeAPI.Data.Models;
using EmployeeAPI.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services.Services.Repositories
{
    public class CRUDLogic : ICRUDLogic, IDisposable
    {
        private bool disposedValue;

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

      
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


        Task<EmpData> ICRUDLogic.AddEmpData(EmpData E)
        {
            throw new NotImplementedException();
        }

        Task<int> ICRUDLogic.DeleteEmpData(int Id)
        {
            throw new NotImplementedException();
        }


        Task<List<EmpData>> ICRUDLogic.GetEmpData()
        {
            throw new NotImplementedException();
        }

        Task<EmpData> ICRUDLogic.UpdateEmpData(EmpData E, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
