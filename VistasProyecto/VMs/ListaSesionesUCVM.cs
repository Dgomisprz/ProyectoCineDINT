using CommunityToolkit.Mvvm.ComponentModel;
using ProyectoCine.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistasProyecto.VMs
{
    class ListaSesionesUCVM : ObservableObject
    {
        private ObservableCollection<Sesiones> _sesion;

        public ObservableCollection<Sesiones> Sesion
        {
            get { return _sesion; }
            set { SetProperty(ref _sesion, value); }
        }
    }
}
