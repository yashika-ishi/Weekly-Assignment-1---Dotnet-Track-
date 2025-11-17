using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagementCQRS_Yashika.Data;
using StudentManagementCQRS_Yashika.Models;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseInMemoryDatabase("StudentsDb"));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Students.AddRange(
        new Student
        {
            Name = "Yashika",
            Email = "yashika.workmail1@gmail.com",
            Age = 21,
            Course = "Computer Science"
        },
        new Student
        {
            Name = "Negi Yashika",
            Email = "negi.yashika@gmail.com",
            Age = 22,
            Course = "Mechanical Engineering"
        },
        new Student
        {
            Name = "Mishthi Negi",
            Email = "mishthi.negi@hotmail.com",
            Age = 19,
            Course = "BCA"
        }
    );

    context.SaveChanges();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
