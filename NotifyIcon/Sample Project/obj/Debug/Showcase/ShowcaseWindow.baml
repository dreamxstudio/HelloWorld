   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      I ESample Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SamplesSamples 5      3clr-namespace:Samples.CommandsSamples.Commands 5         Samples.ShowcaseWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  5      0sys&clr-namespace:System;assembly=mscorlib  5      :d2http://schemas.microsoft.com/expression/blend/2008  5
      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      !localclr-namespace:Samples  5      -Commandsclr-namespace:Samples.Commands  5        � Title$  WPF NotifyIcon��5      $	��874��5      $��936.387��5	      $	��750��5      $	��800��5       � 
ResizeMode$ NoResize=�5       � 	Resources 5          BooleanToVisibilityConverter S� 
MethodName S� 
ObjectType   System.Enum  ActivationModes S� MethodParameters M� TypeName��%�   &	        &	      �� 5   
   5      S� 5   
   $ 	GetValues��5      "  5       5      M� 5      $ tb:PopupActivationMode��5      5      5!      ��5"      �� 5#   
    �� EndPoint$ 0.771,0.907&�5$       �� 
StartPoint$ 0.229,0.093&�5%      .��5&      � 	 � Color$	 	#FFFFFFFF��5'      
 � Offset$
 1Q�5(      � 5)      $	 	#FFDAE9FF��5*      5+       � Triggers 5-      :� 5.   
    :� RoutedEvent$$ tb:TaskbarIcon.TrayToolTipOpen��5/       :� 
SourceName$ tb��50      .��53      � -   5        .+�5>   
   3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  -   5          Name$ tb��5?      $	��Top=�5@       
 tbMenu � ContextMenu# [ 5B         
IconSource 5A      ��  �� Path$ SelectedItem.Source� �� ElementName$ iconList�� �� Mode$ Default=�   ToolTipText 5C      �� $
 Text�$ txtToolTipText��$ Default=�y�5D      �� $ 	IsChecked� �� 	Converter# [  $ iconVisibility��$ Default=�   MenuActivation 5E      �� $ SelectedItem�$ lstMenuTrigger��$ Default=�   PopupActivation 5F      �� $ SelectedItem�$ lstPopupTrigger��$ Default=�   DoubleClickCommand 5G      .  (Samples.Commands.ShowSampleWindowCommand  "   DoubleClickCommandParameter 5H      ��  �� RelativeSource �� *Self+   	TrayPopup 5J        Samples.FancyPopup  5L         TrayToolTip 5O        Samples.FancyToolTip  5Q       J� Opacity$
 0.85Q�5R         InfoText 5S      �� $ ToolTipText�5V      � 5^   
   -   5         �Name$ Balloons��5b      $��509.567,578.58,0,0q�5_      $	��Top=�5`      $	��248��5a      $��405.32��5c      $
��Left=�5d      .+�5e      �� $��Stretch=�5f      $��Stretch=�5g      
���   �$��2,2,2,2q�5i      �� 5j      -   5          ��Name$  txtBalloonTitle��5l      $��125,0,17,133q�5k      $��Bottom=�5m      $��23��5n      .��6   WPF NotifyIcon5p      �� 5q      -   5        $  txtBalloonText��5s      $��125,0,17,76q�5r      ! �� AcceptsReturn! . $��47��5u      $��Bottom=�5v      " �� TextWrapping$
" Wrap=�5x      $M��GYou should see a LED icon in your system tray. This is your NotifyIcon.��5y      	� 5z      -   5        # 	�Name$# rbInfo��5�      $
��Left=�5{      $��	14,0,0,54q�5|      $��Bottom=�5}      $	��111��5~      $��22��5      $��Show as Info��5�      $ d� 	IsChecked$
$ TrueY�5�      5�      �� 5�      $
��Left=�5�      $��
14,0,0,133q�5�      $��Bottom=�5�      $��85��5�      $��23��5�      $
��Wrap=�5�      �� 5�      $�Balloon Title��5�      5�      �� 5�      $��
14,0,0,100q�5�      $
��Wrap=�5�      $
��Left=�5�      $��85��5�      $��23��5�      $��Bottom=�5�      �� 5�      $�Balloon Text��5�      5�      	� 5�      -   5        $# rbError��5�      $��	14,0,0,32q�5�      $��Bottom=�5�      $��22��5�      $��Show as Error��5�      $
��Left=�5�      $	��111��5�      5�      	� 5�      -   5        $# rbCustomIcon��5�      $��	14,0,0,10q�5�      $��Bottom=�5�      $��22��5�      $��Show Custom Icon��5�      $
��Left=�5�      $	��130��5�      5�      �� 5�      -	   5        % ��Name$% showBalloonTip��5�      $��Right=�5�      $��	0,0,17,43q�5�      $	��120��5�      $��Show Balloon Tip��5�      $��Bottom=�5�      $��23��5�      5�      �� 5�      $��10,35.96,21,0q�5�      $	��Top=�5�      $��56.04��5�      $
��Wrap=�5�      �� 5�      $<�6Displays default balloon tips as supported by the OS. ��5�       �� 5�      $4�.You can use custom icons under all OS versions��5�       �� 5�      $.�( (not supported by WinForms NotifyIcon).��5�       �� 5�      $�.��5�      5�      �� 5�      -
   5        $% hideBalloonTip��5�      $��Right=�5�      $��0,0,17,12.52q�5�      $	��120��5�      $��Hide Balloon Tip��5�      $��Bottom=�5�      $��23��5�      5�      �� 5�      $
��Left=�5�      $��	10,10,0,0q�5�      $	��Top=�5�      $
��Auto��5�      $
��Auto��5�      $
��Bold"�5�      $��	Underline{�5�      $
��Wrap=�5�      �� 5�      $ �Standard (OS) Balloon Tips��5�      5�      5�      � 5�   
   -   5        $ Popups��5�      $
��Left=�5�      $��12,543.88,0,0q�5�      $	��Top=�5�      $��469.5��5�      $��282.7��5�      .+�5�      �� $��Stretch=�5�      $��Stretch=�5�      ���	#FF000000$��2,2,2,2q�5�      �� 5�      -   5        & ��Name$& lstPopupTrigger��5�      $' �� IsSynchronizedWithCurrentItem$' FalseY�5�      $��10,0,190,10q�5�      ( �� SelectedIndex$( 0��5�      $	��117��5�      $��Bottom=�5�      ��5�      �� $ OneWay=�) �� Source#) [ 5�      �� 5�      $��10,31.7,14,137q�5�      $
��Wrap=�5�      �� 5�      $ �If the user clicks on the ��5�       �� 5�      $�Notify��5�       �� 5�      $�Icon, a ��5�       �� 5�      $�P��5�       �� 5�      $&� opup can be opened and displayed��5�       �� 5�      $D�> that allows the user to quickly interact with the application��5�       �� 5�      $�. ��5�       �� 5�      $>�8Unlike custom ToolTips, this works under all OS versions��5�       �� 5�      $�. ��5�       �� 5�      $/�)Which mouse button(s) opens the Popup is ��5�       �� 5      $�determined by the ��5      �� 5     $��Italic$�5     $
��Bold"�5     $�PopupActivation ��5      �� 5     $�	property.��5      �� 5     $m�g If both Popup and ContextMenu are configured for the same mouse buttons, ContextMenu takes precedence.��5	     �� 5
     �� 5     $�(Note: ��5      �� 5     $o�iIn case left-clicks are used, popups are displayed with a delay to ensure the user does not double-click.��5      �� 5     $�)��5     5     �� 5     $
��Left=�5     $��	10,10,0,0q�5     $	��Top=�5     $
��Auto��5     $
��Auto��5     $
��Bold"�5     $��	Underline{�5     $
��Wrap=�5     �� 5     $�Popup Controls��5     5     5     � 5  
   -   5        $ ToolTips��5!     $��
10,278,0,0q�5      $��255.88��5"     $	��Top=�5#     $��471.5��5$     $
��Left=�5%     .+�5&     �� $��Stretch=�5'     $��Stretch=�5(     ���	#FF000000$��2,2,2,2q�5*     �� 5+     -   5        $  txtToolTipText��5-     $��
10,0,25,60q�5,     $��Bottom=�5.     $��23��5/     $��THIS IS A SAMPLE TEXT....��50     ���	#FFFF000051     �� 52     $��
10,0,25,93q�53     $
��Wrap=�54     $��21��55     $��Bottom=�56     �� 57     $�ToolTipText��58      �� 59     $?�9 (assigned to property and also used by several bindings)��5:      �� 5;     $�:��5<     5=     �� 5>     $��10,29.88,10,114q�5?     $
��Wrap=�5@     �� 5A     $+�%If the user moves the mouse over the ��5B      �� 5C     $�Notify��5D      �� 5E     $�Icon, ��5F      �� 5G     $�
a ToolTip ��5H      �� 5I     $l�fcan be displayed. Starting from Windows Vista, we have convenient events to display and hide tooltips.��5J      �� 5K     $G�A You can assign arbitrary UIElements (e.g. User Controls) to the ��5L      �� 5M     $��Italic$�5N     $
��Bold"�5O     $�TrayToolTip ��5P      �� 5Q     $�	property.��5R     �� 5S     �� 5T     $� ��5U      �� 5V     $	�If ��5W      �� 5X     $��Italic$�5Y     $
��Bold"�5Z     $�TrayToolTip ��5[      �� 5\     $9�3is not set or the app runs under an older OS (e.g. ��5]      �� 5^     $�Windows ��5_      �� 5`     $�	xp), the ��5a      �� 5b     $�NotifyIcon ��5c      �� 5d     $�falls back to the ��5e      �� 5f     $��Italic$�5g     $
��Bold"�5h     $�ToolTipText ��5i      �� 5j     $�	property.��5k     5l     �� 5m     -   5        $��removeToolTip��5t     $
��Left=�5n     $��	10,0,0,10q�5o     $��Bottom=�5p     $	��147��5q     $��24��5r     $��Remove Custom ToolTip��5s     5u     �� 5v     $��
10,0,25,44q�5w     $��Bottom=�5x     $��16��5y     $
��Wrap=�5z     �� 5{     $C�=Click to fall back to ToolTipText (sets TrayToolTip to null):��5|     5}     �� 5~     $
��Left=�5     $��	10,10,0,0q�5�     $	��Top=�5�     $
��Auto��5�     $
��Auto��5�     $
��Bold"�5�     $��	Underline{�5�     $
��Wrap=�5�     �� 5�     $�ToolTips and ToolTipText��5�     5�     5�     � 5�  
   -   5        $ ContextMenus��5�     $
��Left=�5�     $��509.567,114.5,0,0q�5�     $��405.32��5�     $��255.88��5�     $	��Top=�5�     .+�5�     �� ���	#FF000000$��2,2,2,2q�5�     �� 5�     -   5        $& lstMenuTrigger��5�     $��
10,0,95,10q�5�     $' FalseY�5�     $	��124��5�     $��Bottom=�5�     $( 1��5�     ��5�     �� $ OneWay=�#) [ 5�     �� 5�     $��
10,97,48,0q�5�     $	��Top=�5�     $��22��5�     $
��Wrap=�5�     �� 5�     $.�(Mouse events that open the context menu:��5�     5�     �� 5�     $��
10,30,10,0q�5�     $	��Top=�5�     $��57��5�     $
��Wrap=�5�     �� 5�     $/�)Assign a custon context menu through the ��5�      �� 5�     $��Italic$�5�     $
��Bold"�5�     $�ContextMenu ��5�      �� 5�     $�property of the ��5�      �� 5�     $�Notify��5�      �� 5�     $�
Icon. The ��5�      �� 5�     $��Italic$�5�     $
��Bold"�5�     $�MenuActivation ��5�      �� 5�     $B�<property determines what mouse events open the context menu.��5�     5�     �� 5�     $��	10,10,0,0q�5�     $	��Top=�5�     $
��Auto��5�     $
��Wrap=�5�     $
��Auto��5�     $
��Left=�5�     $
��Bold"�5�     $��	Underline{�5�     �� 5�     $�Context Menu��5�     5�     5�     �� 5�  
   $��	10,10,0,0q�5�     $	��Top=�5�     $
��Auto��5�     $
��Wrap=�5�     $
��Bold"�5�     $��16(�5�     $
��Left=�5�     �� 5�     $�WPF NotifyIcon��5�     5�     �� 5�  
   $��12,57.62,15.5,0q�5�     $	��Top=�5�     $��14(�5�     $��Italic$�5�     ���	#FF303030$
��Wrap=�5�     $��Stretch=�5�     �� 5�     $�This ��5�      �� 5�     $���is a showcase of the different features of the WPF NotifyIcon. Have a look at the used controls and styles in order to see how binding can be supported. For a real-life ��5�      �� 5�     $�example��5�      �� 5�     $�, ��5�      �� 5�     * � Language$* de-ch�5�     $�
check out ��5�      �� 5�     $)��#http://www.hardcodet.net/netdrives/?�5�     .�6C   .�5�     �� $�	NetDrives��5�     5�     5�     � 5�  
   -   5        $ CustomBalloons��5�     $��509.567,380.38,0,0q�5�     $��188.2��5�     $	��Top=�5�     $��405.32��5�     $
��Left=�5�     .+�5�     �� $��Stretch=�5�     $
��Auto��5�     $��2,2,2,2q�5�     ���	#FF0000005�     �� 5�     -   5        $% showCustomBalloon��5�     $
��Show��5�     $��Right=�5�     $��0,0,91.377,10q�5�     $��71.623��5      $��23��5     $��Bottom=�5     �� 5     -   5        $  customBalloonTitle��5	     $��Bottom=�5     $��23��5     $��WPF Balloon��5     $
" Wrap=�5     $��10,0,173,10q�5     5	     �� 5
     $��10,35,24.377,0q�5     $	��Top=�5     $
��Wrap=�5     $��119.68��5     �� 5     $�Custom ��5      �� 5     $�Balloons are much ��5      �� 5     $*�$ore flexible then standard balloons ��5      �� 5     $�tips ��5      �� 5     $�when it comes to styling.��5      �� 5     $U�O You can display arbitrary UI Elements (e.g. User Controls) as custom balloons.��5     �� 5     �� 5     $>�8Apart from the richer UI, custom balloons also provide a��5      �� 5     $I�Cttached properties and events that can be used to control behavior.��5      �� 5      $B�< Custom balloons also work if the NotifyIcon is not visible.��5!     �� 5"     �� 5#     $�(Hint: Hover over the ��5$      �� 5%     $�balloon ��5&      �� 5'     $�to suspend the fade-out.)��5(     5)     �� 5*     -   5        $% hideCustomBalloon��5,     $��Close��5+     $��Right=�5.     $��0,0,9.754,10.52q�5/     $��71.623��50     $��23��51     $��Bottom=�52     �� 53     $
��Left=�54     $��	10,10,0,0q�55     $	��Top=�56     $
��Auto��57     $
��Auto��58     $
��Bold"�59     $��	Underline{�5:     $
��Wrap=�5;     �� 5<     $�Custom Balloons��5=     5>     5?     � 5@  
   -   5        $ Common��5D     $��10,114.5,0,0q�5A     $	��Top=�5B     $��147.351��5C     $��471.5��5E     $
��Left=�5F     .+�5G     �� $��2,2,2,2q�5H     ���	#FF0000005I     �� 5K     -   5        + ��Name$+ iconVisibility��5O     $��10,35.96,0,0q�5L     $	��Top=�5M     $��NotifyIcon Visible��5N     $
$ TrueY�5P     $
��Left=�5Q     $��155.42��5R     �� 5T     -   5        $& iconList��5W     $��10,77.38,0,0q�5U     $
' TrueY�5V     $( 0��5X     $	��123��5Y     $
��Left=�5Z     $��59.971��5[     $	��Top=�5\     $
��Auto=�6)   .@�5]     �� $��16��5^     $��0,4,0,0q�5_     $��16��5`     $��/Icons/Inactive.ico��5a     �� 5b     $��16��5c     $��0,4,0,0q�5d     $��16��5e     $��/Icons/Error.ico��5f     5h     �� 5i     $��10,55.38,0,61q�5j     $
��Auto��5k     $
��Wrap=�5l     $
��Left=�5n     �� 5o     $&� Select an image to switch icons:��5p     5q     �� 5r     $
��Left=�5s     $��	10,10,0,0q�5t     $	��Top=�5u     $
��Auto��5v     $
��Auto��5w     $
��Bold"�5x     $��	Underline{�5y     $
��Wrap=�5z     �� 5{     $�Icon / Visibility��5|     5}     5~     5     5�     