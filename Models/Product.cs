namespace IskurNortwindApi.Models
{
    public class Product
    {
        //Id, Name, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitsInStock { get; set; }

        public string Description { get; set; }
    }
}