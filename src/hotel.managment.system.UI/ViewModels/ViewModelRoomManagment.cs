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
using System.Windows.Input;

namespace hotel.managment.system.UI.ViewModels
{
    public class ViewModelRoomManagment
    {
        private Booking model;

        private RoomService roomService = new RoomService();

        private ObservableCollection<string> roomNames = new ObservableCollection<string>();
        private ObservableCollection<string> equipmentNames = new ObservableCollection<string>();

        private string selectedRoomComboBox;
        private string selectedRoomListBox;

        private ICommand addRoom;
        private ICommand removeRoom;
        private ICommand goBack;
        
        public ViewModelRoomManagment(Booking booking)
        {
            model = booking;

            addRoom = new RelayCommand(Add_Room);
            removeRoom = new RelayCommand(Remove_Room);
            goBack = new RelayCommand(Go_Back);

            ObservableCollection<Room> rooms = roomService.GetAll();

            foreach (Room r in rooms)
            {
                roomNames.Add(r.RoomName);
            }
        }

        private void Go_Back()
        {
            
        }

        private void Add_Room()
        {
            ObservableCollection<Room> rooms = roomService.GetAll();
            foreach (Room room in rooms)
            {
                if (room.RoomName == selectedRoomComboBox)
                {
                    model.Room.Rooms.Add(room);
                }
            }
        }

        private void Remove_Room()
        {
            ObservableCollection<Room> rooms = roomService.GetAll();
            foreach (Room room in rooms)
            {
                if (room.RoomName == selectedRoomComboBox)
                {
                    model.Room.Rooms.Remove(room);
                }
            }
        }

        public ObservableCollection<string> RoomNames { get => roomNames; }
        public string SelectedRoomComboBox { get => selectedRoomComboBox; set => selectedRoomComboBox = value; }
        public string SelectedRoomListBox { get => selectedRoomListBox; set => selectedRoomListBox = value; }
    }
}
