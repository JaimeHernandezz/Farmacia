   M S B A M L   `   `   `  ����V  RMiPoyectoMiQueridoEnfermito, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MiPoyectoMiQueridoEnfermitoMiPoyectoMiQueridoEnfermito  5   	   2    ,MiPoyectoMiQueridoEnfermito.RegistroClientes   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:MiPoyectoMiQueridoEnfermito     5   	     � Title$  RegistroClientes��5   	   $	��390��6"   $	��300��6/   
����  �.��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��30(�6   $��Center=�6   $��0��6;   .��6H   	Cliente6Q   � 5   
   $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��90��6   
�������.��66   	>Nombre *6A   �� 5      -   5         ��Name$ 	txbNombre��5      $	��200��6-   6;   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��90��6   
�������.��67   	Direccion6B   �� 5      -   5        $ txbDireccion��5      $	��200��60   6>   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��90��6   
�������.��66   RFC6;   �� 5      -   5        $ txbRfc��5      $	��200��6*   68   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��90��6   
�������.��66   Teléfono *6B   �� 5       -   5        $ txbTelefono��5       $	��200��6/   6=   5!      �� 5"      $ 
Horizontal=�6   .+�5#      �� $��90��6   
�������.��66   Area De Esta.6E   �� 5$      -   5        $ txbEstacionamiento��5$      $	��200��66   6D   5%      �� 5&      $
��Bold"�6   $��10(�6&   
�������.��6K   *=Areas A,B,C6Z   5'      � 5(   
   $��2��6   .+�5)      �� -   5         ��Name$ btnNuevo��5)       $��70��6   .��6I   Nuevo6P   �� 5*      -   5        $ 
btnGuardar��5*       $��70��6   .��6M   	Guardar6V   �� 5+      -   5        $ 	btnEditar��5+       $��70��6   .��6K   Editar6S   �� 5,      -	   5        $ btnCancelar��5,       $��70��6   .��6O   
Cancelar6Y   �� 5-      -
   5        $ btnEliminar��5-       $��70��6   .��6O   
Eliminar6Y   5.      &   System.Windows.Controls.DataGrid  5/   
   -   5          Name$ dtgTabla��5/         
IsReadOnly . $��3��67   50      51      