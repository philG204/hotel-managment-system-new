using GalaSoft.MvvmLight.Command;
using hotel.managment.system.Service;
using hotel_managment_system;
using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace hotel.managment.system.UI.UserControls
{
    class ViewModelBookingMask
    {
        // Needed Services
        private BookingService bookingService = new BookingService();
        private EventService eventService = new EventService();
        private BreakfastService breakFastService = new BreakfastService();
        private EmployeeService employeeService = new EmployeeService();    
        private CustomerService customerService = new CustomerService();    

        private ICommand save;
        private ICommand delete;
        private ICommand edit;
        private ICommand goBack;

        private Booking model;

        private ObservableCollection<Event> events;
        private ObservableCollection<Breakfast> breakFasts;
        private ObservableCollection<Employee> employees;
        private ObservableCollection<Customer> customers;

        public ViewModelBookingMask()
        {
            goBack = new RelayCommand(GoBackCommand);
            save = new RelayCommand(SaveCommand);
            delete = new RelayCommand(DeleteCommand);
            edit = new RelayCommand(EditCommand);

            model = new Booking();

            //Load all neccessary objects
            ObservableCollection<Event> events = eventService.GetAll();
            ObservableCollection<Breakfast> breakFasts = breakFastService.GetAll();
            ObservableCollection<Employee> employees = employeeService.GetAll();
            ObservableCollection<Customer> customers = customerService.GetAll();
        }

        private void GoBackCommand()
        {
            //Moves back to previous ViewModel
        }
        private void DeleteCommand() 
        {
            //Delete...
        }
        private void EditCommand()
        {
            //Edit...
        }
        private void SaveCommand()
        {
            MessageBox.Show("Test");
            if (model.Room == null)
            {
                Console.WriteLine("Sie müsssen ein Zimmer buchen");
            }
            else
            {
                //Booking objeect is getting saved
                bookingService.Save(model);
            }
        }
        public ObservableCollection<Event> Events { get => events; }
        public ObservableCollection<Breakfast> Breakfasts { get => breakFasts; }
        public ObservableCollection<Employee> Employees { get => employees; }
        public ObservableCollection<Customer> Customers { get => customers; }
        public string SelectedMethodOfPayment { get => model.MethodOfPayment; set => model.MethodOfPayment = value; }
        public Breakfast SelectedBreakfast { get => model.Breakfast; set => model.Breakfast = value; }
        public Event SelectedEvent { get => model.Event; set => model.Event = value; }
        public double Amount { get => model.Amount; set => model.Amount = value; }
        public bool Settel { get => model.settel; set => model.settel = value; }
        public DateTime DepatureTime { get => model.Depature; set => model.Depature = value; }
        public DateTime ArrivalTime { get => model.Arrival; set => model.Arrival = value; }
        public Employee SelectedEmployee { get => model.SubEmployee.Employee; set => model.SubEmployee.Employee = value; }
        public Customer SelectedCustomer { get => model.Customer; set => model.Customer = value; }
        public ICommand Save { get => save; set => save = value; }
        public ICommand GoBack { get => goBack; set => goBack = value; }
    }
}
