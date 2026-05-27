using FAQ_API.Data;
using FAQ_API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Add Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.Faqs.Any(f => f.CourseId == 1))
    {
        db.Faqs.AddRange(
            new Faq
            {
                CourseId = 1,
                Question = "What is included in this course?",
                Answer = "You get access to all lessons, exercises and course material."
            },
            new Faq
            {
                CourseId = 1,
                Question = "How long do I have access?",
                Answer = "You have access to the course material as long as your account is active."
            },
            new Faq
            {
                CourseId = 1,
                Question = "Can I contact a teacher?",
                Answer = "Yes, you can contact a teacher through the course messaging feature."
            }
        );

        db.SaveChanges();
    }
}

app.Run();