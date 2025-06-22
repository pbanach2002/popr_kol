namespace popr_kol.Properties.DTOs;

public class BatchResponseDto
{
    public int BatchId { get; set; }
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime ReadyDate { get; set; }

    public SpeciesDto Species { get; set; }
    public List<EmployeeRoleDto> Responsible { get; set; }
}

public class SpeciesDto
{
    public string LatinName { get; set; }
    public int GrowthTimeInYears { get; set; }
}

public class EmployeeRoleDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
}
    