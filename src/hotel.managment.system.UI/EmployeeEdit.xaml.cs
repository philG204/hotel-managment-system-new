using hotel.managment.system.UI.ViewModels;
using hotel_managment_system.Models;
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
    /// Interaktionslogik für EmployeeEdit.xaml
    /// </summary>
    public partial class EmployeeEdit : Window
    {
        public EmployeeEdit(Employee employee)
        {
            InitializeComponent();
            ViewModelEmployeeEdit vmed = new ViewModelEmployeeEdit(employee);
            this.DataContext = vmed;
        }
    }
}
