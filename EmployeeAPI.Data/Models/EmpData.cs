using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Data.Models
{

    public enum Gender
    {
        Male=0, Female=1,Others=2
    }

    public class EmpData
    {
        [Key]
        public int RowId { get; set; }

        public string? EmployeeCode { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required int CountryId { get; set; }

        public required int StateId { get;set; }

        public required int CityId { get; set; }

        public required string Email { get; set; }

        public required long Phone { get; set; }

        public required string PAN { get; set; }

        public required string Passport { get; set; }

        public string Image { get; set; }
        public required Gender gender { get; set; }

        public bool IsActive { get; set; }

        public DateOnly DoB {  get; set; }

        public DateOnly Doj { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedDate { get; set; }

    }
}
