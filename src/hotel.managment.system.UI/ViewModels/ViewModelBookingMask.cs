using GalaSoft.MvvmLight.Command;
using hotel.managment.system.Service;
using hotel_managment_system;
using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private List<Event> events;
        private List<Breakfast> breakFasts;
        private List<Employee> employees;
        private List<Customer> customers;

        public ViewModelBookingMask()
        {
            goBack = new RelayCommand(GoBack);
            save = new RelayCommand(Save);
            delete = new RelayCommand(Delete);
            edit = new RelayCommand(Edit);  

            //Load all neccessary objects
            List<Event> events = eventService.GetAll();
            List<Breakfast> breakFasts = breakFastService.GetAll();
            List<Employee> employees = employeeService.GetAll();
            List<Customer> customers = customerService.GetAll();
        }

        private void GoBack()
        {
            //Moves back to previous ViewModel
        }
        private void Delete() 
        {
            //Delete...
        }
        private void Edit()
        {
            //Edit...
        }
        private void Save()
        {
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
        public List<Event> Events { get => events; }
        public List<Breakfast> Breakfasts { get => breakFasts; }
        public List<Employee> Employees { get => employees; }
        public List<Customer> Customers { get => customers; }
        public string SelectedMethodOfPayment { get => model.MethodOfPayment; set => model.MethodOfPayment = value}
        public Breakfast SelectedBreakfast { get => model.Breakfast; set => model.Breakfast = value; }
        public Event SelectedEvent { get => model.Event; set => model.Event = value; }
        public double Amount { get => model.Amount; set => model.Amount = value; }
        public bool Settel { get => model.settel; set => model.settel = value; }
        public DateTime DepatureTime { get => model.Depature; set => model.Depature = value; }
        public DateTime ArrivalTime { get => model.Arrival; set => model.Arrival = value; }
        public Employee SelectedEmployee { get => model.SubEmployee.Employee; set => model.SubEmployee.Employee = value; }
        public Customer SelectedCustomer { get => model.Customer; set => model.Customer = value; }
    }
}
