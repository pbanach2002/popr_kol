using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleTest2.Models;

[Table("BatchEmployee")]
public class BatchEmployee
{
    public int BatchId { get; set; }
    public Batch Batch { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public string Role { get; set; }
}
