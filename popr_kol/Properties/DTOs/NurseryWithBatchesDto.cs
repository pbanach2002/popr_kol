namespace popr_kol.Properties.DTOs;

public class NurseryWithBatchesDto
{
    public int NurseryId { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }

    public List<BatchResponseDto> Batches { get; set; }
}
