   M S B A M L   `   `   `  ����H  DFireStats.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FireStats.WPF.PagesFireStats.WPF.Pages  5      C&clr-namespace:FireStats.WPF.ViewModelsFireStats.WPF.ViewModels  5      ]3clr-namespace:FireStats.WPF.Infrastructure.Commands%FireStats.WPF.Infrastructure.Commands  5      S.clr-namespace:FireStats.WPF.Models.Departments FireStats.WPF.Models.Departments  5	      *    $FireStats.WPF.Pages.EmployeeListPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:FireStats.WPF.Pages     5      5vm&clr-namespace:FireStats.WPF.ViewModels     5      Ccmd3clr-namespace:FireStats.WPF.Infrastructure.Commands     5      Fdepartments.clr-namespace:FireStats.WPF.Models.Departments     5	      M IFontAwesome.Sharp, Version=5.14.0.0, Culture=neutral, PublicKeyToken=nullFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5
        N� Title$  EmployeeListPage��5       � DataContext 5      �� *EmployeeListPage+   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $
��364* �6   �� 5      $��60 �6   .+�5   
   �� $0��*СПИСОК ЛИЧНОГО СОСТАВА��6   $��0��62   $��Center=�6?   $��Center=�5      ���	#FF9CCAFF$��25(�5       �� TextAlignment$ Center=�6"   $	��383��5      $��DemiBold"�6    $��106,0,111,0q�66   $��33��6K   � 5   
   $��1��6    5      �� 5      $
��150* �6    �� 5      $
��214* �6    .+�5       � $��0��6    5!      �� 5"      �� 5#      $��30 �6$   .+�5%      �� $ ��Подразделение��6   $��0��6.   .��5&      ]�  � 	Resources 5'        DivisionsCollection �� Source��%O   &	       �� 5(      -   5         5*   3   �� *	Divisions+5+   3   5,      .+�5-      ]� $	��Top=�6$   $��0,0,0,3q�69   .+�5.      !  FontAwesome.Sharp.IconImage  $��12��6+   �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=5.14.0.0, Culture=neutral, PublicKeyToken=null]]   Icon$ Search=�67   $	��3,0q�6E   �� 5/      -   5         ��Name$ DivisionFilter��5/   &   6k   50      ]� 51      $��Bottom=�6$   .+�52      �� 	 �� DisplayMemberPath$
	 Name��6j   
 �� SelectedIndex$
 0��53   P   ��52   &   �� # [  �� SelectedItem 53   &   �� *SelectedDivision+6P   54      56      57      �� 58      $��1��6    �� Orientation$ 
Horizontal=�6*   $��25��6C   $	��6,0q�6O   $��Center=�6\   $��Bottom=�6y   .+�59      �� $
��10,0q�6   ��6+   �� *CreateDivisionCommand+.��5:      �� $ 
Horizontal=�6%   .+�5;        $ Check=�6+   $	��5,0q�68   $��12��6E      
Foreground
 � d �6Q   �� 5<      $1��+Добавить подразделение��6(   $��0,0,10,0q�6F   5=      5>      �� 5?      $
��10,0q�6   ��6+   �� *DeleteDivisionCommand+��6U   �� *SelectedDivision+.��5@      �� $ 
Horizontal=�6%   .+�5A        $ Times=�6+   $	��5,0q�68   $��12��6E   
 �  ��6Q   �� 5B      $/��)Удалить подразделение��6(   $��0,0,10,0q�6E   5C      5D      5E      5F      �� 5I      $��1��6�   ��6   �� *SelectedDivision.Name+ �� FallbackValue$ Личный состав�� �� TargetNullValue$4 .Подразделение не выбрано��.��5J      ]� .+�5K      ]� $	��Top=�6    $��0,0,0,3q�65   .+�5L        $��12��6'   $ Search=�63   $	��3,0q�6A   �� 5M      -   5        $ EmployeeFilter��5M   "   ��5N   "   �� *EmployesFilterText+ �� UpdateSourceTrigger$ PropertyChanged=�5O      &   System.Windows.Controls.DataGrid  5P         AutoGenerateColumns .     GridLinesVisibility$ Vertical=�5S         CanUserAddRows .     VerticalGridLinesBrush
 �����   AlternatingRowBackground
 ��ح���5P      �� *SelecedDivisionEmployees+ 5Q      �� *SelectedEmployee+ �� 
GroupStyle 5W      (  "System.Windows.Controls.GroupStyle  5X         Columns 5Z      0  *System.Windows.Controls.DataGridTextColumn  5[      ,  &System.Windows.Controls.DataGridColumn   Header$ Звание��6-      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Rank+6V     5\      $ Фамилия��6-    .  6>   �� *	Surname+6Z     5]      $ Имя��6-    .  6:   �� *Name+6S     5^      $ Отчество��6-    .  6?   �� *
Patronymic+6^   4  .System.Windows.Controls.DataGridTemplateColumn  5_      $ Дата рождения��61    .     CellTemplate 5`      �� 5a   "    �� DataType$ department:Employee��6/   .R�5b   &   �� ��60   �� *
Birthday+ �� StringFormat$ 
dd.MM.yyyy��5c   #      CellEditingTemplate 5e      �� 5f   &   $ department:Employee��63   .R�5g   *   (	  "System.Windows.Controls.DatePicker	   	  SelectedDate 66   �� *
Birthday+5h   '   5j        5k      $ Должность��6-    .  6@   �� *
Position+6]     5l      $ Примечание��6-       Width5
  /System.Windows.Controls.DataGridLengthConverter$  *
 6Z    .   6A   �� *Note+6d   5o      5q      5r      5s      � 5t   
   $��2��6   $��30��6   .+�5u      �� $ 
Horizontal=�6   $��25��62   $	��6,0q�6>   $��Center=�6K   .+�5w      �� $
��10,0q�6   ��6'   �� *CreateEmployeeCommand+.��5x      �� $ 
Horizontal=�6!   .+�5y        $ Check=�6'   $	��5,0q�64   $��12��6A   
 � d �6M   �� 5z      $+��%Добавить сотрудника��6$   $��0,0,10,0q�6?   5{      5|      �� 5}      $
��10,0q�6   ��6'   �� *DeleteEmployeeCommand+��6Q   �� *SelectedEmployee+.��5~      �� $ 
Horizontal=�6"   .+�5        $ Times=�6'   $	��5,0q�64   $��12��6A   
 �  ��6M   �� 5�      $)��#Удалить сотрудника��6$   $��0,0,10,0q�6>   5�      5�      �� 5�      $
��10,0q�6   ��5�      A  ;FireStats.WPF.Infrastructure.Commands.ManageEmployeeCommand  5�      .��5�      �� $ 
Horizontal=�6!   .+�5�        $ 	PencilAlt=�6'   $	��5,0q�68   $��12��6E   
 �   �6Q   �� 5�      $3��-Управление сотрудниками��6$   $��0,0,10,0q�6C   5�      5�      5�      5�      5�      5�      