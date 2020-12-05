using ChatSock_v1._0._2.utils;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatSock_v1._0._2.customControls
{
    /// <summary>
    /// Interaction logic for imageGridNotification.xaml
    /// </summary>
    public partial class imageGridNotification : UserControl
    {

        private int loadCount = 0; //show self only when count is 3

        public imageGridNotification(string imageSource)
        {
            InitializeComponent();

            //parent
            Grid parentGrid = (Grid)this.Parent;

            try
            {
                //set url
                sourceImage.ImageSource = new BitmapImage(new Uri(@imageSource));
            }
            catch (Exception ex)
            {
                exceptionHandler.handleException(ex, (Grid)this.Parent);
            }

            //hide self 
            this.Opacity = 0;
            this.Margin = new Thickness(0, 0, -100, 0);
        }

        private void closeImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //parent
            hide();
        }

        private void ImageBrush_Changed(object sender, EventArgs e)
        {
            loadCount++;
            if (loadCount == 3)
            {
                show();
            }
        }

        private void show()
        {
            var animationConstant = 0.5;

            //opacity 
            var opacityAnime = animationHelper.getOpacityAnimationObject(this.Opacity, 1, animationConstant);
            this.BeginAnimation(OpacityProperty, opacityAnime);

            //margin
            var marginAnime = animationHelper.getThicknessAnimationObject(this.Margin, new Thickness(0, 0, 20, 0), animationConstant);
            marginAnime.EasingFunction = new QuarticEase();
            this.BeginAnimation(MarginProperty, marginAnime);
        }


        private void hide()
        {
            var animationConstant = 0.5;

            //opacity 
            var opacityAnime = animationHelper.getOpacityAnimationObject(this.Opacity, 0, animationConstant);
            this.BeginAnimation(OpacityProperty, opacityAnime);

            //margin
            var marginAnime = animationHelper.getThicknessAnimationObject(this.Margin, new Thickness(0, 0, -100, 0), animationConstant);
            marginAnime.EasingFunction = new QuadraticEase();

            //to remove object when event is completed
            marginAnime.Completed += (Sender, EventArgs) =>
            {
                Grid parentGrid = (Grid)this.Parent;
                parentGrid.Children.Remove(this);
            };

            this.BeginAnimation(MarginProperty, marginAnime);

        }

    }
}
