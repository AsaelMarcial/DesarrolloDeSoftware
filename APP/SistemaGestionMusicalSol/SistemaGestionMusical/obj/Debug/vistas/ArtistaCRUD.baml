   M S B A M L   `   `   `  ����P  LSistemaGestionMusical, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:SistemaGestionMusical.vistasSistemaGestionMusical.vistas  5   	   .    (SistemaGestionMusical.vistas.ArtistaCRUD   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:SistemaGestionMusical.vistas     5   	     � Title$!  Administración de artistas��5   	   $	��359��6,   $	��576��69   .��5	      � $��	0,0,0,-16q�6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgArtistas��5
      $��25,65,165,0q�6'    J� RenderTransformOrigin$ 0.5,0.5&�6<      SelectionMode$ Single=�6�      
IsReadOnly .    AutoGenerateColumns .  $	��255��6�   $	��Top=�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6%      Header$ Nombre del artista��61   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6M   �� *Nombre+  5      $ 80 6%   $
 Sexo��60   	 6>   �� *Sexo+  5      $ 98 6%   $
 Tipo��60   	 6>   �� *Tipo+5      �� 5   
   -   5        
 ��Name$
 
btnAgregar��5      $��Agregar��6%   $��430,64,24,0q�67   $	��Top=�6L   $��27��6d   ���	#FFB8EABB6�   �� 5   
   -   5        $
 btnEliminar��5      $��Eliminar��6&   $��430,143,24,0q�69   $	��Top=�6O   $��27��6g   ���	#FFFFA5A56�   �� 5   
   -   5        $
 btnActualizar��5      $��
Actualizar��6(   $��430,111,24,0q�6=   $	��Top=�6S   $��27��6k   ���	#FF99B2FD6�   �� 5   
   -   5        $
 btnRegresar��5      $��Regresar��6&   $��466,295,0,0q�69   ���	#FFD0D0D0$��25��6   $	��Top=�6�   $
��Left=�6�   $��86��6�   �� 5   
   $��Filtrar por nombre��6   $
��Left=�6-   $��	17,26,0,0q�6H   $	��Top=�6[   �� 5   
   -   5         ��Name$ 	tbFiltrar��5      $
��Left=�6%   $��
129,34,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��282��6�   6�   5      5      