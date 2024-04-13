using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;
using Обработка_Заявок.Add;
using Word = Microsoft.Office.Interop.Word;
using Обработка_Заявок.DataFiles;
using System.IO;

namespace Обработка_Заявок.View
{
    /// <summary>
    /// Логика взаимодействия для PageViewZakazi.xaml
    /// </summary>
    public partial class PageViewZakazi : Page
    {
        string TemplateFileName = Directory.GetCurrentDirectory() + @"\Макет_договора.docx";
        public static int IdZak;
        public PageViewZakazi()
        {
            InitializeComponent();
            cmbVid_Yslg.IsEditable = false;

            cmbSelected.Items.Add("По дате");
            cmbSelected.Items.Add("По услуге");
            cmbSelected.Items.Add("По Статусе");
            cmbSelected.Items.Add("По ФИО заказчика");
            cmbSelected.Items.Add("По ФИО исполнителя");


            cmbVid_Yslg.SelectedValuePath = "Код_Услуги";
            cmbVid_Yslg.DisplayMemberPath = "Название";
            cmbVid_Yslg.ItemsSource = ConnectHelper.entObj.Вид_Услуги.ToList();

            cmbStatus.SelectedValuePath = "Код_Статуса";
            cmbStatus.DisplayMemberPath = "Наименование";
            cmbStatus.ItemsSource = ConnectHelper.entObj.Статус.ToList();

            cmbFIOGrazh.SelectedValuePath = "Код_Заказчика";
            cmbFIOGrazh.DisplayMemberPath = "ФИО";
            cmbFIOGrazh.ItemsSource = ConnectHelper.entObj.Заказчик.ToList();

            cmbFIOIsp.SelectedValuePath = "Код_Исполнителя";
            cmbFIOIsp.DisplayMemberPath = "ФИО";
            cmbFIOIsp.ItemsSource = ConnectHelper.entObj.Исполнитель.ToList();

            txbSum.Text = "Сумма: " +  ConnectHelper.entObj.Заказ.Sum(x => x.Сумма) + " ₽";

            GridList.ItemsSource = ConnectHelper.entObj.Заказ.ToList();


        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewMain());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddZakaz());
        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            var application = new Excel.Application();
            application.SheetsInNewWorkbook = 1;
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = application.Worksheets[1];
            try
            {
                worksheet.Name = "Заказы";
                Excel.Range table = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[11][ConnectHelper.entObj.Заказ.Count() + 1]];
                table.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
                table.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
                table.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
                table.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
                table.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =
                table.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                table.Cells[1][1] = "№";
                table.Cells[2][1] = "Вид Услуги";
                table.Cells[3][1] = "Краткое Описание";
                table.Cells[4][1] = "Исполнитель";
                table.Cells[5][1] = "Заказчик";
                table.Cells[6][1] = "Оборудование";
                table.Cells[7][1] = "КолВо Оборудования";
                table.Cells[8][1] = "Дата";
                table.Cells[9][1] = "Сумма";
                table.Cells[10][1] = "Статус";
                table.Cells[11][1] = "Серийный номер";

                int i = 2;
                foreach (var zak in ConnectHelper.entObj.Заказ)
                {
                    table.Cells[1][i] = zak.Код_Заказа;
                    table.Cells[2][i] = zak.Вид_Услуги.Название;
                    table.Cells[3][i] = zak.Краткое_описание;
                    table.Cells[4][i] = zak.Исполнитель.ФИО;
                    table.Cells[5][i] = zak.Заказчик.ФИО;
                    table.Cells[6][i] = zak.Используемое_Оборудование.Наименование;
                    table.Cells[7][i] = zak.КолВо_Оборудования;
                    table.Cells[8][i] = zak.Дата;
                    table.Cells[9][i] = zak.Сумма;
                    table.Cells[10][i] = zak.Статус.Наименование;

                    if(zak.СерийныйНомер == null)
                        table.Cells[11][i] = "Серийный номер отсутсвует";
                    else 
                        table.Cells[11][i] = zak.СерийныйНомер;

                    i++;
                }

                table.Columns.AutoFit();
                application.Visible = true;
            }
            catch (Exception ex)
            {
                workbook.Close();
                MessageBox.Show(ex.Message, "Критическая ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cmbVid_Yslg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = Convert.ToInt32(cmbVid_Yslg.SelectedValue);

            GridList.ItemsSource = ConnectHelper.entObj.Заказ.Where(x => x.Код_Услуги == selected).ToList();
            txbSum.Text = "Сумма: " + ConnectHelper.entObj.Заказ.Where(x => x.Код_Услуги == selected).Sum(x => x.Сумма) + " ₽";

        }

        private void btnViewAll_Click(object sender, RoutedEventArgs e)
        {
            cmbSelected.Text = null;
            cmbSelected.SelectedIndex = -1;

            spDate.Visibility = Visibility.Collapsed;

            cmbFIOGrazh.Visibility = Visibility.Collapsed;
            cmbFIOGrazh.SelectedIndex = -1;
            cmbFIOGrazh.Text = null;

            cmbFIOIsp.Visibility = Visibility.Collapsed;
            cmbFIOIsp.SelectedIndex = -1;
            cmbFIOIsp.Text = null;

            cmbStatus.Visibility = Visibility.Collapsed;
            cmbStatus.SelectedIndex = -1;
            cmbStatus.Text = null;

            cmbVid_Yslg.Visibility = Visibility.Collapsed;
            cmbVid_Yslg.SelectedIndex = -1;
            cmbVid_Yslg.Text = null;

            dpStart.SelectedDate = null; dpEnd.SelectedDate = null;

            txbSum.Text = "Сумма: " +  ConnectHelper.entObj.Заказ.Sum(x => x.Сумма) + " ₽";
            GridList.ItemsSource = ConnectHelper.entObj.Заказ.ToList();
        }

        private void cmbSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSelected.SelectedIndex == 0)
            {
                spDate.Visibility = Visibility.Visible;

                cmbVid_Yslg.Visibility = Visibility.Collapsed;
                cmbStatus.Visibility = Visibility.Collapsed;
                cmbFIOGrazh.Visibility = Visibility.Collapsed;
                cmbFIOIsp.Visibility = Visibility.Collapsed;
            }
            else if (cmbSelected.SelectedIndex == 1)
            {
                cmbVid_Yslg.Visibility=Visibility.Visible;

                spDate.Visibility = Visibility.Collapsed;
                cmbStatus.Visibility = Visibility.Collapsed;
                cmbFIOGrazh.Visibility = Visibility.Collapsed;
                cmbFIOIsp.Visibility = Visibility.Collapsed;
            }
            else if(cmbSelected.SelectedIndex == 2)
            {
                cmbStatus.Visibility=Visibility.Visible;

                cmbVid_Yslg.Visibility = Visibility.Collapsed;
                spDate.Visibility = Visibility.Collapsed;
                cmbFIOGrazh.Visibility = Visibility.Collapsed;
                cmbFIOIsp.Visibility = Visibility.Collapsed;
            }
            else if (cmbSelected.SelectedIndex == 3)
            {
                cmbFIOGrazh.Visibility = Visibility.Visible;

                cmbVid_Yslg.Visibility = Visibility.Collapsed;
                cmbStatus.Visibility = Visibility.Collapsed;
                spDate.Visibility = Visibility.Collapsed;
                cmbFIOIsp.Visibility = Visibility.Collapsed;
            }
            else if (cmbSelected.SelectedIndex == 4)
            {
                cmbFIOIsp.Visibility = Visibility.Visible;

                cmbVid_Yslg.Visibility = Visibility.Collapsed;
                cmbStatus.Visibility = Visibility.Collapsed;
                cmbFIOGrazh.Visibility = Visibility.Collapsed;
                spDate.Visibility = Visibility.Collapsed;
            }
        }

        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedStatus = Convert.ToInt32(cmbStatus.SelectedValue);
            txbSum.Text = "Сумма: " + ConnectHelper.entObj.Заказ.Where(x => x.Код_Статуса == selectedStatus).Sum(x => x.Сумма) + " ₽";
            GridList.ItemsSource = ConnectHelper.entObj.Заказ.Where(x => x.Код_Статуса == selectedStatus).ToList();

        }

        private void cmbFIOGrazh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbFIOGrazh.SelectedIndex != -1)
            {
                GridList.ItemsSource = ConnectHelper.entObj.Заказ.Where(x => x.Код_заказчика == (int)cmbFIOGrazh.SelectedValue).ToList();
                txbSum.Text = "Сумма: " + ConnectHelper.entObj.Заказ.Where(x => x.Код_заказчика == (int)cmbFIOGrazh.SelectedValue).Sum(x => x.Сумма) + " ₽";
            }

        }

        private void cmbFIOIsp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFIOIsp.SelectedIndex != -1)
            {
                GridList.ItemsSource = ConnectHelper.entObj.Заказ.Where(x => x.Код_исполнителя == (int)cmbFIOIsp.SelectedValue).ToList();
                txbSum.Text = "Сумма: " + ConnectHelper.entObj.Заказ.Where(x => x.Код_исполнителя == (int)cmbFIOIsp.SelectedValue).Sum(x => x.Сумма) + " ₽";
            }
        }

        private void dpStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpStart.SelectedDate != null)
            {
                GridList.ItemsSource = ConnectHelper.entObj.Заказ.Where(x => x.Дата >= dpStart.SelectedDate).ToList();
                dpEnd.Visibility = Visibility.Visible;
                txbSum.Text = "Сумма: " + ConnectHelper.entObj.Заказ.Where(x => x.Дата >= dpStart.SelectedDate).Sum(x => x.Сумма) + " ₽";
            }
                
        }

        private void dpEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            GridList.ItemsSource = ConnectHelper.entObj.Заказ.Where(x => x.Дата >= dpStart.SelectedDate && x.Дата <= dpEnd.SelectedDate).ToList();

            txbSum.Text = "Сумма: " + ConnectHelper.entObj.Заказ.Where(x => x.Дата >= dpStart.SelectedDate && x.Дата <= dpEnd.SelectedDate).Sum(x => x.Сумма) + " ₽";
        }

        private void GridList_Loaded(object sender, RoutedEventArgs e)
        {
            dgcmbStatus.DisplayMemberPath = "Наименование";
            dgcmbStatus.ItemsSource = ConnectHelper.entObj.Статус.ToList();

        }

        private void miCloase_Click(object sender, RoutedEventArgs e)
        {
            Заказ заказ = GridList.SelectedItem as Заказ;
            if (заказ == null)
                MessageBox.Show("Элемент не выбран!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (заказ.Код_Статуса == 3)
                MessageBox.Show("Данный заказ уже закрыт!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                IdZak = заказ.Код_Заказа;
                WindowsCloseZayavka windowsCloseZayavka = new WindowsCloseZayavka();
                windowsCloseZayavka.ShowDialog();
                GridList.ItemsSource = ConnectHelper.entObj.Заказ.ToList();
                txbSum.Text = "Сумма: " + ConnectHelper.entObj.Заказ.Sum(x => x.Сумма) + " ₽";
            }
        }
        public static int GetZakk()
        {
            return IdZak;
        }

        private void btnDElete_Click(object sender, RoutedEventArgs e)
        {
            Заказ zakaz = GridList.SelectedItem as Заказ;
            if (zakaz == null)
                MessageBox.Show("Не выбранно поле для удаления", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                if (MessageBox.Show("Удалить эту запись ?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ConnectHelper.entObj.Заказ.Remove(zakaz);
                        ConnectHelper.entObj.SaveChanges();
                        MessageBox.Show("Запись удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                        GridList.ItemsSource = ConnectHelper.entObj.Заказ.ToList();
                        txbSum.Text = "Сумма: " + ConnectHelper.entObj.Заказ.Sum(x => x.Сумма) + " ₽";
                    }
                    catch
                    {
                        MessageBox.Show("Данная запись используется в другом месте. Прежде чем ее удалить удостоверьтесь что она нигде не используется!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }

        private void btnWord_Click(object sender, RoutedEventArgs e)
        {
            var wordApp = new Word.Application();
            wordApp.Visible = false;

            Заказ zak = GridList.SelectedItem as Заказ;
            if (zak == null)
                MessageBox.Show("Запись для печати не выбрана!", "Ошибка печати", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                var wordDocument = wordApp.Documents.Open(TemplateFileName);
                try
                {
                    ReplaceWordStud("{Nomer}", zak.Код_Заказа.ToString(), wordDocument);
                    ReplaceWordStud("{FIO zak}", zak.Заказчик.ФИО, wordDocument);
                    ReplaceWordStud("{Obekt zak}", zak.Заказчик.Объект, wordDocument);
                    ReplaceWordStud("{City}", zak.Заказчик.Город.Название, wordDocument);
                    ReplaceWordStud("{Street}", zak.Заказчик.Улица, wordDocument);
                    if(zak.Краткое_описание == null)
                        ReplaceWordStud("{OpisanZayavka}", zak.Вид_Услуги.Название, wordDocument);
                    else
                        ReplaceWordStud("{OpisanZayavka}", zak.Краткое_описание, wordDocument);
                    ReplaceWordStud("{rabota}", zak.Вид_Услуги.Название, wordDocument);

                    ReplaceWordStud("{nomer}", zak.Используемое_Оборудование.Код_Оборудования.ToString(), wordDocument);
                    ReplaceWordStud("{NameOboryd}", zak.Используемое_Оборудование.Наименование, wordDocument);
                    ReplaceWordStud("{Count}", zak.КолВо_Оборудования.ToString(), wordDocument);
                    ReplaceWordStud("{Date}", DateTime.Now.ToString("D"), wordDocument);

                    wordDocument.SaveAs2(Directory.GetCurrentDirectory() + @"\Договор.docx");
                    wordApp.Visible = true;
                }
                catch
                {
                    wordDocument.Close();
                    MessageBox.Show("Произошла ошибка при добавлении!");
                }
            }
        }
        private void ReplaceWordStud(string studToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: studToReplace, ReplaceWith: text);
        }

        private void GridList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConnectHelper.entObj.SaveChanges();
        }
    }
}
