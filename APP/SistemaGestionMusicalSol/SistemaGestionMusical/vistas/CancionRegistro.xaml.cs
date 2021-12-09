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
    /// Lógica de interacción para CancionRegistro.xaml
    /// </summary>
    public partial class CancionRegistro : Window
    {
        private List<Artista> artistas = new List<Artista>();
        private List<Album> albumes = new List<Album>();
        private List<Genero> generos = new List<Genero>();
        private List<Categoria> categorias = new List<Categoria>();
        private List<String> prioridades = new List<String>()
        {
            "\tSeleccionar...", "Baja", "Media", "Alta"
        };

        private bool esNuevo = true;
        private int idCancionEditable = -1;

        public CancionRegistro()
        {
            InitializeComponent();
            CargarCombobox();
            cbPrioridad.ItemsSource = prioridades;
            cbPrioridad.SelectedIndex = 0;
        }

        public void CargarCancion(CancionTuneada cancion)
        {
            this.idCancionEditable = cancion.IdCancion;
            this.esNuevo = false;
            btnRegistrar.Content = "Actualizar";
            cbPrioridad.SelectedItem = cancion.Prioridad;

            Artista artistaEditable = artistas.Find(d => d.idArtista.Equals(cancion.IdArtista));
            cbArtista.SelectedItem = artistaEditable;

            Album albumEditable = albumes.Find(d => d.idAlbum.Equals(cancion.IdAlbum));
            cbAlbum.SelectedItem = albumEditable;

            Genero generoEditable = generos.Find(d => d.idGenero.Equals(cancion.IdGenero));
            cbGenero.SelectedItem = generoEditable;

            Categoria categoriaEditable = categorias.Find(d => d.idCategoria.Equals(cancion.IdCategoria));
            cbCategoria.SelectedItem = categoriaEditable;

            tbTitulo.Text = cancion.Nombre;
            tbDuracion.Text = cancion.Duracion;
            tbDuracionIntro.Text = cancion.DuracionIntro;
            tbRadio.Text = cancion.Radio;
            tbClave.Text = cancion.Clave;
            tbObservacion.Text = cancion.Observacion;
            chbActiva.IsChecked = cancion.Activa;

        }

        private void CargarCombobox()
        {
            CargarArtistas();
            CargarGeneros();
            CargarCategorias();
        }

        private void CargarArtistas()
        {
            artistas.Clear();
            
            Artista rellenoArt = new Artista(); rellenoArt.nombre = "\tSeleccionar..."; artistas.Add(rellenoArt);
            try
            {
                using (Database db = new Database())
                {
                    var artObject = db.Artista;
                    foreach (var artista in artObject)
                    {
                        artista.nombre = artista.nombre.Trim();
                        artistas.Add(artista);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha sido posible cargar los artistas, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine("Excepcion manejada al cargar los artistas de la base de datos:\n\n" + ex.Message);
            }
            finally
            {
                cbArtista.ItemsSource = null;
                cbArtista.ItemsSource = artistas;
            }
        }

        private void CbArtista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Artista artista = (Artista)cbArtista.SelectedItem;
            if (artista != null)
            {
                
                cbAlbum.ItemsSource = null;
                albumes.Clear();
                Album rellenoAlb = new Album(); rellenoAlb.nombre = "\tSeleccionar..."; albumes.Add(rellenoAlb);
                CargarAlbum(artista.nombre);
            }
        }

        private void CargarAlbum(String nombreArtista)
        {
            if (nombreArtista != "\tSeleccionar...")
            {
                try
                {
                    using (Database db = new Database())
                    {
                        var listaAlbumes = db.Album.Where(d => d.artista.Contains(nombreArtista));

                        foreach (var album in listaAlbumes)
                        {
                            album.nombre = album.nombre.Trim();
                            album.artista = album.artista.Trim();
                            albumes.Add(album);
                        }

                        if (albumes.Count > 1)
                        {
                            cbAlbum.ItemsSource = albumes;
                            cbAlbum.SelectedIndex = 0;
                            cbAlbum.IsEnabled = true;
                        }
                        else
                        {
                            albumes[0].nombre = "No hay albumes de este artista";
                            cbAlbum.ItemsSource = albumes;
                            cbAlbum.SelectedIndex = 0;
                            cbAlbum.IsEnabled = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No ha sido posible mostrar los albumes del artista, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine("Excepcion manejada al cargar los albumes de la base de datos:\n\n" + ex.Message);
                }
                
            }
            else
            {
                albumes[0].nombre = "\tElige un artista...";
                cbAlbum.ItemsSource = albumes;
                cbAlbum.SelectedIndex = 0;
                cbAlbum.IsEnabled = false;
            }
                                
        }

        private void CargarGeneros()
        {
            generos.Clear();
            cbGenero.ItemsSource = null;
            Genero rellenoGen = new Genero(); rellenoGen.nombre = "\tSeleccionar..."; generos.Add(rellenoGen);
            try
            {
                using (Database db = new Database())
                {
                    var genObject = db.Genero;
                    foreach (var genero in genObject)
                    {
                        genero.nombre = genero.nombre.Trim();
                        genero.nombreCorto = genero.nombreCorto.Trim();
                        generos.Add(genero);
                    }
                    cbGenero.IsEnabled = true;
                    if (generos.Count == 1)
                    {
                        generos[0].nombre = "No existen géneros registrados";
                        cbGenero.IsEnabled = false;
                    }
                }
                cbGenero.ItemsSource = generos;
                cbGenero.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha sido posible mostrar los géneros, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine("Excepcion manejada al cargar los generos de la base de datos:\n\n" + ex.Message);
            }

        }

        private void CargarCategorias()
        {
            categorias.Clear();
            cbCategoria.ItemsSource = null;
            Categoria rellenoCat = new Categoria(); rellenoCat.descripcion = "\tSeleccionar..."; categorias.Add(rellenoCat);
            try
            {
                using (Database db = new Database())
                {
                    var catObject = db.Categoria;
                    foreach (var categoria in catObject)
                    {
                        categoria.descripcion = categoria.descripcion.Trim();
                        categorias.Add(categoria);
                    }
                }
                cbCategoria.IsEnabled = true;
                if (categorias.Count == 1)
                {
                    categorias[0].descripcion = "No existen categorías registradas";
                    cbCategoria.IsEnabled = false;
                }
                cbCategoria.ItemsSource = categorias;
                cbCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha sido posible mostrar las categorías, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine("Excepcion manejada al cargar las categorías de la base de datos:\n\n" + ex.Message);
            }
        }

        private bool ValidarCampos(String titulo, String radio, String duracion, String duracionIntro, String clave, String observacion, int idGenero, int idCategoria, int idAlbum, int idArtista,int prioridad)
        {
            if (titulo == "" || radio == "" || duracion == "" || duracionIntro == "" || clave == "")
            {
                MessageBox.Show("Debes llenar todos los campos", "Campos invalidos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if(titulo.Length > 150)
            {
                MessageBox.Show("El título de la canción es demasiado largo. \nMax. 150 carácteres", "Campos invalidos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if(clave.Length > 10)
            {
                MessageBox.Show("La clave de la canción es demasiado larga. \nMax. 10 carácteres", "Campos invalidos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if(radio.Length > 50)
            {
                MessageBox.Show("El nombre de la radio es demasiado largo. \nMax. 50 carácteres", "Campos invalidos", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if(duracion.Length > 50)
            {
                MessageBox.Show("El texto escrito en el tiempo de duración de la canción es demasiado largo. \nMax. 50 carácteres", "Campos invalidos", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if(duracionIntro.Length > 50)
            {
                MessageBox.Show("El texto escrito en el tiempo de duración de la introducción de la canción es demasiado largo \nMax. 50 carácteres", "Campos invalidos", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if(idGenero==0 || idCategoria==0 || idAlbum==0 || idArtista==0 || prioridad<=0)
            {
                MessageBox.Show("Debe seleccionar todas las opciones en los menús de opciones", "Campos invalidos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
                
            return true;
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            String titulo = tbTitulo.Text;
            String radio = tbRadio.Text;
            String duracion = tbDuracion.Text;
            String duracionIntro = tbDuracionIntro.Text;
            String clave = tbClave.Text;
            String observacion = tbObservacion.Text;

            //Combobox
            Genero genero = new Genero();
            genero = (Genero)cbGenero.SelectedItem;

            Categoria categoria = new Categoria();
            categoria = (Categoria)cbCategoria.SelectedItem;

            Album album = new Album();
            album = (Album)cbAlbum.SelectedItem;

            Artista artista = new Artista();
            artista = (Artista)cbArtista.SelectedItem;

            String prioridadString = (String)cbPrioridad.SelectedItem;
            int prioridad;

            switch (prioridadString)
            {
                case "Baja":
                    prioridad = 3;
                    break;
                case "Media":
                    prioridad = 2;
                    break;
                case "Alta":
                    prioridad = 1;
                    break;
                default: prioridad = -1;
                    break;
            }

            bool activa = (bool)chbActiva.IsChecked;

            if(ValidarCampos(titulo, radio, duracion, duracionIntro, clave, observacion, genero.idGenero, categoria.idCategoria, album.idAlbum, artista.idArtista, prioridad))
            {
                if (esNuevo)
                {
                    RegistrarCancion(titulo, radio, duracion, duracionIntro, clave, observacion, genero.idGenero, categoria.idCategoria, album.idAlbum, artista.idArtista, prioridad, activa);
                }
                else
                {
                    ActualizarCancion(titulo, radio, duracion, duracionIntro, clave, observacion, genero.idGenero, categoria.idCategoria, album.idAlbum, artista.idArtista, prioridad, activa);
                }
            }
            
        }

        private void RegistrarCancion(String titulo, String radio, String duracion, String duracionIntro, String clave, String observacion, int idGenero, int idCategoria, int idAlbum, int idArtista, int prioridad, bool activa)
        {
            try
            {
                using (Database db = new Database())
                {
                    Cancion canObject = new Cancion();
                    canObject.activa = activa;
                    canObject.artista_id = idArtista;
                    canObject.album_id = idAlbum;
                    canObject.categoria_id = idCategoria;
                    canObject.clave = clave;
                    canObject.genero_id = idGenero;
                    canObject.nombre = titulo;
                    canObject.observacion = observacion;
                    canObject.prioridad = prioridad;
                    canObject.radio = radio;
                    canObject.tiempo = duracion;
                    canObject.tiempoIntro = duracionIntro;

                    db.Cancion.Add(canObject);
                    db.SaveChanges();
                    MessageBox.Show("Se ha registrado la canción en el sistema", "Registro exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }catch (Exception ex)
            {
                MessageBox.Show("No ha sido posible registrar la canción, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine("Excepcion manejada al registrar una canción en la base de datos:\n\n" + ex.Message);
            }
            finally
            {
                this.Close();
            }
            
        }
        private void ActualizarCancion(String titulo, String radio, String duracion, String duracionIntro, String clave, String observacion, int idGenero, int idCategoria, int idAlbum, int idArtista, int prioridad, bool activa)
        {
            
            try
            {
                using (Database db = new Database())
                {
                    Cancion canObject = (Cancion)db.Cancion.Find(idCancionEditable);
                    canObject.activa = activa;
                    canObject.artista_id = idArtista;
                    canObject.album_id = idAlbum;
                    canObject.categoria_id = idCategoria;
                    canObject.clave = clave;
                    canObject.genero_id = idGenero;
                    canObject.nombre = titulo;
                    canObject.observacion = observacion;
                    canObject.prioridad = prioridad;
                    canObject.radio = radio;
                    canObject.tiempo = duracion;
                    canObject.tiempoIntro = duracionIntro;
                    db.Entry(canObject).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                MessageBox.Show("Se ha actualizado la canción en el sistema", "Actualización exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
            }catch (Exception ex)
            {
                MessageBox.Show("No ha sido posible actualizar la canción, intente de nuevo más tarde"+ex.Message, "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine("Excepcion manejada al actualizar una canción en la base de datos:\n\n" + ex.Message);
            }
            finally
            {
                this.Close();
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

        private void ChbActivarExtras_Checked(object sender, RoutedEventArgs e)
        {
            btnAñadirAlbum.IsEnabled = true;
            btnAñadirArtista.IsEnabled = true;
            btnAñadirCategoria.IsEnabled = true;
            btnAñadirGenero.IsEnabled = true;
        }

        private void ChbActivarExtras_Unchecked(object sender, RoutedEventArgs e)
        {
            btnAñadirAlbum.IsEnabled = false;
            btnAñadirArtista.IsEnabled = false;
            btnAñadirCategoria.IsEnabled = false;
            btnAñadirGenero.IsEnabled = false;
        }

        private void BtnAñadirArtista_Click(object sender, RoutedEventArgs e)
        {
            ArtistaRegistro ar = new ArtistaRegistro();
            ar.ShowDialog();
            CargarArtistas();
            int cantidadArtistas = artistas.Count();
            cbArtista.SelectedIndex = cantidadArtistas - 1;
        }

        private void BtnAñadirAlbum_Click(object sender, RoutedEventArgs e)
        {
            AlbumRegistro albumRegistro = new AlbumRegistro();
            albumRegistro.ShowDialog();
            Artista artista = (Artista)cbArtista.SelectedItem;
            cbAlbum.ItemsSource = null;
            albumes.Clear();
            Album rellenoAlb = new Album(); rellenoAlb.nombre = "\tSeleccionar..."; albumes.Add(rellenoAlb);
            CargarAlbum(artista.nombre);
            int cantidadAlbumes = albumes.Count();
            cbAlbum.SelectedIndex = cantidadAlbumes - 1;
        }

        private void BtnAñadirGenero_Click(object sender, RoutedEventArgs e)
        {
            GeneroAñadir generoAñadir = new GeneroAñadir();
            generoAñadir.ShowDialog();
            CargarGeneros();
            int cantidadGeneros = generos.Count;
            cbGenero.SelectedIndex = cantidadGeneros - 1;
        }

        private void BtnAñadirCategoria_Click(object sender, RoutedEventArgs e)
        {
            CategoriaAñadir categoriaAñadir = new CategoriaAñadir();
            categoriaAñadir.ShowDialog();
            CargarCategorias();
            int cantidadCategorias = categorias.Count;
            cbCategoria.SelectedIndex = cantidadCategorias - 1;
        }
    }
}
