using GalaSoft.MvvmLight.Command;
using hotel.managment.system.Service;
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
    public class ViewModelEmployee
    {
        private EmployeeService employeeService = new EmployeeService();

        private Employee model;

        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        private ICommand saveCommand;
        private ICommand deleteCommand;
        private ICommand editCommand;

        public ViewModelEmployee()
        {
            saveCommand = new RelayCommand(Save);
            deleteCommand = new RelayCommand(Delete);
            editCommand = new RelayCommand(Edit);

            employees = employeeService.GetAll();
        }

        private void Save()
        {

        }

        private void Delete()
        {

        }

        private void Edit()
        {

        }

        public ObservableCollection<Employee> Employees { get => employees; }
        public int EmployeeID { get => model.EmployeeID; set => model.EmployeeID = value; }
        public string Name { get => model.Name; set => model.Name = value; }
        public string Surename { get => model.Surename; set => model.Surename = value; }
        public string Street { get => model.Street; set => model.Street = value; }
        public int Housenumber { get => model.Housenumber; set => model.Housenumber = value; }
        public long PostalCode { get => model.PostalCode; set => model.PostalCode = value; }
        public string City { get => model.City; set => model.City = value; }
        public long PhoneNumber { get => model.PhoneNumber; set => model.PhoneNumber = value; }
        public string Email { get => model.Email; set => model.Email = value; }
        public string Password { get => model.Password; set => model.Password = value; }
        public ICommand SaveCommand { get => saveCommand; set => saveCommand = value; }
        public ICommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }
        public ICommand EditCommand { get => editCommand; set => editCommand = value; }
    }
}
