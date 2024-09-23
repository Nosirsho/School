using FluentValidation;
using School.API.Contracts.Student;
using School.API.Validations.Student;
using School.Application.Services;
using School.Core.Stores;
using School.Persistence;
using School.Persistence.Repositories;

namespace School.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<SchoolDbContext>();
        services.AddScoped<StudentService>();
        services.AddScoped<ParentService>();
        services.AddScoped<IStudentStore, StudentRepository>();
        services.AddScoped<IParentStore, ParentRepository>();

        services.AddScoped<IValidator<CreateStudentRequest>, CreateStudentValidator>();
        services.AddScoped<IValidator<UpdateStudentRequest>, UpdateStudentValidator>();
        return services;
    }
}