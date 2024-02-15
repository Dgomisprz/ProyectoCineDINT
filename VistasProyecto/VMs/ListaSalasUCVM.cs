using CommunityToolkit.Mvvm.ComponentModel;
using ProyectoCine.models;
using ProyectoCine.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistasProyecto.VMs
{
    class ListaSalasUCVM : ObservableObject
    {
        private ObservableCollection<Salas> _salas;

        public ObservableCollection<Salas> Salas
        {
            get { return _salas; }
            set { SetProperty(ref _salas, value); }
        }
        private cinebdService _servicio;

        public ListaSalasUCVM()
        {
            _servicio = new cinebdService();
            Salas = new ObservableCollection<Salas>(_servicio.getAllSalas());
        }
    }
}
