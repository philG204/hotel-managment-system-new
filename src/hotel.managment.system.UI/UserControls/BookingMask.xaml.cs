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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hotel.managment.system.UI.UserControls
{
    /// <summary>
    /// Interaktionslogik für BookingMask.xaml
    /// </summary>
    public partial class BookingMask : UserControl
    {
        public BookingMask()
        {
            InitializeComponent();
            ViewModelBookingMask vmbm = new ViewModelBookingMask();
            this.DataContext = vmbm;
        }
    }
}
