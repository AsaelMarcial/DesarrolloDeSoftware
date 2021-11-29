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
        public ArtistaRegistro()
        {
            InitializeComponent();
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            using(Database db = new Database())
            {
                Artista artObject = new Artista();

                artObject.tipo = 1;
                artObject.nombre = txtNombre.Text.ToString();
                artObject.sexo = Int32.Parse(txtSexo.Text.ToString());
                db.Artista.Add(artObject);
                db.SaveChanges();
            }
        }

    }
}
