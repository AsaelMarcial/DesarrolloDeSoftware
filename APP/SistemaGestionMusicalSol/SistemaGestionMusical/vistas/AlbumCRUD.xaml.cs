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
    /// Lógica de interacción para AlbumCRUD.xaml
    /// </summary>
    public partial class AlbumCRUD : Window
    {
        private List<Album> albumes = new List<Album>();
        private List<String> filtro = new List<String>()
        {
            "album:","artista:"
        };

        public AlbumCRUD()
        {
            InitializeComponent();
            cbFiltrar.ItemsSource = filtro;
            cbFiltrar.SelectedIndex = 0;
            dgAlbumes.IsReadOnly = true;
            dgAlbumes.AutoGenerateColumns = false;
            dgAlbumes.CanUserAddRows = false;
            btnActualizar.IsEnabled = false;
            btnEliminar.IsEnabled = false;

            CargarAlbumes();
        }

        private void CargarAlbumes()
        {
            dgAlbumes.ItemsSource = null;
            albumes.Clear();
            try
            {
                using (Database db = new Database())
                {
                    var listaAlbumes = db.Album;
                    foreach (var album in listaAlbumes)
                    {
                        album.nombre = album.nombre.Trim();
                        album.artista = album.artista.Trim();
                        this.albumes.Add(album);
                    }
                }
                dgAlbumes.ItemsSource = albumes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha sido posible mostrar los albumes, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine("Excepcion manejada al cargar los albumes de la base de datos:\n\n" + ex.Message);
            }
            finally
            {
                btnEliminar.IsEnabled = false;
                btnActualizar.IsEnabled = false;
            }
        }

        private void BtnAñadir_Click(object sender, RoutedEventArgs e)
        {
            AlbumRegistro ab = new AlbumRegistro();
            ab.ShowDialog();
            CargarAlbumes();
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Album album = (Album)dgAlbumes.SelectedItem;
            AlbumRegistro ab = new AlbumRegistro();
            ab.CargarAlbum(album);
            ab.ShowDialog();
            CargarAlbumes();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Album albumSeleccionado = new Album();
            albumSeleccionado = (Album)dgAlbumes.SelectedItem;

            var result = MessageBox.Show("¿Está seguro que desea eliminar el álbum seleccionado?", "Eliminar álbum", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        Album album = (Album)db.Album.Find(albumSeleccionado.idAlbum);
                        db.Album.Remove(album);
                        db.SaveChanges();
                        MessageBox.Show("El álbum se ha eliminado exitosamente del sistema", "Álbum eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    CargarAlbumes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No ha sido posible eliminar el álbum, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine("Excepcion manejada al registrar álbum en la base de datos:\n\n" + ex.Message);
                }

            }
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DgAlbumes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnActualizar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
        }

        private void TbFiltrar_TextChanged(object sender, TextChangedEventArgs e)
        {
            String texto = tbFiltrar.Text;
            String filtrarPor = (String)cbFiltrar.SelectedItem;
            if (texto == "")
            {
                CargarAlbumes();
            }
            else
            {
                albumes.Clear();
                dgAlbumes.ItemsSource = null;
                try
                {
                    using (Database db = new Database())
                    {
                        System.Linq.Expressions.Expression<Func<Album, bool>> expression = (d => d.nombre.Contains(texto));
                        if (filtrarPor == "artista:")
                        {
                             expression = (d => d.artista.Contains(texto));
                        }

                        var listaAlbumes = db.Album.Where(expression);

                        foreach (var album in listaAlbumes)
                        {
                            album.nombre = album.nombre.Trim();
                            album.artista = album.artista.Trim();
                            albumes.Add(album);
                        }
                        dgAlbumes.ItemsSource = albumes;
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show("No ha sido posible mostrar los albumes, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine("Excepcion manejada al cargar los albumes por nombre de la base de datos:\n\n" + ex.Message);
                }
                finally
                {

                }
                
                btnEliminar.IsEnabled = false;
                btnActualizar.IsEnabled = false;
            }
        }

        private void CbFiltrar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbFiltrar.Text = "";
        }
    }
}
