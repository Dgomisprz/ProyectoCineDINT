using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    internal class DialogoSesionVM : ObservableObject

    {
        

        private Sesiones _nuevaSesion;

        public Sesiones NuevaSesion
        {
            get { return _nuevaSesion; }
            set { SetProperty(ref _nuevaSesion, value); }
        }

        public DialogoSesionVM() { 
            
        }

        public void Aceptar() {
            WeakReferenceMessenger.Default.Send(new SesionSendMessage(NuevaSesion));
        }
    }
}
