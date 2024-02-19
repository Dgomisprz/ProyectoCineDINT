﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VistasProyecto.VMs;

namespace VistasProyecto
{
    /// <summary>
    /// Lógica de interacción para ListaSesionesUC.xaml
    /// </summary>
    public partial class ListaSesionesUC : UserControl
    {
        private ListaSesionesUCVM vm;
        public ListaSesionesUC()
        {
            InitializeComponent();
            vm = new ListaSesionesUCVM();
            this.DataContext = vm;
        }
    }
}
