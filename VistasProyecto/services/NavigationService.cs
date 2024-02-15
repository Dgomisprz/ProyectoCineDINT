using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VistasProyecto;

namespace VistasProyecto.services
{
    public class NavigationService
    {
        private static UserControl listadoPeliculas = new ListaPeliculasUC();
        private static UserControl listadoSalas = new ListaSalasUC();
        private static UserControl listadoSesiones = new ListaSesionesUC();
        private static UserControl listadoOcupacion = new ListaOcupacionUC();
        public UserControl CargarListaPeliculasUC()
        {
            return listadoPeliculas;
        }
        public bool? AbrirDialogoSala()
        {
            DialogoSala s = new DialogoSala();
            return s.ShowDialogoSala();
        }
        public UserControl CargarListaSalasUC()
        {
            return listadoSalas;
        }
        public bool? AbrirDialogoSesion()
        {
            DialogoSesion d = new DialogoSesion();
            return d.ShowDialog();
        }
        public UserControl CargarListaSesionesUC()
        {
            return listadoSesiones;
        }
        public UserControl CargarFormularioNuevaVentaUC()
        {
            return new FormularioNuevaVentaUC();
        }
        public UserControl CargarListaOcupacionUC()
        {
            return listadoOcupacion;
        }
    }
}
