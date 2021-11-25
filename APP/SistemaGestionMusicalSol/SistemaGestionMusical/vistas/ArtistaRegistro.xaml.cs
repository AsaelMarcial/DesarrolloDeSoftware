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
            using(Entities db = new Entities())
            {
                Artista artObject = new Artista();
                artObject.nombre = txtNombre.Text.ToString();
                artObject.tipo = Int32.Parse(txtSexo.Text.ToString());
                artObject.tipo = Int32.Parse(txtSexo.Text.ToString());
                db.Artistas.Add(artObject);
                db.SaveChanges();
            }
        }

    }
}
