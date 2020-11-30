using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Animation;


namespace ChatSock_v1._0._2.utils
{
    class animationHelper
    {

        //double animation
        public static DoubleAnimation getOpacityAnimationObject(double from , double to , double duration)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = from;
            animation.To = to;
            animation.Duration = TimeSpan.FromSeconds(duration);

            return animation;
        }

        //thickness animation
        public static ThicknessAnimation getThicknessAnimationObject(System.Windows.Thickness from , System.Windows.Thickness to , double duration)
        {
            ThicknessAnimation animation = new ThicknessAnimation();
            animation.From = from;
            animation.To = to;
            animation.Duration = TimeSpan.FromSeconds(duration);

            return animation;

        }
    }
}
