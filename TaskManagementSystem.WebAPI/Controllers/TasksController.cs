using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Features.Tasks.Commands.ChangeStatus;
using TaskManagementSystem.Application.Features.Tasks.Commands.Create;
using TaskManagementSystem.Application.Features.Tasks.Commands.Delete;
using TaskManagementSystem.Application.Features.Tasks.Commands.Update;
using TaskManagementSystem.Application.Features.Tasks.Queries.GetById;
using TaskManagementSystem.Application.Features.Tasks.Queries.GetList;
using TaskManagementSystem.Domain.Enum;

namespace TaskManagementSystem.WebAPI.Controllers;

public class TasksController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask([FromRoute] int id)
    {
        DeleteTaskCommand command = new DeleteTaskCommand() { ID = id };
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdTask([FromRoute] int id)
    {
        GetByIdTaskQuery query = new GetByIdTaskQuery() { ID = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetListTask()
    {
        var result = await _mediator.Send(new GetListTaskQuery());
        return Ok(result);
    }

    [HttpPut("{id}/change-status/{statusID}")]
    public async Task<IActionResult> ChangeStatus([FromRoute] int id, [FromRoute] Status statusID)
    {
        ChangeStatusTaskCommand command = new ChangeStatusTaskCommand() { ID = id, Status = statusID };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}/change-status/new")]
    public async Task<IActionResult> ChangeStatusNew([FromRoute] int id)
    {
        ChangeStatusTaskCommand command = new ChangeStatusTaskCommand() { ID = id, Status = Status.New };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}/change-status/in-progress")]
    public async Task<IActionResult> ChangeStatusInProgress([FromRoute] int id)
    {
        ChangeStatusTaskCommand command = new ChangeStatusTaskCommand() { ID = id, Status = Status.InProgress };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}/change-status/completed")]
    public async Task<IActionResult> ChangeStatusCompleted([FromRoute] int id)
    {
        ChangeStatusTaskCommand command = new ChangeStatusTaskCommand() { ID = id, Status = Status.Completed };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}