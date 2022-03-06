using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Players
    {
        [Key]
        public int Id_user { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "The name should contain more than {0} characters", MinimumLength = 3)]
        public string Nickname { get; set; }
        [Display(Name = "NickName")]
        public int Points { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Date)]
       
        public string classPlayer { get; set; }

    }
}
