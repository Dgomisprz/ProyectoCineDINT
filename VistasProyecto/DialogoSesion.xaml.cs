using System;
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
using System.Windows.Shapes;
using VistasProyecto.VMs;

namespace VistasProyecto
{
    /// <summary>
    /// Lógica de interacción para DialogoSesion.xaml
    /// </summary>
    public partial class DialogoSesion : Window
    {
        private DialogoSesionVM vm;
        public DialogoSesion()
        {
            InitializeComponent();
            vm = new DialogoSesionVM();
            this.DataContext = vm;
        }
        private void AceptarButton1_Click(object sender, RoutedEventArgs e)
        {
            vm.Aceptar();
            this.DialogResult = true;
        }
    }
}
