using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using hotel.managment.system.Service;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.managment.system.UI.Core;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace hotel.managment.system.UI.MVVM.ViewModel
{
    public class ViewModelEmployeeMask : ObservableObject
    {
        private EmployeeService employeeService = new EmployeeService();

        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        private Employee selectedEmployee;

        private ICommand saveCommand;
        private ICommand editCommand;
        private ICommand deleteCommand;

        private Employee model;

        public ViewModelEmployeeMask()
        {
            model = new Employee();
            employees = employeeService.GetAll();

            saveCommand = new RelayCommand(Save);
            editCommand = new RelayCommand(Edit);
            deleteCommand = new RelayCommand(Delete);
        }

        private void Save()
        {
            int id;
            do
            {
                Random rand = new Random();
                id = rand.Next(1, 10000);
            }
            while (!employeeService.CheckIDs(id.ToString()));

            model.EmployeeID = id;

            if (Password == null || Surename == null || Name == null || PhoneNumber == null || Email == null)
            {
                MessageBox.Show("Es wurde ein Feld vergessen");
            }
            else
            {
                employeeService.Save(model);
                model = null;
            }
        }

        private void Edit()
        {
            model = selectedEmployee;
        }

        private void Delete()
        {
            MessageBox.Show(selectedEmployee.EmployeeID.ToString());
            //employeeService.Delete(selectedEmployee);
        }

        public ObservableCollection<Employee> Employees { get { return employees; } set { employees = value; OnPropertyChanged(); } }
        public Employee SelectedEmployee { get { return selectedEmployee; } set { selectedEmployee = value; OnPropertyChanged(); } }

        public int EmployeeID { get => model.EmployeeID; set { model.EmployeeID = value; OnPropertyChanged(); } }
        public string Name { get => model.Name; set { model.Name = value; OnPropertyChanged(); } }  
        public string Surename { get => model.Surename; set { model.Surename = value; OnPropertyChanged(); } }  
        public string Street { get => model.Street; set { model.Street = value; OnPropertyChanged(); } }    
        public int Housenumber { get => model.Housenumber; set { model.Housenumber = value; OnPropertyChanged(); } }    
        public long PostalCode { get => model.PostalCode; set { model.PostalCode = value; OnPropertyChanged(); } }  
        public string City { get => model.City; set { model.City = value; OnPropertyChanged(); } }  
        public long PhoneNumber { get => model.PhoneNumber; set { model.PhoneNumber = value; OnPropertyChanged(); } }   
        public string Email { get => model.Email; set { model.Email = value; OnPropertyChanged(); } }   
        public string Password { get => model.Password; set { model.Password = value; OnPropertyChanged(); } }  

        public ICommand SaveCommand { get => saveCommand; set => saveCommand = value; }
        public ICommand EditCommand { get => editCommand; set => editCommand = value; }
        public ICommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }

    }
}
