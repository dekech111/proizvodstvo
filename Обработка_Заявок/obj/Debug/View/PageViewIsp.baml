   M S B A M L   `   `   `  ����Z  VОбработка_Заявок, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Обработка_Заявок.View$Обработка_Заявок.View  5      6    0Обработка_Заявок.View.PageViewIsp   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:Обработка_Заявок.View     5        N� Title$/  )Просмотр Исполнителей��5	      .��5      � .+�5   
   �� -   5         ��Name$ BtnBack��5      $��
Назад��5      $��80��5      $��25��5      $��5q�5      
������ 
������ $	��Top=�5      $��Right=�5      $��16(�5      6   �� 5   
   $��Center=�6   $��Center=�62   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5      .+�5      �� $��Вывор услуги: ��6   �� 5      -   5         ��Name$ cmbCity��5      $	��200��5      $��22��5       �� 
IsEditable . 5   -   �� 5      -   5        $ 
btnViewAll��5      $��Показать все��5       $	��100��5!      $��15 0 0 0q�5"      6+   5#      &   System.Windows.Controls.DataGrid  5$      -   5          Name$ GridList��5%      $	��220��5&      "   VerticalScrollBarVisibility$
 Auto=�5'         AutoGenerateColumns .     
IsReadOnly . $��16(�5)   #   	   Columns	 5,      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 5/         Header$ ФИО��51      1  +System.Windows.Controls.DataGridBoundColumn   Binding 50      �� *ФИО+51        53      $
 * 54      $! Номер телефона��56       55      �� *Телефон+56        58      $
 * 59      $ Дата Рождения��5;       5:      �� *Дата_Рождения+ �� StringFormat$ {0:dd.}{0:MM.}{0:yyyy}��5;        5=      $
 * 5>      $# Название города��5@       5?      �� *Город.Название+5@        5B      $
 * 5C      $ 
Улица��5E       5D      �� *
Улица+5E      5H      �� 5I      $ 
Horizontal=�6   $��Right=�5J      $��	0 10 10 0q�5K      .+�5L      �� -   5        $ btnRem��5L      $��Right=�5M      $��Удалить��5N      $	��141��5O      $��32��5P      $��16(�5Q      5R      �� 5T      -   5        $ btnAdd��5T      $��Right=�5U      $��Добавить��5V      $	��141��5W      $��32��5X      $��16(�5Y      $��15 0 0 0q�5[      �� 5^      -   5        $ btnExcel��5^      $��Right=�5_      $!��Сохранить в Excel��5`      $	��141��5a      $��32��5b      $��16(�5c      $��15 0 0 0q�5d      6#   5e      5f      5g      5h      