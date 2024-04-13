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
    /// Логика взаимодействия для PageAddYsl.xaml
    /// </summary>
    public partial class PageAddYsl : Page
    {
        public PageAddYsl()
        {
            InitializeComponent();
            tbName.Text = "";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void btnAddDolzh_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Поля нельзя оставлять пустыми!");
            }
            else
            {
                try
                {
                    Вид_Услуги stdObj = new Вид_Услуги()
                    {
                        Название = tbName.Text,
                    };

                    ConnectHelper.entObj.Вид_Услуги.Add(stdObj);
                    ConnectHelper.entObj.SaveChanges();

                    MessageBox.Show("Услуга добавлена!",
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
