using Properties.;
using Properties.Exceptions;
using ExampleTest2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class NurseriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public NurseriesController(AppDbContext context)
    {
        _context = context;
    }

    // GET /api/nurseries/{id}/batches
    [HttpGet("{id}/batches")]
    public async Task<IActionResult> GetNurseryBatches(int id)
    {
        var nursery = await _context.Nurseries
            .Include(n => n.Batches)
                .ThenInclude(b => b.Species)
            .Include(n => n.Batches)
                .ThenInclude(b => b.BatchEmployees)
                    .ThenInclude(be => be.Employee)
            .FirstOrDefaultAsync(n => n.Id == id);

        if (nursery == null)
            return NotFound("Nursery not found");

        var result = new NurseryWithBatchesDto
        {
            NurseryId = nursery.Id,
            Name = nursery.Name,
            EstablishedDate = nursery.EstablishedDate,
            Batches = nursery.Batches.Select(b => new BatchResponseDto
            {
                BatchId = b.Id,
                Quantity = b.Quantity,
                SownDate = b.SownDate,
                ReadyDate = b.ReadyDate,
                Species = new SpeciesDto
                {
                    LatinName = b.Species.LatinName,
                    GrowthTimeInYears = b.Species.GrowthTimeInYears
                },
                Responsible = b.BatchEmployees.Select(be => new EmployeeRoleDto
                {
                    FirstName = be.Employee.FirstName,
                    LastName = be.Employee.LastName,
                    Role = be.Role
                }).ToList()
            }).ToList()
        };

        return Ok(result);
    }

    // POST /api/batches
    [HttpPost("/api/batches")]
    public async Task<IActionResult> AddBatch([FromBody] AddBatchRequest request)
    {
        var species = await _context.Species.FirstOrDefaultAsync(s => s.LatinName == request.Species);
        if (species == null)
            return NotFound($"Species '{request.Species}' not found");

        var nursery = await _context.Nurseries.FirstOrDefaultAsync(n => n.Name == request.Nursery);
        if (nursery == null)
            return NotFound($"Nursery '{request.Nursery}' not found");

        var batch = new Batch
        {
            Quantity = request.Quantity,
            SownDate = DateTime.Now,
            ReadyDate = DateTime.Now.AddYears(species.GrowthTimeInYears),
            Species = species,
            Nursery = nursery,
            BatchEmployees = new List<BatchEmployee>()
        };

        foreach (var responsible in request.Responsible)
        {
            var employee = await _context.Employees.FindAsync(responsible.EmployeeId);
            if (employee == null)
                return NotFound($"Employee with ID {responsible.EmployeeId} not found");

            batch.BatchEmployees.Add(new BatchEmployee
            {
                Employee = employee,
                Role = responsible.Role
            });
        }

        _context.Batches.Add(batch);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetNurseryBatches), new { id = nursery.Id }, null);
    }
}
