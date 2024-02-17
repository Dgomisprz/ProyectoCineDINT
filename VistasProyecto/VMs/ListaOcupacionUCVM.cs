using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistasProyecto.models;
using VistasProyecto.services;

namespace VistasProyecto.VMs
{
    internal class ListaOcupacionUCVM : ObservableObject
    {
        private readonly cinebdService _cinebdService;
        private ObservableCollection<Ocupacion> _ocupacionSalas;

        public ObservableCollection<Ocupacion> OcupacionSalas
        {
            get { return _ocupacionSalas; }
            set
            {
                _ocupacionSalas = value;
                OnPropertyChanged(nameof(OcupacionSalas));
            }
        }

        public ListaOcupacionUCVM()
        {
            _cinebdService = new cinebdService();
            CargarOcupacionSalas();
        }

        private void CargarOcupacionSalas()
        {
            var ocupacion = _cinebdService.getOcupación();
            var listaOcupacionSalas = new ObservableCollection<Ocupacion>();

            foreach (var item in ocupacion)
            {
                var ocupacionSala = new Ocupacion
                {
                    NumSala = item[0].ToString(),
                    CapacidadSala = item[1].ToString(),
                    Hora = item[2].ToString(),
                    NumVentas = (int)item[3]
                };
                listaOcupacionSalas.Add(ocupacionSala);
            }

            OcupacionSalas = listaOcupacionSalas;
        }

    }
}
