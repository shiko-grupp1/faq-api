using FAQ_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FAQ_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FaqController : ControllerBase
{
    private readonly AppDbContext _context;

    public FaqController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("course/{courseId}")]
    public async Task<IActionResult> GetFaqsByCourseId(int courseId)
    {
        var faqs = await _context.Faqs
            .Where(f => f.CourseId == courseId)
            .ToListAsync();

        return Ok(faqs);
    }
} 