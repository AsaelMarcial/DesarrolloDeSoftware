using SistemaGestionMusical.interfaces;
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
using System.Windows.Shapes;

namespace SistemaGestionMusical.vistas
{
    /// <summary>
    /// Lógica de interacción para PlaylistVerCanciones.xaml
    /// </summary>
    public partial class PlaylistVerCanciones : Window
    {
        private List<CancionTuneada> canciones = new List<CancionTuneada>();
        ObservadorRespuesta respuestaCancion;

        public PlaylistVerCanciones()
        {
            InitializeComponent();
            CargarCanciones();
            dgCanciones.SelectionMode = DataGridSelectionMode.Single;
            dgCanciones.AutoGenerateColumns = false;
            dgCanciones.IsReadOnly = true;
            dgCanciones.CanUserAddRows = false;
            this.ResizeMode = ResizeMode.NoResize;
        }

        public PlaylistVerCanciones(ObservadorRespuesta respuestaCancion) : this()
        {
            this.respuestaCancion = respuestaCancion;
        }

        private void CargarCanciones()
        {
            canciones.Clear();
            dgCanciones.ItemsSource = null;
            try
            {
                using (Database db = new Database())
                {
                    var listcanciones = db.Cancion;
                    foreach (var oCancion in listcanciones)
                    {
                        CancionTuneada cancion = new CancionTuneada();
                        cancion.IdCancion = oCancion.idCancion;
                        cancion.Nombre = oCancion.nombre.Trim();
                        cancion.Activa = oCancion.activa;
                        cancion.Duracion = oCancion.tiempo.Trim();
                        cancion.DuracionIntro = oCancion.tiempoIntro.Trim();
                        cancion.Radio = oCancion.radio.Trim();
                        cancion.Clave = oCancion.clave.Trim();
                        cancion.Observacion = oCancion.observacion.Trim();
                        switch (oCancion.prioridad)
                        {
                            case 1:
                                cancion.Prioridad = "Alta";
                                break;
                            case 2:
                                cancion.Prioridad = "Media";
                                break;
                            case 3:
                                cancion.Prioridad = "Baja";
                                break;
                            default:
                                cancion.Prioridad = "\tSeleccionar...";
                                break;
                        }
                        cancion.IdArtista = oCancion.artista_id;
                        var artistaOb = db.Artista.Where(d => d.idArtista.Equals(oCancion.artista_id));
                        foreach (var artista in artistaOb)
                        {
                            cancion.NombreArtista = artista.nombre.Trim();
                        }

                        cancion.IdAlbum = (int)oCancion.album_id;
                        var albumOb = db.Album.Where(d => d.idAlbum.Equals(cancion.IdAlbum));
                        foreach (var album in albumOb)
                        {
                            cancion.NombreAlbum = album.nombre.Trim();
                        }

                        cancion.IdGenero = oCancion.genero_id;
                        var generoOb = db.Genero.Where(d => d.idGenero.Equals(oCancion.genero_id));
                        foreach (var genero in generoOb)
                        {
                            cancion.NombreGenero = genero.nombre.Trim();
                        }

                        cancion.IdCategoria = (int)oCancion.categoria_id;
                        var categoriaOb = db.Categoria.Where(d => d.idCategoria.Equals(oCancion.categoria_id));
                        foreach (var categoria in categoriaOb)
                        {
                            cancion.NombreCategoria = categoria.descripcion;
                        }


                        canciones.Add(cancion);
                    }
                }
                dgCanciones.ItemsSource = canciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha sido posible mostrar las canciones, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine("Excepcion manejada al cargar los albumes de la base de datos:\n\n" + ex.Message);
            }
        }
        

        private void DgCanciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RetornarCancion();
        }

        private void RetornarCancion()
        {
            CancionTuneada cancion = (CancionTuneada)dgCanciones.SelectedItem;
            respuestaCancion.ObtenerCancion(cancion);
            this.Close();
        }
    }
}
