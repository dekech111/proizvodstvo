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
    /// Логика взаимодействия для PageAddOboryd.xaml
    /// </summary>
    public partial class PageAddOboryd : Page
    {
        public PageAddOboryd()
        {
            InitializeComponent();
            tbCash.Text = "";
            tbName.Text = "";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == "" && tbCash.Text == "" )
            {
                MessageBox.Show("Поля нельзя оставлять пустыми!");
            }
            else
            {
                try
                {
                    Используемое_Оборудование stdObj = new Используемое_Оборудование()
                    {
                        Наименование = tbName.Text,
                        Цена = int.Parse(tbCash.Text)
                    };

                    ConnectHelper.entObj.Используемое_Оборудование.Add(stdObj);
                    ConnectHelper.entObj.SaveChanges();

                    MessageBox.Show("Оборудование добавлен!",
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
