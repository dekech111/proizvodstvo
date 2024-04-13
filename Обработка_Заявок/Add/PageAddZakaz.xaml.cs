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
    /// Логика взаимодействия для PageAddZakaz.xaml
    /// </summary>
    public partial class PageAddZakaz : Page
    {
        private static int zakazID;
        private static string zakazFio;

        public static int ZakazID { get => zakazID; set => zakazID = value; }
        public static string ZakazFio { get => zakazFio; set => zakazFio = value; }

        public PageAddZakaz()
        {
            InitializeComponent();
            tbFio.Text = "";
            tbPhone.Text = "";
            tbStreet.Text = "";
            tbOb.Text = "";
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
            if (tbFio.Text == "" && tbPhone.Text == "" && tbStreet.Text == "" && tbOb.Text == "" && cmbCity.Text == "")
            {
                MessageBox.Show("Поля нельзя оставлять пустыми!");
            }
            else
            {
                try
                {
                    Заказчик stdObj = new Заказчик()
                    {
                        ФИО = tbFio.Text,
                        Телефон = tbPhone.Text,
                        Улица = tbStreet.Text,
                        Объект = tbOb.Text,
                        Город = cmbCity.SelectedItem as Город
                    };

                    ConnectHelper.entObj.Заказчик.Add(stdObj);
                    ConnectHelper.entObj.SaveChanges();

                    var zakazcick = ConnectHelper.entObj.Заказчик.FirstOrDefault(x => x.ФИО == tbFio.Text);

                    ZakazID = zakazcick.Код_Заказчика;
                    ZakazFio = zakazcick.ФИО;

                    MessageBox.Show("Заказчик добавлен!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information
                                    );
                    FrameApp.frmObj.Navigate(new PageAddZakazStep2());
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
