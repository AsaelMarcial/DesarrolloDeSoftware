   M S B A M L   `   `   `  ����P  LSistemaGestionMusical, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:SistemaGestionMusical.vistasSistemaGestionMusical.vistas  5   	   .    (SistemaGestionMusical.vistas.CancionCRUD   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:SistemaGestionMusical.vistas     5   	     � Title$"  Administración de canciones��5   	   $	��381��6-   $	��830��6:   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��239* �6   .+�5   
   �� -   5         ��Name$ tbFiltro��5      $
��Left=�6$   $��
210,30,0,0q�6?    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��255��6   $��21��6�   �� 5   
   -   5         ��Name$ 
btnAgregar��5      $��Agregar��6%   $
��Left=�67   $��
684,66,0,0q�6R   $	��Top=�6f   $��27��6~   $	��122��6�   ���	#FFB8EABB6�   �� 5   
   -   5        $ btnEliminar��5      $��Eliminar��6&   $��684,148,0,0q�69   ���	#FFFFA5A5$��27��6e   $	��Top=�6q   $
��Left=�6�   $	��122��6�   6�   �� 5   
   -   5        $ btnActualizar��5      $��
Actualizar��6(   $��684,116,0,0q�6=   $	��Top=�6R   $��27��6j   ���	#FF99B2FD$
��Left=�6�   $	��122��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgCanciones��5      $��	25,66,0,0q�6(   $
��Left=�6;   $	��643��6V   $	��269��6b   $	��Top=�6o      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6%      Header$ Está activa��60   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6E   �� *Activa+  5      $ 70 6%   $ Clave��60   	 6?   �� *Clave+  5      $	 135 6%   $ Nombre de la canción��61   	 6O   �� *Nombre+  5      $	 110 6%   $ Artista��61   	 6B   �� *NombreArtista+  5      $	 110 6%   $ Álbum��61   	 6@   �� *NombreAlbum+  5      $ 80 6%   $ 	Duración��60   	 6B   �� *
Duracion+  5      $ 80 6%   $ Intro��60   	 6?   �� *DuracionIntro+  5      $	 110 6%   $ Género��61   	 6A   �� *NombreGenero+  5      $	 110 6%   $ 
Categoría��61   	 6D   �� *NombreCategoria+  5      $	 110 6%   $ Radio��61   	 6@   �� *Radio+  5      $	 150 6%   $ Observación��61   	 6F   �� *Observacion+5"      �� 5#   
   -   5        $ btnRegresar��5#      $��Regresar��6&   $
��Left=�69   $��720,314,0,0q�6T   $	��Top=�6i   $��21��6�   $��86��6�   ���	#FFE6E6E66�   �� 5$   
   $��Filtrar por
��6   $
��Left=�60   $��	30,26,0,0q�6K   $	��Top=�6^   $��26��6v   $��64��6�   �� 5%   
   -   5        
 ��Name$
 cbFiltro��5%      $
��Left=�6%   $��	94,30,0,0q�6@   $	��Top=�6S   $	��111��6k    �� SelectedIndex$ 0��6w   �� 5&   
   -   5        $ 	btnBuscar��5&      $
��Left=�6$   $��
480,26,0,0q�6?   $	��Top=�6S   $��28��6k   $��28��6�   ��6�   Z� ��5'      �� 5(       �� ImageSource$ /vistas/iconobuscar.png��6    j� Stretch$
 Fill=�6C    j� TileMode$
 None=�6R   5+      5-      5.      