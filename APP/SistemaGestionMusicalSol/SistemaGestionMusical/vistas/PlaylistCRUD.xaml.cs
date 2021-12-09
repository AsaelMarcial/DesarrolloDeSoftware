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
    /// Lógica de interacción para PlaylistCRUD.xaml
    /// </summary>
    public partial class PlaylistCRUD : Window
    {
        private List<Playlist> playlists = new List<Playlist>();

        public PlaylistCRUD()
        {
            InitializeComponent();
            CargarPlaylists();
            dgPaylist.IsReadOnly = true;
        }

        private void CargarPlaylists()
        {
            dgPaylist.ItemsSource = null;
            playlists.Clear();

            try
            {
                using (Database db = new Database())
                {
                    var listaPlaylist = db.Playlist;
                    foreach (var playlist in listaPlaylist)
                    {
                        playlist.nombre = playlist.nombre.Trim();
                        playlist.descripcion = playlist.descripcion.Trim();
                        playlists.Add(playlist);
                    }
                }
                dgPaylist.ItemsSource = playlists;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha sido posible mostrar las playlist, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine("Excepcion manejada al cargar las playlist de la base de datos:\n\n" + ex.Message);
            }
            finally
            {
                btnActualizar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
                btnReproducir.IsEnabled = false;
            }
           
        }

        private void BtnAñadir_Click(object sender, RoutedEventArgs e)
        {
            PlaylistVer pv = new PlaylistVer();
            pv.ShowDialog();
            CargarPlaylists();
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Playlist playlistSeleccionada = (Playlist)dgPaylist.SelectedItem;
            PlaylistVer pv = new PlaylistVer();
            pv.CargarPlaylist(playlistSeleccionada);
            pv.ShowDialog();
            CargarPlaylists();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Playlist playlistSeleccionada = (Playlist)dgPaylist.SelectedItem;
            var result = MessageBox.Show("¿Está seguro que desea eliminar la playlist seleccionada?", "¿Eliminar playlist?", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        var listaCancionPlaylist = db.CancionPlaylist.Where(d => d.idPlaylist.Equals(playlistSeleccionada.idPlaylist));
                        foreach(var cp in listaCancionPlaylist)
                        {
                            db.CancionPlaylist.Remove(cp);
                        }

                        var playlistOb = db.Playlist.Where(d => d.idPlaylist.Equals(playlistSeleccionada.idPlaylist));
                        Playlist playlist = playlistOb.First();
                        db.Playlist.Remove(playlist);

                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No ha sido posible eliminar la playlist, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine("Excepcion manejada al eliminar playlist en la base de datos:\n\n" + ex.Message);
                }
                finally
                {
                    CargarPlaylists();
                }
            }
        }

        private void BtnReproducir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DgPlaylist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnActualizar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
            btnReproducir.IsEnabled = true;
        }
    }
}
