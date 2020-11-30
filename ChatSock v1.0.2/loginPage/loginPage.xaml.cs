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
    /// Interaction logic for loginPage.xaml
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
    }
}
