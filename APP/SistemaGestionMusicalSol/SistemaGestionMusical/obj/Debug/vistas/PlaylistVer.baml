   M S B A M L   `   `   `  ����P  LSistemaGestionMusical, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:SistemaGestionMusical.vistasSistemaGestionMusical.vistas  5   	   .    (SistemaGestionMusical.vistas.PlaylistVer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:SistemaGestionMusical.vistas     5   	     � Title$  Ver playlist��5   	   $	��421��6   $	��568��6+   .��5	      � .+�5
   
   �� -   5         ��Name$ tbNombre��5
      $
��Left=�6$   $��
200,20,0,0q�6?    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��269��6   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgCanciones��5      $��Center=�6(   $	��548��6E   $	��212��6Q   $	��Top=�6^   $��	0,120,0,0q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6%      Header$ Está activa��60   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *Activa+  5      $ 70 6%   $ Clave��60    6?   �� *Clave+  5      $	 135 6%   $ Nombre de la canción��61    6O   �� *Nombre+  5      $	 110 6%   $ Artista��61    6B   �� *NombreArtista+  5      $	 110 6%   $ Álbum��61    6@   �� *NombreAlbum+  5      $ 80 6%   $ 	Duración��60    6B   �� *
Duracion+  5      $ 80 6%   $ Intro��60    6?   �� *DuracionIntro+  5      $	 110 6%   $ Género��61    6A   �� *NombreGenero+  5      $	 110 6%   $ 
Categoría��61    6D   �� *NombreCategoria+  5      $	 110 6%   $ Radio��61    6@   �� *Radio+  5      $	 150 6%   $ Observación��61    6F   �� *Observacion+5      �� 5   
   $��	Canciones��6   $
��Left=�6$   $��	10,97,0,0q�6?   $	��Top=�6R   �� 5   
   -   5         ��Name$ btnAgregarCancion��5      $��Agregar canción��6,   $
��Left=�6F   $��
343,95,0,0q�6a   $	��Top=�6u   ���	#FFB8EABB$��94��6�   6�   �� 5   
   -   5        $ btnQuitarCancion��5      $��Quitar canción��6+   $
��Left=�6D   $��
449,95,0,0q�6_   $	��Top=�6s   $��95��6�   ���	#FFFFA5A5{�.  6�   �� 5   
   -   5        $ btnCancelar��5      $��Cancelar��6&   $
��Left=�69   $��468,362,0,0q�6T   $	��Top=�6i   $��57��6�   6�   �� 5   
   -   5        $ btnRegistrar��5      $��	Registrar��6'   $��Center=�6;   $��	0,351,0,0q�6X   $	��Top=�6k   $	��128��6�   $��31��6�   ���	#FFB8EABB6�   �� 5   
   $��Nombre de la playlist:��6   $
��Left=�61   $��	72,16,0,0q�6L   $	��Top=�6_   �� 5    
   -   5        $ tbDescripcion��5       $
��Left=�6)   $��
200,53,0,0q�6D   $
 Wrap=�6X   $	��Top=�6l   $	��269��6�   �� 5!   
   $��Descripción:��6   $
��Left=�6'   $��
121,49,0,0q�6B   $	��Top=�6V   5#      5$      