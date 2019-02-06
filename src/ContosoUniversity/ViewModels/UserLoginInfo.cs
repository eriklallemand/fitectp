using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.ViewModels
{
    public class UserLoginInfo
    {
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Discriminator { get; set; }
        public DateTime StartingDate { get; set; }
    }
}