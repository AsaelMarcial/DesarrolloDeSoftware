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
    public partial class Inicio : Window
    {
        public Inicio()
        {
            InitializeComponent();
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

        private void btnVerPlaylists_Click(object sender, RoutedEventArgs e)
        {
            /*PlaylistCRUD playlistCRUDVentana = new PlaylistCRUD();
            playlistCRUDVentana.ShowDialog();*/
            using (Entities db = new Entities())
            {
                Console.WriteLine("Conectado a la base de datos: " + db.Database.Connection.Database);
            }

        }
    }
}
