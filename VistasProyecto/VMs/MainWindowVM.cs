using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using VistasProyecto.services;

namespace VistasProyecto.VMs
{
    class MainWindowVM : ObservableObject

    {
        private NavegacionServicio ns;
       
        private UserControl? contenidoMostrar;
        public UserControl? ContenidoMostrar
        {
            get { return contenidoMostrar; }
            set { SetProperty(ref contenidoMostrar, value); }
        }
       
        public RelayCommand ListaSesionesUCCommand { get; }
        public RelayCommand ListaSalasUCCommand { get; }

        public RelayCommand ListaPeliculasUCCommand { get; }
        public RelayCommand FNuevaVentaUCCommand { get; }
        public RelayCommand LOcupacionUCCommand { get; }    


        public MainWindowVM() {
            ns = new NavegacionServicio();

           
            ListaSesionesUCCommand = new RelayCommand(CargarUCListaSesiones);
            ListaSalasUCCommand = new RelayCommand(CargarUCListaSalas);
            ListaPeliculasUCCommand = new RelayCommand(CargarUCListaPeliculas);
            FNuevaVentaUCCommand = new RelayCommand(CargarUCVentas);
            LOcupacionUCCommand = new RelayCommand(CargarUCListaOcupacion);

        }

        public void CargarUCListaSesiones() {
            contenidoMostrar = ns.CargarListaSesionesUC();
        }

        public void CargarUCListaSalas()
        {
            contenidoMostrar = ns.CargarListaSalasUC();
        }

        public void CargarUCListaPeliculas()
        {
            contenidoMostrar = ns.CargarListaPeliculasUC();
        }

        public void CargarUCVentas()
        {
            contenidoMostrar = ns.CargarFormularioNuevaVentaUC();
        }

        public void CargarUCListaOcupacion()
        {
            contenidoMostrar = ns.CargarListaOcupacionUC(); 
        }

    }
}
