using Microsoft.AspNetCore.Mvc;
using ZolsExpenseTracker.Api.DTOs.Integrations;
using ZolsExpenseTracker.Core.Interfaces;
using ZolsExpenseTracker.Core.Models;

namespace ZolsExpenseTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendorProfileController : ControllerBase
{
   private readonly IVendorProfileRepository _repo;

   public VendorProfileController(IVendorProfileRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<List<VendorProfile>>> GetAll()
    => await _repo.GetAllAsync();

    [HttpPost]
    public async Task<ActionResult<VendorProfile>> Create(CreateVendorDTO dto)
    {
        var vendor = new VendorProfile{
            VendorName = dto.VendorName,
            Category = dto.Category,
            Location = dto.Location
        };
        var created = await _repo.AddAsync(vendor);
        return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}