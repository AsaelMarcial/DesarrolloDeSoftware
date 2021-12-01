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
    /// Lógica de interacción para GeneroAñadir.xaml
    /// </summary>
    public partial class GeneroAñadir : Window
    {
        private bool esNuevo = true;
        private int idGeneroEditar = -1;

        public GeneroAñadir()
        {
            InitializeComponent();
        }

        public void CargarGenero(Genero genero)
        {
            this.idGeneroEditar = genero.idGenero;
            tbNombre.Text = genero.nombre;
            tbNombreCorto.Text = genero.nombreCorto;
            esNuevo = false;
            btnAgregar.Content = "Actualizar";
        }

        private bool ValidarCampos(String nombre, String nombreCorto)
        {
            if (nombre == "" || nombreCorto == "")
            {
                MessageBox.Show( "Debe escribir un nombre y un nombre corto", "Campos invalidos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            String nombre = tbNombre.Text;
            String nombreCorto = tbNombreCorto.Text;
            if(ValidarCampos(nombre, nombreCorto))
            {
                if (esNuevo)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            Genero objGenero = new Genero();
                            objGenero.nombre = nombre;
                            objGenero.nombreCorto = nombreCorto;

                            db.Genero.Add(objGenero);
                            db.SaveChanges();
                            MessageBox.Show( "Se ha registrado el género en el sistema", "Registro exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No ha sido posible registrar el género, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                        Console.WriteLine("Excepcion manejada al registrar género en la base de datos:\n\n" + ex.Message);
                    }

                }
                else
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            Genero genObject = (Genero)db.Genero.Find(idGeneroEditar);
                            genObject.nombre = nombre;
                            genObject.nombreCorto = nombreCorto;

                            db.Entry(genObject).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            MessageBox.Show( "Se ha actualizado el género en el sistema", "Actualización exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No ha sido posible registrar el género, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                        Console.WriteLine("Excepcion manejada al registrar género en la base de datos:\n\n" + ex.Message);
                    }
                }
                
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
