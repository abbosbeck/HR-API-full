namespace Dadabase.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Deportment { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public Address Address { get; set; }
        //public int AddressId { get; set; }
    }
}
