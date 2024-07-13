using TaskManagementSystem.Domain.Enum;

namespace TaskManagementSystem.Application.Features.Tasks.Queries.GetById;

public class GetByIdTaskQueryResponse
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public int UserID { get; set; }
    public Status Status { get; set; }
}