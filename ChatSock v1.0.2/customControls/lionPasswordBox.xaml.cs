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
    /// Interaction logic for lionPasswordBox.xaml
    /// </summary>
    public partial class lionPasswordBox : UserControl
    {
        public lionPasswordBox()
        {
            InitializeComponent();
        }

        public string header
        {
            get { return (string)GetValue(headerProperty); }
            set { SetValue(headerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty headerProperty =
            DependencyProperty.Register("header", typeof(string), typeof(lionPasswordBox), new PropertyMetadata("header"));

        private void passwordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //to clear passwordbox
            if (passwordBox.Password == "password")
            {
                passwordBox.Clear();
            }
        }
    }
}
