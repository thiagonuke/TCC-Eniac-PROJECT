using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanFarming.Domain.Classes
{
    public class EmailSettings
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
        public bool EnableSsl { get; set; }
    }
}
