using ChatSock_v1._0._2.customControls;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatSock_v1._0._2.loginPage
{
    /// <summary>
    /// This class allows the user to Login with their creds
    /// When page is loaded the following occurs
    /// (1) Sets the tile of the mainWindow to Login
    /// </summary>
    public partial class loginPage : Page
    {
        //global
        private static string title = "Login";
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public loginPage()
        {
            InitializeComponent(); 
        }



        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            mainWindow.setDisplayingPageAs(mainWindow.configurationsPage);
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mainWindow.setWindowTitle(title);    
        }

        private void signinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //show notification
            body.Children.Add(new gridNotification("Firebase has not been setup yet"));
        }
    }
}
