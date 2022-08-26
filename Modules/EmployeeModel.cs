using System.ComponentModel.DataAnnotations;

namespace Post2.Modules
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Deportment { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [EmailAddress]
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public int AddressId { get; set; }

    }
}
