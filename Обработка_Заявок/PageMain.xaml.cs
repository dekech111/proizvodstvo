using System.Windows;
using System.Windows.Controls;
using Обработка_Заявок.DataFiles;
using Обработка_Заявок.View;
using Обработка_Заявок.Add;

namespace Обработка_Заявок.Work
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
        }
        private void btnAddZakaz_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Добавить с новый заказчиком?: ", "Уведомление", MessageBoxButton.YesNoCancel);
            if (dialogResult == MessageBoxResult.Yes)
                FrameApp.frmObj.Navigate(new PageAddZakaz());
            else if (dialogResult == MessageBoxResult.No)
                FrameApp.frmObj.Navigate(new PageAddZakazZak());
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewMain());
        }
    }
}
