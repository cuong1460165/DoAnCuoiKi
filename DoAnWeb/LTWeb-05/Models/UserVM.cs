using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb_05.Models
{
    public class UserVM
    {
        public int f_ID { get; set; }
        public string f_Username { get; set; }
        public string f_Password { get; set; }
        public string f_Name { get; set; }
        public string f_Email { get; set; }
        public System.DateTime f_DOB { get; set; }
        public int f_Permission { get; set; }
        public Nullable<int> f_Point { get; set; }
    }
}