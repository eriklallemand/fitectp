using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity.ViewModels
{
    public class UserLoginInfo
    {
        [Required]
        public string FirstMidName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [StringLength(50),MinLength(6)]
        public string Login { get; set; }
        [Required]
        [StringLength(50), MinLength(6)]
        public string Password { get; set; }
        [Required]
        public string Discriminator { get; set; }
        public DateTime StartingDate { get; set; }
    }
}