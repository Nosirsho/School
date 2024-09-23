using FluentValidation;
using School.API.Contracts.Student;

namespace School.API.Validations.Student;

public class UpdateStudentValidator : AbstractValidator<UpdateStudentRequest>
{
    public UpdateStudentValidator()
    {
        RuleFor(request => request.Id).NotNull();
        RuleFor(request => request.FirstName).NotNull().NotEmpty().Length(3,50);
        RuleFor(request => request.MiddleName).NotNull().NotEmpty().Length(3,50);
        RuleFor(request => request.LastName).NotNull().NotEmpty().Length(3,50);
        RuleFor(request => request.BirthDate).GreaterThanOrEqualTo(DateTime.Now.AddYears(-18));
    }
}