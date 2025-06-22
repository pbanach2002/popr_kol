using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Models;

[Table("Nursery")]
public class Nursery
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }

    public ICollection<Batch> Batches { get; set; } = new List<Batch>();


}

