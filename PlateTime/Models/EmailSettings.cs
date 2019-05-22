using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateTimeApp.Models
{
    public class EmailSettings
    {
        public string Domain { get; set; }

        public int Port { get; set; }

        public string UsernameLogin { get; set; }

        public string UsernamePassword { get; set; }

        public string FromEmail { get; set; }
    }

}
