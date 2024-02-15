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
    internal class ListaPeliculasUCVM : ObservableObject
    {
        private ObservableCollection<Peliculas> _peliculas;

        public ObservableCollection<Peliculas> Peliculas
        {
            get { return _peliculas; }
            set { SetProperty(ref _peliculas, value); }
        }
        private cinebdService _servicio;

        public ListaPeliculasUCVM() 
        { 
            _servicio = new cinebdService();
            Peliculas = new ObservableCollection<Peliculas>(_servicio.getAllPeliculas());
        }


    }
}
