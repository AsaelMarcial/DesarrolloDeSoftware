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
        public ArtistaRegistro()
        {
            InitializeComponent();
            CargarCombobox();
        }

        private void CargarCombobox()
        {
            List<String> tipos = new List<String>
            {
                "\tSeleccionar...", "Solista", "Grupo", "Dueto", "Trio", "Compositor", "DJ"
            };
            cbTipo.ItemsSource = tipos;
            
            List<String> sexos = new List<String>
            {
                "\tSeleccionar...", "Masculino", "Femenino", "Indefinido"
            };
            cbSexo.ItemsSource = sexos;

            if (esNuevo)
            {
                cbSexo.SelectedIndex = 0;
                cbTipo.SelectedIndex = 0;
            }
            

        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            String nombre = tbNombre.Text;
            String sexoStr = cbSexo.SelectedItem.ToString();
            String tipoStr = cbTipo.SelectedItem.ToString();

            if (ValidarCampos(nombre, sexoStr, tipoStr))
            {
                int sexo = -1;
                int tipo = -1;

                switch (sexoStr)
                {
                    case "Masculino":
                        sexo = 0;
                        break;
                    case "Femenino":
                        sexo = 1;
                        break;
                    case "Indefinido":
                        sexo = 2;
                        break;
                }
                switch (tipoStr)
                {
                    case "Solista":
                        tipo = 0;
                        break;
                    case "Grupo":
                        tipo = 1;
                        break;
                    case "Dueto":
                        tipo = 2;
                        break;
                    case "Trio":
                        tipo = 3;
                        break;
                    case "Compositor":
                        tipo = 4;
                        break;
                    case "DJ":
                        tipo = 5;
                        break;
                }

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
                        MessageBox.Show("Se ha registrado el artista en el sistema", "Registro exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No ha sido posible registrar el artista, intente de nuevo más tarde", "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine("Excepcion manejada al registrar artista en la base de datos:\n\n"+ex.Message);
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
            var result = MessageBox.Show("Está seguro que desea cancelar", "Cancelar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
