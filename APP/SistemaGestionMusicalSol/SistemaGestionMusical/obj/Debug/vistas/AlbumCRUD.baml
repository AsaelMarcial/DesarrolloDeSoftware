   M S B A M L   `   `   `  ����P  LSistemaGestionMusical, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:SistemaGestionMusical.vistasSistemaGestionMusical.vistas  5   	   ,    &SistemaGestionMusical.vistas.AlbumCRUD   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:SistemaGestionMusical.vistas     5   	     � Title$   Administración de albumes��5   	   $	��329��6+   $	��551��68   .��5	      � .+�5
   
   �� -   5         ��Name$ 	tbFiltrar��5
      $
��Left=�6%   $��
153,28,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��231��6�   $��21��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgAlbumes��5      $��	26,56,0,0q�6&   $
��Left=�69   $	��358��6T   $	��238��6`   $	��Top=�6m      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 225 6%      Header$ Nombre del album��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *nombre+  5      $	 123 6%   $ Nombre del artista��61    6M   �� *	artista+5      �� 5   
   -   5         ��Name$ 
btnAñadir��5      $��Añadir��6$   $
��Left=�65   $��
401,56,0,0q�6P   $	��Top=�6d   $��28��6|   $	��122��6�   ���	#FFB8EABB6�   �� 5   
   -   5        $ btnEliminar��5      $��Eliminar��6&   $
��Left=�69   $��401,170,0,0q�6T   $	��Top=�6i   $��28��6�   $	��122��6�   ���	#FFFFA5A56�   �� 5   
   -   5        $ btnActualizar��5      $��
Actualizar��6(   $
��Left=�6=   $��401,125,0,0q�6X   $	��Top=�6m   $��28��6�   $	��122��6�   ���	#FF99B2FD6�   �� 5   
   -   5        $ btnRegresar��5      $��Regresar��6&   $
��Left=�69   $��437,273,0,0q�6T   $	��Top=�6i   $��21��6�   $��86��6�   ���	#FFE6E6E66�   �� 5   
   $��Filtrar por��6   $
��Left=�6&   $��	26,25,0,0q�6A   $	��Top=�6T   �� 5   
   -   5        	 ��Name$	 	cbFiltrar��5      $
��Left=�6&   $��	85,27,0,0q�6A   $	��Top=�6T   $��63��6l   6w   5      5      