using Microsoft.AspNetCore.Mvc;
using School.API.Contracts.Parent;
using School.Application.Services;
using School.Core.Model;

namespace School.API.Controllers;
[ApiController]
[Route("[controller]")]
public class ParentController : ControllerBase
{
    private readonly ParentService _parentService;

    public ParentController(ParentService parentService)
    {
        _parentService = parentService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Parent>> Get(Guid id)
    {
        var parent = await _parentService.GetById(id);
        return Ok(parent);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Parent>>> GetAll()
    {
        var parents = await _parentService.GetAll();
        return Ok(parents);
    }

    [HttpPost]
    public async Task<ActionResult> Create(ParentCreateRequest request)
    {
        var parent = new Parent(
            request.FirstName, 
            request.MiddleName, 
            request.LastName, 
            request.Sex, 
            request.StudentId, 
            request.Phone);
        await _parentService.Create(parent);
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Parent>> Update(Guid id, ParentUpdateRequest request)
    {
        var parent = new Parent(
            request.Id,
            request.FirstName, 
            request.MiddleName, 
            request.LastName, 
            request.Sex, 
            request.StudentId, 
            request.Phone
            );
        var curParent = await _parentService.Update(parent);
        return Ok(curParent);
    }
}