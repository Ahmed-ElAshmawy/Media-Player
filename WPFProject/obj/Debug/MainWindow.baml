   M S B A M L   `   `   `  ����E  AWPFProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WPFProject
WPFProject  5   	       WPFProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WPFProject     5   	   -   5          �Name$  
Mainwindow��5   	    � Title$ 
MainWindow��5   	   $	��400��6   $	��525��6)    � Icon$ Images\icon.jpg��5	   	   ���	#FF004357 � TaskbarItemInfo 5
      *  $System.Windows.Shell.TaskbarItemInfo  5   
      ThumbButtonInfos 5      *  $System.Windows.Shell.ThumbButtonInfo     ImageSource$ Images/play-button.png��6"      Description$
 Play��5         DismissWhenClicked .     Command$
 Play��5      	   CommandTarget	 5      �� 
 �� ElementName$

 play��5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$
 Play��5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      $��5 �6   �� 5      $��* �6    � RowDefinitions 5!   
   �� 5"      $��40 �6   6*   �� 5#      $��* �6   6)   �� 5$      $��90 �6   6*   .+�5&   
   �� -   5         ��Name$ button��5&      $
��Open��6!   $
��Left=�60   $��	10,10,0,0q�6K   $	��Top=�6^   $��75��6v   ���	#FF1545976�   �� 5'   
   -   5         ��Name$ listBox��5'      $��2��6#   $
��Left=�63   $	��219��6N   $��5,10,0,0q�6[   $��1��6m   $	��Top=�6z   $	��197��6�   ��5(      �� 5)      5+      �� 5,   
   -   5        $
 play��5,      $�� ��6   $
��Left=�6*   $��
104,45,0,0q�6E   $��2��6Y   $	��Top=�6f   $��39��6~   $��35��6�   ��6�   Z� ��5-      �� 5.       �� ImageSource$ Images/play-button.png��6   50      �� 51   
   -   5        $
 fast��51      $�� ��6   $
��Left=�6*   $��
161,45,0,0q�6E   $��2��6Y   $	��Top=�6f   $��39��6~   $��35��6�   ��6�   Z� ��52      �� 53      $ Images/fast-forward.png��6   55      �� 56   
   -   5        $
 slow��56      $�� ��6   $
��Left=�6*   $��	46,45,0,0q�6E   $��2��6X   $	��Top=�6e   $��39��6}   $��35��6�   ��6�   Z� ��57      �� 58      $ Images/fast-back.jpg��6   5:      �� 5;   
   -   5        $ rewind��5;      $�� ��6!   $
��Left=�6,   $��
222,45,0,0q�6G   $��2��6[   $	��Top=�6h   $��40��6�   $��35��6�   ��6�   Z� ��5<      �� 5=      $ Images/rewind.jpg��6   5?      �� 5@   
   -	   5         ��Name$ 	slidervol��5@      $��2��6$   $
��Left=�64   $��	60,26,0,0q�6O   $��2��6b   $	��Top=�6o   $	��100��6�    � LargeChange$	 0.1Q�6�    � SmallChange$
 0.01Q�6�    � Maximum$ 1Q�6�   6�   �� 5A   
   -
   5        $ 
sliderprog��5A      $
��Left=�6%   $��	16,22,0,0q�6@   $��2��6S   $	��Top=�6`   $	��270��6x    �� IsMoveToPointEnabled . 6�   �� 5B   
   -   5         ��Name$ label_e��5B      $��Label��6!   $
��Left=�61   $��	196,4,0,0q�6L   $��2��6_   $	��Top=�6l   �� 5C   
   -   5        $ 
button_add��5C      $	��Add��6%   $��2��63   $
��Left=�6C   $��	10,10,0,0q�6^   $	��Top=�6q   $��75��6�   ���	#FF1545976�   � 5D   
   $
��Left=�6   $	��219��6*   $��	10,10,0,0q�67   $��1��6J   $	��Top=�6W   $	��280��6o   ��5E      �� 5F      $ Images/bg.jpg��6   5H      �� 5I   
   -   5        $ 
button_vol��5I      $�� ��6%   $��2��60   $
��Left=�6@   $��	30,19,0,0q�6[   $��2��6n   $	��Top=�6{   $��25��6�   $��25��6�   ��5J      �� 5K      $ Images/vol.png��6   5M      5N      5O      