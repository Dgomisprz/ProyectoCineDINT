using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistasProyecto.models
{
    public  class Sesiones:ObservableObject
    {
        private int idSesion;
        public int IdSesion
        {
            get { return idSesion; } 
            set { SetProperty(ref idSesion, value); }
        }
        private int pelicula;
        public int Pelicula
        {
            get { return pelicula; }
            set { SetProperty(ref pelicula, value); }
        }
        private int sala;
        public int Sala
        {
            get { return sala; }
            set { SetProperty(ref sala, value); }
        }
        private string hora;
        public string Hora
        {
            get { return hora; }
            set { SetProperty(ref hora, value); }
        }

        public Sesiones(int idSesion, int pelicula, int sala, string hora)
        {
            IdSesion = idSesion;
            Pelicula = pelicula;
            Sala = sala;
            Hora = hora;
        }

        public Sesiones() { }
    }
}
