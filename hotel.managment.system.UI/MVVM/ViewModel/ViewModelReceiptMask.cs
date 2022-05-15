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
    public class ViewModelReceiptMask : ObservableObject
    {
        // Needed Services
        private ReceiptService receiptService = new ReceiptService();
        private EventService eventService = new EventService();
        private EmployeeService employeeService = new EmployeeService();
        private CustomerService customerService = new CustomerService();
        private MealService mealService = new MealService();
        private TreatmentService treatmentService = new TreatmentService();
        private DiscountService discountService = new DiscountService();

        private ICommand save;
        private ICommand delete;
        private ICommand edit;
        private ICommand addMeal;
        private ICommand removeMeal;
        private ICommand addTreatment;
        private ICommand removeTreatment;

        private Receipt model;

        private ObservableCollection<Event> events = new ObservableCollection<Event>();
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        private ObservableCollection<Meal> meals = new ObservableCollection<Meal>();
        private ObservableCollection<Treatment> treatments = new ObservableCollection<Treatment>();
        private ObservableCollection<Receipt> receipts = new ObservableCollection<Receipt>();
        private ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        private ObservableCollection<Discount> disounts = new ObservableCollection<Discount>();

        private ObservableCollection<Meal> mealListBox = new ObservableCollection<Meal>();
        private ObservableCollection<Treatment> treatmentListBox = new ObservableCollection<Treatment>();

        private ObservableCollection<string> methodOfPayment = new ObservableCollection<string>();

        private Discount selectedDiscountCombobox;
        private Meal selectedMeal;
        private string selectedMealListBox;
        private Treatment selectedTreatment;
        private Treatment selectedTreatmentListBox;
        private Employee selectedEmployeeComboBox;

        private Receipt selectedReceipt;

        public ViewModelReceiptMask()
        {
            save = new RelayCommand(SaveCommand);
            delete = new RelayCommand(DeleteCommand);
            edit = new RelayCommand(EditCommand);         
            removeMeal = new RelayCommand(Remove_Meal);
            addMeal = new RelayCommand(Add_Meal);
            removeMeal = new RelayCommand(Remove_Meal);
            addTreatment = new RelayCommand(Add_Treatment);
            removeTreatment = new RelayCommand(Remove_Treatment);

            model = new Receipt();
            SubEmployee subEmployee = new SubEmployee();
            model.SubEmployee = subEmployee;

            methodOfPayment.Add("Karte");
            methodOfPayment.Add("Bar");

            //Load all neccessary objects                   
            receipts = receiptService.GetAll();
            customers = customerService.GetAll();
            treatments = treatmentService.GetAll();
            meals = mealService.GetAll();
            employees = employeeService.GetAll();
            events = eventService.GetAll();
            disounts = discountService.GetAll();
            /**
            if (model.BookingID != 0)
            {
                
            }
            **/
        }      

        private void Add_Treatment()
        {
            TotalTreatmentCosts totalTreatmentCost = new TotalTreatmentCosts();
            totalTreatmentCost.Treatments.Add(selectedTreatment);
            totalTreatmentCost.AmountTreatmentCosts += selectedTreatment.TreatmentAmount;
            model.TotalTreatmentCosts = totalTreatmentCost;
            model.CashAmount += selectedTreatment.TreatmentAmount;
            treatmentListBox.Add(selectedTreatment);
            selectedTreatment = null;

        }

        private void Remove_Treatment()
        {
            model.TotalTreatmentCosts.AmountTreatmentCosts -= selectedTreatment.TreatmentAmount;
            model.CashAmount -= selectedTreatment.TreatmentAmount;
            model.TotalTreatmentCosts.Treatments.Remove(selectedTreatment);
        }
        private void Add_Meal()
        {
            TotalMealCosts totalMealCost = new TotalMealCosts();
            totalMealCost.Meals.Add(selectedMeal);
            totalMealCost.MealCost += selectedMeal.Price;
            model.TotalMealCosts = totalMealCost;
            model.CashAmount += selectedMeal.Price;
            mealListBox.Add(selectedMeal);
            selectedMeal = null;
            OnPropertyChanged();

        }

        private void Remove_Meal()
        {
            model.TotalMealCosts.MealCost -= selectedMeal.Price;
            model.CashAmount -= selectedMeal.Price;
            model.TotalMealCosts.Meals.Remove(selectedMeal);

        }


        private void GoBackCommand()
        {
            //Moves back to previous ViewModel
        }
        private void DeleteCommand()
        {
            //Delete...
            receiptService.Delete(selectedReceipt);
            MessageBox.Show(SelectedReceipt.ReceiptID.ToString());
        }
        private void EditCommand()
        {
            //Edit...
            //BookingEdit be = new BookingEdit(SelectedBooking);
            //be.ShowDialog();
            model = SelectedReceipt;
        }
        private void SaveCommand()
        {

            int id;
            do
            {
                Random rand = new Random();
                id = rand.Next(1, 10000);
            }
            while (!receiptService.CheckIDs(id.ToString()));

            model.ReceiptID = id;

            DateTime dt = new DateTime();
            model.SubEmployee.Date = dt.Date;

            if (model.SubEmployee.Employee == null)
            {
                MessageBox.Show("Sie müssen ein Mitarbieter auswählen");
            }
            else
            {
                if (model.Customer == null)
                {
                 MessageBox.Show("Sie müssen ein Kunden auswählen");
                }
                else
                {
                   receiptService.Save(model);
                }
            }
        }

        public Receipt SelectedReceipt { get => selectedReceipt; set { selectedReceipt = value; OnPropertyChanged(); } }
        public Meal SelectedMeal { get => selectedMeal; set { selectedMeal = value; OnPropertyChanged(); } }
        public string SelectedMealListBox { get => selectedMealListBox; set { selectedMealListBox = value; OnPropertyChanged(); } }
        public Treatment SelectedTreatment { get => selectedTreatment; set { selectedTreatment = value; OnPropertyChanged(); } }
        public string SelectedTreatmentListBox { get => selectedMealListBox; set { selectedMealListBox = value; OnPropertyChanged(); } }
        public string SelectedMethodeOfPayment { get => model.MethodOfPayment; set { model.MethodOfPayment = value; OnPropertyChanged(); } }
        public Discount SelectedDiscount { get => selectedDiscountCombobox; set { selectedDiscountCombobox = value; OnPropertyChanged(); } }       
        public ObservableCollection<Meal> Meals { get => meals; }
        public ObservableCollection<Treatment> Treatments { get => treatments; }
        public ObservableCollection<Event> Events { get => events; }
        public ObservableCollection<Employee> Employees { get => employees; }
        public ObservableCollection<Customer> Customers { get => customers; }
        public ObservableCollection<Receipt> Receipts { get { return receipts; OnPropertyChanged(); } set { receipts = value; OnPropertyChanged(); } }
        public ObservableCollection<Discount> Discounts { get => disounts; }
        public ObservableCollection<string> MethodeOfPayment { get => methodOfPayment; }
        public int ReceiptID { get => model.ReceiptID; set { model.ReceiptID = value; OnPropertyChanged(); } }
        public string SelectedMethodOfPayment { get => model.MethodOfPayment; set { model.MethodOfPayment = value; OnPropertyChanged(); } }
        public Event SelectedEvent { get => model.Event; set { model.Event = value; OnPropertyChanged(); } }
        public double ReceiptAmount { get => model.CashAmount; set { model.CashAmount = value; this.OnPropertyChanged(); this.OnPropertyChanged(nameof(model.CashAmount)); } }
        public bool Settel { get => model.settel; set { model.settel = value; OnPropertyChanged(); } }      
        public Employee SelectedEmployee { get => model.SubEmployee.Employee; set { model.SubEmployee.Employee = value; OnPropertyChanged(); } }
        public Customer SelectedCustomer { get => model.Customer; set { model.Customer = value; OnPropertyChanged(); } }
        public ICommand Save { get => save; set => save = value; }
        public ICommand Delete { get => delete; set => delete = value; }
        public ICommand Edit { get => edit; set => edit = value; }       
        public ICommand AddTreatment { get => addTreatment; set => addTreatment = value; }
        public ICommand RemoveTreatment { get => removeTreatment; set => removeTreatment = value; }
    }
}
