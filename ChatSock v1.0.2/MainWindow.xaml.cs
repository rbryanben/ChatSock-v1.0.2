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

namespace ChatSock_v1._0._2
{
    /// <summary>
    /// This is the main window which pages will be being placed
    /// On initialization the following will be checked
    /// (1) Previous window state and will be set 
    /// (2) Create instances of the pages that will be inserted and reversed
    /// (3) Show startup animation
    /// (4) Check if there is a previous logged in user , if not show loggin page if true show config page
    /// 
    /// Methods of the class include 
    /// (1)  setDisplayingPageAs 
    ///      - Sets the page to display for easy transition of pages
    /// </summary>
    public partial class MainWindow : Window
    {

        /// Global varibles come here
        public Page loginPage { get; set; }
        public Page configurationsPage { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            //(1) set the previous window state
            if (Properties.Settings.Default.WindowStateMax)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }


            //(2) instance pages
            this.loginPage = new loginPage.loginPage();
            this.configurationsPage = new configurationsPage.configurationsPage();

            //(3) show startup animation

            //(4) show login if there is no logged in user
            if (Properties.Settings.Default.LoggedInUserIdentification == "")
            {
                setDisplayingPageAs(this.loginPage);
            }

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //store the new state of the window
            if (this.WindowState == WindowState.Maximized)
            {
                Properties.Settings.Default.WindowStateMax = true;
            }
            else
            {
                Properties.Settings.Default.WindowStateMax = false;
            }

            Properties.Settings.Default.Save();

        }

        /*
         * for switching frames
         */
        public void setDisplayingPageAs(Page pageToDisplay)
        {
            if (pageToDisplay != null)
            {
                this.body.Navigate(pageToDisplay);
            }
        }

        //sets window title 
        public void setWindowTitle(string title)
        {
            this.Title = title;
        }
    }
}
