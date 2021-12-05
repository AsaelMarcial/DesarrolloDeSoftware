using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para AlbumRegistro.xaml
    /// </summary>
    public partial class AlbumRegistro : Window
    {
        private List<String> artistas = new List<String>();
        private bool esNuevo = true;
        private int idAlbumEditar = -1;

        public AlbumRegistro()
        {
            InitializeComponent();
            CargarArtistas();
           
        }

        public void CargarAlbum(Album album)
        {
            this.idAlbumEditar = album.idAlbum;
            this.esNuevo = false;
            btnAgregar.Content = "Actualizar";
            tbNombre.Text = album.nombre;
            cbArtistas.SelectedItem = album.artista;
        }

        private void CargarArtistas()
        {
            artistas.Clear();
            artistas.Add("\tSeleccionar...");
            cbArtistas.ItemsSource = null;
            try
            {
                using (Database db = new Database())
                {
                    var listaArtistas = db.Artista;
                    foreach (var artista in listaArtistas)
                    {
                        artistas.Add(artista.nombre.Trim());
                    }
                    cbArtistas.ItemsSource = artistas;
                }
                cbArtistas.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha sido posible mostrar los artistas, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine("Excepcion manejada al cargar los artistas de la base de datos:\n\n" + ex.Message);
            }
            return;
        }

        private bool ValidarCampos(String nombre, String artista)
        {
            if(nombre == "" || artista == "\tSeleccionar...")
            {
                MessageBox.Show("Debe escribir un nombre y seleccionar un artista", "Campos invalidos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void BtnAgregarNuevoArtista_Click(object sender, RoutedEventArgs e)
        {
            ArtistaRegistro ar = new ArtistaRegistro();
            ar.ShowDialog();
            CargarArtistas();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            String nombre = tbNombre.Text;
            String artista = (String)cbArtistas.SelectedItem;

            if (ValidarCampos(nombre, artista))
            {
                if (esNuevo)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            Album album = new Album();
                            album.nombre = nombre;
                            album.artista = artista;

                            db.Album.Add(album);
                            db.SaveChanges();
                            MessageBox.Show("Se ha registrado el album en el sistema", "Actualización exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No ha sido posible registrar el album, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                        Console.WriteLine("Excepcion manejada al registrar album en la base de datos:\n\n" + ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            Album albObject = (Album)db.Album.Find(idAlbumEditar);
                            albObject.nombre = nombre;
                            albObject.artista = artista;

                            db.Entry(albObject).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            MessageBox.Show("Se ha actualizado el album en el sistema", "Actualización exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No ha sido posible actualizar el album, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                        Console.WriteLine("Excepcion manejada al actualizar album en la base de datos:\n\n" + ex.Message);
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
    }
}
