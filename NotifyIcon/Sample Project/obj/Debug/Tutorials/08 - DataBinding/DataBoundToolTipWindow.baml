   M S B A M L   `   `   `  ����  Sample Project:    4Samples.Tutorials.DataBinding.DataBoundToolTipWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  5   	   $	��300��5   	   $	��500��5   	   .��5      � .+�5
   
   3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  -   5           Name$  MyNotifyIcon1��5
         
IconSource$ /Icons/Error.ico��5         ToolTipText 5      ��  �� ElementName$ 
txtToolTip�� �� Path$
 Text�   TrayToolTip 5      �� 5      
�������
��� ���$��2q�5       �� CornerRadius$ 4��5       J� Opacity$	 0.8Q�5      $	��160��5      $��40��5      ._�5      �� $��Center=�5       $��Center=�5       ��5       �� $ ToolTipText�5       5      5         5$   
   -   5        $  MyNotifyIcon2��5$       � DataContext$ WPF FTW ��5%      $ /Icons/Inactive.ico��5&       5'      �� $ 
txtToolTip��$
 Text� 5)      �� 5/      
�������
��� ���$��2q�51      $ 4��52      $	 0.8Q�53      $	��160��54      $��40��55      ._�57      �� ��6    �� �� 59      $��Center=�5;   $   $��Center=�5<   $   ��59   $   �� 	 �� RelativeSource	 �� *Self+$4 .(tb:TaskbarIcon.ParentTaskbarIcon).ToolTipText�5<   $   5=      5>      5A      �� 5D   
   $��
26,26,24,0q�6   $	��Top=�5E      $
��Wrap=�5F      $
��Bold"�5G      �� 5H      $:�4This sample shows data bound ToolTips in two flavors��6   �� 6Q   �� 6^   $� ��6b   �� 5I      �� 6   $(�"- implicit binding via DataContext��6   �� 6L   �� 5J      $B�<- explicit binding via ParentTaskbarIcon (attached property)��6   �� 6Y   �� 6f   $� ��6j   �� 5K      �� 6   $C�=Move over NotifyIcons (grey / red) to show data bound ToolTip��6   5L      �� 5M   
   -   5        
 ��Name$
 
txtToolTip��5P      $��
26,0,24,10q�5M      $��hello world��5N       �� TextWrapping$
 Wrap=�5O      $��25��5Q      $��Bottom=�5R      �� 5S   
   $��26,0,125,45q�6   $��Bottom=�5T      $��26��5U      $
��Wrap=�5V      �� 5W      $�ToolTipText:��6   5X      5Z      5[      