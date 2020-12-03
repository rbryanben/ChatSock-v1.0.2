using ChatSock_v1._0._2.customControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChatSock_v1._0._2.utils
{
    class exceptionHandler
    {
     
        public static void handleException(Exception e , Grid body)
        {
            File.AppendAllText("log.txt", e.ToString());


            if (body != null)
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.mainWindowBody.Children.Add(new gridNotification());

            }
        }

        //the network helper got an exception every time I called it , and it called this class , and it
        //kept on recursing, causing the thread to freeze
        //so I made separate function to handle the login exception
        public static void handleException(Exception e, Grid body, Boolean logOnly)
        {
            if (logOnly)
            {
                File.AppendAllText("log.txt", e.ToString());
            }
        }


        public static void logOnly(Exception e)
        {
            File.AppendAllText("log.txt", e.ToString());
        }
    }
}
