using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleTest2.Models;

[Table("Species")]
public class Species
{
    public int Id { get; set; }
    public string LatinName { get; set; }
    public int GrowthTimeInYears { get; set; }

    public ICollection<Batch> Batches { get; set; } = new List<Batch>();
}


}