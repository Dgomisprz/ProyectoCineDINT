using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using VistasProyecto.services;
using System.IO;


namespace VistasProyecto.VMs
{
    class MainWindowVM : ObservableObject

    {
        private NavegacionServicio ns;
       
        private UserControl contenidoMostrar;
        public UserControl ContenidoMostrar
        {
            get { return contenidoMostrar; }
            set { SetProperty(ref contenidoMostrar, value); }
        }
        public RelayCommand MostrarInfo { get; }
       
        public RelayCommand ListaSesionesUCCommand { get; }
        public RelayCommand ListaSalasUCCommand { get; }

        public RelayCommand ListaPeliculasUCCommand { get; }
        public RelayCommand FNuevaVentaUCCommand { get; }
        public RelayCommand LOcupacionUCCommand { get; }    


        public MainWindowVM() {
            ns = new NavegacionServicio();
            ContenidoMostrar = new UserControl();


            ListaSesionesUCCommand = new RelayCommand(CargarUCListaSesiones);
            ListaSalasUCCommand = new RelayCommand(CargarUCListaSalas);
            ListaPeliculasUCCommand = new RelayCommand(CargarUCListaPeliculas);
            FNuevaVentaUCCommand = new RelayCommand(CargarUCVentas);
            LOcupacionUCCommand = new RelayCommand(CargarUCListaOcupacion);
            MostrarInfo = new RelayCommand(AbrirDocumento);

        }

        public void CargarUCListaSesiones() {
            ContenidoMostrar = ns.CargarListaSesionesUC();
        }

        public void CargarUCListaSalas()
        {
            ContenidoMostrar = ns.CargarListaSalasUC();
        }

        public void CargarUCListaPeliculas()
        {
            ContenidoMostrar = ns.CargarListaPeliculasUC();
        }

        public void CargarUCVentas()
        {
            ContenidoMostrar = ns.CargarFormularioNuevaVentaUC();
        }

        public void CargarUCListaOcupacion()
        {
            ContenidoMostrar = ns.CargarListaOcupacionUC(); 
        }

        public void AbrirDocumento() {
            System.Diagnostics.Process.Start("ProyectoCine.chm");
        }
    }
}
