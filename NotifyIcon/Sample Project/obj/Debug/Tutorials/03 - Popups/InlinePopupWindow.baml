   M S B A M L   `   `   `  ����I  ESample Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Samples.CommandsSamples.Commands  5      0    *Samples.Tutorials.Popups.InlinePopupWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  5      -commandsclr-namespace:Samples.Commands  5      $	��300��5      $	��300��5      .��5	      � .+�5   
   3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  -   5           Name$  MyNotifyIcon��5         
IconSource$ /Icons/Error.ico��5         ToolTipText$ hello world��5         	TrayPopup 5      �� 5      
�������
��� ���$��2q�5       �� CornerRadius$ 4��5      $	��160��5      ._�5      �� .+�5      �� -   5         ��Name$ 	popupText��5      $��	5,10,5,10q�5      $	��200��5      $��24��5       $��Enter Text...��5!      �� 5"      $��	Click Me!��5#      $��5,0,5,10q�5&      $��Center=�5'      $��Center=�5(      ��5$      )   #Samples.Commands.CloseWindowCommand  ��5%      �� 5(      5)      5*      5-      �� 5.   
   $��
26,26,24,0q�5/      $	��Top=�50      $
��Bold"�51      $*��$Left-Click NotifyIcon to open popup.��52      �� 54   
   $��Text on Popup: ��55      $��
26,66,24,0q�56      $	��Top=�57      �� 58      
���  ����59      ��  �� ElementName$ 	popupText�� �� Path$
 Text�5:      5<      5=      