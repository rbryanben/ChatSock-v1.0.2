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

namespace ChatSock_v1._0._2.configurationsPage
{
    /// <summary>
    /// This page is put into the MainWindow when called
    /// It allows the user to set their desired Network and Profile Configurations
    /// </summary>
    public partial class configurationsPage : Page
    {
        public configurationsPage()
        {
            InitializeComponent();

        }

        public void displayMessage(gridNotification notification)
        {
            body.Children.Add(notification);
        }
    }
}
