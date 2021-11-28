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
    /// Lógica de interacción para CancionRegistro.xaml
    /// </summary>
    public partial class CancionRegistro : Window
    {
        public CancionRegistro()
        {
            InitializeComponent();
        }

        private void CargarArtistas()
        {

        }

        private void CargarPrioridades()
        {
            List<String> prioridades = new List<String>();
            prioridades.Add("Alta");
            prioridades.Add("Media");
            prioridades.Add("Baja");
            cbPrioridad.ItemsSource = prioridades;
        }

        private void CargarGeneros()
        {

        }

        private void CargarCategorias()
        {

        }

        private void CargarAlbumes()
        {

        }

        private bool ValidarCampos(String titulo, String radio, String duracion, String duracionIntro, int idGenero, int idCategoria, int idAlbum, int idArtista, String prioridad)
        {
            if (titulo == "" || radio == "" || duracion == "" || duracionIntro == "")
            {
                MessageBox.Show("Debes llenar todos los campos");
                return false;
            }

            if(idGenero==0 || idCategoria==0 || idAlbum==0 || idArtista==0 || prioridad=="")
            {
                MessageBox.Show("Debes seleccionar una opción en todas las cajas de opciones");
                return false;
            }
                
            return true;
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            String titulo = tbTitulo.Text;
            String radio = tbRadio.Text;
            String duracion = tbDuracion.Text;
            String duracionIntro = tbDuracion.Text;

            //Combobox
            Genero genero = new Genero();
            genero = (Genero)cbGenero.SelectedItem;

            Categoria categoria = new Categoria();
            categoria = (Categoria)cbCategoria.SelectedItem;

            Album album = new Album();
            album = (Album)cbAlbum.SelectedItem;

            Artista artista = new Artista();
            artista = (Artista)cbArtista.SelectedItem;

            String prioridadString = cbPrioridad.SelectedItem.ToString();
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

            if(ValidarCampos(titulo, radio, duracion, duracionIntro, genero.idGenero, categoria.idCategoria, album.idAlbum, artista.idArtista, prioridadString))
            {
                RegistrarCancion(titulo, radio, duracion, duracionIntro, genero.idGenero, categoria.idCategoria, album.idAlbum, artista.idArtista, prioridad, activa);
            }
            
        }

        private void RegistrarCancion(String titulo, String radio, String duracion, String duracionIntro, int idGenero, int idCategoria, int idAlbum, int idArtista, int prioridad, bool activa)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    Cancion canObject = new Cancion();
                    canObject.activa = activa;
                    canObject.artista_id = idArtista;
                    canObject.album_id = idAlbum;
                    canObject.categoria_id = idCategoria;
                    //Falta clave?
                    canObject.genero_id = idGenero;
                    canObject.nombre = titulo;
                    //Falta observacion?
                    canObject.prioridad = prioridad;
                    canObject.radio = radio;
                    canObject.tiempo = duracion;
                    canObject.tiempoIntro = duracionIntro;

                    db.Cancions.Add(canObject);
                    db.SaveChanges();
                    MessageBox.Show("Registro exitoso");
                }
            }catch (Exception ex)
            {
                Console.WriteLine("Error en la subida de datos de Cancion con Entity Framework");
                MessageBox.Show("Ha ocurrido un error, intente más tarde: código EFI01");
            }
            finally
            {
                this.Close();
            }
            
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {

            var result = MessageBox.Show("Está seguro que desea cancelar", "Cancelar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            
        }
    }
}
