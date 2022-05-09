using hotel.managment.system.Data.DB;
using hotel_managment_system.Models;
using hotel_managment_system_v2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Service
{
    public class TreatmentService : ITreatmentService
    {
        private readonly TreatmentRepository treatmentRepository = new TreatmentRepository();

        public bool Delete(Treatment obj) => treatmentRepository.Delete(obj);

        public bool Delete(int id) => treatmentRepository.Delete(id);

        public Treatment Get(int TId) => treatmentRepository.Get(TId);

        public ObservableCollection<Treatment> GetAll() => treatmentRepository.GetAll();

        public bool Save(Treatment obj) => treatmentRepository.Save(obj);
    }
}
