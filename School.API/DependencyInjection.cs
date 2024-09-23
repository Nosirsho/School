using FluentValidation;
using School.API.Contracts.Parent;
using School.API.Contracts.Student;
using School.API.Contracts.Teacher;
using School.API.Validations.Parent;
using School.API.Validations.Student;
using School.API.Validations.Teacher;
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
        services.AddScoped<TeacherService>();
        
        services.AddScoped<IStudentStore, StudentRepository>();
        services.AddScoped<IParentStore, ParentRepository>();
        services.AddScoped<ITeacherStore, TeacherRepository>();
        
        services.AddScoped<IValidator<CreateStudentRequest>, CreateStudentValidator>();
        services.AddScoped<IValidator<UpdateStudentRequest>, UpdateStudentValidator>();
        services.AddScoped<IValidator<CreateTeacherRequest>, CreateTeacherValidator>();
        services.AddScoped<IValidator<UpdateTeacherRequest>, UpdateTeacherValidator>();
        services.AddScoped<IValidator<CreateParentRequest>, CreateParentValidator>();
        services.AddScoped<IValidator<UpdateParentRequest>, UpdateParentValidator>();
        
        return services;
    }
}