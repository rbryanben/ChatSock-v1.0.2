﻿using ChatSock_v1._0._2.classes;
using ChatSock_v1._0._2.customControls;
using ChatSock_v1._0._2.utils;
using FireSharp.Response;
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
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //title of main window
            mainWindow.setWindowTitle(title);    
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

                //show attempting login notification
                body.Children.Add(new gridNotification("Attempting sign in", Brushes.Gray));


                Task<object> loginTask = new Task<object>(login);
                loginTask.Start();
                switch (await loginTask)
                {
                    case 0:
                        //login failed
                        body.Children.Add(new gridNotification("Sign in attempt failed"));
                        break;
                    case 1:
                        //login successful
                        body.Children.Add(new gridNotification("Sign in attempt succesful", Brushes.Green));
                        break;
                    case -1:
                        //no internet
                        var converter = new System.Windows.Media.BrushConverter();
                        var brush = (Brush)converter.ConvertFromString("#FFB45B31");
                        body.Children.Add(new gridNotification("Seems like you dont have an active connection", brush));
                        break;
                }
            }

        }


        private object login()
        {
            /*
             *   return of 1 means successfull
             *   return of 0 means unseccessfull sign in
             *   return of -1 means got exception
             */
            //get account
            try
            {
                var res = firebaseConfigurations.client.Get(@"Accounts/" + tempAccountHolder.id);
                Account account = res.ResultAs<Account>();

                if (account == null)
                {
                    return 0;
                }
                else
                {
                    if (account.password == tempAccountHolder.password)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

        }



       
    }
}
