using Microsoft.AspNetCore.Mvc;
using ZolsExpenseTracker.Api.DTOs.Auth;
using ZolsExpenseTracker.Core.Interfaces;
using ZolsExpenseTracker.Core.Models;

namespace ZolsExpenseTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase 
{
    private readonly IUserRepository _repo;

    public UserController(IUserRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAll()
    => await _repo.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(Guid id)
    {
        var user = await _repo.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    [HttpPost]
     public async Task<ActionResult<User>> Create(CreateUserDTO dto)
    {
        var existingUser = await _repo.GetByEmailAsync(dto.Email);
        if (existingUser != null)
        {
            return BadRequest($"Email {dto.Email} already exists");
        }

        var user = new User{
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = dto.PasswordHash,
            Role = dto.Role
        };
        var created = await _repo.AddAsync(user);
        return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
        
    }
}