using Microsoft.AspNetCore.Mvc;

namespace faq_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FaqController : ControllerBase
{
    [HttpGet("course/{courseId}")]
    public IActionResult GetFaqsByCourseId(int courseId)
    {
        var faqs = new[]
        {
            new
            {
                Id = 1,
                CourseId = courseId,
                Title = "What is included in this course?",
                Answer = "You get access to all lessons, exercises and course material."
            },
            new
            {
                Id = 2,
                CourseId = courseId,
                Title = "How long do I have access?",
                Answer = "You have access to the course material as long as your account is active."
            },
            new
            {
                Id = 3,
                CourseId = courseId,
                Title = "Can I contact a teacher?",
                Answer = "Yes, you can contact a teacher through the course messaging feature."
            }
        };

        return Ok(faqs);
    }
} 