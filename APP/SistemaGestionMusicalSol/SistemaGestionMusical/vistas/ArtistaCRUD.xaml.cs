using System;
using System.Collections.Generic;
using System.Dynamic;
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
    /// Lógica de interacción para ArtistaCRUD.xaml
    /// </summary>
    /// 
    class ArtistaTuneado
    {
        private int idArtista;
        private String nombre;
        private String sexo;
        private String tipo;

        public ArtistaTuneado()
        {
        }

        public ArtistaTuneado(int idArtista, String nombre, String sexo, String tipo)
        {
            this.idArtista = idArtista;
            this.nombre = nombre;
            this.sexo = sexo;
            this.tipo = tipo;
        }
        public int IdArtista { get => idArtista; set => idArtista = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Sexo { get => sexo; set => sexo = value; }
        public String Tipo { get => tipo; set => tipo = value; }

        public override string ToString()
        {
            return Nombre;
        }

    }

    public partial class ArtistaCRUD : Window
    {
        private List<Artista> artistas = new List<Artista>();
        private List<String> tipos = new List<String>{
                "\tSeleccionar...", "Solista", "Grupo", "Dueto", "Trio", "Compositor", "DJ"
            };

        private List<String> sexos = new List<String>{
                "\tSeleccionar...", "Masculino", "Femenino", "Indefinido"
            };

        public ArtistaCRUD()
        {
            InitializeComponent();
            CargarArtistas();
            dgArtistas.CanUserAddRows = false;
            dgArtistas.CanUserDeleteRows = false;
            btnActualizar.IsEnabled = false;
            btnEliminar.IsEnabled = false;

        }

        private void CargarArtistas()
        {
            artistas.Clear();
            dgArtistas.ItemsSource = null;

            using (Database db = new Database())
            {
                var listaArtistas = db.Artista;
                List<ArtistaTuneado> artistasTuneados = new List<ArtistaTuneado>();
                foreach (var artista in listaArtistas)
                {
                    ArtistaTuneado at = new ArtistaTuneado();
                    at.IdArtista = artista.idArtista;
                    at.Nombre = artista.nombre.Trim();
                    at.Sexo = sexos[artista.sexo];
                    at.Tipo = tipos[artista.tipo];
                    artistasTuneados.Add(at);
                }
                dgArtistas.ItemsSource = artistasTuneados;
            }
            btnEliminar.IsEnabled = false;
            btnActualizar.IsEnabled = false;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            ArtistaRegistro registro = new ArtistaRegistro();
            registro.ShowDialog();
            CargarArtistas();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            
            Artista artistaEditar = new Artista();
            ArtistaTuneado at = new ArtistaTuneado();
            at = (ArtistaTuneado)dgArtistas.SelectedItem;

            artistaEditar.idArtista = at.IdArtista;
            artistaEditar.nombre = at.Nombre.Trim();
            artistaEditar.tipo = tipos.IndexOf(at.Tipo);
            artistaEditar.sexo = sexos.IndexOf(at.Sexo);

            ArtistaRegistro ar = new ArtistaRegistro();
            ar.CargarArtista(artistaEditar);
            ar.ShowDialog();

            CargarArtistas();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show( "¿Está seguro que desea eliminar al artista seleccionado?", "Eliminar artista", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        ArtistaTuneado at = new ArtistaTuneado();
                        at = (ArtistaTuneado)dgArtistas.SelectedItem;
                        Artista artista = (Artista)db.Artista.Find(at.IdArtista);
                        db.Artista.Remove(artista);
                        db.SaveChanges();
                        MessageBox.Show( "El artista se ha eliminado exitosamente del sistema", "Artista eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                        CargarArtistas();
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show( "No ha sido posible eliminar el artista, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine("Excepcion manejada al registrar artista en la base de datos:\n\n" + ex.Message);
                }
                
            }
        }

        private void TbFiltrar_TextChanged(object sender, TextChangedEventArgs e)
        {
            String texto = tbFiltrar.Text;
            if (texto == "")
            {
                CargarArtistas();
            }
            else
            {
                artistas.Clear();
                dgArtistas.ItemsSource = null;

                using (Database db = new Database())
                {

                    /*
                     * var blogs = from b in context.Blogs
                     * where b.Name.StartsWith("B")
                     * select b;*
                     */

                    var listaArtistas = db.Artista.Where(d=>d.nombre.Contains(texto));
                    List < ArtistaTuneado > artistasTuneados = new List<ArtistaTuneado>();
                    foreach (var artista in listaArtistas)
                    {
                        ArtistaTuneado at = new ArtistaTuneado();
                        at.IdArtista = artista.idArtista;
                        at.Nombre = artista.nombre.Trim();
                        at.Sexo = sexos[artista.sexo];
                        at.Tipo = tipos[artista.tipo];
                        artistasTuneados.Add(at);
                    }
                    dgArtistas.ItemsSource = artistasTuneados;
                }
                btnEliminar.IsEnabled = false;
                btnActualizar.IsEnabled = false;
            }
        }


        private void DgArtustas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEliminar.IsEnabled = true;
            btnActualizar.IsEnabled = true;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
