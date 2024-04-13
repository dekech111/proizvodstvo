using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Обработка_Заявок.DataFiles;

namespace Обработка_Заявок.View
{
    /// <summary>
    /// Логика взаимодействия для WindowsCloseZayavka.xaml
    /// </summary>
    public partial class WindowsCloseZayavka : Window
    {
        private int idZak = PageViewZakazi.GetZakk();
        public WindowsCloseZayavka()
        {
            InitializeComponent();
            var zakaz = ConnectHelper.entObj.Заказ.FirstOrDefault(x => x.Код_Заказа == idZak);
            txbNumer.Text = zakaz.Код_Заказа.ToString();
            txbZakazchick.Text = zakaz.Заказчик.ФИО;
            txbObor.Text = zakaz.Используемое_Оборудование.Наименование;
            txbCount.Text = zakaz.КолВо_Оборудования.ToString();

            ZakObj.Код_Заказа = idZak;
            DataContext = zakaz;

            if (zakaz.СерийныйНомер != null)
                txbSerialNumber.Text = zakaz.СерийныйНомер;
            txbSerialNumber.MaxLength = Convert.ToInt32(zakaz.КолВо_Оборудования * 5);


        }
        private void btnCloase_Click(object sender, RoutedEventArgs e)
        {
            //Изменение заказа
            IEnumerable<Заказ> zaka = ConnectHelper.entObj.Заказ.Where(x => x.Код_Заказа == ZakObj.Код_Заказа).AsEnumerable().
                Select(x =>
                {
                    x.Код_Статуса = 3;
                    x.СерийныйНомер = txbSerialNumber.Text;
                    return x;
                });
            foreach (Заказ r in zaka)
            {
                ConnectHelper.entObj.Entry(r).State = System.Data.Entity.EntityState.Modified;
            }

            try
            {
                ConnectHelper.entObj.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }
    }
}
