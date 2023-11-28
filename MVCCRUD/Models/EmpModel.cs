using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCRUD.Models
{
    public class EmpModel
    {
        public int Id { get; set; }
		[Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
    }
}
