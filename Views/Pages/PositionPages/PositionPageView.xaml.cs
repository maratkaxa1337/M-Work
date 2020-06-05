using Marat.Context;
using Marat.Moderato;
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

namespace Marat.Views.Pages.PositionPages
{
    /// <summary>
    /// Interaction logic for PositionPageView.xaml
    /// </summary>
    public partial class PositionPageView : Page
    {
        public PositionPageView()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

       
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            viewPosition.ItemsSource = XApp.db.Applicant.ToList();
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            Export export = new Export();
            export.ExportToTxt(viewPosition);
        }

        private void txtSearch_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            viewPosition.ItemsSource = XApp.db.Applicant.Where(item => item.FristName.Contains(txtSearch.Text) || item.LasrstName.Contains(txtSearch.Text) || item.Position.Contains(txtSearch.Text) || item.TotalSalary.ToString().Contains(txtSearch.Text) || item.Education.Contains(txtSearch.Text)).ToList();

        }
    }
}
