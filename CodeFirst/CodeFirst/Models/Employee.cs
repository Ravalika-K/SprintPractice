using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Salary { get; set; }
        public virtual Department? Department { get; set; }
        [ForeignKey(nameof(Department))]
        public int? DepartmenId { get; set; }
    }
}
