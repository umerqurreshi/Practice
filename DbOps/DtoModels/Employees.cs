using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbOps.DtoModels
{
    public class Employees
    {
        public int EmployeeId { get; set; }
        [Required]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public long BadgeNumber { get; set; }
        public virtual ICollection<Perks> Perks { get; set; }
    }
}
