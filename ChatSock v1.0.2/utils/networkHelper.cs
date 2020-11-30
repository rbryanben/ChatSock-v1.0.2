using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatSock_v1._0._2.utils
{
    /*
     * This class constucts animatio objects 
     */
    class networkHelper
    {
        public static Boolean hasActiveInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch (Exception ex)
            {
                exceptionHandler.handleException(ex, null);
                return false;
            }
        }
    }
}
