using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace VistasProyecto.VMs
{
    class MainWindowVM : ObservableObject

    {
        private NavigationService ns;

        public RelayCommand DialogoAñadirSalaCommand { get; }
        public RelayCommand DialogoAñadirSesionComand { get; }
        public RelayCommand ListaSesionesUCCommand { get; }
        public RelayCommand ListaSalasUCCommand { get; }
                
 
    }
}
