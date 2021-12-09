using SistemaGestionMusical.vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionMusical.interfaces
{
    public interface ObservadorRespuesta
    {
        void ObtenerCancion(CancionTuneada cancion);
    }
}
