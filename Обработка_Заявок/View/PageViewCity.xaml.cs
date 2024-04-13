using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Обработка_Заявок.Add;
using Обработка_Заявок.DataFiles;
using System;
using System.Text;
using System.Windows.Input;

namespace Обработка_Заявок.View
{
    /// <summary>
    /// Логика взаимодействия для PageViewCity.xaml
    /// </summary>
    public partial class PageViewCity : Page
    {
        public PageViewCity()
        {
            InitializeComponent();
            GridList.ItemsSource = ConnectHelper.entObj.Город.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddCity());
        }

        private void btnRemCity_Click(object sender, RoutedEventArgs e)
        {
            Город City = GridList.SelectedItem as Город;
            if (City == null)
            {
                MessageBox.Show("Не выбранно поле для удаления", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (MessageBox.Show("Удалить эту запись: " + $" {City.Название}?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ConnectHelper.entObj.Город.Remove(City);
                        ConnectHelper.entObj.SaveChanges();
                        MessageBox.Show("Запись удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                        GridList.ItemsSource = ConnectHelper.entObj.Город.ToList();
                    }
                    catch
                    {
                        MessageBox.Show("Данная запись используется в другом месте. Прежде чем ее удалить удостоверьтесь что она нигде не используется!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }

        private void btnExcex_Click(object sender, RoutedEventArgs e)
        {
            GridList.SelectAllCells();
            GridList.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;

            ApplicationCommands.Copy.Execute(null, GridList);

            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);

            String result = (string)Clipboard.GetData(DataFormats.Text);


            GridList.UnselectAllCells();
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Export";
            dlg.DefaultExt = ".text";
            dlg.Filter = "(.xls)|*.xls";

            Nullable<bool> result1 = dlg.ShowDialog();
            if (result1 == true)
            {

                string filename = dlg.FileName;

                System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false, Encoding.Default);
                file.WriteLine(result);
                file.Close();

                MessageBox.Show("Экспорт данных успешно завершен");
            }
        }
    }
}
