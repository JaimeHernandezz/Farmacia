   M S B A M L   `   `   `  ����V  RMiPoyectoMiQueridoEnfermito, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MiPoyectoMiQueridoEnfermitoMiPoyectoMiQueridoEnfermito  5   	   3    -MiPoyectoMiQueridoEnfermito.RegistroProductos   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:MiPoyectoMiQueridoEnfermito     5   	     � Title$  RegistroProductos��5   	   $	��390��6#   $	��300��60   
����  �.��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��30(�6   $��Center=�6   $��0��6;   .��6H   	Productos6S   � 5   
   $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��80��6   
�������.��66   	Categoria6A   �� 5      -   5         ��Name$ txbCategoria��5      $	��200��60   6>   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��80��6   
�������.��66   	>Nombre6?   �� 5      -   5        $ 	txbNombre��5      $	��200��6-   6;   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��80��6   
�������.��66   
>Direccion6B   �� 5      -   5        $ txbDescripcion��5      $	��200��62   6@   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��80��6   
�������.��66   >PrecioCompra6E   �� 5       -   5        $ 	txbCompra��5       $	��200��6-   6;   5!      �� 5"      $ 
Horizontal=�6   .+�5#      �� $��80��6   
�������.��66   >PrecioVenta6D   �� 5$      -   5        $ txbVenta��5$      $	��200��6,   6:   5%      �� 5&      $
��Bold"�6   $��8(�6&   
�������.��6J   *=Campos obligatorios6a   5'      � 5(   
   $��2��6   .+�5)      �� -   5         ��Name$ btnNuevo��5)       $��70��6   .��6I   Nuevo6P   �� 5*      -   5        $ 
btnGuardar��5*       $��70��6   .��6M   	Guardar6V   �� 5+      -   5        $ 	btnEditar��5+       $��70��6   .��6K   Editar6S   �� 5,      -	   5        $ btnCancelar��5,       $��70��6   .��6O   
Cancelar6Y   �� 5-      -
   5        $ btnEliminar��5-       $��70��6   .��6O   
Eliminar6Y   5.      &   System.Windows.Controls.DataGrid  5/   
   -   5          Name$ dtgTabla��5/         
IsReadOnly . $��3��67   50      51      