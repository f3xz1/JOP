   M S B A M L   `   `   `  ����>  :JOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:JOP.ViewJOP.View  5   	       JOP.View.Product_window   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:JOP.View     5   	     � Title$  Product window��5   	   $	��400��6    $	��500��6-    � 	Resources 5
       �� 
TargetType   ImageButtonStyle �� Property �� Value �� 
TargetType��%�   &	        �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� 5      5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5!   
   �� #��[  6   ��6;   �� *GetImageUrlCommand+.��5"      �� ��6   �� *Image+5#      � 5$   
   $��0��6   $��1��6    5&      �� 5'      �� 5(      $��3* �6#    5*      �� 5+      �� 5,      .+�5.      �� -   5         ��Name$ Product_Name_textblock��5.      $��0��68   $��0��6H   $��Name: ��6V   $��15(�6d   $��10q�6r   �� 5/      -   5        	 ��Name$	 Product_Name_textbox��5/      $��0��64   $��1��6A   $
��5 15q�6Q   {�6_   �� *NameTextboxEnabled+��6�   �� *Name+�� 50      $��0��6   $��1��6(   $��
Category: ��66   $
��12.5(�6H   $
��5 15q�6X   �� 51      $��1��6   $��1��6#   $
��5 15q�63   {�6A   �� *CategoryTextboxEnabled+��6n   �� *
Category+52      � 53   
   $��1��6   $��1��6    54      �� 55      �� 56      $��3* �6#    58      �� 59      �� 5:      .+�5<      �� -   5        $ Product_quality_textblock��5<      $��	quality: ��6;   $��10q�6L   $
��12.5(�6X   �� 5=      -   5        $��Product_quality_textbox��5=      $��0��65   $��1��6B   $
��5 10q�6R   {�6`   �� *QualityTextboxEnabled+��6�   �� *	Quality+�� 5>      -   5        $ Product_price_textblock��5>      $��price: ��69   $��1��6H   $��10q�6U   $
��13.5(�6a   �� 5?      -   5        $	 Product_price_textbox��5?      $��1��65   $��1��6B   $
��5 10q�6R   {�6`   �� *PriceTextboxEnabled+��6�   �� *Price+5@      �� 5A   
   -   5        $	 Product_description��5A      $��0��6/   $��2��6?   $��2��6L   $��15(�6�   $��5q�6�   {�6`   �� *DescriptionTextboxEnabled+��6�   �� *Description+�� 5B   
   -   5        
 ��Name$
 Button_Close��5B      $��Close��6'   $��3��67   $��50 30q�6D   ��6S   �� *CloseCommand+�� 5C   
   -	   5        $
 Button_Done��5C      $
��Done��6&   $��3��65   $��1��6B   $��50 30q�6R   ��6a   �� *DoneCommand+5D      5E      