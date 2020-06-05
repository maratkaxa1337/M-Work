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

namespace Marat.Views.Pages.Applicants
{
    /// <summary>
    /// Interaction logic for ApplicantsEditPage.xaml
    /// </summary>
    public partial class ApplicantsEditPage : Page
    {
        private Applicant selectedItem;
        public ApplicantsEditPage()
        {
            InitializeComponent();
        }
        // Load ID
        public ApplicantsEditPage(Applicant selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
            txtLastName.Text = selectedItem.LasrstName;
            txtFirstName.Text = selectedItem.FristName;
            txtMiddleName.Text = selectedItem.MiddleName;
            dateOfBirth.SelectedDate = selectedItem.DateOfBirth;
            comboBoxGender.Text = selectedItem.Gender;
            txtSeries.Text = selectedItem.Series.ToString();
            txtNumber.Text = selectedItem.Number.ToString();
            emlpoymentDate.SelectedDate = selectedItem.EmlpoymentDate;
            comboBoxEducation.Text = selectedItem.Education;
            txtTotalSalary.Text = selectedItem.TotalSalary.ToString();
            comboBoxPosition.Text = selectedItem.Position;
        }
        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
        // Edit
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Applicant editApplicant = XApp.db.Applicant.FirstOrDefault(item => item.ID == selectedItem.ID);
                editApplicant.LasrstName = txtLastName.Text;
                editApplicant.FristName = txtLastName.Text;
                editApplicant.FristName = txtFirstName.Text;
                editApplicant.MiddleName = txtMiddleName.Text;
                editApplicant.DateOfBirth = (DateTime)dateOfBirth.SelectedDate;
                editApplicant.Gender = comboBoxGender.Text;
                editApplicant.Series = int.Parse(txtSeries.Text);
                editApplicant.Number = int.Parse(txtNumber.Text);
                editApplicant.EmlpoymentDate = (DateTime)emlpoymentDate.SelectedDate;
                editApplicant.Education = comboBoxEducation.Text;
                editApplicant.TotalSalary = int.Parse(txtTotalSalary.Text);
                editApplicant.Position = comboBoxPosition.Text;
                XApp.db.SaveChanges();
                MessageBox.Show("Отредактированные данные успешно сохранились.", "Операция прошла успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Произошла ошибка.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
