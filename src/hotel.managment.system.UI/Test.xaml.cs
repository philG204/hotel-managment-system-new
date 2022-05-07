using hotel.managment.system.UI.ViewModels;
using hotel_managment_system;
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

namespace hotel.managment.system.UI
{
    /// <summary>
    /// Interaktionslogik für Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public Test(Booking booking)
        {
            InitializeComponent();
            ViewModelRoomManagment vm = new ViewModelRoomManagment(booking);
            this.DataContext = vm;

        }
    }
}
