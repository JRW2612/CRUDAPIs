using EmployeeAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Data.ViewModels
{
    public class EmpViewModel
    {
        public int RowId { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string PAN { get; set; }
        public string Passport { get; set; }
        public string Image { get; set; }
        public Gender? Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTime DoB { get; set; }
        public DateTime Doj { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
