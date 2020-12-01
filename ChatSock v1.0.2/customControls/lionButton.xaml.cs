﻿using ChatSock_v1._0._2.utils;
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
    /// Interaction logic for lionButton.xaml
    /// </summary>
    public partial class lionButton : UserControl
    {
        public lionButton()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //click animation
            var anime = animationHelper.getOpacityAnimationObject(1, 0.7, 0.1);
            anime.AutoReverse = true;
            this.BeginAnimation(OpacityProperty, anime);
        }



        public Brush buttonColor
        {
            get { return (Brush)GetValue(buttonColorProperty); }
            set { SetValue(buttonColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for buttonColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty buttonColorProperty =
            DependencyProperty.Register("buttonColor", typeof(Brush), typeof(lionButton), new PropertyMetadata(Brushes.LightGreen));


    }
}