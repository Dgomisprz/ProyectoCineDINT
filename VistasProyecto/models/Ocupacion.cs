using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistasProyecto.models
{
    public class Ocupacion : ObservableObject
    {
        private string _numSala;
        public string NumSala
        {
            get { return _numSala; }
            set { SetProperty(ref _numSala, value); }
        }

        private string _capacidadSala;
        public string CapacidadSala
        {
            get { return _capacidadSala; }
            set { SetProperty(ref _capacidadSala, value); }
        }

        private string _hora;
        public string Hora
        {
            get { return _hora; }
            set { SetProperty(ref _hora, value); }
        }

        private int _numVentas;
        public int NumVentas
        {
            get { return _numVentas; }
            set { SetProperty(ref _numVentas, value); }
        }
    }

}
