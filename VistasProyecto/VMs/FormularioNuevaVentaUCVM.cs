using CommunityToolkit.Mvvm.ComponentModel;
using ProyectoCine.models;
using ProyectoCine.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistasProyecto.models;
using VistasProyecto.services;

namespace VistasProyecto.VMs
{
    internal class FormularioNuevaVentaUCVM : ObservableObject
    {

        private cinebdService _cineServicio;
        
        private Ventas _nuevaVenta;
        public Ventas NuevaVenta {
            get { return _nuevaVenta; }
            set { SetProperty(ref _nuevaVenta, value); }
        }

        public FormularioNuevaVentaUCVM() { }

        public void Aceptar() { 
            
            _cineServicio = new cinebdService();
            _cineServicio.anyadirVenta(NuevaVenta);
        }
    }
}
