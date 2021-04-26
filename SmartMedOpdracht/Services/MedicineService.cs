using System;
using System.Collections.Generic;
using MongoDB.Driver;
using SmartMedOpdracht.Models;


namespace SmartMedOpdracht.Services
{
    public class MedicineService : IMedicineService
    {

        private readonly IMongoCollection<Medicine> _medicine;

        public MedicineService(IPharmacyDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _medicine = database.GetCollection<Medicine>(settings.MedicineCollectionName);
        }

        public List<Medicine> Get() =>

            _medicine.Find(book => true).ToList();

        public Medicine Get(string id) =>
            _medicine.Find<Medicine>(medicine => medicine.Id == id).FirstOrDefault();

        public Medicine Create(Medicine med)
        {

            if (QuantityGreaterThanOne(med.quantity))
            {
                DateTime dateNow = DateTime.Now;
                med.creationDate = dateNow;

                _medicine.InsertOne(med);
                return med;
            }
            else
            {
                throw new Exception("Quantity must be greater than 0");
            }
        }

        public void Update(string id, Medicine med) =>
            _medicine.ReplaceOne(medicine => medicine.Id == id, med);

        public void Remove(Medicine med) =>
            _medicine.DeleteOne(medicine => medicine.Id == med.Id);

        public void Remove(string id) =>
            _medicine.DeleteOne(medicine => medicine.Id == id);

        public bool QuantityGreaterThanOne(int quantity)
        {
            if (quantity < 1) { return false; }
            else return true;

        }

    }
}
