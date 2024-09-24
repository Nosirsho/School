using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using School.API.Contracts.Student;
using School.Application.Services;
using School.Core.Model;
using School.Persistence;

namespace School.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;
    private readonly IValidator<CreateStudentRequest> _createStudentValidator;
    private readonly IValidator<UpdateStudentRequest> _updateStudentValidator;
    private readonly SchoolDbContext _schoolDbContext;

    public StudentController(
        StudentService studentService, 
        IValidator<CreateStudentRequest> createStudentValidator,
        IValidator<UpdateStudentRequest> updateStudentValidator, 
        SchoolDbContext schoolDbContext)
    {
        _studentService = studentService;
        _createStudentValidator = createStudentValidator;
        _updateStudentValidator = updateStudentValidator;
        _schoolDbContext = schoolDbContext;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Student>> Get(Guid id)
    {
        var student = await _studentService.GetById(id);
        return Ok(student);
    }

    [HttpGet("{fullname}")]
    public async Task<ActionResult<IEnumerable<Student>>> GetByFullName(string fullname)
    {
        var students = await _studentService.GetByFullname(fullname);
        return Ok(students);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Student>>> GetAll()
    {
        var students = await _studentService.GetAll();
        return Ok(students);
    }

    [HttpPost]
    public async Task<ActionResult<Student>> Post(CreateStudentRequest request)
    {
        var validateResult =await _createStudentValidator.ValidateAsync(request);
        if (!validateResult.IsValid)
        {
            return BadRequest(validateResult.Errors);
        }
        
        var student = new Student(
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.BirthDate,
            request.Sex
            );
        await _studentService.Create(student);
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Student>> Put(Guid id, UpdateStudentRequest request)
    {
        var validateResult = await _updateStudentValidator.ValidateAsync(request);
        if (!validateResult.IsValid)
        {
            return BadRequest(validateResult.Errors);
        }

        var student = new Student(
            request.Id,
            request.FirstName,
            request.MiddleName,
            request.LastName,
            request.BirthDate,
            request.Sex
        );
        student = await _studentService.Update(student);
        return Ok(student);
    }
}