   M S B A M L   `   `   `  ����P  LSistemaGestionMusical, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:SistemaGestionMusical.vistasSistemaGestionMusical.vistas  5   	   -    'SistemaGestionMusical.vistas.GeneroCRUD   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:SistemaGestionMusical.vistas     5   	     � Title$  
GeneroCRUD��5   	   $	��331��6   $	��549��6)   .��5	      � $
��Left=�6   $	��550��6&   $��0,0,0,-6q�62   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgGeneros��5
      $��10,16,176,23q�6&   
�������   SelectionMode$ Single=�6�      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 270 6%      Header$ Nombre del género��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6L   �� *nombre+  5      $ 86 6%   $ Nombre corto��60    6F   �� *nombreCorto+5      �� 5   
   -   5         ��Name$ 
btnAgregar��5      $��Agregar��6%   $
��Left=�67   $��
400,16,0,0q�6R   $	��Top=�6f   $��28��6~   $	��122��6�   ���	#FFB8EABB6�   �� 5   
   -   5        $ btnActualizar��5      $��
Actualizar��6(   $
��Left=�6=   $��
400,71,0,0q�6X   $	��Top=�6l   $��28��6�   $	��122��6�   ���	#FF99B2FD6�   �� 5   
   -   5        $ btnEliminar��5      $��Eliminar��6&   $
��Left=�69   $��400,114,0,0q�6T   $	��Top=�6i   $��27��6�   $	��122��6�   ���	#FFFFA5A56�   �� 5   
   -   5        $ btnRegresar��5      $��Regresar��6&   $
��Left=�69   $��436,262,0,0q�6T   $	��Top=�6i   $��21��6�   $��86��6�   ���	#FFE6E6E66�   5      5      