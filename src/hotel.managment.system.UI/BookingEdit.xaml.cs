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
    /// Interaktionslogik für BookingEdit.xaml
    /// </summary>
    public partial class BookingEdit : Window
    {
        public BookingEdit(Booking booking)
        {
            InitializeComponent();
            ViewModelBookingEdit bevm = new ViewModelBookingEdit(booking);
            this.DataContext = bevm;
        }
    }
}
