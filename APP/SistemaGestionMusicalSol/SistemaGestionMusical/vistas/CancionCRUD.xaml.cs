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
    /// Lógica de interacción para CancionCRUD.xaml
    /// </summary>
    public partial class CancionCRUD : Window
    {
        List<Cancion> canciones = new List<Cancion>();

        public CancionCRUD()
        {
            InitializeComponent();
            CargarCanciones();
        }

        private void CargarCanciones()
        {
            using (Entities db = new Entities())
            {
                var listcanciones = db.Cancions;
                foreach(var oCancions in listcanciones){
                    canciones.Add(oCancions);
                }
            }
            dgCanciones.ItemsSource = canciones;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            CancionRegistro cancionRegistroVentana = new CancionRegistro();
            cancionRegistroVentana.ShowDialog();
        }
    }
}
