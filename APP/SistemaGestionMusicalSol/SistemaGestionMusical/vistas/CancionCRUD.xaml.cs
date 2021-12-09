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
    /// Lógica de interacción para CancionCRUD.xaml
    /// </summary>
    public class CancionTuneada
    {
        private int idCancion;
        private String nombre;
        private bool activa;
        private String duracion;
        private String duracionIntro;
        private String radio;
        private String clave;
        private String observacion;
        private String prioridad;
        private int idArtista;
        private String nombreArtista;
        private int idAlbum;
        private String nombreAlbum;
        private int idGenero;
        private String nombreGenero;
        private int idCategoria;
        private String nombreCategoria;

        public CancionTuneada()
        {

        }

        public CancionTuneada(int idCancion, string nombre, bool activa, string duracion, string duracionIntro, string radio, string clave, string observacion, String prioridad, int idArtista, string nombreArtista, int idAlbum, string nombreAlbum, int idGenero, string nombreGenero, int idCategoria, string nombreCategoria)
        {
            this.idCancion = idCancion;
            this.nombre = nombre;
            this.activa = activa;
            this.duracion = duracion;
            this.duracionIntro = duracionIntro;
            this.radio = radio;
            this.clave = clave;
            this.observacion = observacion;
            this.prioridad = prioridad;
            this.idArtista = idArtista;
            this.nombreArtista = nombreArtista;
            this.idAlbum = idAlbum;
            this.nombreAlbum = nombreAlbum;
            this.idGenero = idGenero;
            this.nombreGenero = nombreGenero;
            this.idCategoria = idCategoria;
            this.nombreCategoria = nombreCategoria;
        }
        public int IdCancion { get => idCancion; set => idCancion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public bool Activa { get => activa; set => activa = value; }
        public string Duracion { get => duracion; set => duracion = value; }
        public string DuracionIntro { get => duracionIntro; set => duracionIntro = value; }
        public string Radio { get => radio; set => radio = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public string Prioridad { get => prioridad; set => prioridad = value; }
        public int IdArtista { get => idArtista; set => idArtista = value; }
        public string NombreArtista { get => nombreArtista; set => nombreArtista = value; }
        public int IdAlbum { get => idAlbum; set => idAlbum = value; }
        public string NombreAlbum { get => nombreAlbum; set => nombreAlbum = value; }
        public int IdGenero { get => idGenero; set => idGenero = value; }
        public string NombreGenero { get => nombreGenero; set => nombreGenero = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }
    }
    public partial class CancionCRUD : Window
    {
        private List<CancionTuneada> canciones = new List<CancionTuneada>();
        private List<String> filtros = new List<String>()
        {
            "canción", "artista"
        };

        public CancionCRUD()
        {
            InitializeComponent();
            CargarCanciones();
            cbFiltro.ItemsSource = filtros;
            dgCanciones.IsReadOnly = true;
            dgCanciones.CanUserAddRows = false;
            dgCanciones.AutoGenerateColumns = false;
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
            finally
            {
                btnEliminar.IsEnabled = false;
                btnActualizar.IsEnabled = false;
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            CancionRegistro cancionRegistroVentana = new CancionRegistro();
            cancionRegistroVentana.ShowDialog();
            CargarCanciones();
        }


        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            CancionTuneada cancion = (CancionTuneada)dgCanciones.SelectedItem;
            CancionRegistro cr = new CancionRegistro();
            cr.CargarCancion(cancion);
            cr.ShowDialog();
            CargarCanciones();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            CancionTuneada cancionSeleccionada = new CancionTuneada();
            cancionSeleccionada = (CancionTuneada)dgCanciones.SelectedItem;

            var result = MessageBox.Show("¿Está seguro que desea eliminar el la canción seleccionada?", "Eliminar canción", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        Cancion cancion = (Cancion)db.Cancion.Find(cancionSeleccionada.IdCancion);
                        db.Cancion.Remove(cancion);
                        db.SaveChanges();
                        MessageBox.Show("La canción se ha eliminado exitosamente del sistema", "Canción eliminada", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    CargarCanciones();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No ha sido posible eliminar la canción, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine("Excepcion manejada al eliminar una canción en la base de datos:\n\n" + ex.Message);
                }

            }
        }

        private void TbBuscar_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DgCanciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEliminar.IsEnabled = true;
            btnActualizar.IsEnabled = true;
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            String filtraPor = cbFiltro.Text;
            String filtro = tbFiltro.Text;
            if (filtro != "")
            {
                canciones.Clear();
                dgCanciones.ItemsSource = null;
                try
                {
                    using (Database db = new Database())
                    {
                        System.Linq.Expressions.Expression<Func<Cancion, bool>> expression = (d => d.nombre.Contains(filtro));
                        if(filtraPor != "canción")
                        { //Filtra por nombre de artista
                            var artistaBuscar = db.Artista.Where(d => d.nombre.Contains(filtro));
                            foreach (var artista in artistaBuscar)
                            {
                                expression = d => d.artista_id.Equals(artista.idArtista);
                            };
                        }

                        var listaCanciones = db.Cancion.Where(expression);
                        foreach (var oCancion in listaCanciones)
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
                        dgCanciones.ItemsSource = canciones;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No ha sido posible mostrar los albumes, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine("Excepcion manejada al cargar los albumes por nombre de la base de datos:\n\n" + ex.Message);
                }
            }
            else
            {
                CargarCanciones();
            }
        }

        
    }
}
