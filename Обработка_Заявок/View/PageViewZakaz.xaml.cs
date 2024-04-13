using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;
using Обработка_Заявок.Add;
using Обработка_Заявок.DataFiles;
using System;
using Excel = Microsoft.Office.Interop.Excel;



namespace Обработка_Заявок.View
{
    /// <summary>
    /// Логика взаимодействия для PageViewZakaz.xaml
    /// </summary>
    public partial class PageViewZakaz : Page
    {
        string TemplateFileName = Directory.GetCurrentDirectory() + @"\Макет_договора.docx";
        private static Заказчик Zak;
        public PageViewZakaz(Заказчик zak)
        {
            InitializeComponent();
            Zak = zak;

            cmbVid_Yslg.SelectedValuePath = "Код_Услуги";
            cmbVid_Yslg.DisplayMemberPath = "Название";
            cmbVid_Yslg.ItemsSource = ConnectHelper.entObj.Вид_Услуги.ToList();

            txbSum.Text = "Сумма: " + ConnectHelper.entObj.Заказ.Where(x => x.Код_заказчика == Zak.Код_Заказчика).Sum(x => x.Сумма) + " ₽";
            GridList.ItemsSource = ConnectHelper.entObj.Заказ.Where(x => x.Код_заказчика == zak.Код_Заказчика).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddZakaz());
        }

        private void btnExportToWord_Click(object sender, RoutedEventArgs e)
        {
            Заказ заказ = GridList.SelectedItem as Заказ;
            if (заказ == null)
                MessageBox.Show("Заказ не выбран!", "Ошибка печати", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                var wordApp = new Word.Application();
                wordApp.Visible = false;
                var wordDocument = wordApp.Documents.Open(TemplateFileName);
                try
                {
                    ReplaceWordStud("{Nomer}", заказ.Код_Заказа.ToString(), wordDocument);
                    ReplaceWordStud("{FIO zak}", заказ.Заказчик.ФИО.ToString(), wordDocument);
                    ReplaceWordStud("{Obekt zak}", заказ.Заказчик.Объект.ToString(), wordDocument);
                    ReplaceWordStud("{City}", заказ.Заказчик.Город.Название.ToString(), wordDocument);
                    ReplaceWordStud("{Street}", заказ.Заказчик.Улица.ToString(), wordDocument);
                    if (заказ.Краткое_описание == null)
                        ReplaceWordStud("{OpisanZayavka}", заказ.Вид_Услуги.Название.ToString(), wordDocument);
                    else 
                       ReplaceWordStud("{OpisanZayavka}", заказ.Краткое_описание.ToString(), wordDocument);
                    ReplaceWordStud("{rabota}", заказ.Вид_Услуги.Название.ToString(), wordDocument);

                    ReplaceWordStud("{nomer}", заказ.Код_оборудования.ToString(), wordDocument);
                    ReplaceWordStud("{NameOboryd}", заказ.Используемое_Оборудование.Наименование.ToString(), wordDocument);
                    ReplaceWordStud("{Count}", заказ.КолВо_Оборудования.ToString(), wordDocument);
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

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            var application = new Excel.Application();
            application.SheetsInNewWorkbook = 1;
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = application.Worksheets[1];
            try
            {
                worksheet.Name = "Заказы";
                Excel.Range table = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[11][ConnectHelper.entObj.Заказ.Where(x => x.Код_заказчика == Zak.Код_Заказчика).Count() + 1]];
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
                foreach (var zak in ConnectHelper.entObj.Заказ.Where(x => x.Код_заказчика == Zak.Код_Заказчика))
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

                    if (zak.СерийныйНомер == null)
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

        private void btnViewAll_Click(object sender, RoutedEventArgs e)
        {
            GridList.ItemsSource = ConnectHelper.entObj.Заказ.Where(x => x.Код_заказчика == Zak.Код_Заказчика).ToList();
            txbSum.Text = "Сумма: " + ConnectHelper.entObj.Заказ.Where(x => x.Код_заказчика == Zak.Код_Заказчика).Sum(x => x.Сумма) + " ₽";

        }

        private void cmbVid_Yslg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = (int)cmbVid_Yslg.SelectedValue;
            txbSum.Text = "Сумма: " + ConnectHelper.entObj.Заказ.Where(x => x.Код_Услуги == selected && x.Код_заказчика == Zak.Код_Заказчика).Sum(x => x.Сумма) + " ₽";
            GridList.ItemsSource = ConnectHelper.entObj.Заказ.Where(x => x.Код_заказчика == Zak.Код_Заказчика && x.Код_Услуги == selected).ToList();
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
                        txbSum.Text = "Сумма: " + ConnectHelper.entObj.Заказ.Sum(x => x.Сумма);
                    }
                    catch
                    {
                        MessageBox.Show("Данная запись используется в другом месте. Прежде чем ее удалить удостоверьтесь что она нигде не используется!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }
    }
}
