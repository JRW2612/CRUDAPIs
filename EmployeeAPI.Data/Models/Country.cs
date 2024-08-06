using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Data.Models
{
    public class Country
    {
        [Key]
        public int RowId { get; set; }

        public string? CountryName { get; set; }
    }
}
