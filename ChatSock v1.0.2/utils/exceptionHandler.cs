using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChatSock_v1._0._2.utils
{
    class exceptionHandler
    {
        public string name;
        public static void handleException(Exception e , Grid body)
        {
            File.AppendAllText("log.txt", e.ToString());

            //check internet
        }
    }
}
