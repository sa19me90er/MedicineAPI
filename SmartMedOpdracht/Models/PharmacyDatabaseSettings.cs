using System;
namespace SmartMedOpdracht.Models
{
    public class PharmacyDatabaseSettings : IPharmacyDatabaseSettings
    {
        public string MedicineCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPharmacyDatabaseSettings
    {
        string MedicineCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
