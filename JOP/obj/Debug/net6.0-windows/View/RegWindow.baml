   M S B A M L   `   `   `  ����>  :JOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:JOPJOP  5   	       JOP.RegWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:JOP     5   	     � Title$  	RegWindow��5   	   $	��350��6   $	��320��6(   .��5	      � 
����  � � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� $��Username��6   $��10q�6#   
�������$��0��6B   �� 5   
   -   5        $��Username_textbox��5   *   $��10q�6   $��24��6   $��0��6B   $��1��6O   
���������6r   �� *Login+�� 5   
   $��Password(1)��6   $��10q�6&   
�������$��1��6E   �� 5   
   -   5        $��Password1_textbox��5   *   $��10q�6   $��24��6   $�� 1��6D   $��1��6S   
���������6w   �� *
Password_1+�� 5   
   $��Password(2)��6   $��10q�6&   
�������$��2��6E   �� 5   
   -   5        $��Password2_textbox��5   *   $��10q�6   $��24��6   $�� 2��6C   $��1��6R   
���������6u   �� *
Password_2+�� 5!   
   $��	Firstname��6   $��10q�6$   
�������$��3��6C   �� 5"   
   -   5        $��Name_textbox��5"   *   $��10q�6   $��24��6   $�� 3��6>   $��1��6M   
���������6p   �� *Name+�� 5$   
   $��Lastname��6   $��10q�6#   
�������$��4��6B   �� 5%   
   -   5        $��Surname_textbox��5%   *   $��10q�6   $��24��6   $�� 4��6A   $��1��6P   
���������6s   �� *	Surname+�� 5'   
   $��Email��6   $��10q�6    
�������$��5��6?   �� 5(   
   $��10q�6   $��24��6   $�� 5��6*   $��1��69   
���������6\   �� *Email+�� 5*   
   -   5         ��Name$ 
Reg_Button��5*      $��Register��6%   $��10q�68   $��6��6E   $��1��6R   ��6b   �� *RegButtonColor+��6�   �� *RegUserCommand+�� 5+   
   -   5        $ Cancel_Button��5+      $��Cancel��6(   $��10q�69   $��6��6F   $��0��6S   ��6c   �� *CancelButtonColor+��6�   �� *CancelCommand+5,      5-      