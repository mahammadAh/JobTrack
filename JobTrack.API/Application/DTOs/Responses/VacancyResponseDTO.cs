namespace Application.DTOs.Responses;

public class VacancyResponseDTO
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateOnly Deadline { get; set; }
    
    public bool Status { get; set; }
}