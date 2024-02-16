using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistasProyecto.models;
using VistasProyecto.Models;

namespace VistasProyecto.VMs
{
    class DialogoSalaVM : ObservableObject
    {
        private Salas _nuevaSala;
        public Salas NuevaSala {
            get { return _nuevaSala; }
            set { SetProperty(ref _nuevaSala, value); }
        }

        public DialogoSalaVM() { }

        public void Aceptar()
        {
            WeakReferenceMessenger.Default.Send(new SalaSendMessage(NuevaSala));
        }



    }
}
