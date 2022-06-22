using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserGmail : IUserGmail
    {
        private string _gmailAddress;
        private string _gmailPassword;
        public string GmailAddress
        {
            get { return _gmailAddress; }
            set
            {
                if (value.Contains("@gmail.com"))
                    _gmailAddress = value;

            }
        }
        public string GmailPassword
        {
            get { return _gmailPassword; }
            set
            {
                if (value.Length > 7 && value.Length < 101)
                    _gmailPassword = value;
            }
        }
    }
}
