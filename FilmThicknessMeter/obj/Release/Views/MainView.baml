   M S B A M L   `   `   `  ���� M  IFilmThicknessMeter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FilmThicknessMeter.ViewsFilmThicknessMeter.Views  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf #    FilmThicknessMeter.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8Views&clr-namespace:FilmThicknessMeter.Views     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     -     � Title$6  0Измеритель толщины плёнки��$	��772��$
��1104��.��� $��0,0,2,1q�.+�� $
��Left=�$	��119��$��	10,19,0,0q�$	��Top=�$	��191��.+��� $
��Left=�$��	10,59,0,0q�$	��Top=�$��90�� J� RenderTransformOrigin$ 	0.248,2.9&�{��� *ConnectionButtonIsEnable+���� *ConnectionCommand+���� *ConnectionButtonText+�� $2��,IP-адрес преобразователя��$
��Left=�$��	10,10,0,0q�$
��Wrap=�$	��Top=�$	��171���� $
��Left=�$��23��$��	10,31,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��171������ *
IPString+�� $
��Left=�$��	10,84,0,0q�$	��Top=�$	��171������ *ConnectionStatusText+���� *ConnectionStatusColour+� $
��Left=�$	��122��$��
10,143,0,0q�$	��Top=�$	��180��.+��� $
��Left=�$��	10,69,0,0q�$	��Top=�$	��161��$��39������ *MeasurementCommand+{��� *MeasurementButtonIsEnable+.���� $
��Wrap=� �� TextAlignment$ Center=��� $%�Начать измерение���� $)��#Время измерения, мс��$
��Left=�$��	10,10,0,0q�$	��Top=��� $
��Left=�$��23��$��	10,41,0,0q�$
 Wrap=�$	��Top=�$	��120������ *MeasurementTime+� $
��Left=�$��60��$��
10,579,0,0q�$	��Top=�$	��180��.+��� $!��Экспорт данных��$��
10,0,10,14q�$��36��$��Bottom=����� *ExportCommand+{��� *ExportButtonIsEnable+� $
��Left=�$��70��$��
10,644,0,0q�$	��Top=�$	��180��.+��� $'��!Настройка каналов��$��10,10,10,11q����� *ConfigureCommand+{��� *ConfigureButtonIsEnable+� .+�#  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   AnimationsSpeed$ 0:0:0.1h�   	Hoverable .     LegendLocation$ Right=�$��224,10,10,10q�   Series   LiveCharts.Wpf.LineSeries    LiveCharts.Wpf.Series   Title$ 1-й канал��	   LineSmoothness$	 1Q�
   StrokeThickness$
 6Q�   Stroke
 ��ح�   Fill
 ����    Values �� *FirstSensor+   PointGeometry Z�   $ 2-ой канал��$	 1Q�$
 6Q�
 ����
 ����  �� *SecondSensor+ Z�   $ 3-й канал��$	 1Q�$
 6Q�
 ���_�
 ����  �� *ThirdSensor+ Z�   $ 4-й канал��$	 1Q�$
 6Q�
 � � �
 ����  �� *FourthSensor+ Z�    AxisX   LiveCharts.Wpf.Axis     
Foreground
 �   �   Title$ Время, мс��   MinValue$ 0Q�   	Separator   LiveCharts.Wpf.Separator     Step$ 1Q�   AxisY   
 �   �$ Толщина, мк��   MinRange$ 0Q�   $ 5Q�