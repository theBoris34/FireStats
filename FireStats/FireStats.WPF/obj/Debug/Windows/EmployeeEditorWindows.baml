   M S B A M L   `   `   `  ����H  DFireStats.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FireStats.WPF.WindowsFireStats.WPF.Windows  5   	   ]3clr-namespace:FireStats.WPF.Infrastructure.Commands%FireStats.WPF.Infrastructure.Commands  6;   1    +FireStats.WPF.Windows.EmployeeEditorWindows   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:FireStats.WPF.Windows     5   	   Hcommands3clr-namespace:FireStats.WPF.Infrastructure.Commands     6;   $	��330��5   	   $	��450��6     � 
ResizeMode$  NoResize=�5
   	    � ShowInTaskbar .   � DataContext 5	   	   ��  �� RelativeSource �� *Self+.��5      �  � RowDefinitions 5   
   �� 5      $��34 �6   �� 5      �� 5      $��40 �6   .+�5   
   �� $7��1Редактирование сотрудника��6   $��0��65   $��Center=�6B   $��Center=�5      ���	#FF9CCAFF$��25(�5       �� TextAlignment$ Center=�6"   $
��Auto��5      $��DemiBold"�6!   $��34��68   � 5   
   $��1��6   $��10q�6    � 	Resources 5       �� 
TargetType �� Triggers	 P� Property
 P� Value �� Property �� Value��%\  '��       '�� �     �� 5      " ��6    5      P� 5      	 � ��$
 0��69   . �5      ��  � ��$ Right=�6D   �� 5       � ��$ Center=�6B   �� 5       � ��$ 0,0,2,0q�67   �� 5       � ��$
 Bold"�6;   5       5"      �� 5#      " ��6   .�5$      ��  � ��$ 3,3,0,3q�6/   5%      5&       � ColumnDefinitions 5'      �� 5(      $
��Auto �6#   �� 5)       5+      �� 5,      $
��Auto �6    �� 5-      $
��Auto �6    �� 5.      $
��Auto �6    �� 5/      $
��Auto �6    �� 50      $
��Auto �6    �� 51      $
��Auto �6    �� 52      $
��Auto �6    .+�54      �� $��0��6   $��0��6(   $��Фамилия: ��65   �� 55      $��0��6   $��1��6(   $��Имя: ��65   �� 56      $��0��6   $��2��6(   $��Отчество: ��65   �� 57      $��0��6   $��3��6(   $!��Дата рождения: ��65   �� 58      $��0��6   $��4��6(   $��Должность: ��65   �� 59      $��0��6   $��5��6(   $��Звание: ��65   �� 5:      $��0��6   $��6��6(   $��Примечание: ��65   �� 5<      $��1��6   $��0��6&   ��63   �� *	SurName+�� 5=      $��1��6   $��1��6&   ��63   �� *	FirstName+�� 5>      $��1��6   $��2��6&   ��63   �� *
Patronymic+(  "System.Windows.Controls.DatePicker  5?      $��1��6   $��3��6)   $��3,0,0,2q�66      SelectedDate 6G   �� *
Birthday+�� 5@      $��1��6   $��4��6&   ��63   �� *
Position+�� 5A      $��1��6   $��5��6&   ��63   �� *Rank+�� 5B      $��1��6   $��6��6&   ��63   �� *Note+5D      A� 5E   
    A� Rows$ 1��6   $��Center=�5F      $��Center=�5G      $��2��5H      $��30��5I      $	��200��5J      .+�5K      �� $��Ok��6   $��5q�6"    �� 	IsDefault . ��5L      ��  ��  �� AncestorType$! local:EmployeeEditorWindowsL���5M      >  8FireStats.WPF.Infrastructure.Commands.CloseDialogCommand  5N         DialogResult$
 TrueX�62   5P      �� 5Q      $��Отмена��6   $��5q�6&    �� IsCancel . ��5R      ��  �� $! local:EmployeeEditorWindowsL���5S        5T      $ FalseX�62   5V      5W      5X      5Y      