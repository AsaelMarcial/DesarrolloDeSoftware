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
    /// Lógica de interacción para CategoriaAñadir.xaml
    /// </summary>
    public partial class CategoriaAñadir : Window
    {
        private bool esNuevo = true;
        private int idCategoriaEditable = -1;

        public CategoriaAñadir()
        {
            InitializeComponent();
        }

        public void CargarCategoria(Categoria categoria)
        {
            this.idCategoriaEditable = categoria.idCategoria;
            tbnNombre.Text = categoria.descripcion;
            esNuevo = false;
            btnAgregar.Content = "Actualizar";
        }

        private bool ValidarCampos(String nombre)
        {
            if(nombre == ""){
                MessageBox.Show("Debe llenar el campo nombre", "Campo vacío", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            String nombre = tbnNombre.Text;
            if (ValidarCampos(nombre))
            {
                if (esNuevo)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            Categoria catObject = new Categoria();
                            catObject.descripcion = nombre;

                            db.Categoria.Add(catObject);
                            db.SaveChanges();
                            MessageBox.Show("Se ha registrado la categoría en el sistema", "Registro exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                    }catch(Exception ex)
                    {
                        MessageBox.Show("No ha sido posible registrar la categoría, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                        Console.WriteLine("Excepcion manejada al registrar la categoría en la base de datos:\n\n" + ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            Categoria catObject = (Categoria)db.Categoria.Find(idCategoriaEditable);
                            catObject.descripcion = nombre;

                            db.Entry(catObject).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            MessageBox.Show("Se ha actualizado la categoría en el sistema", "Actualización exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No ha sido posible actualizar la categoría, intente de nuevo más tarde\n" + ex.Message, "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                        Console.WriteLine("Excepcion manejada al actualizar la categoría en la base de datos:\n\n" + ex.Message);
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
