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
    /// Lógica de interacción para CategoriaCRUD.xaml
    /// </summary>
    public partial class CategoriaCRUD : Window
    {
        List<Categoria> categorias = new List<Categoria>();

        public CategoriaCRUD()
        {
            InitializeComponent();
            dgCategorias.SelectionMode = DataGridSelectionMode.Single;
            dgCategorias.AutoGenerateColumns = false;
            dgCategorias.IsReadOnly = true;
            dgCategorias.CanUserAddRows = false;
            this.ResizeMode = ResizeMode.NoResize;
            btnEliminar.IsEnabled = false;
            btnActualizar.IsEnabled = false;

            CargarCategorias();
        }

        private void CargarCategorias()
        {
            categorias.Clear();
            dgCategorias.ItemsSource = null;

            try
            {
                using (Database db = new Database())
                {
                    var listaCategorias = db.Categoria;
                    foreach (var categoria in listaCategorias)
                    {
                        categoria.descripcion = categoria.descripcion.Trim();
                        categorias.Add(categoria);
                    }
                    dgCategorias.ItemsSource = categorias;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha sido posible mostrar las categorías, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine("Excepcion manejada al cargar las categorías de la base de datos:\n\n" + ex.Message);
            }
            finally
            {
                btnEliminar.IsEnabled = false;
                btnActualizar.IsEnabled = false;
            }

            
        }

        private void BtnAñadir_Click(object sender, RoutedEventArgs e)
        {
            CategoriaAñadir ca = new CategoriaAñadir();
            ca.ShowDialog();
            CargarCategorias();
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoria = new Categoria();
            categoria = (Categoria)dgCategorias.SelectedItem;

            CategoriaAñadir ca = new CategoriaAñadir();
            ca.CargarCategoria(categoria);
            ca.ShowDialog();
            CargarCategorias();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoriaSeleccionada = new Categoria();
            categoriaSeleccionada = (Categoria)dgCategorias.SelectedItem;

            var result = MessageBox.Show("¿Está seguro que desea eliminar la categoría seleccionada?", "Eliminar categoría", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        Categoria categoria = (Categoria)db.Categoria.Find(categoriaSeleccionada.idCategoria);
                        db.Categoria.Remove(categoria);
                        db.SaveChanges();
                        MessageBox.Show("La categoría se ha eliminado exitosamente del sistema", "Categoría eliminada", MessageBoxButton.OK, MessageBoxImage.Information);
                        CargarCategorias();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No ha sido posible eliminar la categoría, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine("Excepcion manejada al registrar la categoría en la base de datos:\n\n" + ex.Message);
                }

            }
        }

        private void DgCategorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
