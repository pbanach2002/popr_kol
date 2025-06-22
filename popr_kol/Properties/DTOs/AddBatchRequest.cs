namespace popr_kol.Properties.DTOs;

public class AddBatchRequest
{
    public int Quantity { get; set; }
    public string Species { get; set; }           // LatinName
    public string Nursery { get; set; }           // Nursery.Name
    public List<ResponsibleDto> Responsible { get; set; }
}
