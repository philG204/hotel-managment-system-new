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
using System.Windows;
using System.Windows.Input;

namespace hotel.managment.system.UI.ViewModels
{
    public class ViewModelReceiptMask
    {
        // Needed Services
        private ReceiptService receiptService = new ReceiptService();
        private EventService eventService = new EventService();
        private EmployeeService employeeService = new EmployeeService();
        private CustomerService customerService = new CustomerService();
        private MealService mealService = new MealService();
        private TreatmentService treatmentService = new TreatmentService();

        private ICommand save;
        private ICommand delete;
        private ICommand edit;
        private ICommand goBack;
        private ICommand addMeal;
        private ICommand removeMeal;
        private ICommand addTreatment;
        private ICommand removeTreatment;

        private Receipt model;

        private ObservableCollection<string> eventNames = new ObservableCollection<string>();
        private ObservableCollection<string> employeeNames = new ObservableCollection<string>();
        private ObservableCollection<string> customerNames = new ObservableCollection<string>();
        private ObservableCollection<string> mealNames = new ObservableCollection<string>();
        private ObservableCollection<string> treatmentNames = new ObservableCollection<string>();
        private ObservableCollection<Receipt> receipts = new ObservableCollection<Receipt>();

        private string selectedMealComboBox;
        private string selectedMealListBox;
        private string selectedTreatmentComboBox;
        private string selectedTreatmentListBox;

        private Receipt selectedReceipt;

        public ViewModelReceiptMask()
        {
            goBack = new RelayCommand(GoBackCommand);
            save = new RelayCommand(SaveCommand);
            delete = new RelayCommand(DeleteCommand);
            edit = new RelayCommand(EditCommand);
            removeMeal = new RelayCommand(Remove_Meal);
            addMeal = new RelayCommand(Add_Meal);
            removeMeal = new RelayCommand(Remove_Treatment);
            addMeal = new RelayCommand(Add_Treatment);

            model = new Receipt();

            //Load all neccessary objects         
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

            ObservableCollection<Customer> customers = customerService.GetAll();
            foreach (Customer customer in customers)
            {
                customerNames.Add(customer.Name + " " + customer.Surname.ToString());
            }         

            ObservableCollection<Meal> meals = mealService.GetAll();
            foreach (Meal m in meals)
            {
                mealNames.Add(m.Name);
            }

            ObservableCollection<Treatment> treatments = treatmentService.GetAll();
            foreach (Treatment t in treatments)
            {
                treatmentNames.Add(t.TreatmentName);
            }

            ObservableCollection<Receipt> receipts = receiptService.GetAll();         
        }       

        private void Add_Treatment()
        {
            ObservableCollection<Treatment> treatments = treatmentService.GetAll();
            foreach (Treatment treatment in treatments)
            {
                if (treatment.TreatmentName == selectedTreatmentComboBox)
                {
                    model.TotalTreatmentCosts.Treatments.Add(treatment);
                }
            }
        }

        private void Remove_Treatment()
        {
            ObservableCollection<Treatment> treatments = treatmentService.GetAll();
            foreach (Treatment treatment in treatments)
            {
                if (treatment.TreatmentName == selectedTreatmentComboBox)
                {
                    model.TotalTreatmentCosts.Treatments.Remove(treatment);
                }
            }
        }
        private void Add_Meal()
        {
            ObservableCollection<Meal> meals = mealService.GetAll();
            foreach (Meal meal in meals)
            {
                if (meal.Name == selectedMealComboBox)
                {
                    model.TotalMealCosts.Meals.Add(meal);
                }
            }
        }

        private void Remove_Meal()
        {
            ObservableCollection<Meal> meals = mealService.GetAll();
            foreach (Meal meal in meals)
            {
                if (meal.Name == selectedMealComboBox)
                {
                    model.TotalMealCosts.Meals.Remove(meal);
                }
            }
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
        public Receipt SelectedReceipt { get => selectedReceipt; set => selectedReceipt = value; }
        public string SelectedMealComboBox { get => selectedMealComboBox; set => selectedMealComboBox = value; }
        public string SelectedMealListBox { get => selectedMealListBox; set => selectedMealListBox = value; }
        public ObservableCollection<Receipt> Receipts { get => receipts; }
        public ObservableCollection<string> MealNames { get => mealNames; }
        public ObservableCollection<string> TreatmentNames { get => treatmentNames; }
        public ObservableCollection<string> EventNames { get => eventNames; }
        public ObservableCollection<string> EmployeeNames { get => employeeNames; }
        public ObservableCollection<string> CustomerNames { get => customerNames; }
        public int ReceitpID { get => model.ReceiptID; set => model.ReceiptID = value; }
        public string SelectedMethodOfPayment { get => model.MethodOfPayment; set => model.MethodOfPayment = value; }
        public Event SelectedEvent { get => model.Event; set => model.Event = value; }
        public double Amount { get => model.CashAmount; set => model.CashAmount = value; }
        public bool Settel { get => model.settel; set => model.settel = value; }
        public Employee SelectedEmployee { get => model.SubEmployee.Employee; set => model.SubEmployee.Employee = value; }
        public Customer SelectedCustomer { get => model.Customer; set => model.Customer = value; }
        public ICommand Save { get => save; set => save = value; }
        public ICommand Delete { get => delete; set => delete = value; }
        public ICommand Edit { get => edit; set => edit = value; }
        public ICommand GoBack { get => goBack; set => goBack = value; }
        public ICommand AddTreatment { get => addTreatment; set => addTreatment = value; }
        public ICommand RemoveTreatment { get => removeTreatment; set => removeTreatment = value; }
    }
}
