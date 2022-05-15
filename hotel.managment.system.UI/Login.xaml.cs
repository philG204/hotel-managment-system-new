using hotel.managment.system.Service;
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

namespace hotel.managment.system.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeService employeeService = new EmployeeService();

            if (employeeService.CheckPassword(password.Password, name.Text))
            {
                MainWindow mw = new MainWindow();
                mw.ShowDialog();    
            }
            else
            {
                password.Password = "";
                name.Text = "";
                MessageBox.Show("Passwort oder Name falsch");
            }
        }
    }
}
