using ChatSock_v1._0._2.classes;
using ChatSock_v1._0._2.customControls;
using ChatSock_v1._0._2.utils;
using Firebase.Database;
using Firebase.Database.Query;
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
using System.Windows.Threading;

namespace ChatSock_v1._0._2.recoverPage
{
    /// <summary>
    /// Interaction logic for recoverPage.xaml
    /// </summary>
    public partial class recoverPage : Page
    {
        //global 
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        private Boolean waiting;
        private Account tempHolder;

        public recoverPage()
        {
            InitializeComponent();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            mainWindow.frameGoback();
        }

        private void recover_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (waiting == false)
            {
             
                //generate waiting time
                Random rnd = new Random();
                int waitTime = rnd.Next(13, 60);

                var waitingTimer = new DispatcherTimer();
                waitingTimer.Interval = TimeSpan.FromSeconds(waitTime);

                tempHolder = new Account();

                //set temp holder
                tempHolder.email = emailText.getText();
                tempHolder.recovery = codeText.getText();

                waitingTimer.Tick += async (Sender, EventArgs) =>
                {
                    //disable wait
                    waiting = false;

                    //get password
                    string result = await recoverAttempt();
                

                   if (result == "error")
                    {
                        var converter = new System.Windows.Media.BrushConverter();
                        var brush = (Brush)converter.ConvertFromString("#FFB45B31");
                        body.Children.Add(new gridNotification("Check your internet connection", brush));
                    }
                   else if (result == "no")
                    {
                        var converter = new System.Windows.Media.BrushConverter();
                        var brush = (Brush)converter.ConvertFromString("#FFB45B31");
                        body.Children.Add(new gridNotification("Invalid combination entered", brush));
                    }
                    else
                    {
                        body.Children.Add(new gridNotification(result, Brushes.Green));
                    }


                    //stop 
                    waitingTimer.Stop();
                };

                waitingTimer.Start();
                waiting = true;
                body.Children.Add(new gridNotification("Please wait " + waitTime + " seconds"));
            }
        }

        private async Task<string> recoverAttempt()
        {

            //firebase
            var auth = firebaseConfigurations.SecretKey;
            var firebaseClient = new FirebaseClient(
              "<URL>",
              new FirebaseOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(auth)
              });
            var firebase = new FirebaseClient(firebaseConfigurations.BasePath);

            //email check
            try
            {
                //username query
                var emailQuery = await firebase
                  .Child("Accounts")
                  .OrderBy("email")
                  .StartAt(tempHolder.email)
                  .LimitToFirst(1)
                  .OnceAsync<Account>();

                //if there are no emails 
                if (emailQuery.Count == 0 || emailQuery.Count > 1)
                {
                    return "no";
                }


                foreach (var account in emailQuery)
                {
           
                    if (account.Object.recovery == tempHolder.recovery && account.Object.email == tempHolder.email)
                        return account.Object.password;
                    else
                    {
                        return "no" ;
                    }
                }
            }
            catch
            {
                return "error" ;
            }

            return "error";
        
        }
    }
}
