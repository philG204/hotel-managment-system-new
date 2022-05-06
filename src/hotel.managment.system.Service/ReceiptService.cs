using hotel.managment.system.Data.DB;
using hotel_managment_system.Models;
using hotel_managment_system.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Service
{
    public class ReceiptService : IReceiptService
    {
        private readonly ReceiptRepository receiptRepository = new ReceiptRepository();

        public bool Delete(Receipt obj) => receiptRepository.Delete(obj);

        public bool Delete(int id) => receiptRepository.Delete(id);

        public Receipt Get(int TId) => receiptRepository.Get(TId);  

        public ObservableCollection<Receipt> GetAll() => receiptRepository.GetAll();

        public bool Save(Receipt obj) => receiptRepository.Save(obj);
    }
}
