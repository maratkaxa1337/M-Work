using Marat.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Marat.Moderato
{
    public class LoadComboBox
    {
        public void LoadCombo (ComboBox comboBox)
        {
			try
			{
				var query = XApp.db.Postiton.Select(item => new
				{
					positionTitle = item.Title
				});
				var collection = from item in query select item.positionTitle;
				comboBox.ItemsSource = collection.ToList();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка загрузки данных", MessageBoxButton.OK, MessageBoxImage.Error);
			}
        }
    }
}
