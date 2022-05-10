using GalaSoft.MvvmLight.Command;
using hotel.managment.system.Service;
using hotel_managment_system;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace hotel.managment.system.UI.ViewModels
{
    public class ViewModelCustomer
    {
        private CustomerService customerService = new CustomerService();

        private Customer model;

        private ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

        private ICommand saveCommand;
        private ICommand deleteCommand;
        private ICommand editCommand;

        public ViewModelCustomer()
        {
            saveCommand = new RelayCommand(Save);
            deleteCommand = new RelayCommand(Delete);
            editCommand = new RelayCommand(Edit);

            customers = customerService.GetAll();
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

        public ObservableCollection<Customer> Customers { get => customers; }
        public int CustomerID { get => model.CustomerID; set => model.CustomerID = value; }
        public string CustomerName { get => model.Name; set => model.Name = value; }
        public string CustomerSurname { get => model.Surname; set => model.Surname = value; }
        public string CustomerStreet { get => model.Street; set => model.Street = value; }
        public string HouseNumber { get => model.HouseNumber; set => model.HouseNumber = value; }
        public long PostalCode { get => model.PostalCode; set => model.PostalCode = value; }
        public string City { get => model.City; set => model.City = value; }
        public string KindOfTravaler { get => model.KindOfTravaler; set => model.KindOfTravaler = value; }
        public long PhoneNumber { get => model.PhoneNumber; set => model.PhoneNumber = value; }
        public string Email { get => model.Email; set => model.Email = value; }
        public DateTime Birthday { get => model.Birthday; set => model.Birthday = value; }
        public string Gender { get => model.Gender; set => model.Gender = value; }
        public string MaritalStatus { get => model.MaritalStatus; set => model.MaritalStatus = value; }
        public string EducationalStatus { get => model.EducationalStatus; set => model.EducationalStatus = value; }
        public string Vocation { get => model.Vocation; set => model.Vocation = value; }
        public ICommand SaveCommand { get => saveCommand; set => saveCommand = value; }
        public ICommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }
        public ICommand EditCommand { get => editCommand; set => editCommand = value; }
    }
}
