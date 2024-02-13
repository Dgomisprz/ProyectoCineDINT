using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistasProyecto.VMs
{
    class DialogoSalaVM : ObservableObject
    {
        private String _nuevaSala;
        public String NuevaSala{
            get { return _nuevaSala; }
            set { SetProperty(ref _nuevaSala, value); }
        }
        private String _salaSeleccionada;
        public String SalaSeleccionada
        {
            get { return _salaSeleccionada; }
            set { SetProperty(ref _salaSeleccionada, value); }
        }

        public void AñadirSalas()
        {
            WeakReferenceMessenger.Default.Send(new DialogoSalaMessage(NuevaSala));
        }

        public void ModificarSala() {
            WeakReferenceMessenger.Default.Register(new DialogoSalaMessage(SalaSeleccionada));
        }

    }
}
