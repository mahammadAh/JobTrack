namespace Application.DTOs.Requests;

public class VacancyRequestDTO
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateOnly Deadline { get; set; }
    
    public bool Status { get; set; }
}