   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	   = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5   	       PLWPF.AddContractWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	   +BEclr-namespace:BE;assembly=BE     5   	     � Title$  AddContractWindow��5
   	   $	��350��6#   $	��525��60   $��20(�6<   .��5      �� $
��Auto=�6   .��5   	   � -   5         �Name$ grid1��5      $��3q�6    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6'   .+�5!      �� $��0��6   $��3q�6&   $��0��61   $��
Mother ID:��6A   �� 5"      -   5         ��Name$ motherIDComboBox��5"      $��1��66   $��3q�6F   $��0��6Q   ��6�   �� *
MotherID+�� 5#      $��1��6   $��3q�6&   $��0��61   $��	Child ID:��6A   �� 5$      -   5        $ childIDComboBox��5$      $��1��65   $��3q�6E   $��1��6P   ��6�   �� *	childID+�� 5%      $��2��6   $��3q�6&   $��0��61   $��	Nunny ID:��6A   �� 5&      -   5        $ nunnyIDComboBox��5&      $��2��6�   $��3q�6�   $��1��6�   ��6j   �� *	NunnyID+6�   �� 5'      $��3��6   $��3q�6&   $��0��61   $��Date Start:��6A   (  "System.Windows.Controls.DatePicker  5(      -   5          Name$ dateStartDatePicker��5(      $��3��6v   $��3q�6�   $��1��6�      SelectedDate 6<   �� *	DateStart+ �� Mode$ OneWayToSource=�6�   �� 5)      $��4��6   $��3q�6&   $��0��61   $��	Date End:��6A     5*      -   5        $ dateEndDatePicker��5*      $��4��6p   $��3q�6}   $��1��6�    68   �� *	DateEnd+$ OneWayToSource=�6�   �� 5+      $��5��6   $��3q�6&   $��0��61   $��Hours Of Contract Month:��6A   �� 5,      -   5         ��Name$! hoursOfContractMonthTextBox��5,      $��5��6�   $��3q�6�   $��1��6�   ��6j   �� *HoursOfContractMonth+$ TwoWay=�	 �� NotifyOnValidationError	 . 
 �� ValidatesOnExceptions
 . 6�   �� 5-      $��6��6   $��3q�6&   $��0��61   $��Is Contract:��6A   �� 5.      -   5         ��Name$ isContractCheckBox��5.      $��Center=�67   $��6��6R   $��3q�6_   $��1��6�   $�� ��6�    d� 	IsChecked 6j   �� *
IsContract+$ TwoWay=�	 . 
 . 6�   �� 5/      $��7��6   $��3q�6&   $��0��61   $��Is Interview:��6A   �� 50      -	   5        $ isInterviewCheckBox��50      $��Center=�68   $��7��6S   $��3q�6`   $��1��6�   $�� ��6�    6k   �� *IsInterview+$ OneWay=�	 . 
 . 6�   �� 51      $��8��6   $��3q�6&   $��0��61   $��Is Morechilds:��6A   �� 52      -
   5        $ isMorechildsCheckBox��52      $��8��6:   $��3q�6G   $��1��6�   $�� ��6�    6R   �� *IsMorechilds+$ TwoWay=�	 . 
 . 6�   �� 53      $��9��6   $��3q�6&   $��0��61   $��Number Of Contract:��6A   �� 54      -   5        $ numberOfContractTextBox��54       �� 
IsReadOnly . $��9��6�   $��3q�6�   $��1��6�   ��6x   �� *NumberOfContract+$ OneWay=�	 . 
 . 6�   �� 59      -   5         ��Name$ AddContract��59      $	��Add��6*   $��3q�69   $��12��6D   $��2��6R   ��5:      �� 5;      enableButton�� �� Triggers 5<      �� 5=       �� Binding 6*   ��  �� ElementName$ motherIDComboBox�� �� Path$
 Text� �� Value  6f   .a�5>   "   ��  �� Property � {� �� Value .  6E   5?      �� 5@       6*   �� $ childIDComboBox��$
 Text�  6e   .a�5A   "   ��  � {� .  6E   5B      �� 5C       6*   �� $ nunnyIDComboBox��$
 Text�  6e   .a�5D   "   ��  � {� .  6E   5E      �� 5F       6*   �� $ dateStartDatePicker��$
 Text�  6i   .a�5G   "   ��  � {� .  6E   5H      �� 5I       6*   �� $ dateEndDatePicker��$
 Text�  6g   .a�5J   "   ��  � {� .  6E   5K      �� 5L       6*   �� $! hoursOfContractMonthTextBox��$
 Text�  6q   .a�5M   "   ��  � {� .  6E   5N      �� 5O       6*   �� $ numberOfContractTextBox��$
 Text�  6m   .a�5P   "   ��  � {� .  6E   5Q      �� 5R       6*   �� $ rateforHourTextBox��$
 Text�  6h   .a�5S   "   ��  � {� .  6E   5T      5V      5X      5Y      5Z      5[      