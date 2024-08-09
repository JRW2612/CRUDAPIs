using EmployeeAPI.Data.ContextData;
using EmployeeAPI.Data.Models;
using EmployeeAPI.Services.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeAPI.Services.Services.Repositories
{
    public class CRUDLogic(EmployeeContext employeeContext) : ICRUDLogic, IDisposable
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


         async Task<EmpData> ICRUDLogic.AddEmpData(EmpData E)
        {
            try
            {
                var parameters = new[]
            {
            new SqlParameter("@FirstName", E.FirstName ),
            new SqlParameter("@LastName", E.LastName ),
            new SqlParameter("@CountryId", E.CountryId ),
            new SqlParameter("@StateId", E.StateId ),
            new SqlParameter("@CityId", E.CityId ),
            new SqlParameter("@Email", E.Email ),
            new SqlParameter("@Phone", E.Phone ),
            new SqlParameter("@PAN", E.PAN ),
            new SqlParameter("@Passport", E.Passport ),
            new SqlParameter("@Image", E.Image ),
            new SqlParameter("@Gender",(int) E.gender ),
            new SqlParameter("@IsActive", E.IsActive),
            new SqlParameter("@DoB", E.DoB ),
            new SqlParameter("@Doj", E.Doj ),
            new SqlParameter("@CreatedDate", E.CreatedDate ),
            new SqlParameter("@UpdatedDate", E.UpdatedDate ),
            new SqlParameter("@IsDeleted", E.IsDeleted),
            new SqlParameter("@DeletedDate", E.DeletedDate )
        };
                await employeeContext.Database.ExecuteSqlRawAsync(
                            "EXEC InsertEmployee @FirstName, @LastName, @CountryId, @StateId, @CityId, @Email, @Phone, @PAN, @Passport, @Image, @Gender, @IsActive, @DoB, @Doj, @CreatedDate, @UpdatedDate, @IsDeleted, @DeletedDate",
                            parameters);

                // Retrieve the newly inserted EmpData object
                var newlyInsertedEmpData = await employeeContext.Employee
                    .OrderByDescending(emp => emp.CreatedDate)
                    .FirstOrDefaultAsync();

                return newlyInsertedEmpData;
            

            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        Task<int> ICRUDLogic.DeleteEmpData(int Id)
        {
            throw new NotImplementedException();
        }


        Task<IList<EmpData>> ICRUDLogic.GetEmpData()
        {
            throw new NotImplementedException();
        }

        Task<EmpData> ICRUDLogic.UpdateEmpData(EmpData E, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
