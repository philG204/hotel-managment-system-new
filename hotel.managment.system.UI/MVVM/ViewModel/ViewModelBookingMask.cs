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
    public class ViewModelBookingMask : ObservableObject
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
        private DiscountService discountService = new DiscountService();

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

        private ObservableCollection<Breakfast> breakfastss = new ObservableCollection<Breakfast>();
        private ObservableCollection<Event> events = new ObservableCollection<Event>();
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        private ObservableCollection<Room> rooms = new ObservableCollection<Room>();
        private ObservableCollection<Meal> meals = new ObservableCollection<Meal>();
        private ObservableCollection<Treatment> treatments = new ObservableCollection<Treatment>();
        private ObservableCollection<Booking> bookings = new ObservableCollection<Booking>();
        private ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        private ObservableCollection<Discount> disounts = new ObservableCollection<Discount>();

        private ObservableCollection<Meal> mealListBox = new ObservableCollection<Meal>();
        private ObservableCollection<Room> roomsListBox = new ObservableCollection<Room>();
        private ObservableCollection<Treatment> treatmentListBox = new ObservableCollection<Treatment>();  

        private ObservableCollection<string> methodOfPayment = new ObservableCollection<string>();

        private Room selectedRoomComboBox;
        private Room selectedRoomListBox;
        private Discount selectedDiscountRoom;
        private Discount selectedDiscountMeal;
        private Discount selectedDisountTreatment; 
        private Meal selectedMealComboBox;
        private string selectedMealListBox;
        private double bookingAmount;
        private Treatment selectedTreatmentComboBox;
        private Treatment selectedTreatmentListBox;
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
            removeMeal = new RelayCommand(Remove_Meal);
            addTreatment = new RelayCommand(Add_Treatment);
            removeTreatment = new RelayCommand(Remove_Treatment);

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
            disounts = discountService.GetAll();
            /**
            if (model.BookingID != 0)
            {
                
            }
            **/
        }

        private void Add_Room()
        {
            if (selectedDiscountRoom == null && selectedRoomComboBox == null)
            {
                MessageBox.Show("Bitte einen Rabatt auswählen");
            }
            else
            {
                SubRoom r = new SubRoom();
                r.Rooms.Add(selectedRoomComboBox);
                r.AmountPrice += selectedRoomComboBox.Price;
                r.DiscountValue = selectedDiscountRoom.DiscountID;
                model.Room = r;
                model.Amount += selectedRoomComboBox.Price;
                roomsListBox.Add(selectedRoomComboBox);
                bookingAmount += selectedRoomComboBox.Price;
                selectedRoomComboBox = null;
            }           
        }

        private void Remove_Room()
        {
            model.Room.AmountPrice -= selectedRoomComboBox.Price;
            model.Amount -= selectedRoomComboBox.Price;
            model.Room.Rooms.Remove(selectedRoomListBox);
            bookingAmount -= selectedRoomComboBox.Price;
        }

        private void Add_Treatment()
        {
            if (selectedDisountTreatment == null && selectedTreatmentComboBox == null)
            {
                MessageBox.Show("Bitte einen Rabatt auswählen");
            }
            else
            {
                TotalTreatmentCosts totalTreatmentCost = new TotalTreatmentCosts();
                totalTreatmentCost.Treatments.Add(selectedTreatmentComboBox);
                totalTreatmentCost.AmountTreatmentCosts += selectedTreatmentComboBox.TreatmentAmount;
                totalTreatmentCost.Discount = selectedDisountTreatment.DiscountValue;
                model.TotalTreatmentCosts = totalTreatmentCost;
                model.Amount += selectedTreatmentComboBox.TreatmentAmount;
                treatmentListBox.Add(selectedTreatmentComboBox);
                bookingAmount += selectedTreatmentComboBox.TreatmentAmount;
                selectedTreatmentComboBox = null;
            }
        }

        private void Remove_Treatment()
        {
            model.TotalTreatmentCosts.AmountTreatmentCosts -= selectedTreatmentComboBox.TreatmentAmount;
            model.Amount -= selectedTreatmentComboBox.TreatmentAmount;
            model.TotalTreatmentCosts.Treatments.Remove(selectedTreatmentComboBox);
            bookingAmount -= selectedTreatmentComboBox.TreatmentAmount;
        }
        private void Add_Meal()
        {
            if (selectedDiscountMeal == null && selectedMealComboBox == null)
            {
                MessageBox.Show("Bitte einen Rabatt auswählen");
            }
            else
            {
                TotalMealCosts totalMealCost = new TotalMealCosts();
                totalMealCost.Meals.Add(selectedMealComboBox);
                totalMealCost.MealCost += selectedMealComboBox.Price;
                totalMealCost.discount = selectedDiscountMeal.DiscountValue;
                model.TotalMealCosts = totalMealCost;
                model.Amount += selectedMealComboBox.Price;
                mealListBox.Add(selectedMealComboBox);
                bookingAmount += selectedMealComboBox.Price;
                selectedMealComboBox = null;
                OnPropertyChanged();
            }
        }

        private void Remove_Meal()
        {
            model.TotalMealCosts.MealCost -= selectedMealComboBox.Price;
            model.Amount -= selectedMealComboBox.Price;
            model.TotalMealCosts.Meals.Remove(selectedMealComboBox);
            bookingAmount -= selectedMealComboBox.Price;

        }


        private void GoBackCommand()
        {
            //Moves back to previous ViewModel
        }
        private void DeleteCommand()
        {
            //Delete...
            bookingService.Delete(selectedBookig);
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

            int id;
            do
            {
                Random rand = new Random();
                id = rand.Next(1, 10000);
            }
            while (!bookingService.CheckIDs(id.ToString()));

            model.BookingID = id;

            DateTime dt = new DateTime();
            model.SubEmployee.Date = dt.Date;

            if (model.Room == null)
            {
                MessageBox.Show("Sie müsssen ein Zimmer hinterlegen");
            }
            else
            {
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
                        model.Amount += (model.Amount *= 0.19);
                        bookingService.Save(model);
                    }
                }               
            }
        }

        public Booking SelectedBooking { get => selectedBookig; set { selectedBookig = value; OnPropertyChanged(); } }
        public Meal SelectedMealComboBox { get => selectedMealComboBox; set { selectedMealComboBox = value; OnPropertyChanged(); } }
        public string SelectedMealListBox { get => selectedMealListBox; set { selectedMealListBox = value; OnPropertyChanged(); } }
        public Treatment SelectedTreatmentComboBox { get => selectedTreatmentComboBox; set { selectedTreatmentComboBox = value; OnPropertyChanged(); } }
        public string SelectedTreatmentListBox { get => selectedMealListBox; set { selectedMealListBox = value; OnPropertyChanged(); } }
        public string SelectedMethodeOfPayment { get => model.MethodOfPayment; set { model.MethodOfPayment = value; OnPropertyChanged(); } }
        public Discount SelectedDiscountRoom { get => selectedDiscountRoom; set { selectedDiscountRoom = value; OnPropertyChanged(); } }  
        public Discount SelectedDiscountMeal { get => selectedDiscountMeal; set { selectedDiscountMeal = value; OnPropertyChanged(); } }
        public Discount SelectedDiscountTreatment{ get => selectedDisountTreatment; set { selectedDisountTreatment = value; OnPropertyChanged(); } }
        public Employee SelectedEmployeeComboBox { get => selectedEmployeeComboBox; set { selectedEmployeeComboBox = value; OnPropertyChanged(); } }
        public Room SelectedRoomComboBox { get => selectedRoomComboBox; set { selectedRoomComboBox = value; OnPropertyChanged(); } }
        public Room SelectedRoomListBox { get => selectedRoomListBox; set { selectedRoomListBox = value; OnPropertyChanged(); } }
        public ObservableCollection<Meal> Meals { get => meals; }
        public ObservableCollection<Treatment> Treatments { get => treatments; }
        public ObservableCollection<Room> Rooms { get => rooms; }
        public ObservableCollection<Event> Events { get => events; }
        public ObservableCollection<Breakfast> Breakfastss { get => breakfastss; }
        public ObservableCollection<Employee> Employees { get => employees; }
        public ObservableCollection<Customer> Customers { get => customers; }
        public ObservableCollection<Booking> Bookings { get { return bookings; OnPropertyChanged(); } set { bookings = value; OnPropertyChanged(); } }
        public ObservableCollection<Discount> Discounts { get => disounts; }
        public ObservableCollection<string> MethodeOfPayment { get => methodOfPayment; }
        public int BookingID { get => model.BookingID; set { model.BookingID = value; OnPropertyChanged(); } }
        public string SelectedMethodOfPayment { get => model.MethodOfPayment; set { model.MethodOfPayment = value; OnPropertyChanged(); } }
        public Breakfast SelectedBreakfast { get => model.Breakfast; set { model.Breakfast = value; OnPropertyChanged(); } }
        public Event SelectedEvent { get => model.Event; set { model.Event = value; OnPropertyChanged(); } }
        public double BookingAmountFinal { get => model.Amount; set { model.Amount = value; this.OnPropertyChanged(); this.OnPropertyChanged(nameof(model.Amount)); } }
        public double BookingAmount { get => bookingAmount; set => bookingAmount = value; }
        public bool Settel { get => model.settel; set { model.settel = value; OnPropertyChanged(); } }
        public DateTime DepatureTime { get => model.Depature; set { model.Depature = value; OnPropertyChanged(); } }
        public DateTime ArrivalTime { get => model.Arrival; set { model.Arrival = value; OnPropertyChanged(); } }
        public Employee SelectedEmployee { get => model.SubEmployee.Employee; set { model.SubEmployee.Employee = value; OnPropertyChanged(); } }
        public Customer SelectedCustomer { get => model.Customer; set { model.Customer = value; OnPropertyChanged(); } }
        public ICommand Save { get => save; set => save = value; }
        public ICommand Delete { get => delete; set => delete = value; }
        public ICommand Edit { get => edit; set => edit = value; }
        public ICommand GoBack { get => goBack; set => goBack = value; }
        public ICommand AddRoom { get => addRoom; set => addRoom = value; }
        public ICommand RemoveRoom { get => removeRoom; set => removeRoom = value; }
        public ICommand AddTreatment { get => addTreatment; set => addTreatment = value; }
        public ICommand RemoveTreatment { get => removeTreatment; set => removeTreatment = value; }
        public  ICommand AddMeal { get => addMeal; set => addMeal = value; }        
        public ICommand RemoveMeal { get => removeMeal; set => removeMeal = value; }
    }
}
