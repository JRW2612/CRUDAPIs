﻿using EmployeeAPI.Data.ContextData;
using EmployeeAPI.Data.Models;
using EmployeeAPI.Data.ViewModels;
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
			new SqlParameter("@DeletedDate",  (object)DBNull.Value ?? DBNull.Value )
		};
				await employeeContext.Database.ExecuteSqlRawAsync(
							"EXEC InsertEmployee @FirstName, @LastName, @CountryId, @StateId, @CityId, @Email, @Phone, @PAN, @Passport, @Image, @Gender, @IsActive, @DoB, @Doj, @CreatedDate, @UpdatedDate, @IsDeleted, @DeletedDate",
							parameters);

				// Retrieve the newly inserted EmpData object
				var newlyInsertedEmpData = await employeeContext.Employee
					.OrderByDescending(e => e.CreatedDate)
					.FirstOrDefaultAsync();

				return newlyInsertedEmpData;


			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while saving the employee data.", ex);
			}
		}

		async Task<int> ICRUDLogic.DeleteEmpData(int Id)
		{

			try
			{


				var parameters = new[]
		   {

			new SqlParameter("@Id",Id)

		   };
				var result = await employeeContext.Database.ExecuteSqlRawAsync(
						"EXEC DeleteEmployee @Id", parameters);

				return result;

			}
			catch (Exception ex)
			{
				// Log the exception or handle it as needed
				throw new Exception("An error occurred while removing the employee data.", ex);
			}
		}


		async Task<IList<EmpViewModel>> ICRUDLogic.GetEmpData()
		{
			try
			{
				var empDataList = (await employeeContext.Employee
					  .FromSqlRaw("EXEC GetEmployee")
					  .ToListAsync()) // Load data into memory asynchronously
					  .Select(e => new EmpViewModel
					  {
						 RowId=e.RowId,
						  EmployeeCode = e.EmployeeCode,
						  FirstName = e.FirstName,
						  LastName = e.LastName,
						  CountryName = e.CountryName,
						  StateName = e.StateName,
						  CityName = e.CityName,
						  Email = e.Email,
						  Phone = e.Phone,
						  PAN = e.PAN,
						  Passport = e.Passport,
						  Image = e.Image,
						  Gender = e.gender,
						  IsActive = e.IsActive,
						  DoB = e.DoB,
						  Doj = e.Doj,
						  CreatedDate = e.CreatedDate,
						  UpdatedDate = e.UpdatedDate,
						  DeletedDate = e.DeletedDate,
						  IsDeleted = e.IsDeleted
					  })
					  .ToList(); // Convert the projection to
				return empDataList;


			}
			catch (Exception ex)
			{
				// Log the exception or handle it as needed
				throw new Exception("An error occurred while getting the employee data.", ex);
			}
		}

		public async Task<EmpData> UpdateEmpData(EmpData E, int Id)
		{
			try
			{
				var parameters = new[]
				{
			new SqlParameter("@Id", Id), // Make sure the Id is used
			new SqlParameter("@FirstName", E.FirstName),
			new SqlParameter("@LastName", E.LastName),
			new SqlParameter("@CountryId", E.CountryId),
			new SqlParameter("@StateId", E.StateId),
			new SqlParameter("@CityId", E.CityId),
			new SqlParameter("@Email", E.Email),
			new SqlParameter("@Phone", E.Phone),
			new SqlParameter("@PAN", E.PAN),
			new SqlParameter("@Passport", E.Passport),
			new SqlParameter("@Image", E.Image),
			new SqlParameter("@Gender", (int)E.gender),
			new SqlParameter("@IsActive", E.IsActive),
			new SqlParameter("@DoB", E.DoB),
			new SqlParameter("@Doj", E.Doj),
			new SqlParameter("@CreatedDate", E.CreatedDate),
			new SqlParameter("@UpdatedDate", E.UpdatedDate),
			new SqlParameter("@IsDeleted", E.IsDeleted),
			new SqlParameter("@DeletedDate", (object)DBNull.Value ?? DBNull.Value)
		};

				await employeeContext.Database.ExecuteSqlRawAsync(
					"EXEC UpdateEmployee @Id, @FirstName, @LastName, @CountryId, @StateId, @CityId, @Email, @Phone, @PAN, @Passport, @Image, @Gender, @IsActive, @DoB, @Doj, @CreatedDate, @UpdatedDate, @IsDeleted, @DeletedDate",
					parameters);

				// Retrieve the updated EmpData object using the Id
				var UpdatedEmpData = await employeeContext.Employee
					.FirstOrDefaultAsync(e => e.RowId == Id);

				return UpdatedEmpData;
			}
			catch (Exception ex)
			{
				// Log the exception or handle it as needed
				throw new Exception("An error occurred while updating the employee data.", ex);
			}
		}

	}
}
