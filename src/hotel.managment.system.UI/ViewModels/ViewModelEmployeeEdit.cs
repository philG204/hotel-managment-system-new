﻿using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.UI.ViewModels
{
    public class ViewModelEmployeeEdit
    {
        private Employee model;
        public ViewModelEmployeeEdit(Employee employee)
        {
            model = employee;
        }
    }
}
