   M S B A M L   `   `   `  ����P  LSistemaGestionMusical, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:SistemaGestionMusical.vistasSistemaGestionMusical.vistas  5   	   /    )SistemaGestionMusical.vistas.PlaylistCRUD   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:SistemaGestionMusical.vistas     5   	     � Title$  Todas las playlist��5   	   $	��271��6$   $	��459��61   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgPaylist��5
      $��	16,40,0,0q�6&   $	��138��69   $	��Top=�6F   $
��Left=�6^   $	��424��6y   ���	#FFC1F3F2
���   �   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 6%      Header$ Nombre de la playlist��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6P   �� *nombre+  5      $	 233 6%   $ Descripción��61    6F   �� *descripcion+5      �� 5      -   5         ��Name$ 
btnAñadir��5      $��Añadir��6(   $
��Left=�69   $��	16,10,0,0q�6T   $	��Top=�6g   $��19��6   $	��100��6�   ���	#FFB8EABB6�   �� 5   
   -   5        $ btnEliminar��5      $��Eliminar��6&   $
��Left=�69   $��
384,10,0,0q�6T   $	��Top=�6h   $��19��6�   $��56��6�   ���	#FFFFA5A5{�.  6�   �� 5   
   -   5        $ btnReproducir��5      $��
Reproducir��6(   $��Center=�6=   $��	0,192,0,0q�6Z   $	��Top=�6m   $��29��6�   $	��156��6�   ���	#FF7ED4D2���	#FFF9C0C0
���   �{�.  6�   �� 5   
   -   5        $ btnRegresar��5      $��Regresar��6&   $
��Left=�69   $��384,201,0,0q�6T   $	��Top=�6i   $��56��6�   
���   ����	#FFC3C3C36�   �� 5   
   -   5        $ btnActualizar��5      $��
Actualizar��6(   $
��Left=�6=   $��
243,10,0,0q�6X   $	��Top=�6l   $��19��6�   $	��102��6�   ���	#FF99B2FD{�.  6�   5      5      