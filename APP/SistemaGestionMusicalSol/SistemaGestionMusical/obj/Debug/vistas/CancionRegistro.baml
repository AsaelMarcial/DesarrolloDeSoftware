   M S B A M L   `   `   `  ����P  LSistemaGestionMusical, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:SistemaGestionMusical.vistasSistemaGestionMusical.vistas  5   	   2    ,SistemaGestionMusical.vistas.CancionRegistro   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:SistemaGestionMusical.vistas     5   	     � Title$  Registrar nueva canción��5   	   $	��367��6)   $	��781��66   .��5	      � .+�5
   
   �� $��Título��6   $
��Left=�6!   $��	21,17,0,0q�6<   $	��Top=�6O   $��27��6g   $��46��6s   �� 5   
   -   5         ��Name$ tbTitulo��5      $
��Left=�6$   $��	21,39,0,0q�6?    �� TextWrapping$
 Wrap=�6R   $	��Top=�6f   $	��201��6~   $��28��6�   �� 5   
   $��Duracion��6   $
��Left=�6#   $��	21,72,0,0q�6>   $	��Top=�6Q   $��27��6i   $��61��6u   �� 5   
   -   5        $ 
tbDuracion��5      $
��Left=�6&   $��	21,97,0,0q�6A   $
 Wrap=�6T   $	��Top=�6h   $	��201��6�   $��28��6�   �� 5   
   $��Duración de la intro
��6   $
��Left=�69   $��
21,142,0,0q�6T   $	��Top=�6h   $��27��6�   $	��117��6�   �� 5   
   -   5        $ tbDuracionIntro��5      $
��Left=�6+   $��
21,169,0,0q�6F   $
 Wrap=�6Z   $	��Top=�6n   $	��201��6�   $��27��6�   �� 5   
   $��Artista��6   $
��Left=�6"   $��
530,17,0,0q�6=   $	��Top=�6Q   $��27��6i   $��46��6u   �� 5   
   $��	Prioridad��6   $
��Left=�6$   $��277,142,0,0q�6?   $	��Top=�6T   $��27��6l   $��63��6x   �� 5   
   -   5         ��Name$ cbPrioridad��5      $
��Left=�6(   $��277,163,0,0q�6C   $	��Top=�6X   $	��200��6p   $��29��6|   �� 5   
   $��Genero��6   $
��Left=�6!   $��528,142,0,0q�6<   $	��Top=�6Q   $��27��6i   $��63��6u   �� 5   
   -   5        $ cbGenero��5      $
��Left=�6%   $��530,163,0,0q�6@   $	��Top=�6U   $	��200��6m   $��29��6y   �� 5   
   $��	Categoria��6   $
��Left=�6$   $��528,209,0,0q�6?   $	��Top=�6T   $��27��6l   $��63��6x   �� 5   
   -   5        $ cbCategoria��5      $
��Left=�6(   $��530,231,0,0q�6C   $	��Top=�6X   $	��200��6p   $��29��6|   �� 5   
   -   5         ��Name$ btnRegistrar��5      $��	Registrar��6'   $
��Left=�6;   $��320,294,0,0q�6V   $	��Top=�6k   $��32��6�   $	��112��6�   ���	#FFB8EABB6�   �� 5   
   -   5        $ 	cbArtista��5      $
��Left=�6&   $��
530,37,0,0q�6A   $	��Top=�6U   $	��200��6m   $��28��6y    �� SelectedIndex$ 0��6�   �� 5   
   -	   5         ��Name$ 	chbActiva��5      $��Canción activa��6&   $
��Left=�6?   $��277,234,0,0q�6Z   $	��Top=�6o    d� 	IsChecked$
 TrueY�6�   �� 5   
   -
   5        $ cbAlbum��5      $
��Left=�6$   $��
530,97,0,0q�6?   $	��Top=�6S   $	��200��6k   $��29��6w   �� 5   
   $��Album��6   $
��Left=�6    $��
528,75,0,0q�6;   $	��Top=�6O   $��26��6g   $��63��6s    J� RenderTransformOrigin$ 
0.444,0.63&�6~   �� 5   
   -   5        $ btnCancelar��5      $��Cancelar��6&   $
��Left=�69   $��656,304,0,0q�6T   $	��Top=�6i   $��22��6�   $��74��6�   ���	#FFD8D8D86�   �� 5   
   -   5        $ tbRadio��5      $
��Left=�6#   $��
21,232,0,0q�6>   $
 Wrap=�6R   $	��Top=�6f   $	��201��6~   $��27��6�   �� 5   
   $��Radio
��6   $
��Left=�6%   $��
21,213,0,0q�6@   $	��Top=�6T   $��27��6l   $	��117��6x   �� 5   
   -   5        $ tbClave��5      $
��Left=�6#   $��
276,40,0,0q�6>   $
 Wrap=�6R   $	��Top=�6f   $	��200��6~   $��26��6�   �� 5    
   $��Clave��6   $
��Left=�6    $��
275,17,0,0q�6;   $	��Top=�6O   $��27��6g   $��46��6s   �� 5!   
   -   5        $ tbObservacion��5!      $
��Left=�6)   $��
276,98,0,0q�6D   $
 Wrap=�6X   $	��Top=�6l   $	��201��6�   $��27��6�   �� 5"   
   $��Observación��6   $
��Left=�6&   $��
276,79,0,0q�6A   $	��Top=�6U   $��27��6m   $��89��6y   �� 5#   
   -   5        $ chbActivarExtras��5#      $��Activar extras��6-   $
��Left=�6F   $��	585,5,0,0q�6a   $	��Top=�6t   6�   �� 5$   
   -   5        $ btnAñadirGenero��5$      $��+��6*   $
��Left=�66   $��505,168,0,0q�6Q   $	��Top=�6f   $��20��6~   {�.  6�   �� 5%   
   -   5        $ btnAñadirCategoria��5%      $��+��6-   $
��Left=�69   $��505,234,0,0q�6T   $	��Top=�6i   $��20��6�   {�.  6�   �� 5&   
   -   5        $ btnAñadirArtista��5&      $��+��6+   $
��Left=�67   $��
505,41,0,0q�6R   $	��Top=�6f   $��20��6~   {�.  6�   �� 5'   
   -   5        $ btnAñadirAlbum��5'      $��+��6)   $
��Left=�65   $��505,102,0,0q�6P   $	��Top=�6e   $��20��6}   {�.  6�   5)      5*      