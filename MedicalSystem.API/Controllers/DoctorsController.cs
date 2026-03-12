using MedicalSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;
using static MedicalSystem.Application.DTOs.DoctorDtos;

namespace MedicalSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorsController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDoctorDto createDoctorDto)
    {
        var doctorDto = await _doctorService.CreateAsync(createDoctorDto);

        return Ok(doctorDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var doctorsDto = await _doctorService.GetAllAsync();

        return Ok(doctorsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var doctorDto = await _doctorService.GetByIdAsync(id);

        return Ok(doctorDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDoctorDto updateDoctorDto)
    {
        await _doctorService.UpdateAsync(id, updateDoctorDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _doctorService.DeleteAsync(id);

        return NoContent();
    }
}
