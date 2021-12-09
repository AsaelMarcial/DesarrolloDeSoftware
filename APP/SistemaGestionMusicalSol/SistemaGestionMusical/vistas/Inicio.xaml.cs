using SistemaGestionMusical.interfaces;
using SistemaGestionMusical.vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaGestionMusical
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Inicio : Window, ObservadorReproduccion
    {
        private List<CancionTuneada> cancionesTuneadas = new List<CancionTuneada>();
        int maxListaCanciones = -1;
        private int cancionReproduciendose = -1;

        public Inicio()
        {
            InitializeComponent();
            btnSkip.IsEnabled = false;
            btnBack.IsEnabled = false;
        }

        public void ObtenerPlaylist(Playlist playlist, List<CancionTuneada> canciones)
        {
            lblNombrePlaylist.Content = playlist.nombre;
            lblDescripcionPlaylist.Content = playlist.descripcion;

            this.cancionesTuneadas = canciones;
            maxListaCanciones = canciones.Count();
            cancionReproduciendose = 0;

            lblAlbum.Content = "Album:";
            lblArtista.Content = "Artista";
            lblCancionReproduciendose.Content = "Cancion reproduciéndose";
            ReproducirCancion();

            btnSkip.IsEnabled = true;
            btnBack.IsEnabled = true;
        }

        public void ReproducirCancion()
        {
            CancionTuneada cr = cancionesTuneadas[cancionReproduciendose];
            lblNombreCanción.Content = cr.Nombre;
            lblNombreArtista.Content = cr.NombreArtista;
            lblNombreAlbum.Content = cr.NombreAlbum;
            lblObservacion.Content = cr.Observacion;
            lblDuracion.Content = cr.Duracion;
            lblConteo.Content = cancionReproduciendose+1 + " / " + maxListaCanciones;
        }

        private void BtnSkip_Click(object sender, RoutedEventArgs e)
        {
            if (cancionReproduciendose < maxListaCanciones-1)
            {
                cancionReproduciendose++;
                ReproducirCancion();
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if(cancionReproduciendose > 0)
            {
                cancionReproduciendose--;
                ReproducirCancion();
            }
        }

        private void btnVerPlaylists_Click(object sender, RoutedEventArgs e)
        {
            PlaylistCRUD playlistCRUDVentana = new PlaylistCRUD(this);
            playlistCRUDVentana.ShowDialog();
        }

        private void btnCanciones_Click(object sender, RoutedEventArgs e)
        {
            CancionCRUD cancionCRUDVentana = new CancionCRUD();
            cancionCRUDVentana.ShowDialog();
        }

        private void btnArtistas_Click(object sender, RoutedEventArgs e)
        {
            ArtistaCRUD artistaCRUDVentana = new ArtistaCRUD();
            artistaCRUDVentana.ShowDialog();
        }

        private void btnAlbumes_Click(object sender, RoutedEventArgs e)
        {
            AlbumCRUD albumCRUDVentana = new AlbumCRUD();
            albumCRUDVentana.ShowDialog();
        }

        private void btnCategorias_Click(object sender, RoutedEventArgs e)
        {
            CategoriaCRUD categoriaCRUDVentana = new CategoriaCRUD();
            categoriaCRUDVentana.ShowDialog();
        }

        private void btnGeneros_Click(object sender, RoutedEventArgs e)
        {
            GeneroCRUD generoCRUDVentana = new GeneroCRUD();
            generoCRUDVentana.ShowDialog();
        }

        
    }
}
