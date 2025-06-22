using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleTest2.Models;

[Table("Employee")]
public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<BatchEmployee> BatchEmployees { get; set; } = new List<BatchEmployee>();
}


