using Marat.Context;
using Marat.Models;
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

namespace Marat.Views.Pages
{
    /// <summary>
    /// Interaction logic for ApplicantsPage.xaml
    /// </summary>
    public partial class ApplicantsPage : Page
    {
        public ApplicantsPage()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void buttonToView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ApplicantsViewPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadComboBox load = new LoadComboBox();
            load.LoadCombo(comboBoxPosition);
        }
        // Add
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Applicant newApplicant = new Applicant();
                newApplicant.LasrstName = txtLastName.Text;
                newApplicant.FristName = txtFirstName.Text;
                newApplicant.MiddleName = txtMiddleName.Text;
                newApplicant.DateOfBirth = (DateTime)dateOfBirth.SelectedDate;
                newApplicant.Gender = comboBoxGender.Text;
                newApplicant.Series = int.Parse(txtSeries.Text);
                newApplicant.Number = int.Parse(txtNumber.Text);
                newApplicant.EmlpoymentDate = (DateTime)emlpoymentDate.SelectedDate;
                newApplicant.Education = comboBoxEducation.Text;
                newApplicant.TotalSalary = int.Parse(txtTotalSalary.Text);
                newApplicant.Position = comboBoxPosition.Text;
                XApp.db.Applicant.Add(newApplicant);
                XApp.db.SaveChanges();
                if (MessageBox.Show("Хотите посмотреть запись?", "Сохранение прошло успешно!!", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    NavigationService.Navigate(new ApplicantsViewPage());
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
