using TaskManagementSystem.Domain.Enum;

namespace TaskManagementSystem.Application.Features.Tasks.Commands.Update;

public class UpdateTaskCommandResponse
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
}
