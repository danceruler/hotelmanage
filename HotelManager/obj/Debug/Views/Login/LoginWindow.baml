   M S B A M L   `   `   `  ����D  @Panuon.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Panuon.UI;assembly=Panuon.UI	Panuon.UI  5   	   G CHotelManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HotelManager.ViewsHotelManager.Views 5   	   *   $HotelManager.Views.Login.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =panuon*clr-namespace:Panuon.UI;assembly=Panuon.UI     5   	   2local clr-namespace:HotelManager.Views     5   	     � Title$  LoginWindow��5	   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6   
������ .��5      ��  �� CornerRadius$ 15,15,15,15��6   ��5   
   �� 5       �� ImageSource$0 *pack://application:,,,/AppData/testbg5.jpg��6   ._�5   
   ]� .+�5      �  � RowDefinitions 5      �� 5      $��50 �6$   �� 5      $��* �6$   .+�5      �� -   5        $��titlebar��5   \   $ 	15,15,0,0��6   $
��auto��64   $
��auto��6A   $��0��6O    J� Opacity$	 0.9Q�6l   ._�5      ]� .+�5      �� -   5        $��	TitleText��5   !   $
��Left=�62   $��Center=�6N   $��30,0,0,0q�6i   $��管理员登录��6{   $
��auto��6�   
���   �6�   � 5      -   5        $��closeicongrid��5      $��Right=�64   $��Center=�6P   $��50��6k   $��50��6v   .+�5      �� -   5        $��	closeicon��5   $   $*��$/AppData/icon/black_exit_favicon.ico��65   $��30��6c   $��30��6o    J� RenderTransformOrigin$ 0.5,0.5&�6z   6�   5      5      5      � 5       $��1��6    5"      �� 5#      $��* �6(   �� 5$      $	��200 �6(   �� 5%      $��* �6(    � ColumnDefinitions 5'      �� 5(      $��* �6+   �� 5)      $	��200 �6+   �� 5*      $��* �6+   .+�5,      � $��1��6   $��1��6+   .+�5-      �  5.      �� 5/   "   $��* �60   �� 50   "   $��* �60   �� 51   "   $��* �60    53      �� 54   "   $��50 �63   �� 55   "   $��* �63   .+�57      �� $(��"/AppData/icon/username_favicon.ico��6$   $��30��6Q   $��30��6\   6j   �� 58      $(��"/AppData/icon/password_favicon.ico��6$   $��30��6Q   $��30��6\   $��0��6h   $��1��6x   6�      Panuon.UI.PUTextBox  59      -   5        $��UserName��59   /   $��1��6?   $��0��6O   $��40��6\   $	��140��6h   $��0,5,10,5q�6t   	   BorderCornerRadius$	 5��6�   
   	Watermark$
 	用户名��6�   6�      Panuon.UI.PUPasswordBox  5:      -   5        $��Password��5:   3   $��1��6C   $��1��6S   $��40��6`   $	��140��6l   $��0,5,10,5q�6x      BorderCornerRadius$ 5��6�      	Watermark$ 密码��6�   6�      Panuon.UI.PUButton  5;      $��2��6T   $��2��6h   $	��120��6u   $��40��6�      BorderCornerRadius$ 10��6�      
ClickStyle$
 Sink=�6�      ButtonStyle$ General=�6�   
�������   
CoverBrush
 �����$��登录��6�   
���   ���6.   ��  �� Path$ LoginCommand�6  5<      5=      5@      5A      5B      5C      5G      