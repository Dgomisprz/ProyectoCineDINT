using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistasProyecto.models;
using VistasProyecto.Models;
using VistasProyecto.services;

namespace VistasProyecto.VMs
{
    class ListaSesionesUCVM : ObservableObject
    {

        private NavegacionServicio ns2;
        public RelayCommand EliminarSesionCommand { get; }
        public RelayCommand DialogoAñadirSesionCommand { get; }
        private ObservableCollection<Sesiones> _sesion;

        public ObservableCollection<Sesiones> Sesion
        {
            get { return _sesion; }
            set { SetProperty(ref _sesion, value); }
        }
        private Sesiones _sesionSeleccionada;

        public Sesiones SesionSeleccionada
        {
            get { return _sesionSeleccionada; }
            set { SetProperty(ref _sesionSeleccionada, value); }
        }

        private cinebdService _servicio;

        public ListaSesionesUCVM()
        {
             ns2 = new NavegacionServicio();
            _servicio = new cinebdService();
            Sesion = new ObservableCollection<Sesiones>(_servicio.getAllSesiones());
            DialogoAñadirSesionCommand = new RelayCommand(AbrirVentanaSesion);
            EliminarSesionCommand = new RelayCommand(EliminarSesion);
            WeakReferenceMessenger.Default.Register<SesionSendMessage>(this, (r, m) =>
            {
                Sesion.Add(m.Value);
               
                
            });

        }

        public void AbrirVentanaSesion() {
            bool? resultado = ns2.AbrirDialogoSesion();
        }
        public void EliminarSesion()
        {
            _servicio.eliminarSesion(SesionSeleccionada.IdSesion);
            Sesion.Remove(SesionSeleccionada);
        }
    }
}
