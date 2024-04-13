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
using Обработка_Заявок.View;

namespace Обработка_Заявок.Add
{
    /// <summary>
    /// Логика взаимодействия для PageAddZakazStep2.xaml
    /// </summary>
    public partial class PageAddZakazStep2 : Page
    {
        int zakazID = PageAddZakaz.ZakazID;
        string zakazFIO = PageAddZakaz.ZakazFio;
        public PageAddZakazStep2()
        {
            InitializeComponent();
            dpDate.DisplayDateStart = DateTime.Now;
            cmbYslyg.Text = "";
            cmbIsp.Text = "";
            cmbObor.Text = "";
            tbCount.Text = "";
            tbOpis.Text = "";
            dpDate.Text = "";
            cmbZak.Text = zakazFIO;

            cmbYslyg.SelectedValuePath = "Код_Услуги";
            cmbYslyg.DisplayMemberPath = "Название";
            cmbYslyg.ItemsSource = ConnectHelper.entObj.Вид_Услуги.ToList();


            cmbIsp.SelectedValuePath = "Код_Исполнителя";
            cmbIsp.DisplayMemberPath = "ФИО";
            cmbIsp.ItemsSource = ConnectHelper.entObj.Исполнитель.ToList();

            cmbObor.SelectedValuePath = "Код_Оборудования";
            cmbObor.DisplayMemberPath = "Наименование";
            cmbObor.ItemsSource = ConnectHelper.entObj.Используемое_Оборудование.ToList();
        }

        private void btnAddDolzh_Click(object sender, RoutedEventArgs e)
        {
            Byte isp = Convert.ToByte(cmbIsp.SelectedValue);
            Byte obor = Convert.ToByte(cmbObor.SelectedValue);
            Byte ysl = Convert.ToByte(cmbYslyg.SelectedValue);

            var zakaz = ConnectHelper.entObj.Заказ.FirstOrDefault(x => x.Краткое_описание == tbOpis.Text & x.Код_Услуги == ysl &
        x.Дата == dpDate.SelectedDate & x.Код_исполнителя == isp & x.КолВо_Оборудования.ToString() == tbCount.Text & x.Код_оборудования == obor);
            if (zakaz != null)
                MessageBox.Show("Такой заказ уже существует!", "Повторное создание заявки!", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {


                if (cmbYslyg.Text == "" && cmbIsp.Text == "" && cmbObor.Text == "" && tbCount.Text == "" && tbOpis.Text == "" && dpDate.Text == "")
                {
                    MessageBox.Show("Поля нельзя оставлять пустыми!");
                }
                else
                {
                    try
                    {
                        Заказ stdObj = new Заказ()
                        {

                            Вид_Услуги = cmbYslyg.SelectedItem as Вид_Услуги,
                            Краткое_описание = tbOpis.Text,
                            Исполнитель = cmbIsp.SelectedItem as Исполнитель,
                            Код_заказчика = zakazID,
                            Используемое_Оборудование = cmbObor.SelectedItem as Используемое_Оборудование,
                            КолВо_Оборудования = int.Parse(tbCount.Text),
                            Дата = dpDate.SelectedDate,
                            Сумма = 1,
                            Код_Статуса = 1,


                        };

                        ConnectHelper.entObj.Заказ.Add(stdObj);
                        ConnectHelper.entObj.SaveChanges();

                        MessageBox.Show("Заказ добавлен!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information
                                        );
                        FrameApp.frmObj.Navigate(new PageViewZakazi());
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
