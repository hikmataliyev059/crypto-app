using AutoMapper;
using crypto_app.DAL.Context;
using crypto_app.Helpers.DTOs.Positions;
using crypto_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crypto_app.Areas.Manage.Controllers;
[Area("Manage")]
public class PositionController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public PositionController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        ICollection<Position> positions = await _context.Positions
            .Include(x => x.Agents)
            .ToListAsync();
        return View(positions);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePositionDto createPositionDto)
    {
        if (!ModelState.IsValid)
        {
            return View(createPositionDto);
        }

        if (await _context.Positions.AnyAsync(x => x.Name == createPositionDto.Name))
        {
            ModelState.AddModelError("Name", "Name already exists");
            return View(createPositionDto);
        }

        var position = _mapper.Map<Position>(createPositionDto);

        await _context.Positions.AddAsync(position);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int? id)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        if (id == null) return NotFound();

        var position = await _context.Positions.FirstOrDefaultAsync(x => x.Id == id);
        if (position == null) return NotFound();

        var vm = _mapper.Map<UpdatePositionDto>(position);

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdatePositionDto newPositionDto)
    {
        if (!ModelState.IsValid)
        {
            return View(newPositionDto);
        }

        var oldPositionDto = await _context.Positions.FirstOrDefaultAsync(x => x.Id == newPositionDto.Id);
        if (oldPositionDto == null) return NotFound();
        _mapper.Map(newPositionDto, oldPositionDto);

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var position = await _context.Positions.FirstOrDefaultAsync(x => x.Id == id);
        if (position == null) return NotFound();

        _context.Positions.Remove(position);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
