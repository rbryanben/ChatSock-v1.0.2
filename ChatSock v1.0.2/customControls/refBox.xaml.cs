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

namespace ChatSock_v1._0._2.customControls
{
    /// <summary>
    /// Interaction logic for refBox.xaml
    /// </summary>
    public partial class refBox : UserControl
    {

        //global
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public refBox()
        {
            InitializeComponent();
        }

        private void contactUsLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://mail.google.com/mail/?view=cm&fs=1&to=rbryanben@gmail.com.com&su=GREETINGS&body=Hie..");

        }

        private void privacyPageLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //show privacy
            mainWindow.setDisplayingPageAs(new contentPage.contentPage("Privacy", "here is our document on our" , "privacy actions", "privacy.txt"));
        }

        private void securityPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //show security
            mainWindow.setDisplayingPageAs(new contentPage.contentPage("Security", "here is our document on our", "security measures", "security.txt"));
        }

        private void termsAndConditionsLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //show terms
            mainWindow.setDisplayingPageAs(new contentPage.contentPage("Terms and Conditions", "here is our document on our", "terms and conditions", "termsAndConditions.txt"));
        }
    }
}
