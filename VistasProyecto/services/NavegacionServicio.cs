﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VistasProyecto;

namespace VistasProyecto.services
{
    public class NavegacionServicio
    {
        private UserControl listadoPeliculas = new ListaPeliculasUC();
        private static UserControl listadoSalas = new ListaSalasUC();
        private static UserControl listadoSesiones = new ListaSesionesUC();
        private UserControl listadoOcupacion = new ListaOcupacionUC();
        

        public NavegacionServicio() 
        { 
        
        }

        public UserControl CargarListaPeliculasUC()
        {
            return listadoPeliculas;
        }
        public bool? AbrirDialogoSala()
        {
            DialogoSala s = new DialogoSala();
            return s.ShowDialog();
        }
        public UserControl CargarListaSalasUC()
        {
            if (listadoSalas == null)
            {
                listadoSalas = new ListaSalasUC();
            }
            return listadoSalas;

        }
        public bool? AbrirDialogoSesion()
        {
            DialogoSesion d = new DialogoSesion();
            return d.ShowDialog();
        }
        public UserControl CargarListaSesionesUC()
        {
            return listadoSesiones;
        }
        public UserControl CargarFormularioNuevaVentaUC()
        {
            return new FormularioNuevaVentaUC();
        }
        public UserControl CargarListaOcupacionUC()
        {
            return listadoOcupacion;
        }
    }
}
