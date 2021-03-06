﻿using Marat.Views.Pages.PositionPages;
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

namespace Marat.Views.Pages
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void buttonToApplicants_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ApplicantsPage());
        }

        private void buttonToFrames_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ApplicantsViewPage());
        }

        private void buttonToPosition_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PositionPageView());
        }
    }
}
