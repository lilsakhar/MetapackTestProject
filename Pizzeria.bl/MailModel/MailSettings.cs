using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.bl.MailModel
{
    public class MailSettings
    {
        public string User { get; set; }
        public string Pass { get;  set; }
        public string Smtptext { get;  set; }
        public int Port { get;  set; }
        public bool Ssl { get;  set; }
        
    }

    public class MailParams
    {
        public string Totxt { get;  set; }
        public string Cctxt { get;  set; }
        public string Subject { get;  set; }
        public string Msgbody { get;  set; }
    }
}
