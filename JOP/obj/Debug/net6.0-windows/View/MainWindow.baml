   M S B A M L   `   `   `  ����>  :JOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:JOPJOP  5   	   -clr-namespace:JOP.ViewModelJOP.ViewModel  5   	       JOP.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:JOP     5   	   *VMclr-namespace:JOP.ViewModel     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5      � 
����  � � RowDefinitions 5   
   �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   � $��1��6   $��1��6    5      �� 5      �� 5      �� 5      .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Login��6   $��14(�6(   $��10 10 12 10q�66   
�������6K   �� 5      -   5        $��Login_textbox��5   .   $��
0 10 10 10q�6   $	��190��6C   
���������6b   �� *Login+5       �� 5!      $ 
Horizontal=�6   $��1��62   .+�5"      �� $��Password��6   $��14(�6+   $��	0 10 0 10q�69   
�������6L   �� 5#      $��1��6   $��2��6'   $��
0 10 10 10q�6;   $	��190��6P   
���������6o   �� *
Password+5%      � 5&      $��2��6    5'      �� 5(      �� 5)      .+�5+      �� -   5        $��
Reg_button��5+      $��2��6+   $��7q�68   $��Register��6C   $	��120��6W   ��6c   �� *
RegCommand+�� 5,      -   5        $��
Log_button��5,      $��2��6+   $��2��68   $��7q�6H   $��Login��6S   $	��120��6d   ��6p   �� *LoginCommand+5-      5.      �� 5/   
   -   5        $��
wrong_info��5/      $@��:Неверно введен логин или пароль��6"   
���  ��$��1��6]   $��Bottom=�6m   $��Center=�6�   y�6�   �� *Wrong_label_visable+50      51      