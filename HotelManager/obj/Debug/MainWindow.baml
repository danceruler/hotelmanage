   M S B A M L   `   `   `  ����D  @Panuon.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Panuon.UI;assembly=Panuon.UI	Panuon.UI  5   	   G CHotelManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HotelManagerHotelManager 5   	      HotelManager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =panuon*clr-namespace:Panuon.UI;assembly=Panuon.UI     5   	   ,localclr-namespace:HotelManager     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
      Panuon.UI.PUButton  -   5        $��ToLogin��5      6>     5   
   -   5        $��1��5      $��0��6*   $��
ToMainMenu��67   6a     5   
   -   5        $��2��5      $��0��6*   $
��Test��67   6]     5   
   -   5        $��0��5      $��1��6*   $��	ToAddRoom��67   6_     5   
   -   5        $��1��5      $��1��6*   $��ToEditRoomType��67   6i     5   
   -   5        $��0��5      $��2��6*   $��
ToOpenRoom��67   6a     5   
   -   5        $��1��5      $��2��6*   $��ToDataPicker��67   6e   �� 5   
   -   5        $��testcombobox��5      $��2��6'   $��1��67   $	��100��6D   $��Center=�6P   $��Center=�6m   ��5      �� 5       �� Triggers 5      P� 5        P� Property �@J�IsMouseOver P� Value . . �5!      ��  �� Property � �� �� Value
 � � �6B   5"      5$      .@�5'      �� .��5(      �� $��Cashier��6   
���� ��6+   5)      �� 5*      
���  ��.��5+      �� $��Manager��6   5,      5-        5.   
   -	   5        $��2��5.      $��2��6*   $��ToTableWindow��67   6g   5/      50      