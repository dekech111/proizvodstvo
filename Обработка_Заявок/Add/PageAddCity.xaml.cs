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
    /// Логика взаимодействия для PageAddCity.xaml
    /// </summary>
    public partial class PageAddCity : Page
    {
        public PageAddCity()
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
                MessageBox.Show("Нужно заполнить поле Название",
                                      "Уведомление");
            }
            else
            {
                try
                {
                    Город stdObj = new Город()
                    {
                        Название = tbName.Text
                    };

                    ConnectHelper.entObj.Город.Add(stdObj);
                    ConnectHelper.entObj.SaveChanges();

                    MessageBox.Show("Город добавлен!",
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
