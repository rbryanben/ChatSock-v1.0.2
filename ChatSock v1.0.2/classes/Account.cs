using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSock_v1._0._2.classes
{
    class Account
    {
        public string id { get; set; }
        public string key { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string recovery { get; set; }
    }
}
