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

namespace Обработка_Заявок.View
{
    /// <summary>
    /// Логика взаимодействия для PageViewZak.xaml
    /// </summary>
    public partial class PageViewZak : Page
    {
        public PageViewZak()
        {
            InitializeComponent();
            GridList.ItemsSource = ConnectHelper.entObj.Заказчик.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
        private void BtnProfile_click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewZakaz((sender as Button).DataContext as Заказчик));
        }
    }
}
