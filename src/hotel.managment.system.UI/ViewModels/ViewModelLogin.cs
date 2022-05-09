using GalaSoft.MvvmLight.Command;
using hotel.managment.system.Service;
using hotel_managment_system;
using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace hotel.managment.system.UI.ViewModels
{
    public class ViewModelLogin
    {
        private string password;
        private string userName;

        private ICommand login;

        public ViewModelLogin()
        {
            login = new RelayCommand(CheckLogin);
        }

        private void CheckLogin()
        {
            if ()
            {
                MainWindow mw = new MainWindow();
                mw.ShowDialog();
            }
            else
            {
                // Showing error window
            }
        }

        public string Password { get => password; set => userName = value; }
        public string UserName { get => userName; set => userName = value; }
        public ICommand Login { get => login; set => login = value; }
    }
}
