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
        private BreakfastService breakfastService = new BreakfastService();
        private BreakfastService breakFastService = new BreakfastService();
        private EmployeeService employeeService = new EmployeeService();    
        private CustomerService customerService = new CustomerService();
        private RoomService roomService = new RoomService();
        private MealService mealService = new MealService();
        private TreatmentService treatmentService = new TreatmentService();

        private ICommand save;
        private ICommand delete;
        private ICommand edit;
        private ICommand goBack;
        private ICommand addRoom;
        private ICommand removeRoom;
        private ICommand addMeal;
        private ICommand removeMeal;
        private ICommand addTreatment;
        private ICommand removeTreatment;

        private Booking model;
        private Employee loggedInEmployee;

        private ObservableCollection<Breakfast> breakfastss = new ObservableCollection<Breakfast>();
        private ObservableCollection<Event> events = new ObservableCollection<Event>();
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        private ObservableCollection<Room> rooms = new ObservableCollection<Room>();
        private ObservableCollection<Meal> meals = new ObservableCollection<Meal>();
        private ObservableCollection<Treatment> treatments = new ObservableCollection<Treatment>();
        private ObservableCollection<Booking> bookings = new ObservableCollection<Booking>();
        private ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

        private ObservableCollection<Meal> mealListBox = new ObservableCollection<Meal>();
        private ObservableCollection<Room> roomsListBox = new ObservableCollection<Room>();

        private ObservableCollection<string> methodOfPayment = new ObservableCollection<string>();

        private Room selectedRoomComboBox;
        private Room selectedRoomListBox;
        private string selectedMealComboBox;
        private string selectedMealListBox;
        private string selectedTreatmentComboBox;
        private string selectedTreatmentListBox;
        private Employee selectedEmployeeComboBox;

        private Booking selectedBookig;

        public ViewModelBookingMask()
        {
            goBack = new RelayCommand(GoBackCommand);
            save = new RelayCommand(SaveCommand);
            delete = new RelayCommand(DeleteCommand);
            edit = new RelayCommand(EditCommand);
            addRoom = new RelayCommand(Add_Room);
            removeRoom = new RelayCommand(Remove_Room);
            removeMeal = new RelayCommand(Remove_Meal);
            addMeal = new RelayCommand(Add_Meal);
            removeMeal = new RelayCommand(Remove_Treatment);
            addMeal = new RelayCommand(Add_Treatment);

            model = new Booking();
            SubEmployee subEmployee = new SubEmployee();
            model.SubEmployee = subEmployee;

            methodOfPayment.Add("Karte");
            methodOfPayment.Add("Bar");

            //Load all neccessary objects                   
            bookings = bookingService.GetAll();
            customers = customerService.GetAll();
            treatments = treatmentService.GetAll();
            rooms = roomService.GetAll();
            meals = mealService.GetAll();
            employees = employeeService.GetAll();
            events = eventService.GetAll();
            breakfastss = breakfastService.GetAll();

            if (model.BookingID != 0)
            {
                
            }
        }

        private void Add_Room()
        {
            SubRoom r = new SubRoom();
            r.Rooms.Add(selectedRoomComboBox);
            r.AmountPrice += selectedRoomComboBox.Price;
            model.Room = r;
            model.Amount += selectedRoomComboBox.Price;
            roomsListBox.Add(selectedRoomComboBox);
            selectedRoomComboBox = null;
        }

        private void Remove_Room()
        {
            model.Room.Rooms.Remove(selectedRoomListBox);
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
                if (meal.Name == selectedMealComboBox.Split(" ")[1])
                {
                    model.TotalMealCosts.Meals.Add(meal);
                    //mealListBox.Add();
                }
            }
        }

        private void Remove_Meal()
        {
            ObservableCollection<Meal> meals = mealService.GetAll();
            foreach (Meal meal in meals)
            {
                if (meal.Name == selectedMealComboBox.Split(" ")[1])
                {
                    model.TotalMealCosts.Meals.Remove(meal);
                    //mealListBox.Add();
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
            //bookingService.Delete(selectedBookig);
            MessageBox.Show(SelectedBooking.BookingID.ToString());
        }
        private void EditCommand()
        {
            //Edit...
            //BookingEdit be = new BookingEdit(SelectedBooking);
            //be.ShowDialog();
            model = SelectedBooking;
        }
        private void SaveCommand()
        {

            if (model.Room == null)
            {
                MessageBox.Show("Sie müsssen ein Zimmer hinterlegen");
            }
            else
            {
                if (model.SubEmployee.Employee == null)
                {
                    SubEmployee subEmployee = new SubEmployee();
                    subEmployee.Employee = loggedInEmployee;
                    subEmployee.Date = DateTime.Now;
                }
                bookingService.Save(model);
            }         
        }

        public Booking SelectedBooking { get => selectedBookig; set => selectedBookig = value; }
        public string SelectedMealComboBox { get => selectedMealComboBox; set => selectedMealComboBox = value; }
        public string SelectedMealListBox { get => selectedMealListBox; set => selectedMealListBox = value; }
        public string SelectedTreatmentComboBox { get => selectedMealComboBox; set => selectedMealComboBox = value; }
        public string SelectedTreatmentListBox { get => selectedMealListBox; set => selectedMealListBox = value; }
        public string SelectedMethodeOfPayment { get => model.MethodOfPayment; set => model.MethodOfPayment = value; }
        public Employee SelectedEmployeeComboBox { get => selectedEmployeeComboBox; set => selectedEmployeeComboBox = value; }
        public Room SelectedRoomComboBox { get => selectedRoomComboBox; set => selectedRoomComboBox = value; }
        public Room SelectedRoomListBox { get => selectedRoomListBox; set => selectedRoomListBox = value; }
        public ObservableCollection<Meal> Meals { get => meals; }
        public ObservableCollection<Treatment> Treatments { get => treatments; }
        public ObservableCollection<Room> Rooms { get => rooms; }
        public ObservableCollection<Event> Events { get => events; }
        public ObservableCollection<Breakfast> Breakfastss { get => breakfastss; }
        public ObservableCollection<Employee> Employees { get => employees; }
        public ObservableCollection<Customer> Customers { get => customers; }
        public ObservableCollection<Booking> Bookings { get => bookings; }
        public ObservableCollection<string> MethodeOfPayment { get => methodOfPayment; }
        public int BookingID { get => model.BookingID; set => model.BookingID = value; }
        public string SelectedMethodOfPayment { get => model.MethodOfPayment; set => model.MethodOfPayment = value; }
        public Breakfast SelectedBreakfast { get => model.Breakfast; set => model.Breakfast = value; }
        public Event SelectedEvent { get => model.Event; set => model.Event = value; }
        public double BookingAmount { get => model.Amount; set => model.Amount = value; }
        public bool Settel { get => model.settel; set => model.settel = value; }
        public DateTime DepatureTime { get => model.Depature; set => model.Depature = value; }
        public DateTime ArrivalTime { get => model.Arrival; set => model.Arrival = value; }
        public Employee SelectedEmployee { get => model.SubEmployee.Employee; set => model.SubEmployee.Employee = value; }
        public Customer SelectedCustomer { get => model.Customer; set => model.Customer = value; }
        public ICommand Save { get => save; set => save = value; }
        public ICommand Delete { get => delete; set => delete = value; }
        public ICommand Edit { get => edit; set => edit = value; }
        public ICommand GoBack { get => goBack; set => goBack = value; }
        public ICommand AddRoom { get => addRoom; set => addRoom = value; }
        public ICommand RemoveRoom { get => removeRoom; set => removeRoom = value; }
        public ICommand AddTreatment { get => addTreatment; set => addTreatment = value; }
        public ICommand RemoveTreatment { get => removeTreatment; set => removeTreatment = value; }
    }
}
