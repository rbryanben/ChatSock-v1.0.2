using ChatSock_v1._0._2.customControls;
using ChatSock_v1._0._2.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChatSock_v1._0._2.startup
{
    /// <summary>
    /// This class is the first to be launched
    /// When loaded the following occurs
    ///    (1) Icon is animated - our greeting
    ///    (2) If there is an existing user, go to configurationsPage
    ///    (3) If not [2] check for an active internaet connection 
    ///    (4) if [3] show login page
    /// </summary>
    public partial class startup : Page
    {
        //global 
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public startup()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            

            //animate icon
            var anime = animationHelper.getOpacityAnimationObject(0, 1, 0.5);
            anime.Completed += (Sender, EventArgs) =>
            {
                //sleep for some time
                var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
                timer.Start();
                timer.Tick += (SenderDelay, args) =>
                {
                    timer.Stop();
                    //if there is internet connection
                    if (networkHelper.hasActiveInternetConnection())
                    {
                        //(1) show login if there is no logged in user
                        if (Properties.Settings.Default.LoggedInUserIdentification == "")
                        {
                            mainWindow.setDisplayingPageAs(mainWindow.loginPage);
                        }
                        else
                        {
                            mainWindow.setDisplayingPageAs(mainWindow.configurationsPage);
                        }
                    }
                    else
                    {
                        var a = new gridNotification();
                        body.Children.Add(a);  
                    }
                };

                
            };
            logo.BeginAnimation(OpacityProperty, anime);
        }
    }
}
