using EmployeeAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services.Services.Interfaces
{
    public interface ICRUDLogic
    {
        Task<EmpData> AddEmpData(EmpData E);

        Task<EmpData> UpdateEmpData(EmpData E,int Id);

        Task<int> DeleteEmpData(int Id);

        Task<List<EmpData>> GetEmpData();
    }
}
