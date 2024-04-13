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
using Обработка_Заявок.DataFiles;

namespace Обработка_Заявок.Add
{
    /// <summary>
    /// Логика взаимодействия для PageAddIsp.xaml
    /// </summary>
    public partial class PageAddIsp : Page
    {
        public PageAddIsp()
        {
            InitializeComponent();
            DpDate.DisplayDateStart = DateTime.Parse("01.01.1900");
            DpDate.DisplayDateEnd = DateTime.Parse("01.01.2004");
            tbFio.Text = "";
            tbPhone.Text = "";
            tbStreet.Text = "";
            DpDate.Text = "";
            cmbCity.SelectedItem = null;

            cmbCity.SelectedValuePath = "Код_Города";
            cmbCity.DisplayMemberPath = "Название";
            cmbCity.ItemsSource = ConnectHelper.entObj.Город.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void btnAddDolzh_Click(object sender, RoutedEventArgs e)
        {
            if (tbFio.Text == "" && tbPhone.Text == "" && tbStreet.Text == "" && DpDate.SelectedDate == null && cmbCity.Text == "")
            {
                MessageBox.Show("Поля нельзя оставлять пустыми!");
            }
            else if (DpDate.SelectedDate > DateTime.Today)
            {
                {
                    MessageBox.Show("Дата не может быть в будующем!");
                    DpDate.Text = "";
                }
            }
            else
            {
                try
                {
                    Исполнитель stdObj = new Исполнитель()
                    {
                        ФИО = tbFio.Text,
                        Телефон = tbPhone.Text,
                        Улица = tbStreet.Text,
                        Дата_Рождения = DpDate.SelectedDate,
                        Город = cmbCity.SelectedItem as Город
                    };

                    ConnectHelper.entObj.Исполнитель.Add(stdObj);
                    ConnectHelper.entObj.SaveChanges();

                    MessageBox.Show("Исполнитель добавлен!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information
                                    );

                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Критическая работа с приложением: " + ex.Message.ToString(),
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );
                }
            }
            
        }
    }
}
