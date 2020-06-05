using Marat.Context;
using Marat.Models;
using Marat.Moderato;
using Marat.Views.Pages.Applicants;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ApplicantsViewPage.xaml
    /// </summary>
    public partial class ApplicantsViewPage : Page
    {
        public ApplicantsViewPage()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            viewApplicants.ItemsSource = XApp.db.Applicant.ToList();
        }
        // Edit
        private void buttonOpenToEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Applicant editApplicant = (Applicant)viewApplicants.SelectedItem;
                if (editApplicant != null)
                    NavigationService.Navigate(new ApplicantsEditPage(editApplicant));
                else
                    throw new Exception("Пожалуйста, выберите запись, которую хотите отредактировать!");
            }
            catch (Exception)
            {

                throw;
            }
        }
        // Remove
        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Applicant selectedItem = (Applicant)viewApplicants.SelectedItem;
                if (MessageBox.Show("Вы действительно хотите удалить выбранную вами запись? Данные будут удалены без возможности восстановления!", "Внимание!",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Applicant removeApplicant = XApp.db.Applicant.FirstOrDefault(item => item.ID == selectedItem.ID);
                    XApp.db.Applicant.Remove(removeApplicant);
                    XApp.db.SaveChanges();
                    Page_Loaded(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Search
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewApplicants.ItemsSource = XApp.db.Applicant.Where(item => item.FristName.Contains(txtSearch.Text) || item.LasrstName.Contains(txtSearch.Text) || item.Position.Contains(txtSearch.Text) || item.TotalSalary.ToString().Contains(txtSearch.Text) || item.Education.Contains(txtSearch.Text)).ToList();
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            viewApplicants.ItemsSource = XApp.db.Applicant.Where(date => date.EmlpoymentDate == searchEmploymentDate.SelectedDate).ToList();
        }

        Export export = new Export();
        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                export.ExportToTxt(viewApplicants);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
