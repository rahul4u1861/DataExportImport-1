namespace DataExportImport.Models
{
    public class CustomerOwnedVehicle
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Odometer { get; set; }
        public Customer Customer { get; set; }
    }
}