using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb_05.Models
{
    public class RegisterVM
    {
        public string Username { get; set; }
        public string RawPWD { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }


    }
}