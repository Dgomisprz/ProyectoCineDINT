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
        private NavegacionServicio ns;
        public RelayCommand DialogoAñadirSalasCommand { get; }
        private ObservableCollection<Salas> _salas = new ObservableCollection<Salas>();

        public ObservableCollection<Salas> Salas
        {
            get { return _salas; }
            set { SetProperty(ref _salas, value); }
        }
        private cinebdService _servicio;

        public ListaSalasUCVM()
        {
             ns = new NavegacionServicio(); 
            
            _servicio = new cinebdService();
            Salas = new ObservableCollection<Salas>(_servicio.getAllSalas());
            DialogoAñadirSalasCommand = new RelayCommand(AbrirVentanaSalas);

            WeakReferenceMessenger.Default.Register<SalaSendMessage>(this, (r, m) =>
            {
                Salas.Add(m.Value);
            });
        }
        public void AbrirVentanaSalas() {
            bool? resultado = ns.AbrirDialogoSala();
        }
    }
}
