using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "The name should contain more than {0} characters", MinimumLength = 3)]
        public string FirstName { get; set; }
        [Display(Name ="Apellido")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirthday { get; set; }
        public string MiddleName { get; set; }

    }
}
