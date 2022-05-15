using GalaSoft.MvvmLight.Command;
using hotel.managment.system.Service;
using hotel.managment.system.UI.Core;
using hotel_managment_system;
using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace hotel.managment.system.UI.MVVM.ViewModel
{
    public class ViewModelCustomerMask : ObservableObject
    {
        private CustomerService customerService = new CustomerService();

        private ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

        private Customer selectedCustomer;

        private ICommand saveCommand;
        private ICommand editCommand;
        private ICommand deleteCommand;

        private Customer model;

        public ViewModelCustomerMask()
        {
            model = new Customer();
            customers = customerService.GetAll();

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
                id = rand.Next(1, 1000);
            }
            while (!customerService.CheckIDs(id.ToString()));

            model.CustomerID = id;

            if (Surename == null || Name == null || PhoneNumber == null || Email == null)
            {
                MessageBox.Show("Es wurde ein Feld vergessen");
            }
            else
            {
                customerService.Save(model);
                model = null;
                OnPropertyChanged();
            }
        }

        private void Edit()
        {
            model = selectedCustomer;
        }

        private void Delete()
        {
            customerService.Delete(selectedCustomer);
        }

        public ObservableCollection<Customer> Customers 
        { 
            get { return customers; } 
            set 
            { 
                customers = value; 
                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(customers)); 
            } 
        }
        public Customer SelectedCustomer { get => selectedCustomer; set { selectedCustomer = value; OnPropertyChanged(); } }

        public int CustomerID { get => model.CustomerID; set { model.CustomerID = value; OnPropertyChanged(); } }
        public string Name { get => model.Name; set { model.Name = value; OnPropertyChanged(); } }
        public string Surename { get => model.Surname; set { model.Surname = value; OnPropertyChanged(); } }
        public string Street { get => model.Street; set { model.Street = value; OnPropertyChanged(); } }
        public string Housenumber { get => model.HouseNumber; set { model.HouseNumber = value; OnPropertyChanged(); } }
        public long PostalCode { get => model.PostalCode; set { model.PostalCode = value; OnPropertyChanged(); } }
        public string City { get => model.City; set { model.City = value; OnPropertyChanged(); } }
        public long PhoneNumber { get => model.PhoneNumber; set { model.PhoneNumber = value; OnPropertyChanged(); } }
        public string Email { get => model.Email; set { model.Email = value; OnPropertyChanged(); } }
        public DateTime Birthday { get => model.Birthday; set { model.Birthday = value; OnPropertyChanged(); } }
        public string KindOfTravaler { get => model.KindOfTravaler; set { model.KindOfTravaler = value; OnPropertyChanged(); } }
        public string MaritalStatus { get => model.MaritalStatus; set { model.MaritalStatus = value; OnPropertyChanged(); } }
        public string EducationalStatus { get => model.EducationalStatus; set { model.EducationalStatus = value; OnPropertyChanged(); } }
        public string Vocation { get => model.Vocation; set { model.Vocation = value; OnPropertyChanged(); } } 
        public string Gender { get => model.Gender; set { model.Gender = value; OnPropertyChanged(); } }

        public ICommand SaveCommand { get => saveCommand; set => saveCommand = value; }
        public ICommand EditCommand { get => editCommand; set => editCommand = value; }
        public ICommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }
    }
}
