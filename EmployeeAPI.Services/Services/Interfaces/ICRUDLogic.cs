using EmployeeAPI.Data.Models;
using EmployeeAPI.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services.Services.Interfaces
{
    public interface ICRUDLogic
    {
        public Task<EmpData> AddEmpData(EmpData E);

        public Task<EmpData> UpdateEmpData(EmpData E,int Id);

        public Task<int> DeleteEmpData(int Id);

        public Task<IList<EmpViewModel>> GetEmpData();
    }
}
