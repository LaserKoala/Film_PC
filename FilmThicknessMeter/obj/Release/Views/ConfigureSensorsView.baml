   M S B A M L   `   `   `  ����   FilmThicknessMeter3    -FilmThicknessMeter.Views.ConfigureSensorsView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     �Name$  ConfigurationWindow�� � Title$' !Настройка каналов��$��381.572��$��353.73��.��� $��0,0,2,2q�.+�� $
��Left=�$	��255��$��	21,87,0,0q�$	��Top=�$	��312��.+��� $'��!Настройка каналов��$
��Left=�$��	10,10,0,0q�$	��Top=�� $
��Left=�$��40��$	��Top=�$	��302��$��0,41,0,0q�.+��� $
��Left=�$��	85,10,0,0q�$	��Top=�$	��136��$��23�� � Minimum$ 0Q� � Maximum$ 1Q� �� TickPlacement$ BottomRight=� �� TickFrequency$
 0.05Q� � Value �� *FirstSensor+�� $
��Left=�$��23��$��
226,10,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��66������ *FirstSensor+�� $��1-й канал��$
��Left=�$��10,7,0,0q�$	��Top=�$��70���� $
��Left=�$��
10,206,0,0q�$	��Top=�$	��145��$��33������ *SaveConfigurationCommand+ �� Mode$ OneWay=����� 	 �� ElementName$	 ConfigurationWindow��.���� $
��Wrap=�$+��%Сохранить настройки��� $
��Left=�$��40��$	��Top=�$	��302��$��0,81,0,0q�.+��� $
��Left=�$��	85,10,0,0q�$	��Top=�$	��136��$��23��$ 0Q�$ 1Q�$ BottomRight=�$
 0.05Q� �� *SecondSensor+�� $
��Left=�$��23��$��	226,7,0,0q�$
 Wrap=�$	��Top=�$��66������ *SecondSensor+�� $��2-ой канал��$
��Left=�$��10,7,0,0q�$	��Top=�$��70��� $
��Left=�$��40��$	��Top=�$	��302��$��	0,121,0,0q�.+��� $
��Left=�$��	85,10,0,0q�$	��Top=�$	��136��$��23��$ 0Q�$ 1Q�$ BottomRight=�$
 0.05Q� �� *ThirdSensor+�� $
��Left=�$��23��$��	226,7,0,0q�$
 Wrap=�$	��Top=�$��66������ *ThirdSensor+�� $��3-й канал��$
��Left=�$��10,7,0,0q�$	��Top=�$��70��� $
��Left=�$��40��$	��Top=�$	��302��$��	0,161,0,0q�.+��� $
��Left=�$��85,7,0,0q�$	��Top=�$	��136��$��23��$ 0Q�$ 1Q�$ BottomRight=�$
 0.05Q� �� *FourthSensor+�� $
��Left=�$��23��$��	226,7,0,0q�$
 Wrap=�$	��Top=�$��66������ *FourthSensor+�� $��4-й канал��$
��Left=�$��10,7,0,0q�$	��Top=�$��70���� 
���  ��$
��Left=�$��190,209,0,0q�$	��Top=�$	��100������ *ErrorMessage+� $
��Left=�$��86��$��	21,10,0,0q�$	��Top=�$	��312��.+��� -   $
��Left=�$��23��$��	10,41,0,0q�$
 Wrap=�$	��Top=�$	��157��
 J� RenderTransformOrigin$
 0.158,0.696&����� *
PWMValue+�� $0��*Опорная частота ШИМ, Гц��$
��Left=�$��	10,10,0,0q�$	��Top=�