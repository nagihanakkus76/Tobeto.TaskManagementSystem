using TaskManagementSystem.Domain.Enum;

namespace TaskManagementSystem.Application.Features.Tasks.Commands.Create;

public class CreateTaskCommandResponse
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
    public DateTime CreationDate { get; set; }
    public int UserID { get; set;}
}