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
    /// Lógica de interacción para ArtistaRegistro.xaml
    /// </summary>
    public partial class ArtistaRegistro : Window
    {
        private bool esNuevo = true;
        int idArtistaEditable = -1;

        private List<String> tipos = new List<String>{
                "\tSeleccionar...", "Solista", "Grupo", "Dueto", "Trio", "Compositor", "DJ"
            };
        
        private List<String> sexos = new List<String>{
                "\tSeleccionar...", "Masculino", "Femenino", "Indefinido"
            };
        public ArtistaRegistro()
        {
            InitializeComponent();
            cbTipo.ItemsSource = tipos;
            cbSexo.ItemsSource = sexos;
            if (esNuevo)
            {
                cbSexo.SelectedIndex = 0;
                cbTipo.SelectedIndex = 0;
            }
        }

        public void CargarArtista(Artista artista)
        {
            this.idArtistaEditable = artista.idArtista;
            esNuevo = false;
            btnRegistrar.Content = "Actualizar";
            tbNombre.Text = artista.nombre;
            cbSexo.SelectedValue = sexos[artista.sexo];
            cbTipo.SelectedValue = tipos[artista.tipo];
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            String nombre = tbNombre.Text;
            String sexoStr = cbSexo.SelectedItem.ToString();
            String tipoStr = cbTipo.SelectedItem.ToString();

            if (ValidarCampos(nombre, sexoStr, tipoStr))
            {
                /* Ojo: se guarda el indice de la lista previamente
                 * generada, del objeto que sea igual al string 
                 * seleccionado en el combobox  */
                int sexo = sexos.IndexOf(sexoStr);
                int tipo = tipos.IndexOf(tipoStr);
                if (esNuevo) // Registro
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            Artista artObject = new Artista();
                            artObject.nombre = nombre;
                            artObject.sexo = sexo;
                            artObject.tipo = tipo;

                            db.Artista.Add(artObject);
                            db.SaveChanges();
                            MessageBox.Show( "Se ha registrado el artista en el sistema", "Registro exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show( "No ha sido posible registrar el artista, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                        Console.WriteLine("Excepcion manejada al registrar artista en la base de datos:\n\n" + ex.Message);
                    }
                }
                else //Actualización
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            Artista artObject = (Artista)db.Artista.Find(idArtistaEditable);
                            artObject.nombre = nombre;
                            artObject.sexo = sexo;
                            artObject.tipo = tipo;

                            db.Entry(artObject).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            MessageBox.Show( "Se ha actualizado el artista en el sistema", "Actualización exitosa",  MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No ha sido posible actualizar el artista, intente de nuevo más tarde\n"+ex.Message, "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                        Console.WriteLine("Excepcion manejada al actualizar artista en la base de datos:\n\n" + ex.Message);
                    }
                }
                
                
            }
        }

        private bool ValidarCampos(String nombre, String sexo, String tipo)
        {
            if(nombre=="" || sexo=="\tSeleccionar..." || tipo== "\tSeleccionar...")
            {
                MessageBox.Show("Debe llenar el campo nombre y debe seleccionar un sexo, y tipo", "Campos vacíos",MessageBoxButton.OK,MessageBoxImage.Warning);
                return false;
            }
                return true;
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
