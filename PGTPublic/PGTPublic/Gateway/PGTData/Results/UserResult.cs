using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PGTPublic.Gateway.PGTData.Results
{
    public class UserResult
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int UserRegister { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int CampusID { get; set; }
        public int UserTypeID { get; set; }
        public int GroupID { get; set; }
    }
}
