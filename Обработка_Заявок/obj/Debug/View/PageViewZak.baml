   M S B A M L   `   `   `  ����Z  VОбработка_Заявок, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Обработка_Заявок.View$Обработка_Заявок.View  5      6    0Обработка_Заявок.View.PageViewZak   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:Обработка_Заявок.View     5        N� Title$+  %Просмотр заказчиков��5	      .��5      � .+�5   
   �� -   5         ��Name$ BtnBack��5      $��
Назад��5      $��80��5      $��25��5      $��5q�5      
������ 
������ $	��Top=�5      $��Right=�5      $��16(�5      6   �� 5   
   $��Center=�6   $��Center=�62   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ GridList��5      $	��220��5      "   VerticalScrollBarVisibility$
 Auto=�5         AutoGenerateColumns .     
IsReadOnly . $��16(�5   #      Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5#         Header$ Фио��5%      1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5$      �� *ФИО+5%        5'      $ * 5(      $! Номер Телефона��5*      	 5)      �� *Телефон+5*        5,      $ * 5-      $ Объект��5/      	 5.      �� *Объект+5/        51      $ * 52      $ 
Город��54      	 53      �� *Город.Название+54        56      $ * 57      $ 
Улица��59      	 58      �� *
Улица+59      4  .System.Windows.Controls.DataGridTemplateColumn  5;      $ * 5<      
   CellTemplate
 5=      �� 5>      .R�5?   "   �� $ 
BtnProfile��5A   %   -   5        $	��100��5@   %   $��Подробнее��5C   %   5D      5F      5I      5J      5K      5L      