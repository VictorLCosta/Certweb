using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Certweb.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(70, MinimumLength = 5)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string ContractType { get; set; }


        public DateTime RegisterDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
