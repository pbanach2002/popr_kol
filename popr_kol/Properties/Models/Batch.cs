using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Enti;

namespace ExampleTest2.Models;

[Table("Batch")]
public class Batch
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime ReadyDate { get; set; }

    public int NurseryId { get; set; }
    public Nursery Nursery { get; set; }

    public int SpeciesId { get; set; }
    public Species Species { get; set; }

    public ICollection<BatchEmployee> BatchEmployees { get; set; } = new List<BatchEmployee>();
}
