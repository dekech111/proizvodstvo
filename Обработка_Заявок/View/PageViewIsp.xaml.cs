﻿using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Обработка_Заявок.Add;
using Обработка_Заявок.DataFiles;

namespace Обработка_Заявок.View
{
    /// <summary>
    /// Логика взаимодействия для PageViewIsp.xaml
    /// </summary>
    public partial class PageViewIsp : Page
    {
        public PageViewIsp()
        {
            InitializeComponent();
            cmbCity.SelectedValuePath = "Код_Города";
            cmbCity.DisplayMemberPath = "Название";
            cmbCity.ItemsSource = ConnectHelper.entObj.Город.ToList();

            GridList.ItemsSource = ConnectHelper.entObj.Исполнитель.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddIsp());
        }

        private void btnRem_Click(object sender, RoutedEventArgs e)
        {
            Исполнитель Isp = GridList.SelectedItem as Исполнитель;
            if (Isp == null)
            {
                MessageBox.Show("Не выбранно поле для удаления", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (MessageBox.Show("Удалить эту запись: " + $" {Isp.ФИО}?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ConnectHelper.entObj.Исполнитель.Remove(Isp);
                        ConnectHelper.entObj.SaveChanges();
                        MessageBox.Show("Запись удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                        GridList.ItemsSource = ConnectHelper.entObj.Исполнитель.ToList();
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

        private void btnViewAll_Click(object sender, RoutedEventArgs e)
        {
            GridList.ItemsSource = ConnectHelper.entObj.Исполнитель.ToList();
        }

        private void cmbVid_Yslg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = (int)cmbCity.SelectedValue;

            GridList.ItemsSource = ConnectHelper.entObj.Исполнитель.Where(x => x.Код_Города == selected).ToList();
        }
    }
}
