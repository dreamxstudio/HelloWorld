   M S B A M L   `   `   `  ����  Sample Project    Samples.FancyPopup   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  5      -   5          >�Name$  me��5      $	��215��5      $	��300��5       � 	Resources 5         
RotateIcon g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value �� 	KeySpline��%A  &	        �� 5	      .��5
      U� $ 00:00:00X�6#   $ image��68   $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6V   .\�5      �� $ 00:00:00��6   $ 0Q�6.   �� 5      $ 0,0.284,0.39,1��6   $ 00:00:01.4000000��66   $	 360Q�6Q   5      5      5       � Triggers 5      :� 5      	 :� RoutedEvent$ 	 tb:TaskbarIcon.PopupOpened��6   .[�5      �� -   5        
 ��Name$ 
 RotateIcon_BeginStoryboard��5   >   #��[  6   6>   5      .��5      � .+�5      �� $��Stretch=�5      $��Stretch=�5      $
��Auto��5      $
��Auto��5      $��5,5,5,5q�5       �� CornerRadius$ 10,10,10,10��5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5   
      Color$ 	#FF474747��5      ��5!      �� 5"   
    �� EndPoint$ 0.5,1&�5#       �� 
StartPoint$ 0.5,0&�5$      .��5%      �  � Color$ 	#FF58C2FF��5&       � Offset$ 0Q�5'      � 5(      $ 	#FFFFFFFF��5)      $ 1Q�5*      5+      5-      �� 5.      -   5         ��Name$ image��55      $
��Left=�5/      $��	19,10,0,0q�50      $	��Top=�51      $��72��52      $��72��53      $��/Images/Preferences.png��54      $
��Fill=�55       J� RenderTransformOrigin$ 0.5,0.5&�6%   z�56      V� 57      .~�58   	   ��  �� ScaleX$ 1Q�6    �� ScaleY$ 1Q�6#   �� 59   	    �� AngleX$ 0Q�6    �� AngleY$ 0Q�6"   �� 5:   	    �� Angle$ 0Q�6   T� 5;   	    T� X$ 0Q�6    T� Y$ 0Q�6"   5<   	   5>      �� 5?      $��107,10,20,0q�5@      $
��Wrap=�5A      $
��Auto��5B      $	��Top=�5C      $��16(�5D      $
��Bold"�5E      ���	#FF575757$��Right=�5F      �� 6;   $�This is a fancy Popup...��5G   	    � Language$ de-ch�5H   	   6   �� 5I      -   5        $��Right=�5L      $��Bottom=�5M      $��89��5N      $��29��5O      $��Click me��5P      $��	0,0,20,20q�5Q      ���	#FFFFFFFF � ToolTip 5K      ��  �� Path$ ToolTipText���5S      �� 5T   
   $	 0,1&�5U      $	 0,0&�5V      .��5W      � $ 	#FFFFFFFF��5X      $ 1Q�5Y      � 5Z      $ 	#FFFFD197��5[      $ 0.459Q�5\      � 5]      $ 	#FFFFDBAD��5^      $ 0Q�5_      � 5`      $ 	#FFF18E23��5a      $ 0.508Q�5b      � 5c      $ 	#FFF9D4AC��5d      $ 0.954Q�5e      5f      5h      �� 5i      $��19,92,10,49q�5j      $
��Wrap=�5k      �� 6   $)�#This user control makes use of the ��6    $ de-ch�6K   �� 6^   $��Italic$�6b   $
��Bold"�6u   $�PopupOpened ��6�   $ de-ch�6�   �� 6�   $z�tattached routed event . Whenever the popup is opened, this attached event fires and triggers the rotation animation.��6�   $ de-ch�6.  6B  �� 5l      $��	0,52,20,0q�6   $	��Top=�6#   $
��Auto��6;   $
��Wrap=�6I   $
��Bold"�6]   $��14(�6o   $��Right=�6}   ���	#FF575757�� 6�   $�Clicks: ��6�   $ de-ch�6�   �� 6�   .F�5m      �� $
��Auto��6   $
��Auto��6   $
��Wrap=�6l   ��6-   �� $ 
ClickCount� �� ElementName$ me�� �� Mode$ Default=�6l   5n      6   �� 5o      $��16��5p   )   $
��Left=�64   $��	19,0,0,23q�6O   $��16��6b   $��Bottom=�6n   ��6   �� $ 
IconSource�6n   5r      5s      