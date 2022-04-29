﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Data.DB
{
    public interface IRepositoryBase<TId, TModel>
    {
        public bool Delete(TModel obj);
        public bool Delete(TId id);
        public TModel Get(int TId);
        public List<TModel> GetAll();
        public bool Save(TModel obj);
    }
}
