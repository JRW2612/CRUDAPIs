using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Data.Models
{
    public class City
    {
        [Key]
        public int RowId { get; set; }

        public string? CityName { get; set; }

        public int StateId { get; set; }
    }
}
