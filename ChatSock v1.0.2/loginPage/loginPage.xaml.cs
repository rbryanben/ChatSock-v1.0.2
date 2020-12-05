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

namespace ChatSock_v1._0._2.loginPage
{
    /// <summary>
    /// This class allows the user to Login with their creds
    /// When page is loaded the following occurs
    /// (1) Sets the tile of the mainWindow to Login
    /// When the sign in button is clicked 
    /// (0) Check if the input username and password meets standard
    /// (1) Create an instance of an Account class with username and password , but not the id
    /// (2) Call async login function which makes use of our account class and returns a result
    /// (3) Act upon the result , success(go to login , set the new signed in account details to settings)
    /// </summary>
    public partial class loginPage : Page
    {
        //global
        private static string title = "Login";
        private Account tempAccountHolder = new Account();

        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public loginPage()
        {
            InitializeComponent();
            signinButton.dontAnimate = true;            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //title of main window
            mainWindow.setWindowTitle(title);

            //set notification
            body.Children.Add(new imageGridNotification("https://www.goodcore.co.uk/blog/wp-content/uploads/2019/08/types-of-software.png"));
        }

        private async void signinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {

            //does input meet standard
            if (usernameLionBox.getText() == "password" || usernameLionBox.getText().Length < 6 || passwordText.getPassword() == "password"
                || passwordText.getPassword().Length < 6)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#FFB45B31");
                body.Children.Add(new gridNotification("Please check you entered a valid input", brush));
            }
            else
            {
              
                //thread cannot access the usernameTextBox object
                tempAccountHolder.id = usernameLionBox.getText();
                tempAccountHolder.password = passwordText.getPassword();

                //reduce opacity 
                signinButton.enabled(false);
                
                
                switch (await loginAsync())
                {
                    case 0:
                        //login failed
                        body.Children.Add(new gridNotification("Sign in attempt failed"));
                        break;
                    case 1:          
                        //go to configurations
                        mainWindow.setDisplayingPageAs(mainWindow.configurationsPage);
                        
                        break;
                    case -1:
                        //no internet
                        var converter = new System.Windows.Media.BrushConverter();
                        var brush = (Brush)converter.ConvertFromString("#FFB45B31");
                        body.Children.Add(new gridNotification("Seems like you dont have an active connection", brush));
                        break;
                }

                //reduce opacity 
                signinButton.enabled(true);


            }

        }


    
        private async Task<int> loginAsync()
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


            try
            {
                //username query
                var accountQuery = await firebase
                  .Child("Accounts")
                  .OrderByKey()
                  .StartAt(tempAccountHolder.id)
                  .LimitToFirst(1)
                  .OnceAsync<Account>();

            
            //no account exists 
            if (accountQuery.Count == 0)
            {
                    //email check
                    try
                    {
                        //email query
                        var emailQuery = await firebase
                          .Child("Accounts")
                          .OrderBy("email")
                          .StartAt(tempAccountHolder.id)
                          .LimitToFirst(1)
                          .OnceAsync<Account>();


                        //if there are no emails 
                        if (emailQuery.Count == 0)
                        {
                            return 0;
                        }

                        var a = tempAccountHolder;
                        foreach (var account in emailQuery)
                        {
                            if (account.Object.password == tempAccountHolder.password && account.Object.email == tempAccountHolder.id)
                                return 1;
                            else
                            {
                                return 0;
                            }
                        }
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show(ex.ToString());
                        return -1;
                    }
                }

            //there is a username
            foreach (var account in accountQuery)
            {
               
                /*
                 *   return of 1 means successfull
                 *   return of 0 means unseccessfull sign in
                 *   return of -1 means got exception
                 */
                //get account
           
                if (account.Object.password == tempAccountHolder.password && account.Object.id == tempAccountHolder.id)
                {
                    return 1;      
                }
                else
                {
                    return 0;

                }

            }
            }
            catch (Exception)
            {
                return -1;
            }

            return -1;
            
        }

        private void forgotPasswordLink_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //go to password recovery
            mainWindow.setDisplayingPageAs(mainWindow.recoverPage);
           
        }

        private void createAccount(object sender, RoutedEventArgs e)
        {
            mainWindow.setDisplayingPageAs(mainWindow.usernameEmail);
        }

        private void passwordText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                signinButton_MouseDown(sender, null);
            }
        }
    }
}
