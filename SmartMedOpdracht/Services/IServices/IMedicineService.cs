using System;
using System.Collections.Generic;
using SmartMedOpdracht.Models;

namespace SmartMedOpdracht.Services
{
    public interface IMedicineService
    {
        public List<Medicine> Get();
        public Medicine Get(string id);
        public Medicine Create(Medicine med);
        public void Update(string id, Medicine med);
        public void Remove(Medicine med);
        public void Remove(string id);
        public bool QuantityGreaterThanOne(int quantity);
    }
}
