using ChatSock_v1._0._2.customControls;
using ChatSock_v1._0._2.utils;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ChatSock_v1._0._2.contentPage
{
    /// <summary>
    /// Interaction logic for contentPage.xaml
    /// </summary>
    public partial class contentPage : Page
    {
        //global
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public contentPage()
        {
            InitializeComponent();
        }

        public contentPage(string header, string subtext00 , string subtext01 , string filename)
        {
            InitializeComponent();

            try
            {
                var lines = File.ReadAllText(@filename);
                linesBlock.Text = lines;
            }
            catch (Exception ex)
            {
                exceptionHandler.logOnly(ex);
                body.Children.Add(new gridNotification("Some files were deleted, error 404"));
            }
           
        }

        private void back(object sender, RoutedEventArgs e)
        {
            mainWindow.frameGoback();
        }
    }
}
