   M S B A M L   `   `   `  ����M  IFilmThicknessMeter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FilmThicknessMeter.ViewsFilmThicknessMeter.Views  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	   #    FilmThicknessMeter.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8Views&clr-namespace:FilmThicknessMeter.Views     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   -   5          � Title$6  0Измеритель толщины плёнки��5
   	   $	��772��6+   $
��1104��68   .��5      � $��0,0,2,1q�6   .+�5   
   � $
��Left=�6   $	��119��6*   $��	10,19,0,0q�67   $	��Top=�6J   $	��191��6b   .+�5      �� $
��Left=�5      $��	10,59,0,0q�5      $	��Top=�5      $��90��5       J� RenderTransformOrigin$ 	0.248,2.9&�5      {�5      �� *ConnectionButtonIsEnable+��5      �� *ConnectionCommand+��5      �� *ConnectionButtonText+5      �� 5      $2��,IP-адрес преобразователя��5      $
��Left=�5      $��	10,10,0,0q�5      $
��Wrap=�5      $	��Top=�5      $	��171��5      �� 5       $
��Left=�5"      $��23��5#      $��	10,31,0,0q�6    �� TextWrapping$
 Wrap=�5$      $	��Top=�5%      $	��171��5&      ��5!      �� *
IPString+5&      �� 5'      $
��Left=�6=   $��	10,84,0,0q�6X   $	��Top=�6k   $	��171��6�   ��6   �� *ConnectionStatusText+��6�   �� *ConnectionStatusColour+5(      � 5*   
   $
��Left=�6   $	��122��6*   $��
10,143,0,0q�67   $	��Top=�6K   $	��180��6c   .+�5+      �� $
��Left=�5.      $��	10,69,0,0q�5/      $	��Top=�50      $	��161��51      $��39��52      ��5,      �� *MeasurementCommand+{�5-      �� *MeasurementButtonIsEnable+.��53      �� $
��Wrap=�6    �� TextAlignment$ Center=�61   �� 6I   $%�Начать измерение��6M   6h   54      �� 56      $)��#Время измерения, мс��57      $
��Left=�58      $��	10,10,0,0q�59      $	��Top=�5:      �� 5<      $
��Left=�5>      $��23��5?      $��	10,41,0,0q�5@      $
 Wrap=�5A      $	��Top=�5B      $	��120��5C      ��5=      �� *MeasurementTime+5C      5D      � 5E   
   $
��Left=�6   $��60��6*   $��
10,579,0,0q�66   $	��Top=�6J   $	��180��6b   .+�5F      �� $!��Экспорт данных��6b   $��
10,0,10,14q�6{   $��36��6�   $��Bottom=�6�   ��6   �� *ExportCommand+{�67   �� *ExportButtonIsEnable+6�   5G      � 5H   
   $
��Left=�6   $��70��6*   $��
10,644,0,0q�66   $	��Top=�6J   $	��180��6b   .+�5I      �� $'��!Настройка каналов��6h   $��10,10,10,11q�6�   ��6   �� *ConfigureCommand+{�6:   �� *ConfigureButtonIsEnable+6�   5J      � 5L   
   .+�5P      #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   AnimationsSpeed$ 0:0:0.1h�6!      	Hoverable .     LegendLocation$ Right=�6M   $��224,10,10,10q�6e      Series 5R        LiveCharts.Wpf.LineSeries    LiveCharts.Wpf.Series   Title$ 1-й канал��5S   !   	   LineSmoothness$	 1Q�5V   !   
   StrokeThickness$
 6Q�5W   !      Stroke
 ��ح�   Fill
 ����    Values 5T   !   �� *FirstSensor+   PointGeometry 5U   !   Z� 5Y   !     5Z      $ 2-ой канал��5[   !   $	 1Q�5^   !   $
 6Q�5_   !   
 ����
 ����  5\   !   �� *SecondSensor+ 5]   !   Z� 5a   !     5b      $ 3-й канал��5c   !   $	 1Q�5f   !   $
 6Q�5g   !   
 ���_�
 ����  5d   !   �� *ThirdSensor+ 5e   !   Z� 5i   !     5j      $ 4-й канал��5k   !   $	 1Q�5n   !   $
 6Q�5o   !   
 � � �
 ����  5l   !   �� *FourthSensor+ 5m   !   Z� 5q   !      AxisX 5t        LiveCharts.Wpf.Axis     
Foreground
 �   �   Title$ Время, мс��5v         MinValue$ 0Q�5w         	Separator 5x        LiveCharts.Wpf.Separator  5y         Step$ 1Q�6,   5{         AxisY 5        
 �   �$ Толщина, мк��5�         MinRange$ 0Q�5�       5�        5�      $ 5Q�6,   5�      5�      5�      5�      5�      