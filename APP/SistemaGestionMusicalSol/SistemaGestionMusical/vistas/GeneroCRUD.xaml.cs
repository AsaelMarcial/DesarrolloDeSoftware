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
    /// Lógica de interacción para GeneroCRUD.xaml
    /// </summary>
    public partial class GeneroCRUD : Window
    {
        private List<Genero> generos = new List<Genero>();

        public GeneroCRUD()
        {
            InitializeComponent();
            dgGeneros.IsReadOnly = true;
            btnEliminar.IsEnabled = false;
            btnActualizar.IsEnabled = false;

            CargarGeneros();
        }

        private void CargarGeneros()
        {
            generos.Clear();
            dgGeneros.ItemsSource = null;

            try
            {
                using (Database db = new Database())
                {
                    var listaGeneros = db.Genero;
                    foreach (var genero in listaGeneros)
                    {
                        genero.nombre = genero.nombre.Trim();
                        genero.nombreCorto = genero.nombreCorto.Trim();
                        generos.Add(genero);
                    }
                    dgGeneros.ItemsSource = generos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha sido posible mostrar los géneros, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine("Excepcion manejada al cargar los géneros de la base de datos:\n\n" + ex.Message);
            }
            
            btnEliminar.IsEnabled = false;
            btnActualizar.IsEnabled = false;
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            GeneroAñadir ga = new GeneroAñadir();
            ga.ShowDialog();
            CargarGeneros();
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Genero genero = new Genero();
            genero = (Genero)dgGeneros.SelectedItem;

            GeneroAñadir ga = new GeneroAñadir();
            ga.CargarGenero(genero);
            ga.ShowDialog();
            CargarGeneros();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Genero generoSeleccionado = new Genero();
            generoSeleccionado = (Genero)dgGeneros.SelectedItem;

            var result = MessageBox.Show( "¿Está seguro que desea eliminar el género seleccionado?", "Eliminar genero", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        Genero genero = (Genero)db.Genero.Find(generoSeleccionado.idGenero);
                        db.Genero.Remove(genero);
                        db.SaveChanges();
                        MessageBox.Show( "El genero se ha eliminado exitosamente del sistema", "Genero eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                        CargarGeneros();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show( "No ha sido posible eliminar el género, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine("Excepcion manejada al registrar artista en la base de datos:\n\n" + ex.Message);
                }

            }
        }

        private void DgGeneros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEliminar.IsEnabled = true;
            btnActualizar.IsEnabled = true;
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
