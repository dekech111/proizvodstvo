
using System.Windows;
using System.Windows.Controls;
using Обработка_Заявок.DataFiles;
using Обработка_Заявок.Work;

namespace Обработка_Заявок.View
{
    /// <summary>
    /// Логика взаимодействия для PageViewMain.xaml
    /// </summary>
    public partial class PageViewMain : Page
    {
        public PageViewMain()
        {
            InitializeComponent();
        }

        private void btnViewYsl_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewYsl());
        }

        private void btnViewZak_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewZak());
        }

        private void btnViewIpl_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewIsp());
        }

        private void btnViewOboryd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewOboryd());
        }
        private void btnViewCity_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewCity());
        }

        private void btnViewZakaz_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewZakazi());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageMain());
        }
    }
}
