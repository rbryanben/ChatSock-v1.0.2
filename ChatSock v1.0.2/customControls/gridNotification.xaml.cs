using ChatSock_v1._0._2.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ChatSock_v1._0._2.customControls
{
    /// <summary>
    /// This class is for a Notification
    /// It is used to notify a message in a body and then disappers
    /// The following occurs when it if constructed
    /// (1) Align the notification to the bottom center of its parent
    /// (2) Animate sliding up with quartic ease to a certain margin using either show() or showButHold()
    /// (3) Depending on the type function used the notification either stays on the screen or fades and ,
    ///     removes itself from the parent.
    /// </summary>
    public partial class gridNotification : UserControl
    {
        public gridNotification()
        {
            InitializeComponent();
            this.VerticalAlignment = VerticalAlignment.Bottom;
            showButHold();
        }

        public gridNotification(string notificationMessage)
        {
            InitializeComponent();
            this.gridNotificationText.Content = notificationMessage;
            this.VerticalAlignment = VerticalAlignment.Bottom;
            show();
   
        }

        public gridNotification(string notificationMessage,Brush backgroundColor)
        {
            InitializeComponent();
            this.gridNotificationBack.Background = backgroundColor;
            this.gridNotificationText.Content = notificationMessage;
            this.VerticalAlignment = VerticalAlignment.Bottom;
            show();
           
        }


        public gridNotification(string notificationMessage, Brush backgroundColor , Boolean hold)
        {
            InitializeComponent();
            this.gridNotificationBack.Background = backgroundColor;
            this.gridNotificationText.Content = notificationMessage;
            this.VerticalAlignment = VerticalAlignment.Bottom;
            showButHold();

        }

        /*
         * This procedure shows the notification and fades it
         */
        public void show()
        {
            var anime = animationHelper.getThicknessAnimationObject(this.Margin, new Thickness(50), 0.5);
            anime.EasingFunction = new System.Windows.Media.Animation.QuarticEase();
            anime.Completed += (sender, EventArgs) =>
            {
                //delay hidding
                var delay = new DispatcherTimer();
                delay.Interval = TimeSpan.FromSeconds(1);
                delay.Tick += (senderDelay, EventArgsDelay) =>
                {
                    //hide notification
                    delay.Stop();

                    var hideNotification = animationHelper.getOpacityAnimationObject(1, 0, 0.2);
                    hideNotification.Completed += (senderHide, EventArgsHide) =>
                    {
                        //remove from parent
                        Grid parentGrid = (Grid)this.Parent;
                        parentGrid.Children.Remove(this);
                    };

                    this.BeginAnimation(OpacityProperty, hideNotification);

                };
                delay.Start();
            };
            this.BeginAnimation(MarginProperty, anime);
        }

        /*
         * This procedure shows the notification but stays on the screen forever
         */
        public void showButHold()
        {
            var anime = animationHelper.getThicknessAnimationObject(this.Margin, new Thickness(50), 0.5);
            anime.EasingFunction = new System.Windows.Media.Animation.QuarticEase();
            anime.Completed += (sender, EventArgs) =>
            {
                //delay hidding
                var delay = new DispatcherTimer();
                delay.Interval = TimeSpan.FromSeconds(1);
                delay.Tick += (senderDelay, EventArgsDelay) =>
                {
                    //hide notification
                    delay.Stop();

                };
                delay.Start();
            };
            this.BeginAnimation(MarginProperty, anime);
        }
    }
}
