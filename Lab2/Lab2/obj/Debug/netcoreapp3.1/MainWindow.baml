   M S B A M L   `   `   `  ����?  ;Lab2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab1Lab1  5   	       Lab2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Lab1     5   	     � Title$  
MainWindow��5   	   $	��440��6   $	��437��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��229* �6   �� 5      $
��234* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DATAS��5   8   $	��404��6   $	��Top=�6    $
��Left=�6G      AutoGenerateColumns$ False��6b   $	��408��6   $��2��6�      SelectionMode$ Single=�6      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Identifier��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *
Identifier+  5      $ Origin��6%   $	 100 65    6A   �� *Origin+  5      $ Destination��6%   $	 100 6:    6F   �� *Destination+  5      $ 
Passengers��6%   $	 100 69    6E   �� *
Passengers+5      5      5      