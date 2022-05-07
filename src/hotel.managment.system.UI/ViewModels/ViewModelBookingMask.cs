﻿using GalaSoft.MvvmLight.Command;
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
        private ICommand room;

        private Booking model;

        private ObservableCollection<string> breakfastsNames = new ObservableCollection<string>();
        private ObservableCollection<string> eventNames = new ObservableCollection<string>();
        private ObservableCollection<string> employeeNames = new ObservableCollection<string>();
        private ObservableCollection<string> customerNames = new ObservableCollection<string>();


        public ViewModelBookingMask()
        {
            goBack = new RelayCommand(GoBackCommand);
            save = new RelayCommand(SaveCommand);
            delete = new RelayCommand(DeleteCommand);
            edit = new RelayCommand(EditCommand);
            room = new RelayCommand(Room);

            model = new Booking();

            //Load all neccessary objects
            ObservableCollection<Breakfast> breakfasts = breakFastService.GetAll();
            foreach (Breakfast breakfast in breakfasts)
            {
                breakfastsNames.Add(breakfast.KindOfBreakfast);
            }

            ObservableCollection<Event> events = eventService.GetAll();
            foreach (Event e in events)
            {
                eventNames.Add(e.EventName + " " + e.DiscountValue.ToString());
            }

            ObservableCollection<Employee> employees = employeeService.GetAll();
            foreach (Employee employee in employees)
            {
                employeeNames.Add(employee.Name + " " + employee.Surename.ToString());
            }

            ObservableCollection<Employee> customers = employeeService.GetAll();
            foreach (Employee customer in customers)
            {
                customerNames.Add(customer.Name + " " + customer.Surename.ToString());
            }
        }

        private void Room()
        {
            //opens room managment window
            Test roomManagment = new Test(model);
            roomManagment.ShowDialog();
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

            /**
            if (model.Room == null)
            {
                Console.WriteLine("Sie müsssen ein Zimmer buchen");
            }
            else
            {
                //Booking objeect is getting saved
                bookingService.Save(model);
            }
            **/
        }
        public ObservableCollection<string> EventNames { get => eventNames; }
        public ObservableCollection<string> BreakfastsNames { get => breakfastsNames; }
        public ObservableCollection<string> EmployeeNames { get => employeeNames; }
        public ObservableCollection<string> CustomerNames { get => customerNames; }
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
        public ICommand ShowRoom { get => room; set => room = value; }
    }
}
