using School.Application.Services;
using School.Core.Stores;
using School.Persistence;
using School.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<SchoolDbContext>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<ParentService>();
builder.Services.AddScoped<IStudentStore, StudentRepository>();
builder.Services.AddScoped<IParentStore, ParentRepository>();

var app = builder.Build();
using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<SchoolDbContext>();
await dbContext.Database.EnsureCreatedAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();