using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VistasProyecto.models;
using VistasProyecto.Models;
using VistasProyecto.services;

namespace VistasProyecto.VMs
{
    class ListaSalasUCVM : ObservableObject
    {
        private NavegacionServicio navs;
        public RelayCommand DialogoSalasCommand { get; }
        private ObservableCollection<Salas> _salas = new ObservableCollection<Salas>();

        public ObservableCollection<Salas> Salas
        {
            get { return _salas; }
            set { SetProperty(ref _salas, value); }
        }
        private Salas _salaSeleccionada;

        public Salas SalaSeleccionada
        {
            get { return _salaSeleccionada; }
            set { SetProperty(ref _salaSeleccionada, value); }
        }
        private cinebdService _servicio;

        public ListaSalasUCVM()
        {
             navs = new NavegacionServicio(); 
            
            _servicio = new cinebdService();
            Salas = new ObservableCollection<Salas>(_servicio.getAllSalas());
            DialogoSalasCommand = new RelayCommand(AbrirVentanaSalas);

            
            WeakReferenceMessenger.Default.Register<SalaSendMessage>(this, (vm, mensaje) =>
            {
                var viewModel = vm as ListaSalasUCVM;
                if (viewModel != null)
                {
                    // Verificar si la sala ya existe en la lista
                    var salaExistente = viewModel.Salas.FirstOrDefault(s => s.IdSala == mensaje.Value.IdSala);
                    if (salaExistente != null)
                    {
                        // Si la sala existe, actualizar sus propiedades
                        salaExistente.Numero = mensaje.Value.Numero;
                        salaExistente.Capacidad = mensaje.Value.Capacidad;
                        salaExistente.Disponible = mensaje.Value.Disponible;
                    }
                    else
                    {
                        // Si la sala no existe, agregarla a la lista
                        viewModel.Salas.Add(mensaje.Value);
                        _servicio.anyadirSala(mensaje.Value);

                    }
                }
            });
        }
        public void AbrirVentanaSalas() {
          bool? resultado = navs.AbrirDialogoSala();
        }
    }
}
