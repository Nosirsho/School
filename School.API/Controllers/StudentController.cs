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
    private readonly SchoolDbContext _schoolDbContext;

    public StudentController(StudentService studentService, SchoolDbContext schoolDbContext)
    {
        _studentService = studentService;
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
        var student = new Student(
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.BirthDate
            );
        await _studentService.Create(student);
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Student>> Put(Guid id, UpdateStudentRequest request)
    {
        var student = new Student(
            request.Id,
            request.FirstName,
            request.MiddleName,
            request.LastName,
            request.BirthDate
        );
        student = await _studentService.Update(student);
        return Ok(student);
    }
}