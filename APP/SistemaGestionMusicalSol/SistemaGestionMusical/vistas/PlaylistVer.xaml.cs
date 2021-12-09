using SistemaGestionMusical.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SistemaGestionMusical.vistas
{
    /// <summary>
    /// Lógica de interacción para PlaylistVer.xaml
    /// </summary>
    public partial class PlaylistVer : Window, ObservadorRespuesta
    {
        private List<CancionTuneada> canciones = new List<CancionTuneada>();
        private bool esNuevo = true;
        private int idPlaylistEditable = -1;

        public PlaylistVer()
        {
            InitializeComponent();
            btnQuitarCancion.IsEnabled = false;
            dgCanciones.IsReadOnly = true;
            dgCanciones.CanUserAddRows = false;
            dgCanciones.AutoGenerateColumns = false;
            dgCanciones.SelectionMode = DataGridSelectionMode.Single;
        }

        public void CargarPlaylist(Playlist playlist)
        {
            this.esNuevo = false;
            this.idPlaylistEditable = playlist.idPlaylist;
            btnRegistrar.Content = "Actualizar";
            tbNombre.Text = playlist.nombre;
            tbDescripcion.Text = playlist.descripcion;

            using (Database db = new Database())
            {
                var listaCancionPlaylist = db.CancionPlaylist.Where(d => d.idPlaylist.Equals(playlist.idPlaylist));
                foreach(var cp in listaCancionPlaylist)
                {
                        var listaCanciones = db.Cancion.Where(d => d.idCancion.Equals(cp.idCancion));
                        Cancion oCancion = listaCanciones.First();
                        CancionTuneada cancionT = new CancionTuneada();

                        cancionT.IdCancion = oCancion.idCancion;
                        cancionT.Nombre = oCancion.nombre.Trim();
                        cancionT.Activa = oCancion.activa;
                        cancionT.Duracion = oCancion.tiempo.Trim();
                        cancionT.DuracionIntro = oCancion.tiempoIntro.Trim();
                        cancionT.Radio = oCancion.radio.Trim();
                        cancionT.Clave = oCancion.clave.Trim();
                        cancionT.Observacion = oCancion.observacion.Trim();
                        switch (oCancion.prioridad)
                        {
                            case 1:
                                cancionT.Prioridad = "Alta";
                                break;
                            case 2:
                                cancionT.Prioridad = "Media";
                                break;
                            case 3:
                                cancionT.Prioridad = "Baja";
                                break;
                            default:
                                cancionT.Prioridad = "\tSeleccionar...";
                                break;
                        }
                        cancionT.IdArtista = oCancion.artista_id;
                        var artistaOb = db.Artista.Where(d => d.idArtista.Equals(oCancion.artista_id));
                        Artista artista = artistaOb.First();
                        cancionT.NombreArtista = artista.nombre.Trim();

                        cancionT.IdAlbum = (int)oCancion.album_id;
                        var albumOb = db.Album.Where(d => d.idAlbum.Equals(cancionT.IdAlbum));
                        Album album = albumOb.First();
                        cancionT.NombreAlbum = album.nombre.Trim();

                        cancionT.IdGenero = oCancion.genero_id;
                        var generoOb = db.Genero.Where(d => d.idGenero.Equals(oCancion.genero_id));
                        Genero genero = generoOb.First();
                        cancionT.NombreGenero = genero.nombre.Trim();

                        cancionT.IdCategoria = (int)oCancion.categoria_id;
                        var categoriaOb = db.Categoria.Where(d => d.idCategoria.Equals(oCancion.categoria_id));
                        Categoria categoria = categoriaOb.First();
                        cancionT.NombreCategoria = categoria.descripcion;

                        canciones.Add(cancionT);
                    
                }
                    
            }
            dgCanciones.ItemsSource = canciones;
        }
        

        private void BtAgregarCancion_Click(object sender, RoutedEventArgs e)
        {
            PlaylistVerCanciones pvc = new PlaylistVerCanciones(this);
            pvc.ShowDialog();
        }

        //Método receptor de PlaylistVerCanciones
        public void ObtenerCancion(CancionTuneada cancion)
        {

            if (canciones.Any(cancionG => cancionG.IdCancion == cancion.IdCancion))
            {
                MessageBox.Show("Ya agregaste esta canción a la playlist", "Ya agregaste esta canción", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                btnQuitarCancion.IsEnabled = false;
                canciones.Add(cancion);
                dgCanciones.ItemsSource = null;
                dgCanciones.ItemsSource = canciones;
            };
        }

        private void BtnQuitarCancion_Click(object sender, RoutedEventArgs e)
        {
            btnQuitarCancion.IsEnabled = false;
            int cancionSeleccionada = dgCanciones.SelectedIndex;
            canciones.RemoveAt(cancionSeleccionada);
            dgCanciones.ItemsSource = null;
            dgCanciones.ItemsSource = canciones;
        }

        private bool ValidarCampos(String nombre, String descripcion, int tamañoLista)
        { 
            if(nombre.Length==0 || descripcion.Length == 0)
            {
                MessageBox.Show("No puede dejar el nombre ni la descripción vacíos", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (tamañoLista <= 0)
            {
                MessageBox.Show("Debe agregar al menos una canción a la playlist", "Lista de canciones vacía", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (nombre.Length > 150 || descripcion.Length > 50)
            {
                MessageBox.Show("Debe agregar al menos una canción a la playlist", "Lista de canciones vacía", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            String nombre = tbNombre.Text;
            String descripcion = tbDescripcion.Text;

            if(ValidarCampos(nombre, descripcion, canciones.Count)){
                if (esNuevo)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            Playlist playlist = new Playlist();
                            playlist.nombre = nombre;
                            playlist.descripcion = descripcion;
                            db.Playlist.Add(playlist);
                            db.SaveChanges();
                            int idPlaylist = playlist.idPlaylist;

                            foreach(var cancion in canciones)
                            {
                                CancionPlaylist cancionPlaylist = new CancionPlaylist();
                                cancionPlaylist.idPlaylist = idPlaylist;
                                cancionPlaylist.idCancion = cancion.IdCancion;
                                db.CancionPlaylist.Add(cancionPlaylist);
                            }
                            db.SaveChanges();

                            MessageBox.Show("Se ha registrado la playlist en el sistema", "Registro exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No ha sido posible registrar la playlist, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                        Console.WriteLine("Excepcion manejada al registrar playlist en la base de datos:\n\n" + ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            var playlistOb = db.Playlist.Where(d => d.idPlaylist.Equals(idPlaylistEditable));
                            Playlist playlist = playlistOb.First();
                            playlist.nombre = nombre;
                            playlist.descripcion = descripcion;
                            db.Entry(playlist).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();

                            var listaCancionPlaylist = db.CancionPlaylist.Where(d => d.idPlaylist.Equals(idPlaylistEditable));
                            foreach (var cp in listaCancionPlaylist)
                            {
                                db.CancionPlaylist.Remove(cp);
                            }
                            db.SaveChanges();

                            foreach(var cancion in canciones)
                            {
                                CancionPlaylist cancionPlaylist = new CancionPlaylist();
                                cancionPlaylist.idPlaylist = idPlaylistEditable;
                                cancionPlaylist.idCancion = cancion.IdCancion;
                                db.CancionPlaylist.Add(cancionPlaylist);
                            }
                            db.SaveChanges();

                            MessageBox.Show("Se ha actualizado la playlist en el sistema", "Registro exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No ha sido posible actualizar la playlist, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                        Console.WriteLine("Excepcion manejada al actualizar playlist en la base de datos:\n\n" + ex.Message);
                    }
                }
                
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea cancelar?", "Cancelar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void DgCanciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnQuitarCancion.IsEnabled = true;
        }
    }
}
