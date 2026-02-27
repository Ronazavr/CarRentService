// CarRentService.API/Controllers/CarsController.cs
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CarRentService.DataAccess;
using CarRentService.DataAccess.Entities;
using CarRentService.API.DTO;
using Microsoft.EntityFrameworkCore;

namespace CarRentService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly CarRentDbContext _context;
    private readonly IMapper _mapper;

    public CarsController(CarRentDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/cars
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CarDto>>> GetCars([FromQuery] bool includeExclusive = false)
    {
        var query = _context.Cars.AsQueryable();
        if (!includeExclusive)
        {
            query = query.Where(c => !c.IsExclusive);
        }
        var cars = await query.ToListAsync();
        var carDtos = _mapper.Map<IEnumerable<CarDto>>(cars);
        return Ok(carDtos);
    }

    // GET: api/cars/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CarDto>> GetCar(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            return NotFound();
        }
        var carDto = _mapper.Map<CarDto>(car);
        return Ok(carDto);
    }

    // POST: api/cars
    [HttpPost]
    public async Task<ActionResult<CarDto>> CreateCar(CreateCarRequest request)
    {
        var car = _mapper.Map<Car>(request);
        car.Status = "available"; // начальный статус

        _context.Cars.Add(car);
        await _context.SaveChangesAsync();

        var carDto = _mapper.Map<CarDto>(car);
        return CreatedAtAction(nameof(GetCar), new { id = car.Id }, carDto);
    }

    // PUT: api/cars/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCar(int id, CreateCarRequest request)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            return NotFound();
        }

        // Обновляем поля car из request с помощью маппера
        _mapper.Map(request, car);
        // Не меняем статус, если не нужно

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/cars/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            return NotFound();
        }

        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}