   M S B A M L   `   `   `  ����E  AHelloWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:HelloWorld
HelloWorld  5   	        HelloWorld.HoverMainWindow   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   >d2http://schemas.microsoft.com/expression/blend/2008    5   	   Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5   	   (localclr-namespace:HelloWorld    5   	     � Title$  HoverMainWindow��5   	   $��50��6!   $��50��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   6*   �� 5      $��5* �6   6*   �� 5      $��1* �6   6+   .+�5   
   (� -   5        $��viewboxAnimUI��5      $��1��5      .��5      � -   5        $��menuGrid��5      $	��380��5      $	��380��5      .+�5      A� -   5        $��menuRoundBig��5      ���#F4F8FB$��Center=�5      $��Center=�5      ���#E0E0E0$��1��5      $	��380��5      $	��380��5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q�6+      ShadowDepth$ 0Q�5   +      Color$ #52D3EC��5   +   5!      A� 5"      -   5        $��menuRoundSmall��5"      $��Center=�5#      $��Center=�5$      ���#E0E0E0$��0��5&      $	��300��5'      $	��300��5(       5)        5*      $ 50Q�6+   $ 0Q�5+   +   $ #52D3EC��5,   +   ���#DFE2E551      A� 52      -   5        $��menuRoundCenter��52      $��Center=�53      $��Center=�54      ���#E0E0E0$��0��56      $	��300��57      $	��300��58      ��59      
� 5:       
� RadiusX$ 1Q�6.    
� RadiusY$ 1Q�5;   .    
� GradientOrigin$ 0.7,0.3&�5<   .   .��5=      � 	 � Color$	 White��6+   
 � Offset$
 0Q�5>   +   68   � 5?      $	 #DFE2E5��6+   $
 1Q�5@   +   68   5A      5C      �� 5I      -   5        $��
MenuCanvas��5I      $��Center=�5J      $��Center=�5K      $	��340��5L      $	��340��5M      5N      5O      5P      5Q      5R      