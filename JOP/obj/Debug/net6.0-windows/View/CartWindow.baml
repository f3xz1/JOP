   M S B A M L   `   `   `  ����>  :JOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:JOP.ViewJOP.View  5   	       JOP.View.CartWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:JOP.View     5   	     � Title$  
CartWindow��5   	   $	��450��6   $	��600��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��8* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��Finish Shoping��6   $��1��6*   $��1��6:   �� 5   
   $��Cancel��6   $��0��6"   $��1��62   �� 5   
   -   5        $��MyList��5   *   
������� �� View 5      �� 5      .P�5      ��  �� CellTemplate 5      �� 5      .R�5   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5   &   �� �� 5   &   5   #   5      5       �� 5!      $��
Is in cart��6%    �� Width$ 50��69   �� 5"      $��Product name��6%   $ 80��6;   5#      5%      5&      5'      