using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSock_v1._0._2.utils
{
    /*
     *  To whom-ever is on this page , please do not use this for bad things
     *  do the right thing.
     */
    class firebaseConfigurations
    {

        private static string doNotUseThisForTheWrongReasons = "JBMQoPowyxPjzWtfdq9oKh7NjbQlRlrdgFugu07t";
        private static string basePath  = "https://chatsock-938ab.firebaseio.com/" ;
        public static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = doNotUseThisForTheWrongReasons,
            BasePath = basePath
        };
        public static IFirebaseClient client = new FirebaseClient(config);
    }


}
