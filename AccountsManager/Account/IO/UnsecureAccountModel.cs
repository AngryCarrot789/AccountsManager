using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager.Account.IO
{
    public class UnsecureAccountModel
    {
        public string AccountName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DateOfBirth { get; set; }
        public string SecurityInfo { get; set; }
        public string ExtraInfo1 { get; set; }
        public string ExtraInfo2 { get; set; }
        public string ExtraInfo3 { get; set; }
        public string ExtraInfo4 { get; set; }
        public string ExtraInfo5 { get; set; }
        public string ExtraInfo6 { get; set; }
    }
}
